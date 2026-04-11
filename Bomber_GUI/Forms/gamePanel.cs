using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomber_GUI.Forms
{
    public delegate void OnRemoveCallback(gamePanel sender);
    public delegate void OnHistoryToggleCallback(gamePanel sender, bool visible);

    public partial class gamePanel : UserControl
    {
        CookieContainer cc = new CookieContainer();
        private int guesscount = 0;
        private double wins = 0;
        private double loss = 0;
        private decimal BasebetCost = 0;
        private int currentBetStreak = 0;
        private int currentPlayStreak = 0;
        private int MultiplyDeadlineTracker = 0;
        private int MultiplyWinTracker = 0;
        private bool running = false;
        private decimal currentBal = 0;
        private bool fastmode = false;

        public event OnRemoveCallback OnRemove;
        public event OnHistoryToggleCallback OnHistoryToggle;

        public GameSettings GameConfig;
        //private GameData Data;
        private Random r = new Random();

        public int currentWinStreak = 0;
        public decimal multiplyOnWin = 1;
        private decimal multiplyOnLoss = 1;
        private int stratergyIndex = 0;
        private bool notFirstClear = false;
        private bool IsWaiting = false;

        private int[] SquareRepeatData = null;
        public int[] LatestBombs = new int[] { 1 };
        private CancellationTokenSource _cts;

        // Bet history fields
        private int betCount = 0;
        private bool historyVisible = false;
        private readonly Dictionary<ListViewItem, string> _resolvedBetIids = new Dictionary<ListViewItem, string>();
        private PrivateFontCollection _privateFonts = new PrivateFontCollection();
        public gamePanel()
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            ApplyFont();
            LoadMontserrat();
            this.Font = new Font(FontHelper.Montserrat, 9f, FontStyle.Regular);
            InitBetHistoryView();
            Log("Welcome to Bomber Bot");
        }

        public gamePanel(bool hideStop)
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            ApplyFont();
            LoadMontserrat();
            this.Font = new Font(FontHelper.Montserrat, 9f, FontStyle.Regular);
            InitBetHistoryView();
            Log("Welcome to Bomber Bot");
            if (hideStop)
            {
                // button2 is now History, keep it enabled for all panels
            }
            StartLoop();
        }
        private void ApplyFont()
        {
            var font = new Font(FontHelper.Montserrat, 9f, FontStyle.Regular);

            // Apply to every button in the panel
            foreach (Control c in this.GetAllControls(this))
            {
                if (c is Button || c is TextBox || c is Label || c is GroupBox)
                    c.Font = font;
            }
            label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            winStats.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular);
            betHistoryView.Font = new Font(FontHelper.Montserrat, 8.25f, FontStyle.Regular);
        }

        // Recursive helper to get all controls including inside GroupBoxes
        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (Control child in GetAllControls(c))
                    yield return child;
            }
        }
        private void LoadMontserrat()
        {
            // Embed Montserrat-Regular.ttf as a project resource (Build Action: Embedded Resource)
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Bomber_GUI.Fonts.Montserrat-Regular.ttf"))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                IntPtr ptr = Marshal.AllocCoTaskMem(data.Length);
                Marshal.Copy(data, 0, ptr, data.Length);
                _privateFonts.AddMemoryFont(ptr, data.Length);
                Marshal.FreeCoTaskMem(ptr);
            }
            betHistoryView.Font = new Font(_privateFonts.Families[0], 8.25f, FontStyle.Regular);
        }
        private void InitBetHistoryView()
        {
            // Apply double buffering to the ListView via reflection
            betHistoryView
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(betHistoryView, true, null);

            betHistoryView.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
            betHistoryView.MouseClick += BetHistoryView_MouseClick;
        }

        // ── Owner-draw handlers for blue underlined "View" link in last column ────────

        private void BetHistoryView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Draw background
            e.DrawBackground();

            using (var font = new Font(FontHelper.Montserrat, 8.25f, FontStyle.Bold))
            using (var brush = new SolidBrush(SystemColors.ControlText))
            {
                var fmt = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.NoWrap
                };
                var textBounds = new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height);
                e.Graphics.DrawString(e.Header.Text, font, brush, textBounds, fmt);
            }
        }

        private void BetHistoryView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Let sub-item drawing handle everything.
        }

        private void BetHistoryView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Draw row background (respects win/loss colour set on the item).
            e.Graphics.FillRectangle(new SolidBrush(e.Item.BackColor), e.Bounds);

            const int VIEW_COL = 5;

            if (e.ColumnIndex == VIEW_COL)
            {
                bool resolved = _resolvedBetIids.TryGetValue(e.Item, out string iid);
                string cellText = resolved ? iid : "View";
                Color linkColor = resolved ? Color.Black : Color.Blue;
                using (var linkFont = new Font(e.SubItem.Font, FontStyle.Regular))
                using (var brush = new SolidBrush(linkColor))
                {
                    var fmt = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString(cellText, linkFont, brush, e.Bounds, fmt);
                }
            }
            else
            {
                // Draw all other sub-items normally using the item's foreground colour.
                using (var brush = new SolidBrush(e.Item.ForeColor))
                {
                    var fmt = new StringFormat { LineAlignment = StringAlignment.Center };
                    var textBounds = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height);
                    e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, brush, textBounds, fmt);
                }
            }
        }

        private async void BetHistoryView_MouseClick(object sender, MouseEventArgs e)
        {
            var info = betHistoryView.HitTest(e.X, e.Y);
            if (info.Item == null || info.SubItem == null) return;

            int colIndex = info.Item.SubItems.IndexOf(info.SubItem);
            if (colIndex == 5) // "Bet ID" (View link) column
            {
                string betId = info.Item.Tag as string;
                if (string.IsNullOrEmpty(betId)) return;

                betHistoryView.Cursor = Cursors.WaitCursor;
                string iid = null;
                try { iid = await FetchBetIid(betId); }
                catch { }
                finally { betHistoryView.Cursor = Cursors.Default; }

                // If we couldn't resolve the IID, fall back to opening by betId.
                if (string.IsNullOrEmpty(iid))
                {
                    System.Diagnostics.Process.Start(
                        string.Format("https://{0}/?betId={1}&modal=bet", GameConfig.SiteConfig, betId));
                    return;
                }

                string cleanIid = iid.Replace("house:", "casino:");
                string openUrl = string.Format("https://{0}/?modal=bet&iid={1}", GameConfig.SiteConfig, cleanIid);

                _resolvedBetIids[info.Item] = cleanIid;

                // Widen the column if the IID text is wider than the current column.
                int needed = TextRenderer.MeasureText(cleanIid, betHistoryView.Font).Width + 10;
                if (needed > betHistoryView.Columns[5].Width)
                    betHistoryView.Columns[5].Width = 250;

                betHistoryView.Invalidate();

                var menu = new ContextMenuStrip();

                var copyItem = new ToolStripMenuItem(string.Format("📋  Copy IID:  {0}", cleanIid));
                copyItem.Click += (s, ev) => Clipboard.SetText(cleanIid);

                var openItem = new ToolStripMenuItem("🌐  Open in browser");
                openItem.Click += (s, ev) => System.Diagnostics.Process.Start(openUrl);

                menu.Items.Add(copyItem);
                menu.Items.Add(openItem);
                menu.Show(betHistoryView, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// Resolves a betId to its IID string via the GraphQL BetLookup query.
        /// Returns null if the request fails or the IID is not present.
        /// </summary>
        private async Task<string> FetchBetIid(string betId)
        {
            try
            {
                var url = "https://" + GameConfig.SiteConfig + "/_api/graphql";
                string json;

                if (GameConfig.FetchModeIndex == 1) // Extension mode for this panel
                {
                    var body = new
                    {
                        operationName = "BetLookup",
                        query = "query BetLookup($iid: String, $betId: String) { bet(iid: $iid, betId: $betId) { iid } }",
                        variables = new { betId }
                    };
                    var options = new
                    {
                        method = "POST",
                        headers = new Dictionary<string, string>
                        {
                            { "Content-Type", "application/json" },
                            { "x-access-token", GameConfig.PlayerHash }
                        },
                        body
                    };
                    json = await BrowserFetch.FetchAsync(url, options);
                }
                else
                {
                    var client = new RestClient(url);
                    client.CookieContainer = cc;
                    client.UserAgent = GameConfig.Agent;
                    client.CookieContainer.Add(
                        new Cookie("cf_clearance", GameConfig.Cookie, "/", GameConfig.SiteConfig));

                    var payload = new
                    {
                        operationName = "BetLookup",
                        query = "query BetLookup($iid: String, $betId: String) { bet(iid: $iid, betId: $betId) { iid } }",
                        variables = new { betId }
                    };
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("x-access-token", GameConfig.PlayerHash);
                    request.AddParameter("application/json",
                        JsonConvert.SerializeObject(payload), ParameterType.RequestBody);

                    var resp = await client.ExecuteAsync(request);
                    json = resp.Content;
                }

                var jObj = JObject.Parse(json);
                return jObj["data"]?["bet"]?["iid"]?.ToString();
            }
            catch { return null; }
        }

        private async Task<string> GraphQL(string operationName, string query,
                                    BetClass variables = null)
        {
            var url = "https://" + GameConfig.SiteConfig + "/_api/graphql";

            if (GameConfig.FetchModeIndex == 1) // Extension mode for this panel
            {
                var body = new BetSend
                {
                    operationName = operationName,
                    query = query,
                    variables = variables
                };
                var options = new
                {
                    method = "POST",
                    headers = new Dictionary<string, string>
                    {
                        { "Content-Type", "application/json" },
                        { "x-access-token", GameConfig.PlayerHash }
                    },
                    body = body
                };
                return await BrowserFetch.FetchAsync(url, options);
            }
            else
            {
                // Cookie mode — use RestSharp with cf_clearance cookie.
                var client = new RestClient(url);
                client.CookieContainer = cc;
                client.UserAgent = GameConfig.Agent;
                client.CookieContainer.Add(
                    new Cookie("cf_clearance", GameConfig.Cookie, "/", GameConfig.SiteConfig));

                var payload = new BetSend
                {
                    operationName = operationName,
                    query = query,
                    variables = variables
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", GameConfig.PlayerHash);
                request.AddParameter("application/json",
                    JsonConvert.SerializeObject(payload), ParameterType.RequestBody);

                var resp = await client.ExecuteAsync(request);
                return resp.Content;
            }
        }

        public async void StartLoop()
		{
			// Cancel any previously running loop before starting a new one
			_cts?.Cancel();
			_cts?.Dispose();
			_cts = new CancellationTokenSource();
			var token = _cts.Token;

			// Brief delay so the constructor finishes and GameConfig gets fully populated
			try { await Task.Delay(500, token); }
			catch (OperationCanceledException) { return; }

			try
			{
				while (!token.IsCancellationRequested)
				{
					// Skip the request if the config hasn't been set yet
					if (!string.IsNullOrEmpty(GameConfig.SiteConfig)
						&& !string.IsNullOrEmpty(GameConfig.PlayerHash)
						&& !string.IsNullOrEmpty(GameConfig.ConfigTag))
					{
						await CheckBalance(GameConfig.SiteConfig, GameConfig.PlayerHash, GameConfig.ConfigTag);
					}

					try { await Task.Delay(5000, token); }
					catch (OperationCanceledException) { return; }
				}
			}
			catch (OperationCanceledException)
			{
				// Expected when loop is stopped — no action needed
			}
		}

        public void StopRunning()
        {
            running = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Remove this panel
            if (OnRemove != null)
                OnRemove(this);

            // Refresh the parent container so remaining panels reposition
            // correctly and don't overlap the bet history area.
            var parent = this.Parent;
            if (parent != null)
            {
                parent.PerformLayout();
                parent.Refresh();
            }
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            historyVisible = !historyVisible;
            betHistoryView.Visible = historyVisible;
            buttonLog.Text = historyVisible ? "Close Log" : "Log";

            this.Height = historyVisible
                ? gameGroupBox.Bottom + betHistoryView.Height
                : gameGroupBox.Bottom + 10;

            if (OnHistoryToggle != null)
                OnHistoryToggle(this, historyVisible);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear starts for this game?", "Clear stats", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                loss = 0;
                wins = 0;
                ShowWinLosStats();
            }
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            using (SettingsForm sf = new SettingsForm(Global.DefaultGameSettings))
            {
                // Always load saved defaults first so a new panel never opens blank.
                sf.loadConfigSettings();

                // If this panel already has its own config, overlay it on top of the defaults.
                if (!string.IsNullOrEmpty(GameConfig.SiteConfig))
                {
                    if (BasebetCost > 0)
                        GameConfig.BetCost = BasebetCost;

                    var configCopy = JsonConvert.DeserializeObject<GameSettings>(
                        JsonConvert.SerializeObject(GameConfig));
                    sf.LoadFromGameConfig(configCopy);
                }

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    GameConfig = sf.GameConfig;
                    BasebetCost = GameConfig.BetCost;
                    multiplyOnLoss = (GameConfig.PercentOnLoss / 100) + 1;
                    multiplyOnWin  = (GameConfig.precentOnWin  / 100) + 1;
                    stratergyIndex = 0;
                    Log("Settings updated.");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!running)
            {
                currentPlayStreak = 0;
                using (SettingsForm sf = new SettingsForm(Global.DefaultGameSettings))
                {
                    sf.loadConfigSettings();
                    // If this panel already has its own config (set at creation), keep it.
                    if (GameConfig != null && !string.IsNullOrEmpty(GameConfig.SiteConfig))
                    {
                        // Reset BetCost to the original base bet before passing to the
                        // settings form, so a previously-multiplied runtime bet cost
                        // never bleeds into the next run.
                        if (BasebetCost > 0)
                            GameConfig.BetCost = BasebetCost;
                        sf.GameConfig = GameConfig;
                    }
                    GameConfig = sf.GameConfig;
                    BasebetCost = GameConfig.BetCost;   // capture base from settings
                    GameConfig.BetCost = BasebetCost;   // always start from base bet
                    multiplyOnLoss = (GameConfig.PercentOnLoss / 100) + 1;
                    multiplyOnWin = (GameConfig.precentOnWin / 100) + 1;
                    stratergyIndex = 0;
                }
                Log("Starting...");

                try
                {
                    if (GameConfig.UseProxy && !string.IsNullOrEmpty(GameConfig.Proxy))
                    {
                        //Proxy = new WebProxy(GameConfig.Proxy);
                    }
                }
                catch
                {
                    //Proxy = null;
                }
                running = true;
                if (GameConfig.Instant)
                {
                    fastRequest();
                }
                else
                {
                    PrepRequest();
                }
            }
            else
            {
                button1.Text = "Stopping after game...";
                button1.Enabled = false;
                running = false;
            }
        }

        public async Task CheckBalance(string site, string phash, string currency)
        {
            try
            {
                var json = await GraphQL(
                    "UserBalances",
                    "query UserBalances {\n  user {\n    id\n    balances {\n      available {\n        amount\n        currency\n        __typename\n      }\n      vault {\n        amount\n        currency\n        __typename\n      }\n      __typename\n    }\n    __typename\n  }\n}\n"
                );

                BalancesData response = JsonConvert.DeserializeObject<BalancesData>(json);

                if (response.errors != null)
                {
                }
                else
                {
                    if (response.data != null)
                    {
                        for (var i = 0; i < response.data.user.balances.Count; i++)
                        {
                            if (response.data.user.balances[i].available.currency == currency.ToLower())
                            {
                                liveBitsBox.Text = String.Format("{0} | {1}", currency, response.data.user.balances[i].available.amount.ToString("0.00000000"));
                                currentBal = response.data.user.balances[i].available.amount;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        // ── Bet History ──────────────────────────────────────────────────────────────

        /// <summary>
        /// Adds a bet result entry to the history ListView.
        /// Green row = win (multiplier > 0), Red row = loss (multiplier == 0).
        /// </summary>
        public void AddBetHistory(decimal amount, decimal multiplier, decimal profit, bool isWin, string betId = "")
        {
            betCount++;
            Action action = () =>
            {
                string multStr = multiplier.ToString("0.00") + "x";
                string profitStr = (profit >= 0 ? "+" : "") + profit.ToString("0.00000000");

                string[] row = {
                    betCount.ToString(),
                    DateTime.Now.ToString("HH:mm:ss"),
                    amount.ToString("0.00000000"),
                    multStr,
                    profitStr,
                    "View"
                };

                var item = new ListViewItem(row);
                item.Tag = betId;

                if (!isWin || multiplier == 0)
                {
                    // Loss - red
                    item.BackColor = Color.FromArgb(255, 199, 206);
                    item.ForeColor = Color.Black;
                }
                else
                {
                    // Win - green
                    item.BackColor = Color.FromArgb(198, 239, 206);
                    item.ForeColor = Color.Black;
                }

                betHistoryView.Items.Insert(0, item);
                if (betHistoryView.Items.Count > 200)
                    betHistoryView.Items[betHistoryView.Items.Count - 1].Remove();
            };

            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)(() => action()));
            else
                action();
        }

        // ── Game logic ───────────────────────────────────────────────────────────────

        async void fastRequest()
        {
            try
            {
                guesscount = 0;
                button1.Text = "Stop after game.";
                button1.Enabled = true;

                List<int> fieldsToReveal;
                if (GameConfig.UseStrat && GameConfig.StratergySquares != null && GameConfig.StratergySquares.Length > 0)
                {
                    fieldsToReveal = GameConfig.StratergySquares.Take(GameConfig.BetAmmount).ToList();
                }
                else
                {
                    var allSquares = Randomize(new int[] {
                        0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,
                        15,16,17,18,19,20,21,22,23,24
                    });
                    fieldsToReveal = allSquares.Take(GameConfig.BetAmmount).ToList();
                }

                clearSquares();
                ClearLog(notFirstClear);
                notFirstClear = true;
                Log("=[Instant Bet Started]=");
                Log("Betting {0} tiles | Bombs: {1} | Amount: {2} {3}",
                    fieldsToReveal.Count, GameConfig.BombCount,
                    GameConfig.BetCost.ToString("0.00000000"), GameConfig.ConfigTag);

                var json = await GraphQL(
                    "MinesBet",
                    "mutation MinesBet($amount: Float!, $currency: CurrencyEnum!, $minesCount: Int!, $fields: [Int!], $identifier: String) {\n" +
                    "  minesBet(\n    amount: $amount\n    currency: $currency\n    minesCount: $minesCount\n    fields: $fields\n    identifier: $identifier\n  ) {\n" +
                    "    ...CasinoBet\n    state {\n      ...CasinoGameMines\n    }\n  }\n}\n\n" +
                    "fragment CasinoBet on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n  }\n}\n\n" +
                    "fragment CasinoGameMines on CasinoGameMines {\n  mines\n  minesCount\n  rounds {\n    field\n    payoutMultiplier\n  }\n}\n",
                    new BetClass
                    {
                        currency = GameConfig.ConfigTag.ToLower(),
                        amount = GameConfig.BetCost,
                        minesCount = GameConfig.BombCount,
                        fields = fieldsToReveal
                    }
                );

                Data response = JsonConvert.DeserializeObject<Data>(json);

                if (response.errors != null)
                {
                    Log("Error: " + response.errors[0].message);
                    if (running)
                    {
                        if (response.errors[0].errorType == "insufficientBalance")
                        {
                            if (GameConfig.RestartOnCrashChecked)
                            {
                                GameConfig.BetCost = BasebetCost;
                                await Task.Delay(2000);
                                fastRequest();
                            }
                            else BSta(true);
                        }
                        else
                        {
                            await Task.Delay(2000);
                            fastRequest();
                        }
                    }
                    else BSta(true);
                    return;
                }

                var state = response.data.minesBet.state;
                var bet = response.data.minesBet;
                bool hitBomb = false;

                HashSet<int> minePositions = new HashSet<int>(state.mines ?? new List<int>());
                HashSet<int> roundFields = new HashSet<int>();

                if (state.rounds != null)
                {
                    foreach (var round in state.rounds)
                    {
                        roundFields.Add(round.field);
                    }
                }

                if (state.rounds != null)
                {
                    foreach (var round in state.rounds)
                    {
                        if (minePositions.Contains(round.field))
                        {
                            hitBomb = true;
                            bombSquare(round.field + 1);
                        }
                        else
                        {
                            glowSquare(round.field + 1);
                        }
                    }
                }

                if (state.mines != null && GameConfig.ShowGameBombs)
                {
                    foreach (int minePos in state.mines)
                    {
                        if (!roundFields.Contains(minePos))
                        {
                            FadebombSquare(minePos + 1);
                        }
                    }
                }

                if (hitBomb)
                {
                    // ── LOSS ────────────────────────────────────────────────────────
                    MultiplyDeadlineTracker++;
                    MultiplyWinTracker++;
                    Log("Bomb. Loss: {0} {1}",
                        bet.amount.ToString("0.00000000"),
                        GameConfig.ConfigTag);

                    currentWinStreak = 0;
                    AddLoss();
                    AddBetHistory(bet.amount, 0m, -bet.amount, false, bet.id);
                    CheckLastGame();

                    bool wasReset = false;
                    if (GameConfig.ResetBetMultiplyer && GameConfig.MetaSettings)
                    {
                        if (MultiplyDeadlineTracker >= GameConfig.ResetBetMultiplyerDeadline && GameConfig.BetCost > BasebetCost)
                        {
                            Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                            GameConfig.BetCost = BasebetCost;
                            MultiplyDeadlineTracker = 0;
                            wasReset = true;
                        }
                    }
                    if (GameConfig.percentOnWinResetChecked && GameConfig.MetaSettings)
                    {
                        if (MultiplyWinTracker > GameConfig.PercentOnWinResetGames && GameConfig.BetCost > BasebetCost)
                        {
                            Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                            GameConfig.BetCost = BasebetCost;
                            MultiplyWinTracker = 0;
                            wasReset = true;
                        }
                    }
                    if (GameConfig.StopAfterLoss && running)
                    {
                        Log("Stop After Loss enabled... Stopping...");
                        notFirstClear = false;
                        running = false;
                        //BSta(true);
                        //return;
                    }

                    if (!wasReset && multiplyOnLoss != 1 && GameConfig.MetaSettings)
                    {
                        Log("Bet increased: {0} → {1}", GameConfig.BetCost, GameConfig.BetCost * multiplyOnLoss);
                        GameConfig.BetCost *= multiplyOnLoss;
                        MultiplyDeadlineTracker = 0;
                    }
                }
                else
                {
                    MultiplyDeadlineTracker++;
                    MultiplyWinTracker++;
                    // ── WIN ──────────────────────────────────────────────────────────
                    decimal profit = bet.payout - bet.amount;
                    Log("Win! +{0} {1} | Multiplier: {2}x",
                        profit.ToString("0.00000000"),
                        GameConfig.ConfigTag,
                        bet.payoutMultiplier.ToString("0.00"));
                    if (GameConfig.BetCost > BasebetCost)
                    {
                        currentWinStreak++;

                    }
                    
                    AddWin();
                    AddBetHistory(bet.amount, Convert.ToDecimal(bet.payoutMultiplier), profit, true, bet.id);
                    CheckLastGame();

                    bool wasReset = false;
                    if (GameConfig.ResetBaseWinsChecked && currentWinStreak >= GameConfig.ResetBaseWinCount && GameConfig.MetaSettings && GameConfig.BetCost > BasebetCost)
                    {
                        Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                        GameConfig.BetCost = BasebetCost;
                        currentWinStreak = 0;
                        wasReset = true;
                    }
                    if (!wasReset && GameConfig.ResetBetMultiplyer && GameConfig.MetaSettings)
                    {
                        if (MultiplyDeadlineTracker >= GameConfig.ResetBetMultiplyerDeadline && GameConfig.BetCost > BasebetCost)
                        {
                            Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                            GameConfig.BetCost = BasebetCost;
                            MultiplyDeadlineTracker = 0;
                            wasReset = true;
                        }
                    }
                    if (!wasReset && GameConfig.percentOnWinResetChecked && GameConfig.MetaSettings)
                    {
                        if (MultiplyWinTracker > GameConfig.PercentOnWinResetGames && GameConfig.BetCost > BasebetCost)
                        {
                            Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                            GameConfig.BetCost = BasebetCost;
                            MultiplyWinTracker = 0;
                            wasReset = true;
                        }
                    }

                    if (GameConfig.StopAfterWin && running)
                    {
                        Log("Stop After Win enabled... Stopping...");
                        notFirstClear = false;
                        running = false;
                        //BSta(true);
                        //return;
                    }

                    if (!wasReset && multiplyOnWin != 1 && GameConfig.MetaSettings)
                    {
                        Log("Bet increased: {0} → {1}", GameConfig.BetCost, GameConfig.BetCost * multiplyOnWin);
                        GameConfig.BetCost *= multiplyOnWin;
                    }
                }

                // ── Balance checks ────────────────────────────────────────────────
                currentBal += bet.payout - bet.amount;
                liveBitsBox.Text = String.Format("{0} | {1}", GameConfig.ConfigTag, currentBal.ToString("0.00000000"));
                await Task.Delay(50);
                if (GameConfig.CheckboxStopAbove && currentBal >= GameConfig.BalanceStopAbove)
                {
                    Log("Balance above limit... Stopping...");
                    running = false;
                }
                if (GameConfig.CheckboxStopBelow && currentBal <= GameConfig.BalanceStopBelow)
                {
                    Log("Balance below limit... Stopping...");
                    running = false;
                }

                if (GameConfig.RandomEveryGameChecked ||
                    (hitBomb && GameConfig.RandomEveryLossChecked) ||
                    (!hitBomb && GameConfig.RandomEveryWinChecked))
                {
                    GameConfig.StratergySquares = Randomize(
                        new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 })
                        .Take(GameConfig.StratergySquares.Length).ToArray();
                }

                if (running)
                {
                    if (GameConfig.GameDelay != 0)
                    {
                        await Task.Delay(GameConfig.GameDelay);
                    }
                    fastRequest();
                }
                else
                {
                    BSta(true);
                }
            }
            catch (Exception ex)
            {
                Log("Instant bet failed: " + ex.Message);
                if (running)
                {
                    await Task.Delay(2000);
                    fastRequest();
                }
                else BSta(true);
            }
        }

        async void PrepRequest()
        {
            try
            {
                guesscount = 0;
                button1.Text = "Stop after game.";
                button1.Enabled = true;

                Guid guid = Guid.NewGuid();
                var json = await GraphQL(
                    "MinesBet",
                    "mutation MinesBet($amount: Float!, $currency: CurrencyEnum!, $minesCount: Int!, $fields: [Int!], $identifier: String) {\n  minesBet(\n    amount: $amount\n    currency: $currency\n    minesCount: $minesCount\n    fields: $fields\n    identifier: $identifier\n  ) {\n    ...CasinoBet\n    state {\n      ...CasinoGameMines\n    }\n  }\n}\n\nfragment CasinoBet on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n  }\n}\n\nfragment CasinoGameMines on CasinoGameMines {\n  mines\n  minesCount\n  rounds {\n    field\n    payoutMultiplier\n  }\n}\n",
                    new BetClass
                    {
                        currency = GameConfig.ConfigTag.ToLower(),
                        amount = GameConfig.BetCost,
                        minesCount = GameConfig.BombCount
                    }
                );

                Data response = JsonConvert.DeserializeObject<Data>(json);

                if (response.errors != null)
                {
                    Log(response.errors[0].message);

                    if (running == true)
                    {
                        if (response.errors[0].errorType == "insufficientBalance")
                        {
                            if (GameConfig.RestartOnCrashChecked)
                            {
                                GameConfig.BetCost = BasebetCost;
                                await Task.Delay(2000);
                                PrepRequest();
                            }
                            else
                            {
                                BSta(true);
                            }
                        }
                        else
                        {
                            await Task.Delay(2000);
                            PrepRequest();
                        }
                    }
                    else
                    {
                        BSta(true);
                    }
                }
                else
                {
                    clearSquares();
                    currentBetStreak = 0;
                    stratergyIndex = 0;

                    ClearLog(notFirstClear);
                    notFirstClear = true;
                    Log("=[Game Started]=");
                    Log("Name: {0} | Bombs: {1}", response.data.minesBet.user.name, response.data.minesBet.state.minesCount);
                    EndNewGameResponce();
                }
            }
            catch (Exception ex)
            {
                Log("Failed to start new game.");
                if (running == true)
                {
                    await Task.Delay(2000);
                    PrepRequest();
                }
                else
                {
                    BSta(true);
                }
            }
        }

        private void AddWin()
        {
            wins++;
            ShowWinLosStats();
        }

        private void AddLoss()
        {
            loss++;
            ShowWinLosStats();
        }

        private void ShowWinLosStats()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                double percent = 0;
                if (wins != 0 || loss != 0)
                    percent = (wins / (wins + loss)) * 100;
                winStats.Text = string.Format("{0}% | Wins: {1} | Losses: {2}", Math.Round(percent, 2), wins, loss);
            });
        }

        public void ClearLog(bool save)
        {
            string[] log = new string[] { };
            this.Invoke((MethodInvoker)delegate ()
            {
                log = outputLog.Lines;
                outputLog.Clear();
            });
        }

        public void Log(string input, params object[] format)
        {
            try
            {
                string fStr = string.Format(input, format);
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        outputLog.AppendText(fStr + "\r\n");
                        outputLog.SelectionStart = outputLog.Text.Length;
                        outputLog.ScrollToCaret();
                    });
                }
                else
                {
                    outputLog.AppendText(fStr + "\r\n");
                    outputLog.SelectionStart = outputLog.Text.Length;
                    outputLog.ScrollToCaret();
                }
            }
            catch { }
        }

        public int getNextSquare()
        {
            if (GameConfig.UseStrat)
            {
                lock (this)
                {
                    if ((GameConfig.StratergySquares.Length == 1) || (stratergyIndex >= GameConfig.StratergySquares.Length - 1))
                        stratergyIndex = 0;
                    else
                        stratergyIndex++;
                    return GameConfig.StratergySquares[stratergyIndex] + 1;
                }
            }
            else if (GameConfig.OppositeTileChecked)
            {
                return 25 - LatestBombs[0];
            }
            int i = r.Next(1, 26);
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    while (!gameSquares.IsIdle(i - 1))
                        i = r.Next(1, 26);
                });
            }
            catch
            {
                i = r.Next(1, 26);
            }
            return i;
        }

        public void glowSquare(int s)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                gameSquares.SetSquare(s - 1, Brushes.Green);
            });
        }

        public void bombSquare(int s)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                gameSquares.SetSquare(s - 1, Brushes.Red);
            });
        }

        public void FadebombSquare(int s)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                if (!gameSquares.IsIdle(s - 1))
                    return;
                gameSquares.SetSquare(s - 1, Brushes.LightSalmon);
            });
        }

        public void clearSquares()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                gameSquares.Reset();
            });
        }

        public void clearSquare(int s)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                gameSquares.IdleSquare(s - 1);
            });
        }

        private async void endCashoutResponce()
        {
            try
            {
                Guid guid = Guid.NewGuid();
                var json = await GraphQL(
                    "MinesCashout",
                    "mutation MinesCashout($identifier: String!) {\n  minesCashout(identifier: $identifier) {\n    ...CasinoBet\n    state {\n      ...CasinoGameMines\n    }\n  }\n}\n\nfragment CasinoBet on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n  }\n}\n\nfragment CasinoGameMines on CasinoGameMines {\n  mines\n  minesCount\n  rounds {\n    field\n    payoutMultiplier\n  }\n}\n",
                    new BetClass
                    {
                        identifier = guid.ToString()
                    }
                );

                Data cd = JsonConvert.DeserializeObject<Data>(json);

                if (cd.errors != null)
                {
                    Log(cd.errors[0].message);

                    if (running == true)
                    {
                        await Task.Delay(2000);
                        endCashoutResponce();
                    }
                    else
                    {
                        BSta(true);
                    }
                }
                else
                {
                    LatestBombs = cd.data.minesCashout.state.mines.ToArray();
                    if (GameConfig.ShowGameBombs)
                    {
                        List<int> bmbz = cd.data.minesCashout.state.mines;
                        foreach (int s in bmbz)
                        {
                            FadebombSquare(s + 1);
                        }
                    }

                    decimal cashoutProfit = cd.data.minesCashout.payout - cd.data.minesCashout.amount;
                    Log("Cashed out " + cashoutProfit.ToString("0.00000000") + " " + GameConfig.ConfigTag + ".");
                    AddWin();
                    AddBetHistory(cd.data.minesCashout.amount, Convert.ToDecimal(cd.data.minesCashout.payoutMultiplier), cashoutProfit, true, cd.data.minesCashout.id);

                    guesscount = 0;
                    MultiplyDeadlineTracker++;
                    MultiplyWinTracker++;
                    bool ShouldStop = false;

                    if (GameConfig.StopAfterWin && running)
                    {
                        Log("Stop After win is enabled... Stopping...");
                        notFirstClear = false;
                        running = false;
                    }
                    else if (ShouldStop && !running)
                    {
                        Log("Balance level met (x bits)... Stopping...");
                        notFirstClear = false;
                        running = false;
                    }

                    if (GameConfig.BetCost > BasebetCost)
                    {
                        currentWinStreak++;

                    }

                    bool wasReset = false;
                    if (GameConfig.ResetBaseWinsChecked && currentWinStreak >= GameConfig.ResetBaseWinCount && GameConfig.MetaSettings && GameConfig.BetCost > BasebetCost)
                    {
                        Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                        GameConfig.BetCost = BasebetCost;
                        currentWinStreak = 0;
                        wasReset = true;
                    }

                    if (!wasReset && GameConfig.ResetBetMultiplyer && GameConfig.MetaSettings)
                    {
                        if (MultiplyDeadlineTracker >= GameConfig.ResetBetMultiplyerDeadline && GameConfig.BetCost > BasebetCost)
                        {
                            Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                            GameConfig.BetCost = BasebetCost;
                            MultiplyDeadlineTracker = 0;
                            wasReset = true;
                        }
                    }
                    if (!wasReset && GameConfig.percentOnWinResetChecked && GameConfig.MetaSettings)
                    {
                        if (MultiplyWinTracker > GameConfig.PercentOnWinResetGames && GameConfig.BetCost > BasebetCost)
                        {
                            Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                            GameConfig.BetCost = BasebetCost;
                            MultiplyWinTracker = 0;
                            wasReset = true;
                        }
                    }

                    if (!wasReset && multiplyOnWin != 1 && GameConfig.MetaSettings)
                    {
                        Log("Betting increced from {0} to {1}", GameConfig.BetCost, GameConfig.BetCost * multiplyOnWin);
                        GameConfig.BetCost = GameConfig.BetCost * multiplyOnWin;
                    }
                    CheckLastGame();

                    currentBal += cd.data.minesCashout.payout - cd.data.minesCashout.amount;
                    liveBitsBox.Text = String.Format("{0} | {1}", GameConfig.ConfigTag, currentBal.ToString("0.00000000"));
                    await Task.Delay(50);

                    if (GameConfig.CheckboxStopAbove && currentBal >= GameConfig.BalanceStopAbove)
                    {
                        Log("Balance is over " + GameConfig.BalanceStopAbove.ToString("0.00000000"));
                        running = false;
                    }
                    if (GameConfig.CheckboxStopBelow && currentBal <= GameConfig.BalanceStopBelow)
                    {
                        Log("Balance is under " + GameConfig.BalanceStopBelow.ToString("0.00000000"));
                        running = false;
                    }

                    if (GameConfig.RandomEveryGameChecked || GameConfig.RandomEveryWinChecked)
                    {
                        GameConfig.StratergySquares = Randomize(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }).ToList().Take(GameConfig.StratergySquares.Length).ToArray();
                    }
                    if (running)
                    {
                        if (GameConfig.GameDelay != 0)
                        {
                            await Task.Delay(GameConfig.GameDelay);
                        }
                        PrepRequest();
                    }
                    else
                    {
                        BSta(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Failed to cashout.");
                if (running == true)
                {
                    await Task.Delay(2000);
                    endCashoutResponce();
                }
                else
                {
                    BSta(true);
                }
            }
        }

        void CheckLastGame()
        {
            if (GameConfig.StopAfterGames && running)
            {
                currentPlayStreak++;
                if (currentPlayStreak > GameConfig.StopAfterGamesAmmount - 1)
                {
                    Log("Completed {0} games... Stopping...", currentPlayStreak);
                    notFirstClear = false;
                    running = false;
                }
            }
        }

        private async void EndBetResponce(Data bd)
        {
            try
            {
                if (bd.data.minesNext.state.mines != null)
                {
                    guesscount++;
                    currentWinStreak = 0;
                    bombSquare(bd.data.minesNext.state.rounds[guesscount - 1].field + 1);
                    LatestBombs = bd.data.minesNext.state.mines.ToArray();
                    AddLoss();
                    AddBetHistory(bd.data.minesNext.amount, 0m, -bd.data.minesNext.amount, false, bd.data.minesNext.id);
                    Log("Bomb. Loss: {0} {1}", bd.data.minesNext.amount, GameConfig.ConfigTag);
                    MultiplyDeadlineTracker++;
                    MultiplyWinTracker++;

                    bool wasReset = false;
                    if (GameConfig.ResetBetMultiplyer && GameConfig.MetaSettings)
                    {
                        if (MultiplyDeadlineTracker >= GameConfig.ResetBetMultiplyerDeadline && GameConfig.BetCost > BasebetCost)
                        {
                            Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                            GameConfig.BetCost = BasebetCost;
                            MultiplyDeadlineTracker = 0;
                            wasReset = true;
                        }
                    }
                    if (GameConfig.percentOnWinResetChecked && GameConfig.MetaSettings)
                    {
                        if (MultiplyWinTracker > GameConfig.PercentOnWinResetGames && GameConfig.BetCost > BasebetCost)
                        {
                            Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                            GameConfig.BetCost = BasebetCost;
                            MultiplyWinTracker = 0;
                            wasReset = true;
                        }
                    }

                    List<int> bmbz = bd.data.minesNext.state.mines;
                    if (GameConfig.ShowGameBombs)
                    {
                        foreach (int s in bmbz)
                        {
                            FadebombSquare(s + 1);
                        }
                    }

                    if (GameConfig.GameDelay != 0)
                    {
                        await Task.Delay(GameConfig.GameDelay);
                    }
                    if (GameConfig.CheckForSquareRepeat)
                    {
                        if (SquareRepeatData == null)
                        {
                            SquareRepeatData = new int[bmbz.Count];
                            for (int i = 0; i < SquareRepeatData.Length; i++)
                            {
                                SquareRepeatData[i] = 0;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < SquareRepeatData.Length; i++)
                            {
                                if (bmbz.Contains(i))
                                    SquareRepeatData[i]++;
                                else
                                    SquareRepeatData[i] = 0;
                                if (SquareRepeatData[i] >= 5)
                                {
                                    running = false;
                                    MessageBox.Show(string.Format("Square {0} has been a bomb 5 times", i));
                                }
                            }
                        }
                    }

                    bool ShouldStop = false;
                    CheckLastGame();

                    if (GameConfig.StopAfterLoss && running)
                    {
                        Log("Stop After loss is enabled... Stopping...");
                        notFirstClear = false;
                        running = false;
                        BSta(true);
                    }
                    else if (ShouldStop && running)
                    {
                        Log("Balance level met (x bits)... Stopping...");
                        notFirstClear = false;
                        running = false;
                        BSta(true);
                    }
                    else
                    {
                        if (!wasReset && multiplyOnLoss != 1 && GameConfig.MetaSettings)
                        {
                            Log("Betting increced from {0} to {1}", GameConfig.BetCost, GameConfig.BetCost * multiplyOnLoss);
                            GameConfig.BetCost = GameConfig.BetCost * multiplyOnLoss;
                            MultiplyDeadlineTracker = 0;
                        }

                        currentBal += bd.data.minesNext.payout - bd.data.minesNext.amount;
                        liveBitsBox.Text = String.Format("{0} | {1}", GameConfig.ConfigTag, currentBal.ToString("0.00000000"));
                        await Task.Delay(50);
                        if (GameConfig.CheckboxStopAbove && currentBal >= GameConfig.BalanceStopAbove)
                        {
                            Log("Balance is over " + GameConfig.BalanceStopAbove.ToString("0.00000000"));
                            running = false;
                        }
                        if (GameConfig.CheckboxStopBelow && currentBal <= GameConfig.BalanceStopBelow)
                        {
                            Log("Balance is under " + GameConfig.BalanceStopBelow.ToString("0.00000000"));
                            running = false;
                        }
                        if (GameConfig.RandomEveryGameChecked || GameConfig.RandomEveryLossChecked)
                        {
                            GameConfig.StratergySquares = Randomize(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }).ToList().Take(GameConfig.StratergySquares.Length).ToArray();
                        }
                        if (running)
                        {
                            PrepRequest();
                        }
                        else
                        {
                            BSta(true);
                        }
                    }
                }
                else
                {
                    guesscount++;
                    Log("Found {0} {1}", ((bd.data.minesNext.state.rounds[guesscount - 1].payoutMultiplier * (double)bd.data.minesNext.amount) - (double)bd.data.minesNext.amount).ToString("0.00000000"), GameConfig.ConfigTag);
                    glowSquare(bd.data.minesNext.state.rounds[guesscount - 1].field + 1);
                    currentBetStreak++;

                    if (currentBetStreak >= GameConfig.BetAmmount)
                    {
                        endCashoutResponce();
                    }
                    else
                    {
                        EndNewGameResponce();
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Failed bet.");

                if (running == true)
                {
                    await Task.Delay(2000);
                    stratergyIndex++;
                    EndNewGameResponce();
                }
                else
                {
                    BSta(true);
                }
            }
        }

        private async void EndNewGameResponce()
        {
            try
            {
                int betSquare = getNextSquare();
                Log("betting square {0}", betSquare);

                var json = await GraphQL(
                    "MinesNext",
                    "mutation MinesNext($fields: [Int!]!) {\n  minesNext(fields: $fields) {\n    ...CasinoBet\n    state {\n      ...CasinoGameMines\n    }\n  }\n}\n\nfragment CasinoBet on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n  }\n}\n\nfragment CasinoGameMines on CasinoGameMines {\n  mines\n  minesCount\n  rounds {\n    field\n    payoutMultiplier\n  }\n}\n",
                    new BetClass
                    {
                        fields = new List<int> { betSquare - 1 }
                    }
                );

                Data response = JsonConvert.DeserializeObject<Data>(json);

                if (response.errors != null)
                {
                    Log(response.errors[0].message);

                    if (running == true)
                    {
                        await Task.Delay(2000);
                        stratergyIndex--;
                        EndNewGameResponce();
                    }
                    else
                    {
                        BSta(true);
                    }
                }
                else
                {
                    EndBetResponce(response);
                }
            }
            catch (Exception ex)
            {
                Log("Failed to guess.");
                if (running == true)
                {
                    await Task.Delay(2000);
                    stratergyIndex--;
                    EndNewGameResponce();
                }
                else
                {
                    BSta(true);
                }
            }
        }

        async void CheckWait(int Delay)
        {
            if (GameConfig.GameDelay != 0 && running)
            {
                await Task.Delay(Delay * 1000);
            }
        }

        void BSta(bool en)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    button1.Enabled = en;
                    if (en)
                    {
                        button1.Text = "Start";
                        running = false;
                    }
                });
            }
            catch { }
        }

        public static int[] Randomize(int[] items)
        {
            Random rand = new Random();
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                int temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
            return items;
        }
    }
}

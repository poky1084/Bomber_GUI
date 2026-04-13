using Keno;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Bomber_GUI.Forms
{
    public partial class SettingsForm : Form
    {
        CookieContainer cc = new CookieContainer();
        public GameSettings GameConfig { get; set; }
        private bool settingDefaults = false;
        private bool LoadingDefaults = false;

        public List<string> coinList = new List<string>();
        public int coinIndex = 0;

        public SettingsForm()
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            ApplyFont();
            GameConfig.BombCount = 3;
            LoadDefaultSettings();
            //button3.PerformClick();
            this.Load += SettingsForm_Load;
        }

        public SettingsForm(DefaultSettings ds)
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            ApplyFont();
            LoadDefaultSettings();
            this.Load += SettingsForm_Load;
        }

        public SettingsForm(DefaultSettings ds, bool settingDef)
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            ApplyFont();
            LoadDefaultSettings();
            this.Load += SettingsForm_Load;
            if (settingDef)
            {
                settingDefaults = true;
                this.Text = "Default settings";
            }
        }

        private void ApplyFont()
        {
            var font = new Font(FontHelper.Montserrat, 9f, FontStyle.Regular);
            this.Font = font;
            foreach (Control c in GetAllControls(this))
                c.Font = font;
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (Control child in GetAllControls(c))
                    yield return child;
            }
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            PutBalance(true);
        }

        private void UpdateCookieStatusLabel()
        {
            bool hasCookie = !string.IsNullOrWhiteSpace(Properties.Settings.Default.Cookie);
            lblCookieStatus.Text      = hasCookie ? "Cookie OK" : "Cookie OFF";
            lblCookieStatus.ForeColor = hasCookie ? Color.Orange : Color.Gray;
            if (hasCookie)
            {
                button3.PerformClick();
            }
        }
        private void metaChecked_CheckedChanged(object sender, EventArgs e)
        {
            metaBox.Enabled = metaChecked.Checked;
        }

        private void stopAfterGamesChecked_CheckedChanged(object sender, EventArgs e)
        {
            stopAfterGamesNum.Enabled = stopAfterGamesChecked.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //balanceStopperGroup.Enabled = BalanceStopCheck.Checked;
            //BalanceStopCheck.Enabled = true;
        }

        private void balanceStopUnderChecked_CheckedChanged(object sender, EventArgs e)
        {
            balanceStopUnder.Enabled = balanceStopUnderChecked.Checked;
        }

        private void balanceStopOverChecked_CheckedChanged(object sender, EventArgs e)
        {
            balanceStopOver.Enabled = balanceStopOverChecked.Checked;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            proxyGroup.Enabled = useProxy.Checked;
        }
        private void useStratCheck_CheckedChanged(object sender, EventArgs e)
        {
            groupBox5.Enabled = true;

            if (useStratCheck.Checked)
            {
                OppositeTileChecked.CheckState = CheckState.Unchecked;
                OppositeTileChecked.Enabled = false;
                GameConfig.UseStrat = true;
            }
            else
            {
                if (numberofBets.Value < 2 && BombCountBox.Value < 2)
                    OppositeTileChecked.Enabled = true;
                GameConfig.UseStrat = false;
                embeddedStratGrid.Reset();
                GameConfig.StratergySquares = new int[0];
            }
            numberofBets.Enabled = !GameConfig.UseStrat;
        }

        private void embeddedStratGrid_MouseUp(object sender, MouseEventArgs e)
        {
            var selectedSquares = new System.Collections.Generic.List<int>();
            for (int i = 0; i < embeddedStratGrid.squareData.Length; i++)
            {
                if (embeddedStratGrid.squareData[i] == 1)
                    selectedSquares.Add(i);
            }
            GameConfig.StratergySquares = selectedSquares.ToArray();
            bool hasSquares = selectedSquares.Count > 0;

            // Ensure useStratCheck reflects selection state (hidden but still drives logic)
            if (useStratCheck.Checked != hasSquares)
                useStratCheck.Checked = hasSquares;
            else if (hasSquares)
            {
                GameConfig.UseStrat = true;
                numberofBets.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                /*using (var str = new AdvancedStratForm())
                {
                    if (str.ShowDialog() == DialogResult.OK)
                    {
                        numberofBets.Enabled = false;
                        betCostNUD.Enabled = false;
                        useStratCheck.Checked = false;
                        useStratCheck.Enabled = false;
                    }
                }*/
            }
            else
            {
                /*numberofBets.Enabled = true;
                betCostNUD.Enabled = true;
                useStratCheck.Enabled = true;*/
            }
        }

        /// <summary>Safely parses a '-'-delimited string of integers, ignoring blank or non-numeric tokens.</summary>
        private static int[] SafeParseSquares(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return new int[0];
            return raw.Split('-')
                      .Select(n => n.Trim())
                      .Where(n => !string.IsNullOrEmpty(n) && n.All(char.IsDigit))
                      .Select(n => Convert.ToInt32(n))
                      .ToArray();
        }

        public void loadConfigSettings()
        {

            int BetAmmount = (int)Properties.Settings.Default.BetAmmount;
            if (GameConfig.UseStrat)
                BetAmmount = SafeParseSquares(Properties.Settings.Default.StratergySquares).Length;
            //GameConfig.UseProxy = useProxy.Checked;
            //GameConfig.Proxy = proxyBox.Text;
            GameConfig.Agent = Properties.Settings.Default.Agent;
            GameConfig.Cookie = Properties.Settings.Default.Cookie;
            GameConfig.Instant = Properties.Settings.Default.Type;

            GameConfig.PlayerHash = Properties.Settings.Default.PlayerHash;
            GameConfig.BetAmmount = BetAmmount;
            GameConfig.BetCost = Properties.Settings.Default.BetCost;
            GameConfig.StopAfterWin = Properties.Settings.Default.StopAfterWin;
            GameConfig.StopAfterLoss = Properties.Settings.Default.StopAfterLoss;
            //GameConfig.ShowExceptionWindow = showExWindow.Checked;

            GameConfig.GameDelay = Properties.Settings.Default.GameDelay;
            GameConfig.BombCount = (int)Properties.Settings.Default.BombCount;
            GameConfig.ShowGameBombs = Properties.Settings.Default.ShowGameBombs;
            //GameConfig.SaveLogToFile = saveLog.Checked;
            GameConfig.ConfigTag = Properties.Settings.Default.ConfigTag;
            GameConfig.SiteConfig = Properties.Settings.Default.SiteConfig;
            GameConfig.StopAfterGamesAmmount = (int)Properties.Settings.Default.StopAfterGamesAmmount;
            GameConfig.StopAfterGames = Properties.Settings.Default.StopAfterGames;
            //GameConfig.CheckBalance = BalanceStopCheck.Checked;
            GameConfig.BalanceStopAbove = Properties.Settings.Default.BalanceStopAbove;
            GameConfig.BalanceStopBelow = Properties.Settings.Default.BalanceStopBelow;

            GameConfig.CheckboxStopAbove = Properties.Settings.Default.CheckboxStopAbove;
            GameConfig.CheckboxStopBelow = Properties.Settings.Default.CheckboxStopBelow;

            GameConfig.RandomEveryGameChecked = Properties.Settings.Default.RandomEveryGameChecked;
            GameConfig.RandomEveryWinChecked = Properties.Settings.Default.RandomEveryWinChecked;
            GameConfig.RandomEveryLossChecked = Properties.Settings.Default.RandomEveryLossChecked;

            GameConfig.RestartOnCrashChecked = Properties.Settings.Default.RestartOnCrashChecked;

            GameConfig.ResetBaseWinsChecked = Properties.Settings.Default.ResetBaseWinsChecked;
            GameConfig.ResetBaseWinCount = Properties.Settings.Default.ResetBaseWinCount;
            GameConfig.percentOnWinResetChecked = Properties.Settings.Default.percentOnWinResetChecked;
            GameConfig.PercentOnWinResetGames = Properties.Settings.Default.PercentOnWinResetGames;
            GameConfig.precentOnWin = Properties.Settings.Default.precentOnWin;

            GameConfig.OppositeTileChecked = Properties.Settings.Default.OppositeTileChecked;

            GameConfig.MetaSettings = Properties.Settings.Default.MetaSettings;
            if (GameConfig.MetaSettings)
            {
                GameConfig.PercentOnLoss = Properties.Settings.Default.PercentOnLoss;
                GameConfig.ResetBetMultiplyer = Properties.Settings.Default.ResetBetMultiplyer;
                GameConfig.ResetBetMultiplyerDeadline = (int)Properties.Settings.Default.ResetBetMultiplyerDeadline;
            }
            else
            {
                GameConfig.PercentOnLoss = 100;
                GameConfig.ResetBetMultiplyer = false;
                GameConfig.ResetBetMultiplyerDeadline = 2;
            }
            int savedIndex = Properties.Settings.Default.SavedTabIndex;

            // Check if the index is valid for the current list
            if (savedIndex >= 0 && savedIndex < cmbFetchMode.Items.Count)
            {
                cmbFetchMode.SelectedIndex = savedIndex;
            }
            else
            {
                // Optional: Default to the first item if nothing is saved
                cmbFetchMode.SelectedIndex = 0;
            }
        }
        private void LoadDefaultSettings()
        {
            GameConfig = new GameSettings();
            //if (ds == null)
            //return;
            LoadingDefaults = true;

            GameConfig.Cookie = Properties.Settings.Default.Cookie;
            GameConfig.Agent  = Properties.Settings.Default.Agent;

            checkInstant.Checked = Properties.Settings.Default.Type;
            pHash.Text = Properties.Settings.Default.PlayerHash;
            numberofBets.Value = Properties.Settings.Default.BetAmmount;
            GameConfig.UseStrat = Properties.Settings.Default.UseStrat;
            GameConfig.ResetBetMultiplyer = Properties.Settings.Default.ResetBetMultiplyer;
            GameConfig.ResetBetMultiplyerDeadline = Properties.Settings.Default.ResetBetMultiplyerDeadline;

            useStratCheck.Checked = GameConfig.UseStrat;
            groupBox5.Enabled = true;
            GameConfig.StratergySquares = SafeParseSquares(Properties.Settings.Default.StratergySquares);
            if (GameConfig.UseStrat)
            {
                embeddedStratGrid.Reset();
                foreach (int sv in GameConfig.StratergySquares)
                {
                    embeddedStratGrid.SetValue(sv, 1);
                }
            }

            betCostNUD.Value = Properties.Settings.Default.BetCost;
            stopAfterWinCheck.Checked = Properties.Settings.Default.StopAfterWin;
            stopAfterLossCheck.Checked = Properties.Settings.Default.StopAfterLoss;
            //showExWindow.Checked = Properties.Settings.Default.ShowExceptionWindow;
            precentOnLoss.Value = Properties.Settings.Default.PercentOnLoss;
            showGBombsCheck.Checked = Properties.Settings.Default.ShowGameBombs;
            //saveLog.Checked = Properties.Settings.Default.SaveLogToFile;
            //cfgTag.Text = Properties.Settings.Default.ConfigTag;
            SiteConfig.Text = Properties.Settings.Default.SiteConfig;
            BombCountBox.Value = Properties.Settings.Default.BombCount;
            stopAfterGamesChecked.Checked = Properties.Settings.Default.StopAfterGames;
            percentOnLossReset.Checked = Properties.Settings.Default.ResetBetMultiplyer;
            PercentOnLossResetGames.Value = Properties.Settings.Default.ResetBetMultiplyerDeadline;
            //useProxy.Checked = Properties.Settings.Default.UseProxy;
            //proxyBox.Text = Properties.Settings.Default.Proxy;
            metaChecked.Checked = Properties.Settings.Default.MetaSettings;

            RandomEveryGameChecked.Checked = Properties.Settings.Default.RandomEveryGameChecked;
            RandomEveryWinChecked.Checked = Properties.Settings.Default.RandomEveryWinChecked;
            RandomEveryLossChecked.Checked = Properties.Settings.Default.RandomEveryLossChecked;

            RestartOnCrashChecked.Checked = Properties.Settings.Default.RestartOnCrashChecked;

            ResetBaseWinCount.Value = Properties.Settings.Default.ResetBaseWinCount;
            ResetBaseWinsChecked.Checked = Properties.Settings.Default.ResetBaseWinsChecked;
            percentOnWinResetChecked.Checked = Properties.Settings.Default.percentOnWinResetChecked;
            PercentOnWinResetGames.Value = Properties.Settings.Default.PercentOnWinResetGames;
            precentOnWin.Value = Properties.Settings.Default.precentOnWin;

            OppositeTileChecked.Checked = Properties.Settings.Default.OppositeTileChecked;

            nudDelay.Value = Properties.Settings.Default.GameDelay;

            //BalanceStopCheck.Checked = Properties.Settings.Default.CheckBalance;
            if (Properties.Settings.Default.BalanceStopAbove == -1)
            {
                balanceStopOverChecked.Checked = false;
            }
            else
            {
                if (Properties.Settings.Default.BalanceStopAbove > balanceStopOver.Minimum && Properties.Settings.Default.BalanceStopAbove < balanceStopOver.Maximum)
                    balanceStopOver.Value = Properties.Settings.Default.BalanceStopAbove;
                balanceStopOverChecked.Checked = true;
            }
            if (Properties.Settings.Default.BalanceStopBelow == -1)
            {
                balanceStopUnderChecked.Checked = false;
            }
            else
            {
                if (Properties.Settings.Default.BalanceStopBelow > balanceStopUnder.Minimum && Properties.Settings.Default.BalanceStopBelow < balanceStopUnder.Maximum)
                    balanceStopUnder.Value = Properties.Settings.Default.BalanceStopBelow;
                balanceStopUnderChecked.Checked = true;
            }

            if (Properties.Settings.Default.StopAfterGamesAmmount < 1)
                stopAfterGamesNum.Value = 1;
            else
                stopAfterGamesNum.Value = Properties.Settings.Default.StopAfterGamesAmmount;
            stopAfterGamesNum.Enabled = stopAfterGamesChecked.Checked;

            balanceStopOverChecked.Checked = Properties.Settings.Default.CheckboxStopAbove;
            balanceStopUnderChecked.Checked = Properties.Settings.Default.CheckboxStopBelow;
            numberofBets.Enabled = !GameConfig.UseStrat;
            int savedIndex = Properties.Settings.Default.SavedTabIndex;

            // Check if the index is valid for the current list
            if (savedIndex >= 0 && savedIndex < cmbFetchMode.Items.Count)
            {
                cmbFetchMode.SelectedIndex = savedIndex;
            }
            else
            {
                // Optional: Default to the first item if nothing is saved
                cmbFetchMode.SelectedIndex = 0;
            }
            LoadingDefaults = false;
            UpdateCookieStatusLabel();
        }

        /// <summary>
        /// Populates every UI control from an existing GameSettings object.
        /// Call this instead of loadConfigSettings() when editing a specific panel's config.
        /// </summary>
        /// <summary>Clamps value to a NumericUpDown's own Minimum/Maximum so set_Value never throws.</summary>
        private static decimal NudClamp(NumericUpDown nud, decimal value)
            => Math.Max(nud.Minimum, Math.Min(nud.Maximum, value));

        public void LoadFromGameConfig(GameSettings config)
        {
            LoadingDefaults = true;
            GameConfig = config;

            checkInstant.Checked = config.Instant;
            pHash.Text = config.PlayerHash;
            SiteConfig.Text = config.SiteConfig;

            // Strategy
            GameConfig.UseStrat = config.UseStrat;
            GameConfig.StratergySquares = config.StratergySquares;
            useStratCheck.Checked = config.UseStrat;
            groupBox5.Enabled = true;
            embeddedStratGrid.Reset();
            if (config.UseStrat && config.StratergySquares != null)
            {
                foreach (int sv in config.StratergySquares)
                    embeddedStratGrid.SetValue(sv, 1);
            }
            numberofBets.Value = NudClamp(numberofBets,
                (config.UseStrat && config.StratergySquares != null)
                    ? config.StratergySquares.Length
                    : config.BetAmmount);
            numberofBets.Enabled = !config.UseStrat;

            betCostNUD.Value = NudClamp(betCostNUD, config.BetCost);
            BombCountBox.Value = NudClamp(BombCountBox, config.BombCount);
            nudDelay.Value = NudClamp(nudDelay, config.GameDelay);

            stopAfterWinCheck.Checked = config.StopAfterWin;
            stopAfterLossCheck.Checked = config.StopAfterLoss;
            showGBombsCheck.Checked = config.ShowGameBombs;

            // Stop after N games
            stopAfterGamesChecked.Checked = config.StopAfterGames;
            stopAfterGamesNum.Value = NudClamp(stopAfterGamesNum,
                config.StopAfterGamesAmmount < 1 ? 1 : config.StopAfterGamesAmmount);
            stopAfterGamesNum.Enabled = config.StopAfterGames;

            // Balance stops
            if (config.BalanceStopAbove == -1)
            {
                balanceStopOverChecked.Checked = false;
            }
            else
            {
                balanceStopOver.Value = NudClamp(balanceStopOver, config.BalanceStopAbove);
                balanceStopOverChecked.Checked = config.CheckboxStopAbove;
            }
            if (config.BalanceStopBelow == -1)
            {
                balanceStopUnderChecked.Checked = false;
            }
            else
            {
                balanceStopUnder.Value = NudClamp(balanceStopUnder, config.BalanceStopBelow);
                balanceStopUnderChecked.Checked = config.CheckboxStopBelow;
            }

            // Meta / multiplier
            metaChecked.Checked = config.MetaSettings;
            metaBox.Enabled = config.MetaSettings;
            precentOnLoss.Value = NudClamp(precentOnLoss, config.PercentOnLoss);
            percentOnLossReset.Checked = config.ResetBetMultiplyer;
            PercentOnLossResetGames.Value = NudClamp(PercentOnLossResetGames, config.ResetBetMultiplyerDeadline);

            // Randomisation
            RandomEveryGameChecked.Checked = config.RandomEveryGameChecked;
            RandomEveryWinChecked.Checked = config.RandomEveryWinChecked;
            RandomEveryLossChecked.Checked = config.RandomEveryLossChecked;

            RestartOnCrashChecked.Checked = config.RestartOnCrashChecked;

            // Win-streak reset
            ResetBaseWinsChecked.Checked = config.ResetBaseWinsChecked;
            ResetBaseWinCount.Value = NudClamp(ResetBaseWinCount, config.ResetBaseWinCount);
            percentOnWinResetChecked.Checked = config.percentOnWinResetChecked;
            PercentOnWinResetGames.Value = NudClamp(PercentOnWinResetGames, config.PercentOnWinResetGames);
            precentOnWin.Value = NudClamp(precentOnWin, config.precentOnWin);

            OppositeTileChecked.Checked = config.OppositeTileChecked;

            // Each panel stores its own fetch mode — do NOT fall back to the global SavedTabIndex here.
            int panelModeIndex = config.FetchModeIndex;
            cmbFetchMode.SelectedIndex = (panelModeIndex >= 0 && panelModeIndex < cmbFetchMode.Items.Count)
                ? panelModeIndex
                : 0;

            LoadingDefaults = false;
            UpdateCookieStatusLabel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initSettings();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void initSettings()
        {

            int savedIndex = Properties.Settings.Default.SavedTabIndex;

            // Check if the index is valid for the current list
            if (savedIndex >= 0 && savedIndex < cmbFetchMode.Items.Count)
            {
                cmbFetchMode.SelectedIndex = savedIndex;
            }
            else
            {
                // Optional: Default to the first item if nothing is saved
                cmbFetchMode.SelectedIndex = 0;
            }
            GameConfig.ConfigTag = coinList.Count > 0 ? coinList[coinIndex] : string.Empty;
            int BetAmmount = (int)numberofBets.Value;
            if (GameConfig.UseStrat)
                BetAmmount = GameConfig.StratergySquares.Length;
            GameConfig.UseProxy = useProxy.Checked;
            GameConfig.Proxy = proxyBox.Text;

            GameConfig.Instant = checkInstant.Checked;
            //GameConfig.Agent = textBox2.Text;
            //GameConfig.Cookie = textBox1.Text;
            GameConfig.PlayerHash = pHash.Text;
            GameConfig.BetAmmount = BetAmmount;
            GameConfig.BetCost = betCostNUD.Value;
            GameConfig.StopAfterWin = stopAfterWinCheck.Checked;
            GameConfig.StopAfterLoss = stopAfterLossCheck.Checked;
            GameConfig.ShowExceptionWindow = showExWindow.Checked;

            GameConfig.GameDelay = (int)nudDelay.Value;
            GameConfig.BombCount = (int)BombCountBox.Value;
            GameConfig.ShowGameBombs = showGBombsCheck.Checked;
            GameConfig.SaveLogToFile = saveLog.Checked;
    
            
            GameConfig.SiteConfig = SiteConfig.Text;
            GameConfig.StopAfterGamesAmmount = (int)stopAfterGamesNum.Value;
            GameConfig.StopAfterGames = stopAfterGamesChecked.Checked;
            //GameConfig.CheckBalance = BalanceStopCheck.Checked;
            GameConfig.BalanceStopAbove = balanceStopOver.Value;
            GameConfig.BalanceStopBelow = balanceStopUnder.Value;

            GameConfig.CheckboxStopAbove = balanceStopOverChecked.Checked;
            GameConfig.CheckboxStopBelow = balanceStopUnderChecked.Checked;

            GameConfig.RandomEveryGameChecked = RandomEveryGameChecked.Checked;
            GameConfig.RandomEveryWinChecked = RandomEveryWinChecked.Checked;
            GameConfig.RandomEveryLossChecked = RandomEveryLossChecked.Checked;

            GameConfig.RestartOnCrashChecked = RestartOnCrashChecked.Checked;

            GameConfig.ResetBaseWinsChecked = ResetBaseWinsChecked.Checked;
            GameConfig.ResetBaseWinCount = (int)ResetBaseWinCount.Value;
            GameConfig.percentOnWinResetChecked = percentOnWinResetChecked.Checked;
            GameConfig.PercentOnWinResetGames = (int)PercentOnWinResetGames.Value;
            GameConfig.precentOnWin = precentOnWin.Value;

            GameConfig.OppositeTileChecked = OppositeTileChecked.Checked;

            GameConfig.MetaSettings = metaChecked.Checked;
            if (GameConfig.MetaSettings)
            {
                GameConfig.PercentOnLoss = precentOnLoss.Value;
                GameConfig.ResetBetMultiplyer = percentOnLossReset.Checked;
                GameConfig.ResetBetMultiplyerDeadline = (int)PercentOnLossResetGames.Value;
            }
            else
            {
                GameConfig.PercentOnLoss = 100;
                GameConfig.ResetBetMultiplyer = false;
                GameConfig.ResetBetMultiplyerDeadline = 2;
            }

            // Store the chosen fetch mode in the panel's own GameConfig (not just the global setting).
            GameConfig.FetchModeIndex = cmbFetchMode.SelectedIndex;

            //Save Settings

        }

        public void SaveSettings()
        {
            int BetAmmount = (int)numberofBets.Value;
            if (GameConfig.UseStrat)
                BetAmmount = GameConfig.StratergySquares.Length;
            //Properties.Settings.Default.UseProxy = GameConfig.UseProxy;
            //GameConfig.Proxy = proxyBox.Text;
            Properties.Settings.Default.Type = checkInstant.Checked;
            Properties.Settings.Default.Cookie = GameConfig.Cookie;
            Properties.Settings.Default.Agent  = GameConfig.Agent;
            Properties.Settings.Default.PlayerHash = pHash.Text;
            Properties.Settings.Default.BetAmmount = BetAmmount;
            Properties.Settings.Default.BetCost = betCostNUD.Value;
            Properties.Settings.Default.StopAfterWin = stopAfterWinCheck.Checked;
            Properties.Settings.Default.StopAfterLoss = stopAfterLossCheck.Checked;
            //Properties.Settings.Default.ShowExceptionWindow = showExWindow.Checked;

            Properties.Settings.Default.UseStrat = useStratCheck.Checked;
            if (GameConfig.StratergySquares != null)
            {
                Properties.Settings.Default.StratergySquares = string.Join("-", GameConfig.StratergySquares);
            }
            Properties.Settings.Default.GameDelay = (int)nudDelay.Value;
            Properties.Settings.Default.BombCount = (int)BombCountBox.Value;
            Properties.Settings.Default.ShowGameBombs = showGBombsCheck.Checked;
            //Properties.Settings.Default.SaveLogToFile = saveLog.Checked;
            Properties.Settings.Default.ConfigTag = coinList.Count > 0 ? coinList[coinIndex] : string.Empty;
            Properties.Settings.Default.SiteConfig = SiteConfig.Text;
            Properties.Settings.Default.StopAfterGamesAmmount = (int)stopAfterGamesNum.Value;
            Properties.Settings.Default.StopAfterGames = stopAfterGamesChecked.Checked;
            //Properties.Settings.Default.CheckBalance = BalanceStopCheck.Checked;
            Properties.Settings.Default.CheckboxStopAbove = balanceStopOverChecked.Checked;
            Properties.Settings.Default.CheckboxStopBelow = balanceStopUnderChecked.Checked;
            Properties.Settings.Default.BalanceStopAbove = balanceStopOver.Value;
            Properties.Settings.Default.BalanceStopBelow = balanceStopUnder.Value;
            Properties.Settings.Default.MetaSettings = metaChecked.Checked;

            Properties.Settings.Default.RandomEveryGameChecked = RandomEveryGameChecked.Checked;
            Properties.Settings.Default.RandomEveryWinChecked = RandomEveryWinChecked.Checked;
            Properties.Settings.Default.RandomEveryLossChecked = RandomEveryLossChecked.Checked;

            Properties.Settings.Default.RestartOnCrashChecked = RestartOnCrashChecked.Checked;

            Properties.Settings.Default.ResetBaseWinsChecked = ResetBaseWinsChecked.Checked;
            Properties.Settings.Default.ResetBaseWinCount = (int)ResetBaseWinCount.Value;
            Properties.Settings.Default.percentOnWinResetChecked = percentOnWinResetChecked.Checked;
            Properties.Settings.Default.PercentOnWinResetGames = (int)PercentOnWinResetGames.Value;
            Properties.Settings.Default.precentOnWin = precentOnWin.Value;

            Properties.Settings.Default.OppositeTileChecked = OppositeTileChecked.Checked;

            if (GameConfig.MetaSettings)
            {
                Properties.Settings.Default.PercentOnLoss = precentOnLoss.Value;
                Properties.Settings.Default.ResetBetMultiplyer = percentOnLossReset.Checked;
                Properties.Settings.Default.ResetBetMultiplyerDeadline = (int)PercentOnLossResetGames.Value;
            }
            else
            {
                Properties.Settings.Default.PercentOnLoss = 100;
                Properties.Settings.Default.ResetBetMultiplyer = false;
                Properties.Settings.Default.ResetBetMultiplyerDeadline = 2;
            }
            Properties.Settings.Default.Save();

        }

        private void CheckBal_Click(object sender, EventArgs e)
        {
            PutBalance(false);
        }
        private async Task<string> GraphQL(string operationName, string query,
                                  BetClass variables = null)
        {
            var url = "https://" + SiteConfig.Text + "/_api/graphql";
			bool isExtension = cmbFetchMode.SelectedIndex == 1;
            if (isExtension)
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
                        { "x-access-token", pHash.Text }
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
                    new System.Net.Cookie("cf_clearance", GameConfig.Cookie, "/", SiteConfig.Text));

                var payload = new BetSend
                {
                    operationName = operationName,
                    query = query,
                    variables = variables
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", pHash.Text);
                request.AddParameter("application/json",
                    JsonConvert.SerializeObject(payload), ParameterType.RequestBody);

                var resp = await client.ExecuteAsync(request);
                return resp.Content;
            }
        }
        public async void PutBalance(bool sign)
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
                        // *** Save current selection before clearing ***
                        string currentSelected = coinList.Count > 0 ? coinList[coinIndex]
                            : (!string.IsNullOrEmpty(GameConfig.ConfigTag) ? GameConfig.ConfigTag : Properties.Settings.Default.ConfigTag);

                        if (sign)
                        {
                            //button3.Enabled = false;
                            coinList.Clear();
                            cfgTag.Items.Clear();
                        }

                        for (var i = 0; i < response.data.user.balances.Count; i++)
                        {
                            if (sign)
                            {
                                coinList.Add(response.data.user.balances[i].available.currency);
                                var balance = response.data.user.balances[i].available;

                                if (balance.amount > 0)
                                {
                                    cfgTag.Items.Add($"{balance.currency.ToUpper()} - {balance.amount.ToString("N8")}");
                                }
                                else
                                {
                                    cfgTag.Items.Add(response.data.user.balances[i].available.currency.ToUpper());
                                }
                            }

                            if (response.data.user.balances[i].available.currency == currentSelected.ToLower())
                            {
                                balanceStopOver.Value = response.data.user.balances[i].available.amount;
                                balanceStopUnder.Value = response.data.user.balances[i].available.amount;
                            }
                        }

                        if (sign)
                        {
                            // *** Restore previously selected currency ***
                            int savedIndex = coinList.FindIndex(c => c.Equals(currentSelected, StringComparison.OrdinalIgnoreCase));
                            coinIndex = savedIndex >= 0 ? savedIndex : 0;
                            cfgTag.SelectedIndex = coinIndex;
                            button3.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (sign) button3.Enabled = true;
            }
        }

        private void cfgTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            coinIndex = cfgTag.SelectedIndex;
        }

        private void RandomEveryGameChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (RandomEveryGameChecked.CheckState == CheckState.Checked)
            {
                RandomEveryLossChecked.CheckState = CheckState.Unchecked;
                RandomEveryWinChecked.CheckState = CheckState.Unchecked;

            }
        }

        private void RandomEveryLossChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (RandomEveryLossChecked.CheckState == CheckState.Checked)
            {
                RandomEveryGameChecked.CheckState = CheckState.Unchecked;
                RandomEveryWinChecked.CheckState = CheckState.Unchecked;
            }
        }

        private void RandomEveryWinChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (RandomEveryWinChecked.CheckState == CheckState.Checked)
            {
                RandomEveryLossChecked.CheckState = CheckState.Unchecked;
                RandomEveryGameChecked.CheckState = CheckState.Unchecked;
            }
        }

        private void BombCountBox_ValueChanged(object sender, EventArgs e)
        {
            if (numberofBets.Value < 2 && BombCountBox.Value < 2)
            {
                OppositeTileChecked.Enabled = true;
            }
            else
            {
                OppositeTileChecked.Enabled = false;
                OppositeTileChecked.CheckState = CheckState.Unchecked;
            }
        }

        private void numberofBets_ValueChanged(object sender, EventArgs e)
        {
            if (numberofBets.Value < 2 && BombCountBox.Value < 2)
            {
                OppositeTileChecked.Enabled = true;
            }
            else
            {
                OppositeTileChecked.Enabled = false;
                OppositeTileChecked.CheckState = CheckState.Unchecked;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Login just refreshes the balance regardless of mode.
            PutBalance(true);
        }

        private void btnGetCookie_Click(object sender, EventArgs e)
        {
            using (var loginForm = new WebViewLogin(SiteConfig.Text))
            {
                if (loginForm.ShowDialog(this) == DialogResult.OK)
                {
                    GameConfig.Cookie = loginForm.CapturedClearance;
                    GameConfig.Agent  = loginForm.CapturedUserAgent;

                    Properties.Settings.Default.Cookie = GameConfig.Cookie;
                    Properties.Settings.Default.Agent  = GameConfig.Agent;
                    Properties.Settings.Default.Save();

                    cc = new CookieContainer();
                    UpdateCookieStatusLabel();
                }
            }
        }

        private void pHash_TextChanged(object sender, EventArgs e)
        {
            //button3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //button3.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //button3.Enabled = true;
        }

        private void checkInstant_CheckedChanged(object sender, EventArgs e)
        {
            GameConfig.Instant = checkInstant.Checked;

        }

        private void nudDelay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbFetchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SavedTabIndex = cmbFetchMode.SelectedIndex;
            Properties.Settings.Default.Save();
            bool isExtension = cmbFetchMode.SelectedIndex == 1;
            cfgTag.Items.Clear();
            UpdateCookieStatusLabel();
            if (isExtension)
            {
                BrowserFetch.StartServer();
                BrowserFetch.Connected    += OnWsConnected;
                BrowserFetch.Disconnected += OnWsDisconnected;

                // Reflect live connection state immediately.
                bool already          = BrowserFetch.IsConnected;
                lblWsIndicator.ForeColor = already ? Color.LimeGreen : Color.Gray;
                lblWsStatus.ForeColor    = already ? Color.LimeGreen : Color.Gray;
                lblWsStatus.Text         = already ? "Extension OK" : "Extension OFF";
                if (already)
                {
                    button3.PerformClick();
                }
                // Show WS controls, hide Get Cookie button.
                btnGetCookie.Visible      = false;
                lblCookieStatus.Visible   = false;
                lblWsIndicator.Visible = true;
                lblWsStatus.Visible    = true;
            }
            else
            {
                BrowserFetch.Connected    -= OnWsConnected;
                BrowserFetch.Disconnected -= OnWsDisconnected;
                //BrowserFetch.StopServer();

                lblWsIndicator.ForeColor = Color.Gray;
                lblWsStatus.ForeColor    = Color.Gray;
                lblWsStatus.Text         = "Extension OFF";

                // Hide WS controls, show Get Cookie button.
                lblWsIndicator.Visible    = false;
                lblWsStatus.Visible       = false;
                btnGetCookie.Visible      = true;
                lblCookieStatus.Visible   = true;
            }
        }

        private void OnWsConnected(object sender, EventArgs e)
        {
            void Apply()
            {
                lblWsIndicator.ForeColor = Color.LimeGreen;
                lblWsStatus.ForeColor    = Color.LimeGreen;
                lblWsStatus.Text         = "Extension OK";
                button3.PerformClick();
            }
            if (lblWsIndicator.InvokeRequired)
                lblWsIndicator.Invoke((MethodInvoker)Apply);
            else
                Apply();
        }

        private void OnWsDisconnected(object sender, EventArgs e)
        {
            void Apply()
            {
                lblWsIndicator.ForeColor = Color.Gray;
                lblWsStatus.ForeColor    = Color.Gray;
                lblWsStatus.Text         = "Extension OFF";
            }
            if (lblWsIndicator.InvokeRequired)
                lblWsIndicator.Invoke((MethodInvoker)Apply);
            else
                Apply();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            BrowserFetch.Connected    -= OnWsConnected;
            BrowserFetch.Disconnected -= OnWsDisconnected;
            base.OnFormClosing(e);
        }
    }
}

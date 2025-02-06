using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace Bomber_GUI.Forms
{
    public delegate void OnRemoveCallback(gamePanel sender);
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
        private bool running = false;
        private decimal currentBal = 0;
        private bool fastmode = false;

        public event OnRemoveCallback OnRemove;

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
        public int[] LatestBombs = new int[] {1};

        public gamePanel()
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            Log("Welcome to Bomber Bot");
            
        }
        public gamePanel(bool hideStop)
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            Log("Welcome to Bomber Bot");
            if (hideStop)
            {
                //button2.Visible = false;
                button2.Enabled = false;
                // button1.Location = new Point(147, 19);
                // button1.Width = 307;
            }
        }
        
        public void StopRunning()
        {
            running = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OnRemove != null)
                OnRemove(this);
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (!running)
            {
                currentPlayStreak = 0;
                using (SettingsForm sf = new SettingsForm(Global.DefaultGameSettings))
                {
                    sf.loadConfigSettings();
                    GameConfig = sf.GameConfig;
                    BasebetCost = GameConfig.BetCost;
                    GameConfig.BetCost = BasebetCost;
                    multiplyOnLoss = GameConfig.PercentOnLoss / 100;
                    multiplyOnWin = GameConfig.precentOnWin / 100;
                    stratergyIndex = 0;
                    
                    //gameGroupBox.Text = GameConfig.ConfigTag;
                }
                // button1.Enabled = false;
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
                    PrepRequest();
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
                var mainurl = "https://" + site + "/_api/graphql";
                var request = new RestRequest(Method.POST);
                var client = new RestClient(mainurl);
                client.CookieContainer = cc;
                client.UserAgent = GameConfig.Agent;
                client.CookieContainer.Add(new Cookie("cf_clearance", GameConfig.Cookie, "/", GameConfig.SiteConfig));
                BetQuery payload = new BetQuery();
                payload.operationName = "UserBalances";
                payload.query = "query UserBalances {\n  user {\n    id\n    balances {\n      available {\n        amount\n        currency\n        __typename\n      }\n      vault {\n        amount\n        currency\n        __typename\n      }\n      __typename\n    }\n    __typename\n  }\n}\n";
                
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", phash);

                request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
                
                

                var restResponse =
                    await client.ExecuteAsync(request);

               
                //Debug.WriteLine(restResponse.Content);
                BalancesData response = JsonConvert.DeserializeObject<BalancesData>(restResponse.Content);
               

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

        async void fastRequest()
        {
            try
            {


                guesscount = 0;

                button1.Text = "Stop after game.";
                button1.Enabled = true;
                //CheckBalance(GameConfig.SiteConfig, GameConfig.PlayerHash, GameConfig.ConfigTag);


                var mainurl = "https://" + GameConfig.SiteConfig + "/_api/graphql";
                var request = new RestRequest(Method.POST);
                var client = new RestClient(mainurl);
                client.CookieContainer = cc;
                client.UserAgent = GameConfig.Agent;
                client.CookieContainer.Add(new Cookie("cf_clearance", GameConfig.Cookie, "/", GameConfig.SiteConfig));
                Guid guid = Guid.NewGuid();
                BetQuery payload = new BetQuery();
                payload.variables = new BetClass()
                {
                    identifier = guid.ToString(),
                    currency = GameConfig.ConfigTag.ToLower(),
                    amount = GameConfig.BetCost,
                    minesCount = GameConfig.BombCount,
                    fields = new List<int> { 0, 1 }

                };

                payload.query = "mutation MinesBet($amount: Float!, $currency: CurrencyEnum!, $minesCount: Int!, $fields: [Int!], $identifier: String) {\n  minesBet(\n    amount: $amount\n    currency: $currency\n    minesCount: $minesCount\n    fields: $fields\n    identifier: $identifier\n  ) {\n    ...CasinoBet\n    state {\n      ...CasinoGameMines\n    }\n  }\n}\n\nfragment CasinoBet on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n  }\n}\n\nfragment CasinoGameMines on CasinoGameMines {\n  mines\n  minesCount\n  rounds {\n    field\n    payoutMultiplier\n  }\n}\n";

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", GameConfig.PlayerHash);

                request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);


                var restResponse =
                    await client.ExecuteAsync(request);


                //Debug.WriteLine(restResponse.Content);
                Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content);

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
                                fastRequest();
                            }
                            else
                            {
                                BSta(true);
                            }

                        }
                        else
                        {
                            await Task.Delay(2000);
                            fastRequest(); 
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
                    //EndNewGameResponce();
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
        async void PrepRequest()
        {
            try
            {


                guesscount = 0;

                button1.Text = "Stop after game.";
                button1.Enabled = true;
                //CheckBalance(GameConfig.SiteConfig, GameConfig.PlayerHash, GameConfig.ConfigTag);


                var mainurl = "https://" + GameConfig.SiteConfig + "/_api/graphql";
                var request = new RestRequest(Method.POST);
                var client = new RestClient(mainurl);
                client.CookieContainer = cc;
                client.UserAgent = GameConfig.Agent;
                client.CookieContainer.Add(new Cookie("cf_clearance", GameConfig.Cookie, "/", GameConfig.SiteConfig));
                BetQuery payload = new BetQuery();
                payload.variables = new BetClass()
                {
                    currency = GameConfig.ConfigTag.ToLower(),
                    amount = GameConfig.BetCost,
                    minesCount = GameConfig.BombCount

                };

                payload.query = "mutation MinesBet($amount: Float!, $currency: CurrencyEnum!, $minesCount: Int!, $fields: [Int!], $identifier: String) {\n  minesBet(\n    amount: $amount\n    currency: $currency\n    minesCount: $minesCount\n    fields: $fields\n    identifier: $identifier\n  ) {\n    ...CasinoBet\n    state {\n      ...CasinoGameMines\n    }\n  }\n}\n\nfragment CasinoBet on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n  }\n}\n\nfragment CasinoGameMines on CasinoGameMines {\n  mines\n  minesCount\n  rounds {\n    field\n    payoutMultiplier\n  }\n}\n";

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", GameConfig.PlayerHash);

                request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);


                var restResponse =
                    await client.ExecuteAsync(request);


                //Debug.WriteLine(restResponse.Content);
                Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content);

                if (response.errors != null)
                {
                    Log(response.errors[0].message);

                    if (running == true)
                    {
                        if(response.errors[0].errorType == "insufficientBalance")
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
            else if(GameConfig.OppositeTileChecked)
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
                var mainurl = "https://" + GameConfig.SiteConfig + "/_api/graphql";
                var request = new RestRequest(Method.POST);
                var client = new RestClient(mainurl);
                client.CookieContainer = cc;
                client.UserAgent = GameConfig.Agent;
                client.CookieContainer.Add(new Cookie("cf_clearance", GameConfig.Cookie, "/", GameConfig.SiteConfig));
                BetQuery payload = new BetQuery();
                Guid guid = Guid.NewGuid();
                payload.variables = new BetClass()
                {
                    identifier = guid.ToString()
                };
                payload.query = "mutation MinesCashout($identifier: String!) {\n  minesCashout(identifier: $identifier) {\n    ...CasinoBet\n    state {\n      ...CasinoGameMines\n    }\n  }\n}\n\nfragment CasinoBet on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n  }\n}\n\nfragment CasinoGameMines on CasinoGameMines {\n  mines\n  minesCount\n  rounds {\n    field\n    payoutMultiplier\n  }\n}\n";

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", GameConfig.PlayerHash);

                request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);

                var restResponse =
                    await client.ExecuteAsync(request);

               
                //Debug.WriteLine(restResponse.Content);
                Data cd = JsonConvert.DeserializeObject<Data>(restResponse.Content);

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
                    Log("Cashed out " + (cd.data.minesCashout.payout - cd.data.minesCashout.amount).ToString("0.00000000") + " " + GameConfig.ConfigTag + ".");
                    //string url = string.Format("https://satoshimines.com/s/{0}/{1}/", cd.game_id, cd.random_string);
                    //Log("Url: {0}", url);
                    AddWin();
                    guesscount = 0;
                    bool ShouldStop = false;


                    if (GameConfig.StopAfterWin && running)
                    {
                        Log("Stop After win is enabled... Stopping...");
                        //SaveLogDisk();
                        notFirstClear = false;
                        running = false;
                    }
                    else if (ShouldStop && !running)
                    {
                        Log("Balance level met (x bits)... Stopping...");
                        //SaveLogDisk();
                        notFirstClear = false;
                        running = false;
                    }

                    if(multiplyOnWin != 1)
                    {
                        Log("Betting increced from {0} to {1}", GameConfig.BetCost, GameConfig.BetCost * multiplyOnWin);
                        GameConfig.BetCost = GameConfig.BetCost * multiplyOnWin;
                    }

                    currentWinStreak++;
                    if (GameConfig.ResetBaseWinsChecked && currentWinStreak >= GameConfig.ResetBaseWinCount)
                    {
                        GameConfig.BetCost = BasebetCost;
                       currentWinStreak = 0;
                       // Log("Bet has been reset. ResetBaseWinsChecked");
                    }

                    if (currentWinStreak >= GameConfig.PercentOnWinResetGames && GameConfig.percentOnWinResetChecked)
                    {
                        GameConfig.BetCost = BasebetCost;
                        currentWinStreak = 0;
                        //Log("Bet has been reset. PercentOnWinResetGames");

                    }


                    CheckLastGame();
                    await CheckBalance(GameConfig.SiteConfig, GameConfig.PlayerHash, GameConfig.ConfigTag);
                    //Log("");
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


                    //int betSquare = getNextSquare();
                    if (GameConfig.RandomEveryGameChecked || GameConfig.RandomEveryWinChecked)
                    {
                        //stratergyIndex = 0;
                        GameConfig.StratergySquares = Randomize(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }).ToList().Take(GameConfig.StratergySquares.Length).ToArray();
                    }
                    if (running)
                    {
                        CheckWait(GameConfig.GameDelay);
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
                    //SaveLogDisk();
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
                    Log("Bomb. Loss: {0} {1}", bd.data.minesNext.amount, GameConfig.ConfigTag);

                    List<int> bmbz = bd.data.minesNext.state.mines;
                    if (GameConfig.ShowGameBombs)
                    {
                        foreach (int s in bmbz)
                        {
                            FadebombSquare(s + 1);
                        }
                    }
                   
                    CheckWait(GameConfig.GameDelay * 2);
                    if (GameConfig.CheckForSquareRepeat)
                    {
                        if (SquareRepeatData == null)
                        {
                            SquareRepeatData = new int[bmbz.Count];
                            //int sint;
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
                    //var data = BalanceStopShouldStop(out ShouldStop);

                    CheckLastGame();

                    if (GameConfig.StopAfterLoss && running)
                    {
                        Log("Stop After loss is enabled... Stopping...");
                        //SaveLogDisk();
                        notFirstClear = false;
                        running = false;
                        BSta(true);
                    }
                    else if (ShouldStop && running)
                    {
                        Log("Balance level met (x bits)... Stopping...");
                        //SaveLogDisk();
                        notFirstClear = false;
                        running = false;
                        BSta(true);
                    }
                    else
                    {
                        if (GameConfig.ResetBetMultiplyer)
                        {
                            if (MultiplyDeadlineTracker >= GameConfig.ResetBetMultiplyerDeadline)
                            {
                                Log("Resetting bet cost from {0} to {1}", GameConfig.BetCost, BasebetCost);
                                GameConfig.BetCost = BasebetCost;
                                MultiplyDeadlineTracker = 0;
                            }
                            else
                            {
                                if (multiplyOnLoss != 1)
                                {
                                    Log("Betting increced from {0} to {1}", GameConfig.BetCost, GameConfig.BetCost * multiplyOnLoss);
                                    GameConfig.BetCost = GameConfig.BetCost * multiplyOnLoss;
                                    MultiplyDeadlineTracker++;
                                }
                            }

                        }
                        else
                        {
                            if (multiplyOnLoss != 1)
                            {
                                Log("Betting increced from {0} to {1}", GameConfig.BetCost, GameConfig.BetCost * multiplyOnLoss);
                                GameConfig.BetCost = GameConfig.BetCost * multiplyOnLoss;
                            }
                        }

                        //string url = string.Format("https://satoshimines.com/s/{0}/{1}/", bd.game_id, bd.random_string);
                        //Log("Url: {0}", url);
                        //Log("");

                        await CheckBalance(GameConfig.SiteConfig, GameConfig.PlayerHash, GameConfig.ConfigTag);
                        if (GameConfig.CheckboxStopAbove &&  currentBal >= GameConfig.BalanceStopAbove)
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
                            //stratergyIndex = 0;
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
                    //int betSquare = getNextSquare();
                    currentBetStreak++;
                    if (currentBetStreak >= GameConfig.BetAmmount)
                    {
                        MultiplyDeadlineTracker = 0;
                        //Log("");
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
                
                var mainurl = "https://" + GameConfig.SiteConfig + "/_api/graphql";
                var request = new RestRequest(Method.POST);
                var client = new RestClient(mainurl);
                client.CookieContainer = cc;
                client.UserAgent = GameConfig.Agent;
                client.CookieContainer.Add(new Cookie("cf_clearance", GameConfig.Cookie, "/", GameConfig.SiteConfig));
                BetQuery payload = new BetQuery();
                payload.variables = new BetClass()
                {
                    fields = new List<int> { betSquare - 1 }

                };
                payload.query = "mutation MinesNext($fields: [Int!]!) {\n  minesNext(fields: $fields) {\n    ...CasinoBet\n    state {\n      ...CasinoGameMines\n    }\n  }\n}\n\nfragment CasinoBet on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n  }\n}\n\nfragment CasinoGameMines on CasinoGameMines {\n  mines\n  minesCount\n  rounds {\n    field\n    payoutMultiplier\n  }\n}\n";

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", GameConfig.PlayerHash);

                request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);


                var restResponse =
                    await client.ExecuteAsync(request);


                //Debug.WriteLine(restResponse.Content);
                Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content);

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
                //Log("Waiting {0}ms...", Delay);
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

            // For each spot in the array, pick
            // a random item to swap into that spot.
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

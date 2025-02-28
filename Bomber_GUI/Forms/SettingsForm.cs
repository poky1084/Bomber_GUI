﻿using Newtonsoft.Json;
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
            GameConfig.BombCount = 3;
            LoadDefaultSettings();
            //button3.PerformClick();
        }
        public SettingsForm(DefaultSettings ds)
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            LoadDefaultSettings();
        }

        public SettingsForm(DefaultSettings ds, bool settingDef)
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            LoadDefaultSettings();
            if (settingDef)
            {
                settingDefaults = true;
                this.Text = "Default settings";
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
            groupBox5.Enabled = useStratCheck.Checked;

            if (useStratCheck.Checked)
            {
                OppositeTileChecked.CheckState = CheckState.Unchecked;
                OppositeTileChecked.Enabled = false;
                if (LoadingDefaults)
                    return;
                using (StratergyForm sf = new StratergyForm())
                {
                    if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        GameConfig.StratergySquares = sf.StratergyArray;
                        GameConfig.UseStrat = GameConfig.StratergySquares != null && GameConfig.StratergySquares.Length > 0;
                        if (GameConfig.UseStrat)
                        {
                            /*
                            for (int i = 0; i < StratergySquares.Length; i++)
                            {
                                if (StratergySquares[i] == 1)
                                {
                                    stratDisplay.SetSquare(i, Brushes.Green);
                                }
                            }*/
                            foreach (int sv in GameConfig.StratergySquares)
                            {
                                stratDisplay.SetSquare(sv, Brushes.Green);
                            }
                        }
                        else
                        {
                            useStratCheck.Checked = false;
                            stratDisplay.Reset();
                        }
                    }
                    else
                    {
                        useStratCheck.Checked = false;
                        GameConfig.UseStrat = false;
                    }
                }
            }
            else
            {
                if (numberofBets.Value < 2 && BombCountBox.Value < 2)
                {
                    OppositeTileChecked.Enabled = true;
                }
                GameConfig.UseStrat = false;
                stratDisplay.Reset();
            }
            numberofBets.Enabled = !GameConfig.UseStrat;
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

        public void loadConfigSettings()
        {

            int BetAmmount = (int)Properties.Settings.Default.BetAmmount;
            if (GameConfig.UseStrat)
                BetAmmount = Properties.Settings.Default.StratergySquares.Split('-').Select(n => Convert.ToInt32(n)).ToArray().Length;
            //GameConfig.UseProxy = useProxy.Checked;
            //GameConfig.Proxy = proxyBox.Text;
            GameConfig.Agent = Properties.Settings.Default.Agent;
            GameConfig.Cookie = Properties.Settings.Default.Cookie;
            GameConfig.Instant = Properties.Settings.Default.Instant;

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
        }
        private void LoadDefaultSettings()
        {
            GameConfig = new GameSettings();
            //if (ds == null)
            //return;
            LoadingDefaults = true;

            textBox1.Text = Properties.Settings.Default.Cookie;
            textBox2.Text = Properties.Settings.Default.Agent;

            checkInstant.Checked = Properties.Settings.Default.Instant;
            pHash.Text = Properties.Settings.Default.PlayerHash;
            numberofBets.Value = Properties.Settings.Default.BetAmmount;
            GameConfig.UseStrat = Properties.Settings.Default.UseStrat;
            GameConfig.ResetBetMultiplyer = Properties.Settings.Default.ResetBetMultiplyer;
            GameConfig.ResetBetMultiplyerDeadline = Properties.Settings.Default.ResetBetMultiplyerDeadline;

            useStratCheck.Checked = GameConfig.UseStrat;
            groupBox5.Enabled = useStratCheck.Checked;
            GameConfig.StratergySquares = Properties.Settings.Default.StratergySquares.Split('-').Select(n => Convert.ToInt32(n)).ToArray();
            if (GameConfig.UseStrat)
            {
                stratDisplay.Reset();
                foreach (int sv in GameConfig.StratergySquares)
                {
                    stratDisplay.SetSquare(sv, Brushes.Green);
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

            LoadingDefaults = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            initSettings();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void initSettings()
        {
            
                    
            GameConfig.ConfigTag = coinList[coinIndex];
            int BetAmmount = (int)numberofBets.Value;
            if (GameConfig.UseStrat)
                BetAmmount = GameConfig.StratergySquares.Length;
            GameConfig.UseProxy = useProxy.Checked;
            GameConfig.Proxy = proxyBox.Text;

            GameConfig.Instant = checkInstant.Checked;
            GameConfig.Agent = textBox2.Text;
            GameConfig.Cookie = textBox1.Text;
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
            //Save Settings

        }

        public void SaveSettings()
        {
            int BetAmmount = (int)numberofBets.Value;
            if (GameConfig.UseStrat)
                BetAmmount = GameConfig.StratergySquares.Length;
            //Properties.Settings.Default.UseProxy = GameConfig.UseProxy;
            //GameConfig.Proxy = proxyBox.Text;
            Properties.Settings.Default.Instant = checkInstant.Checked;
            Properties.Settings.Default.Agent = textBox2.Text;
            Properties.Settings.Default.Cookie = textBox1.Text;
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
            Properties.Settings.Default.ConfigTag = coinList[coinIndex];
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

        public async void PutBalance(bool sign)
        {
            try
            {
                var mainurl = "https://" + SiteConfig.Text + "/_api/graphql";
                var request = new RestRequest(Method.POST);
                var client = new RestClient(mainurl);
                client.CookieContainer = cc;
                client.UserAgent = textBox2.Text; ;
                client.CookieContainer.Add(new Cookie("cf_clearance", textBox1.Text, "/", SiteConfig.Text));
                BetQuery payload = new BetQuery();
                payload.operationName = "UserBalances";
                payload.query = "query UserBalances {\n  user {\n    id\n    balances {\n      available {\n        amount\n        currency\n        __typename\n      }\n      vault {\n        amount\n        currency\n        __typename\n      }\n      __typename\n    }\n    __typename\n  }\n}\n";
                //request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", pHash.Text);

                request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
                //request.AddJsonBody(payload);
                //IRestResponse response = client.Execute(request);

                var restResponse =
                    await client.ExecuteAsync(request);

                // Will output the HTML contents of the requested page
                //Debug.WriteLine(restResponse.Content);
                //Debug.WriteLine(GameConfig.BombCount);
                BalancesData response = JsonConvert.DeserializeObject<BalancesData>(restResponse.Content);
                //Log(response.data.minesBet.user.name); ;

                if (response.errors != null)
                {

                }
                else
                {
                    if (response.data != null)
                    {

                        if (sign)
                        {
                            button3.Enabled = false;
                            coinList.Clear();
                            cfgTag.Items.Clear();
                        }

                        for (var i = 0; i < response.data.user.balances.Count; i++)
                        {
                            if (sign)
                            {
                                coinList.Add(response.data.user.balances[i].available.currency);

                                cfgTag.Items.Add(response.data.user.balances[i].available.currency + " - " + response.data.user.balances[i].available.amount.ToString("N8"));
                                cfgTag.SelectedIndex = coinIndex;
                            }

                            if (response.data.user.balances[i].available.currency == coinList[coinIndex].ToLower())
                            {
                                balanceStopOver.Value = response.data.user.balances[i].available.amount;
                                balanceStopUnder.Value = response.data.user.balances[i].available.amount;
                            }

                        }

                    }


                }
            }
            catch (Exception ex)
            {

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
            PutBalance(true);
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
    }
}

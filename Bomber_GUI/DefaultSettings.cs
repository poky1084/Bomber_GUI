using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber_GUI
{
    public static class Global
    {
        public static DefaultSettings DefaultGameSettings = null;
    }
    public class DefaultSettings
    {
        public int BombCount { get; set; }
        public string PlayerHash { get; set; }
        public int BetAmmount { get; set; }
        public decimal BetCost { get; set; }
        public decimal PercentOnLoss { get; set; }
        public bool StopAfterWin { get; set; }
        public bool StopAfterLoss { get; set; }
        public bool ShowExceptionWindow { get; set; }
        public int[] StratergySquares { get; set; }
        public bool UseStrat { get; set; }
        public bool ShowGameBombs { get; set; }
        public string ConfigTag { get; set; }
        public string SiteConfig { get; set; }
        public bool SaveLogToFile { get; set; }
        public bool StopAfterGames { get; set; }
        public int StopAfterGamesAmmount { get; set; }
        public bool CheckBalance { get; set; }
        public decimal BalanceStopAbove { get; set; }
        public decimal BalanceStopBelow { get; set; }
        public bool ResetBetMultiplyer { get; set; }
        public int ResetBetMultiplyerDeadline { get; set; }
        public bool UseProxy { get; set; }
        public string Proxy { get; set; }
        public bool MetaSettings { get; set; }
        public int GameDelay { get; set; }
        public bool CheckboxStopAbove { get; set; }
        public bool CheckboxStopBelow { get; set; }

        public bool RandomEveryGameChecked { get; set; }
        public bool RandomEveryWinChecked { get; set; }
        public bool RandomEveryLossChecked { get; set; }

        public bool RestartOnCrashChecked { get; set; }
        public DefaultSettings()
        {
            BetCost = 30;
            PercentOnLoss = 100;
            BetAmmount = 3;
            GameDelay = 0;
        }
    }
}

namespace Bomber_GUI.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            pHash = new TextBox();
            label2 = new Label();
            label3 = new Label();
            numberofBets = new NumericUpDown();
            button1 = new Button();
            betCostNUD = new NumericUpDown();
            label4 = new Label();
            stopAfterWinCheck = new CheckBox();
            showExWindow = new CheckBox();
            precentOnLoss = new NumericUpDown();
            label5 = new Label();
            useStratCheck = new CheckBox();
            groupBox2 = new GroupBox();
            stratDisplay = new SatoshiGrid();
            checkBox1 = new CheckBox();
            showGBombsCheck = new CheckBox();
            label6 = new Label();
            saveLog = new CheckBox();
            stopAfterLossCheck = new CheckBox();
            stopAfterGamesChecked = new CheckBox();
            stopAfterGamesNum = new NumericUpDown();
            label7 = new Label();
            groupBox1 = new GroupBox();
            OppositeTileChecked = new CheckBox();
            RestartOnCrashChecked = new CheckBox();
            groupBox3 = new GroupBox();
            checkInstant = new CheckBox();
            label12 = new Label();
            label11 = new Label();
            nudDelay = new NumericUpDown();
            groupBox4 = new GroupBox();
            BombCountBox = new NumericUpDown();
            balanceStopperGroup = new GroupBox();
            CheckBal = new Button();
            balanceStopOver = new NumericUpDown();
            balanceStopOverChecked = new CheckBox();
            balanceStopUnder = new NumericUpDown();
            balanceStopUnderChecked = new CheckBox();
            metaBox = new GroupBox();
            label13 = new Label();
            ResetBaseWinCount = new NumericUpDown();
            ResetBaseWinsChecked = new CheckBox();
            label8 = new Label();
            PercentOnWinResetGames = new NumericUpDown();
            percentOnWinResetChecked = new CheckBox();
            precentOnWin = new NumericUpDown();
            label9 = new Label();
            label10 = new Label();
            PercentOnLossResetGames = new NumericUpDown();
            percentOnLossReset = new CheckBox();
            metaChecked = new CheckBox();
            proxyGroup = new GroupBox();
            button2 = new Button();
            proxyBox = new TextBox();
            useProxy = new CheckBox();
            cfgTag = new ComboBox();
            SiteLabel = new Label();
            SiteConfig = new ComboBox();
            groupBox5 = new GroupBox();
            RandomEveryLossChecked = new CheckBox();
            RandomEveryWinChecked = new CheckBox();
            RandomEveryGameChecked = new CheckBox();
            label14 = new Label();
            textBox1 = new TextBox();
            label15 = new Label();
            textBox2 = new TextBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)numberofBets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betCostNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)precentOnLoss).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stopAfterGamesNum).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDelay).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BombCountBox).BeginInit();
            balanceStopperGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)balanceStopOver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)balanceStopUnder).BeginInit();
            metaBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ResetBaseWinCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PercentOnWinResetGames).BeginInit();
            ((System.ComponentModel.ISupportInitialize)precentOnWin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PercentOnLossResetGames).BeginInit();
            proxyGroup.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 12);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 0;
            label1.Text = "Api key:";
            // 
            // pHash
            // 
            pHash.Location = new Point(132, 5);
            pHash.Margin = new Padding(6, 5, 6, 5);
            pHash.Name = "pHash";
            pHash.Size = new Size(160, 31);
            pHash.TabIndex = 1;
            pHash.TextChanged += pHash_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 45);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 2;
            label2.Text = "Mines:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 97);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(154, 25);
            label3.TabIndex = 7;
            label3.Text = "Number of guess:";
            // 
            // numberofBets
            // 
            numberofBets.Location = new Point(160, 92);
            numberofBets.Margin = new Padding(6, 5, 6, 5);
            numberofBets.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numberofBets.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numberofBets.Name = "numberofBets";
            numberofBets.Size = new Size(231, 31);
            numberofBets.TabIndex = 8;
            numberofBets.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numberofBets.ValueChanged += numberofBets_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(11, 795);
            button1.Margin = new Padding(6, 5, 6, 5);
            button1.Name = "button1";
            button1.Size = new Size(701, 45);
            button1.TabIndex = 9;
            button1.Text = "Go";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // betCostNUD
            // 
            betCostNUD.DecimalPlaces = 8;
            betCostNUD.Increment = new decimal(new int[] { 10, 0, 0, 524288 });
            betCostNUD.Location = new Point(160, 142);
            betCostNUD.Margin = new Padding(6, 5, 6, 5);
            betCostNUD.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            betCostNUD.Name = "betCostNUD";
            betCostNUD.Size = new Size(231, 31);
            betCostNUD.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 147);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(82, 25);
            label4.TabIndex = 10;
            label4.Text = "Bet Cost:";
            // 
            // stopAfterWinCheck
            // 
            stopAfterWinCheck.AutoSize = true;
            stopAfterWinCheck.Location = new Point(17, 52);
            stopAfterWinCheck.Margin = new Padding(6, 5, 6, 5);
            stopAfterWinCheck.Name = "stopAfterWinCheck";
            stopAfterWinCheck.Size = new Size(148, 29);
            stopAfterWinCheck.TabIndex = 13;
            stopAfterWinCheck.Text = "Stop after win";
            stopAfterWinCheck.UseVisualStyleBackColor = true;
            // 
            // showExWindow
            // 
            showExWindow.AutoSize = true;
            showExWindow.Enabled = false;
            showExWindow.Location = new Point(326, 38);
            showExWindow.Margin = new Padding(6, 5, 6, 5);
            showExWindow.Name = "showExWindow";
            showExWindow.Size = new Size(230, 29);
            showExWindow.TabIndex = 14;
            showExWindow.Text = "Show exception window";
            showExWindow.UseVisualStyleBackColor = true;
            // 
            // precentOnLoss
            // 
            precentOnLoss.Location = new Point(150, 37);
            precentOnLoss.Margin = new Padding(6, 5, 6, 5);
            precentOnLoss.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            precentOnLoss.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            precentOnLoss.Name = "precentOnLoss";
            precentOnLoss.Size = new Size(140, 31);
            precentOnLoss.TabIndex = 15;
            precentOnLoss.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 40);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(135, 25);
            label5.TabIndex = 16;
            label5.Text = "Percent on loss:";
            // 
            // useStratCheck
            // 
            useStratCheck.AutoSize = true;
            useStratCheck.Location = new Point(446, 230);
            useStratCheck.Margin = new Padding(6, 5, 6, 5);
            useStratCheck.Name = "useStratCheck";
            useStratCheck.Size = new Size(137, 29);
            useStratCheck.TabIndex = 17;
            useStratCheck.Text = "Use Strategy";
            useStratCheck.UseVisualStyleBackColor = true;
            useStratCheck.CheckedChanged += useStratCheck_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(stratDisplay);
            groupBox2.Location = new Point(440, 230);
            groupBox2.Margin = new Padding(6, 5, 6, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(6, 5, 6, 5);
            groupBox2.Size = new Size(260, 275);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            // 
            // stratDisplay
            // 
            stratDisplay.GridBorder = false;
            stratDisplay.Location = new Point(30, 37);
            stratDisplay.Margin = new Padding(6, 5, 6, 5);
            stratDisplay.Name = "stratDisplay";
            stratDisplay.Size = new Size(189, 189);
            stratDisplay.SquareBorder = true;
            stratDisplay.TabIndex = 18;
            stratDisplay.Text = "satoshiGrid1";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(329, 37);
            checkBox1.Margin = new Padding(6, 5, 6, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(221, 29);
            checkBox1.TabIndex = 19;
            checkBox1.Text = "Use Advanced Startegy";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // showGBombsCheck
            // 
            showGBombsCheck.AutoSize = true;
            showGBombsCheck.Location = new Point(10, 28);
            showGBombsCheck.Margin = new Padding(6, 5, 6, 5);
            showGBombsCheck.Name = "showGBombsCheck";
            showGBombsCheck.Size = new Size(194, 29);
            showGBombsCheck.TabIndex = 19;
            showGBombsCheck.Text = "Show Game Bombs";
            showGBombsCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 58);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(52, 25);
            label6.TabIndex = 20;
            label6.Text = "Coin:";
            // 
            // saveLog
            // 
            saveLog.AutoSize = true;
            saveLog.Enabled = false;
            saveLog.Location = new Point(306, 80);
            saveLog.Margin = new Padding(6, 5, 6, 5);
            saveLog.Name = "saveLog";
            saveLog.Size = new Size(156, 29);
            saveLog.TabIndex = 22;
            saveLog.Text = "Save log to file";
            saveLog.UseVisualStyleBackColor = true;
            // 
            // stopAfterLossCheck
            // 
            stopAfterLossCheck.AutoSize = true;
            stopAfterLossCheck.Location = new Point(17, 93);
            stopAfterLossCheck.Margin = new Padding(6, 5, 6, 5);
            stopAfterLossCheck.Name = "stopAfterLossCheck";
            stopAfterLossCheck.Size = new Size(152, 29);
            stopAfterLossCheck.TabIndex = 23;
            stopAfterLossCheck.Text = "Stop after loss";
            stopAfterLossCheck.UseVisualStyleBackColor = true;
            // 
            // stopAfterGamesChecked
            // 
            stopAfterGamesChecked.AutoSize = true;
            stopAfterGamesChecked.Location = new Point(17, 137);
            stopAfterGamesChecked.Margin = new Padding(6, 5, 6, 5);
            stopAfterGamesChecked.Name = "stopAfterGamesChecked";
            stopAfterGamesChecked.Size = new Size(120, 29);
            stopAfterGamesChecked.TabIndex = 24;
            stopAfterGamesChecked.Text = "Stop after:";
            stopAfterGamesChecked.UseVisualStyleBackColor = true;
            stopAfterGamesChecked.CheckedChanged += stopAfterGamesChecked_CheckedChanged;
            // 
            // stopAfterGamesNum
            // 
            stopAfterGamesNum.Enabled = false;
            stopAfterGamesNum.Location = new Point(151, 135);
            stopAfterGamesNum.Margin = new Padding(6, 5, 6, 5);
            stopAfterGamesNum.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            stopAfterGamesNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            stopAfterGamesNum.Name = "stopAfterGamesNum";
            stopAfterGamesNum.Size = new Size(133, 31);
            stopAfterGamesNum.TabIndex = 25;
            stopAfterGamesNum.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(294, 138);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(66, 25);
            label7.TabIndex = 26;
            label7.Text = "Games";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(OppositeTileChecked);
            groupBox1.Controls.Add(RestartOnCrashChecked);
            groupBox1.Controls.Add(stopAfterWinCheck);
            groupBox1.Controls.Add(stopAfterLossCheck);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(stopAfterGamesNum);
            groupBox1.Controls.Add(stopAfterGamesChecked);
            groupBox1.Location = new Point(11, 315);
            groupBox1.Margin = new Padding(6, 5, 6, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(6, 5, 6, 5);
            groupBox1.Size = new Size(409, 200);
            groupBox1.TabIndex = 27;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stops";
            // 
            // OppositeTileChecked
            // 
            OppositeTileChecked.AutoSize = true;
            OppositeTileChecked.Enabled = false;
            OppositeTileChecked.Location = new Point(190, 93);
            OppositeTileChecked.Margin = new Padding(4, 5, 4, 5);
            OppositeTileChecked.Name = "OppositeTileChecked";
            OppositeTileChecked.Size = new Size(143, 29);
            OppositeTileChecked.TabIndex = 28;
            OppositeTileChecked.Text = "Opposite Tile";
            OppositeTileChecked.UseVisualStyleBackColor = true;
            // 
            // RestartOnCrashChecked
            // 
            RestartOnCrashChecked.AutoSize = true;
            RestartOnCrashChecked.Location = new Point(190, 52);
            RestartOnCrashChecked.Margin = new Padding(4, 5, 4, 5);
            RestartOnCrashChecked.Name = "RestartOnCrashChecked";
            RestartOnCrashChecked.Size = new Size(164, 29);
            RestartOnCrashChecked.TabIndex = 27;
            RestartOnCrashChecked.Text = "Restart on crash";
            RestartOnCrashChecked.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkInstant);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(nudDelay);
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Controls.Add(showExWindow);
            groupBox3.Controls.Add(saveLog);
            groupBox3.Controls.Add(showGBombsCheck);
            groupBox3.Location = new Point(430, 103);
            groupBox3.Margin = new Padding(6, 5, 6, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(6, 5, 6, 5);
            groupBox3.Size = new Size(283, 130);
            groupBox3.TabIndex = 28;
            groupBox3.TabStop = false;
            groupBox3.Text = "Extra";
            // 
            // checkInstant
            // 
            checkInstant.AutoSize = true;
            checkInstant.Enabled = false;
            checkInstant.Location = new Point(10, 56);
            checkInstant.Margin = new Padding(6, 5, 6, 5);
            checkInstant.Name = "checkInstant";
            checkInstant.Size = new Size(154, 29);
            checkInstant.TabIndex = 26;
            checkInstant.Text = "Instant betting";
            checkInstant.UseVisualStyleBackColor = true;
            checkInstant.CheckedChanged += checkInstant_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(200, 90);
            label12.Margin = new Padding(6, 0, 6, 0);
            label12.Name = "label12";
            label12.Size = new Size(36, 25);
            label12.TabIndex = 25;
            label12.Text = "ms";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 90);
            label11.Margin = new Padding(6, 0, 6, 0);
            label11.Name = "label11";
            label11.Size = new Size(60, 25);
            label11.TabIndex = 24;
            label11.Text = "Delay:";
            // 
            // nudDelay
            // 
            nudDelay.Location = new Point(77, 86);
            nudDelay.Margin = new Padding(6, 5, 6, 5);
            nudDelay.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nudDelay.Name = "nudDelay";
            nudDelay.Size = new Size(113, 31);
            nudDelay.TabIndex = 23;
            nudDelay.ValueChanged += nudDelay_ValueChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BombCountBox);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(numberofBets);
            groupBox4.Controls.Add(betCostNUD);
            groupBox4.Controls.Add(label4);
            groupBox4.Location = new Point(11, 103);
            groupBox4.Margin = new Padding(6, 5, 6, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(6, 5, 6, 5);
            groupBox4.Size = new Size(409, 203);
            groupBox4.TabIndex = 29;
            groupBox4.TabStop = false;
            groupBox4.Text = "General";
            // 
            // BombCountBox
            // 
            BombCountBox.Location = new Point(160, 37);
            BombCountBox.Margin = new Padding(6, 5, 6, 5);
            BombCountBox.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            BombCountBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            BombCountBox.Name = "BombCountBox";
            BombCountBox.Size = new Size(231, 31);
            BombCountBox.TabIndex = 12;
            BombCountBox.Value = new decimal(new int[] { 3, 0, 0, 0 });
            BombCountBox.ValueChanged += BombCountBox_ValueChanged;
            // 
            // balanceStopperGroup
            // 
            balanceStopperGroup.Controls.Add(CheckBal);
            balanceStopperGroup.Controls.Add(balanceStopOver);
            balanceStopperGroup.Controls.Add(balanceStopOverChecked);
            balanceStopperGroup.Controls.Add(balanceStopUnder);
            balanceStopperGroup.Controls.Add(balanceStopUnderChecked);
            balanceStopperGroup.Location = new Point(11, 518);
            balanceStopperGroup.Margin = new Padding(6, 5, 6, 5);
            balanceStopperGroup.Name = "balanceStopperGroup";
            balanceStopperGroup.Padding = new Padding(6, 5, 6, 5);
            balanceStopperGroup.Size = new Size(391, 140);
            balanceStopperGroup.TabIndex = 30;
            balanceStopperGroup.TabStop = false;
            balanceStopperGroup.Text = "Balance Check";
            // 
            // CheckBal
            // 
            CheckBal.Location = new Point(314, 60);
            CheckBal.Margin = new Padding(6, 5, 6, 5);
            CheckBal.Name = "CheckBal";
            CheckBal.Size = new Size(71, 45);
            CheckBal.TabIndex = 35;
            CheckBal.Text = "Check";
            CheckBal.UseVisualStyleBackColor = true;
            CheckBal.Click += CheckBal_Click;
            // 
            // balanceStopOver
            // 
            balanceStopOver.DecimalPlaces = 8;
            balanceStopOver.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            balanceStopOver.Location = new Point(134, 43);
            balanceStopOver.Margin = new Padding(6, 5, 6, 5);
            balanceStopOver.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            balanceStopOver.Name = "balanceStopOver";
            balanceStopOver.Size = new Size(174, 31);
            balanceStopOver.TabIndex = 4;
            balanceStopOver.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // balanceStopOverChecked
            // 
            balanceStopOverChecked.AutoSize = true;
            balanceStopOverChecked.Location = new Point(11, 45);
            balanceStopOverChecked.Margin = new Padding(6, 5, 6, 5);
            balanceStopOverChecked.Name = "balanceStopOverChecked";
            balanceStopOverChecked.Size = new Size(118, 29);
            balanceStopOverChecked.TabIndex = 3;
            balanceStopOverChecked.Text = "Stop Over";
            balanceStopOverChecked.UseVisualStyleBackColor = true;
            balanceStopOverChecked.CheckedChanged += balanceStopOverChecked_CheckedChanged;
            // 
            // balanceStopUnder
            // 
            balanceStopUnder.DecimalPlaces = 8;
            balanceStopUnder.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            balanceStopUnder.Location = new Point(134, 87);
            balanceStopUnder.Margin = new Padding(6, 5, 6, 5);
            balanceStopUnder.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            balanceStopUnder.Name = "balanceStopUnder";
            balanceStopUnder.Size = new Size(174, 31);
            balanceStopUnder.TabIndex = 1;
            balanceStopUnder.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // balanceStopUnderChecked
            // 
            balanceStopUnderChecked.AutoSize = true;
            balanceStopUnderChecked.Location = new Point(11, 88);
            balanceStopUnderChecked.Margin = new Padding(6, 5, 6, 5);
            balanceStopUnderChecked.Name = "balanceStopUnderChecked";
            balanceStopUnderChecked.Size = new Size(128, 29);
            balanceStopUnderChecked.TabIndex = 0;
            balanceStopUnderChecked.Text = "Stop Under";
            balanceStopUnderChecked.UseVisualStyleBackColor = true;
            balanceStopUnderChecked.CheckedChanged += balanceStopUnderChecked_CheckedChanged;
            // 
            // metaBox
            // 
            metaBox.Controls.Add(label13);
            metaBox.Controls.Add(ResetBaseWinCount);
            metaBox.Controls.Add(ResetBaseWinsChecked);
            metaBox.Controls.Add(label8);
            metaBox.Controls.Add(PercentOnWinResetGames);
            metaBox.Controls.Add(percentOnWinResetChecked);
            metaBox.Controls.Add(precentOnWin);
            metaBox.Controls.Add(label9);
            metaBox.Controls.Add(label10);
            metaBox.Controls.Add(PercentOnLossResetGames);
            metaBox.Controls.Add(percentOnLossReset);
            metaBox.Controls.Add(precentOnLoss);
            metaBox.Controls.Add(label5);
            metaBox.Enabled = false;
            metaBox.Location = new Point(409, 525);
            metaBox.Margin = new Padding(6, 5, 6, 5);
            metaBox.Name = "metaBox";
            metaBox.Padding = new Padding(6, 5, 6, 5);
            metaBox.Size = new Size(300, 263);
            metaBox.TabIndex = 31;
            metaBox.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(236, 218);
            label13.Margin = new Padding(6, 0, 6, 0);
            label13.Name = "label13";
            label13.Size = new Size(43, 25);
            label13.TabIndex = 26;
            label13.Text = "Win";
            // 
            // ResetBaseWinCount
            // 
            ResetBaseWinCount.Location = new Point(163, 213);
            ResetBaseWinCount.Margin = new Padding(6, 5, 6, 5);
            ResetBaseWinCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            ResetBaseWinCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ResetBaseWinCount.Name = "ResetBaseWinCount";
            ResetBaseWinCount.Size = new Size(67, 31);
            ResetBaseWinCount.TabIndex = 25;
            ResetBaseWinCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ResetBaseWinsChecked
            // 
            ResetBaseWinsChecked.AutoSize = true;
            ResetBaseWinsChecked.Location = new Point(17, 217);
            ResetBaseWinsChecked.Margin = new Padding(4, 5, 4, 5);
            ResetBaseWinsChecked.Name = "ResetBaseWinsChecked";
            ResetBaseWinsChecked.Size = new Size(154, 29);
            ResetBaseWinsChecked.TabIndex = 24;
            ResetBaseWinsChecked.Text = "Reset Bet After";
            ResetBaseWinsChecked.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(233, 170);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(58, 25);
            label8.TabIndex = 19;
            label8.Text = "Game";
            // 
            // PercentOnWinResetGames
            // 
            PercentOnWinResetGames.Location = new Point(150, 160);
            PercentOnWinResetGames.Margin = new Padding(6, 5, 6, 5);
            PercentOnWinResetGames.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            PercentOnWinResetGames.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PercentOnWinResetGames.Name = "PercentOnWinResetGames";
            PercentOnWinResetGames.Size = new Size(80, 31);
            PercentOnWinResetGames.TabIndex = 23;
            PercentOnWinResetGames.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // percentOnWinResetChecked
            // 
            percentOnWinResetChecked.AutoSize = true;
            percentOnWinResetChecked.Location = new Point(17, 162);
            percentOnWinResetChecked.Margin = new Padding(6, 5, 6, 5);
            percentOnWinResetChecked.Name = "percentOnWinResetChecked";
            percentOnWinResetChecked.Size = new Size(124, 29);
            percentOnWinResetChecked.TabIndex = 22;
            percentOnWinResetChecked.Text = "Reset After";
            percentOnWinResetChecked.UseVisualStyleBackColor = true;
            // 
            // precentOnWin
            // 
            precentOnWin.Location = new Point(150, 120);
            precentOnWin.Margin = new Padding(6, 5, 6, 5);
            precentOnWin.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            precentOnWin.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            precentOnWin.Name = "precentOnWin";
            precentOnWin.Size = new Size(140, 31);
            precentOnWin.TabIndex = 20;
            precentOnWin.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 123);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(131, 25);
            label9.TabIndex = 21;
            label9.Text = "Percent on win:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(233, 87);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(58, 25);
            label10.TabIndex = 6;
            label10.Text = "Game";
            // 
            // PercentOnLossResetGames
            // 
            PercentOnLossResetGames.Location = new Point(150, 77);
            PercentOnLossResetGames.Margin = new Padding(6, 5, 6, 5);
            PercentOnLossResetGames.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            PercentOnLossResetGames.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PercentOnLossResetGames.Name = "PercentOnLossResetGames";
            PercentOnLossResetGames.Size = new Size(80, 31);
            PercentOnLossResetGames.TabIndex = 18;
            PercentOnLossResetGames.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // percentOnLossReset
            // 
            percentOnLossReset.AutoSize = true;
            percentOnLossReset.Location = new Point(17, 78);
            percentOnLossReset.Margin = new Padding(6, 5, 6, 5);
            percentOnLossReset.Name = "percentOnLossReset";
            percentOnLossReset.Size = new Size(124, 29);
            percentOnLossReset.TabIndex = 17;
            percentOnLossReset.Text = "Reset After";
            percentOnLossReset.UseVisualStyleBackColor = true;
            // 
            // metaChecked
            // 
            metaChecked.AutoSize = true;
            metaChecked.Location = new Point(426, 518);
            metaChecked.Margin = new Padding(6, 5, 6, 5);
            metaChecked.Name = "metaChecked";
            metaChecked.Size = new Size(78, 29);
            metaChecked.TabIndex = 34;
            metaChecked.Text = "Meta";
            metaChecked.UseVisualStyleBackColor = true;
            metaChecked.CheckedChanged += metaChecked_CheckedChanged;
            // 
            // proxyGroup
            // 
            proxyGroup.Controls.Add(button2);
            proxyGroup.Controls.Add(proxyBox);
            proxyGroup.Controls.Add(useProxy);
            proxyGroup.Enabled = false;
            proxyGroup.Location = new Point(736, 687);
            proxyGroup.Margin = new Padding(6, 5, 6, 5);
            proxyGroup.Name = "proxyGroup";
            proxyGroup.Padding = new Padding(6, 5, 6, 5);
            proxyGroup.Size = new Size(391, 100);
            proxyGroup.TabIndex = 32;
            proxyGroup.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(343, 33);
            button2.Margin = new Padding(6, 5, 6, 5);
            button2.Name = "button2";
            button2.Size = new Size(37, 45);
            button2.TabIndex = 34;
            button2.Text = "C";
            button2.UseVisualStyleBackColor = true;
            // 
            // proxyBox
            // 
            proxyBox.Location = new Point(9, 38);
            proxyBox.Margin = new Padding(6, 5, 6, 5);
            proxyBox.Name = "proxyBox";
            proxyBox.Size = new Size(324, 31);
            proxyBox.TabIndex = 0;
            // 
            // useProxy
            // 
            useProxy.AutoSize = true;
            useProxy.Location = new Point(17, 5);
            useProxy.Margin = new Padding(6, 5, 6, 5);
            useProxy.Name = "useProxy";
            useProxy.Size = new Size(82, 29);
            useProxy.TabIndex = 33;
            useProxy.Text = "Proxy";
            useProxy.UseVisualStyleBackColor = true;
            useProxy.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // cfgTag
            // 
            cfgTag.DropDownStyle = ComboBoxStyle.DropDownList;
            cfgTag.FormattingEnabled = true;
            cfgTag.Location = new Point(131, 52);
            cfgTag.Margin = new Padding(6, 5, 6, 5);
            cfgTag.Name = "cfgTag";
            cfgTag.Size = new Size(198, 33);
            cfgTag.TabIndex = 35;
            cfgTag.SelectedIndexChanged += cfgTag_SelectedIndexChanged;
            // 
            // SiteLabel
            // 
            SiteLabel.AutoSize = true;
            SiteLabel.Location = new Point(425, 56);
            SiteLabel.Margin = new Padding(6, 0, 6, 0);
            SiteLabel.Name = "SiteLabel";
            SiteLabel.Size = new Size(45, 25);
            SiteLabel.TabIndex = 36;
            SiteLabel.Text = "Site:";
            // 
            // SiteConfig
            // 
            SiteConfig.FormattingEnabled = true;
            SiteConfig.Items.AddRange(new object[] { "stake.com", "stake.bet", "stake.games", "staketr.com", "staketr2.com", "staketr3.com", "staketr4.com", "staketr5.com", "stake.bz", "stake.jp", "stake.ac", "stake.icu" });
            SiteConfig.Location = new Point(466, 52);
            SiteConfig.Margin = new Padding(6, 5, 6, 5);
            SiteConfig.Name = "SiteConfig";
            SiteConfig.Size = new Size(245, 33);
            SiteConfig.TabIndex = 37;
            SiteConfig.Text = "stake.com";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(RandomEveryLossChecked);
            groupBox5.Controls.Add(RandomEveryWinChecked);
            groupBox5.Controls.Add(RandomEveryGameChecked);
            groupBox5.Location = new Point(11, 665);
            groupBox5.Margin = new Padding(4, 5, 4, 5);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(4, 5, 4, 5);
            groupBox5.Size = new Size(391, 123);
            groupBox5.TabIndex = 38;
            groupBox5.TabStop = false;
            groupBox5.Text = "Random Tiles";
            // 
            // RandomEveryLossChecked
            // 
            RandomEveryLossChecked.AutoSize = true;
            RandomEveryLossChecked.Location = new Point(190, 42);
            RandomEveryLossChecked.Margin = new Padding(4, 5, 4, 5);
            RandomEveryLossChecked.Name = "RandomEveryLossChecked";
            RandomEveryLossChecked.Size = new Size(116, 29);
            RandomEveryLossChecked.TabIndex = 2;
            RandomEveryLossChecked.Text = "Every loss";
            RandomEveryLossChecked.UseVisualStyleBackColor = true;
            RandomEveryLossChecked.CheckedChanged += RandomEveryLossChecked_CheckedChanged;
            // 
            // RandomEveryWinChecked
            // 
            RandomEveryWinChecked.AutoSize = true;
            RandomEveryWinChecked.Location = new Point(13, 83);
            RandomEveryWinChecked.Margin = new Padding(4, 5, 4, 5);
            RandomEveryWinChecked.Name = "RandomEveryWinChecked";
            RandomEveryWinChecked.Size = new Size(112, 29);
            RandomEveryWinChecked.TabIndex = 1;
            RandomEveryWinChecked.Text = "Every win";
            RandomEveryWinChecked.UseVisualStyleBackColor = true;
            RandomEveryWinChecked.CheckedChanged += RandomEveryWinChecked_CheckedChanged;
            // 
            // RandomEveryGameChecked
            // 
            RandomEveryGameChecked.AutoSize = true;
            RandomEveryGameChecked.Location = new Point(13, 42);
            RandomEveryGameChecked.Margin = new Padding(4, 5, 4, 5);
            RandomEveryGameChecked.Name = "RandomEveryGameChecked";
            RandomEveryGameChecked.Size = new Size(130, 29);
            RandomEveryGameChecked.TabIndex = 0;
            RandomEveryGameChecked.Text = "Every game";
            RandomEveryGameChecked.UseVisualStyleBackColor = true;
            RandomEveryGameChecked.CheckedChanged += RandomEveryGameChecked_CheckedChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(325, 5);
            label14.Margin = new Padding(6, 0, 6, 0);
            label14.Name = "label14";
            label14.Size = new Size(71, 25);
            label14.TabIndex = 39;
            label14.Text = "Cookie:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(399, 4);
            textBox1.Margin = new Padding(6, 5, 6, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(106, 31);
            textBox1.TabIndex = 40;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(510, 6);
            label15.Margin = new Padding(6, 0, 6, 0);
            label15.Name = "label15";
            label15.Size = new Size(64, 25);
            label15.TabIndex = 41;
            label15.Text = "Agent:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(572, 5);
            textBox2.Margin = new Padding(6, 5, 6, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(137, 31);
            textBox2.TabIndex = 42;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(331, 45);
            button3.Margin = new Padding(6, 5, 6, 5);
            button3.Name = "button3";
            button3.Size = new Size(74, 45);
            button3.TabIndex = 36;
            button3.Text = "Get";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 845);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(label15);
            Controls.Add(textBox1);
            Controls.Add(label14);
            Controls.Add(metaChecked);
            Controls.Add(groupBox5);
            Controls.Add(SiteConfig);
            Controls.Add(SiteLabel);
            Controls.Add(cfgTag);
            Controls.Add(useStratCheck);
            Controls.Add(proxyGroup);
            Controls.Add(metaBox);
            Controls.Add(balanceStopperGroup);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(label6);
            Controls.Add(groupBox2);
            Controls.Add(button1);
            Controls.Add(pHash);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(6, 5, 6, 5);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)numberofBets).EndInit();
            ((System.ComponentModel.ISupportInitialize)betCostNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)precentOnLoss).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stopAfterGamesNum).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDelay).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BombCountBox).EndInit();
            balanceStopperGroup.ResumeLayout(false);
            balanceStopperGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)balanceStopOver).EndInit();
            ((System.ComponentModel.ISupportInitialize)balanceStopUnder).EndInit();
            metaBox.ResumeLayout(false);
            metaBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ResetBaseWinCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)PercentOnWinResetGames).EndInit();
            ((System.ComponentModel.ISupportInitialize)precentOnWin).EndInit();
            ((System.ComponentModel.ISupportInitialize)PercentOnLossResetGames).EndInit();
            proxyGroup.ResumeLayout(false);
            proxyGroup.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numberofBets;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown betCostNUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox stopAfterWinCheck;
        private System.Windows.Forms.CheckBox showExWindow;
        private System.Windows.Forms.NumericUpDown precentOnLoss;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox useStratCheck;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox showGBombsCheck;
        private System.Windows.Forms.Label label6;
        private SatoshiGrid stratDisplay;
        private System.Windows.Forms.CheckBox saveLog;
        private System.Windows.Forms.CheckBox stopAfterLossCheck;
        private System.Windows.Forms.CheckBox stopAfterGamesChecked;
        private System.Windows.Forms.NumericUpDown stopAfterGamesNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox balanceStopperGroup;
        private System.Windows.Forms.CheckBox balanceStopUnderChecked;
        private System.Windows.Forms.NumericUpDown balanceStopOver;
        private System.Windows.Forms.CheckBox balanceStopOverChecked;
        private System.Windows.Forms.NumericUpDown balanceStopUnder;
        private System.Windows.Forms.GroupBox metaBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown PercentOnLossResetGames;
        private System.Windows.Forms.CheckBox percentOnLossReset;
        private System.Windows.Forms.GroupBox proxyGroup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox proxyBox;
        private System.Windows.Forms.CheckBox useProxy;
        private System.Windows.Forms.CheckBox metaChecked;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.ComboBox cfgTag;
        private System.Windows.Forms.Label SiteLabel;
        private System.Windows.Forms.ComboBox SiteConfig;
        private System.Windows.Forms.NumericUpDown BombCountBox;
        private Button CheckBal;
        private GroupBox groupBox5;
        private CheckBox RandomEveryLossChecked;
        private CheckBox RandomEveryWinChecked;
        private CheckBox RandomEveryGameChecked;
        private CheckBox RestartOnCrashChecked;
        private Label label8;
        private NumericUpDown PercentOnWinResetGames;
        private CheckBox percentOnWinResetChecked;
        private NumericUpDown precentOnWin;
        private Label label9;
        private Label label13;
        private NumericUpDown ResetBaseWinCount;
        private CheckBox ResetBaseWinsChecked;
        private CheckBox OppositeTileChecked;
        private Label label14;
        private TextBox textBox1;
        private Label label15;
        private TextBox textBox2;
        private Button button3;
        private CheckBox checkInstant;
    }
}
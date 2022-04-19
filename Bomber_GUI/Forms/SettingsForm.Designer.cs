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
            this.label1 = new System.Windows.Forms.Label();
            this.pHash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numberofBets = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.betCostNUD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.stopAfterWinCheck = new System.Windows.Forms.CheckBox();
            this.showExWindow = new System.Windows.Forms.CheckBox();
            this.precentOnLoss = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.useStratCheck = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.showGBombsCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.saveLog = new System.Windows.Forms.CheckBox();
            this.stopAfterLossCheck = new System.Windows.Forms.CheckBox();
            this.stopAfterGamesChecked = new System.Windows.Forms.CheckBox();
            this.stopAfterGamesNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RestartOnCrashChecked = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BombCountBox = new System.Windows.Forms.NumericUpDown();
            this.balanceStopperGroup = new System.Windows.Forms.GroupBox();
            this.CheckBal = new System.Windows.Forms.Button();
            this.balanceStopOver = new System.Windows.Forms.NumericUpDown();
            this.balanceStopOverChecked = new System.Windows.Forms.CheckBox();
            this.balanceStopUnder = new System.Windows.Forms.NumericUpDown();
            this.balanceStopUnderChecked = new System.Windows.Forms.CheckBox();
            this.metaBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PercentOnLossResetGames = new System.Windows.Forms.NumericUpDown();
            this.percentOnLossReset = new System.Windows.Forms.CheckBox();
            this.proxyGroup = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.proxyBox = new System.Windows.Forms.TextBox();
            this.useProxy = new System.Windows.Forms.CheckBox();
            this.metaChecked = new System.Windows.Forms.CheckBox();
            this.cfgTag = new System.Windows.Forms.ComboBox();
            this.SiteLabel = new System.Windows.Forms.Label();
            this.SiteConfig = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RandomEveryLossChecked = new System.Windows.Forms.CheckBox();
            this.RandomEveryWinChecked = new System.Windows.Forms.CheckBox();
            this.RandomEveryGameChecked = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numberofBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betCostNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precentOnLoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopAfterGamesNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BombCountBox)).BeginInit();
            this.balanceStopperGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceStopOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceStopUnder)).BeginInit();
            this.metaBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PercentOnLossResetGames)).BeginInit();
            this.proxyGroup.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Hash:";
            // 
            // pHash
            // 
            this.pHash.Location = new System.Drawing.Point(107, 3);
            this.pHash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pHash.Name = "pHash";
            this.pHash.Size = new System.Drawing.Size(391, 23);
            this.pHash.TabIndex = 1;
            this.pHash.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mines:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of guess:";
            // 
            // numberofBets
            // 
            this.numberofBets.Location = new System.Drawing.Point(112, 55);
            this.numberofBets.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numberofBets.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numberofBets.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberofBets.Name = "numberofBets";
            this.numberofBets.Size = new System.Drawing.Size(162, 23);
            this.numberofBets.TabIndex = 8;
            this.numberofBets.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 477);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(491, 27);
            this.button1.TabIndex = 9;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // betCostNUD
            // 
            this.betCostNUD.DecimalPlaces = 8;
            this.betCostNUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            524288});
            this.betCostNUD.Location = new System.Drawing.Point(112, 85);
            this.betCostNUD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.betCostNUD.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.betCostNUD.Name = "betCostNUD";
            this.betCostNUD.Size = new System.Drawing.Size(162, 23);
            this.betCostNUD.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Bet Cost:";
            // 
            // stopAfterWinCheck
            // 
            this.stopAfterWinCheck.AutoSize = true;
            this.stopAfterWinCheck.Location = new System.Drawing.Point(12, 31);
            this.stopAfterWinCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stopAfterWinCheck.Name = "stopAfterWinCheck";
            this.stopAfterWinCheck.Size = new System.Drawing.Size(99, 19);
            this.stopAfterWinCheck.TabIndex = 13;
            this.stopAfterWinCheck.Text = "Stop after win";
            this.stopAfterWinCheck.UseVisualStyleBackColor = true;
            // 
            // showExWindow
            // 
            this.showExWindow.AutoSize = true;
            this.showExWindow.Enabled = false;
            this.showExWindow.Location = new System.Drawing.Point(228, 23);
            this.showExWindow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.showExWindow.Name = "showExWindow";
            this.showExWindow.Size = new System.Drawing.Size(155, 19);
            this.showExWindow.TabIndex = 14;
            this.showExWindow.Text = "Show exception window";
            this.showExWindow.UseVisualStyleBackColor = true;
            // 
            // precentOnLoss
            // 
            this.precentOnLoss.Location = new System.Drawing.Point(105, 22);
            this.precentOnLoss.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.precentOnLoss.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.precentOnLoss.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.precentOnLoss.Name = "precentOnLoss";
            this.precentOnLoss.Size = new System.Drawing.Size(98, 23);
            this.precentOnLoss.TabIndex = 15;
            this.precentOnLoss.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Percent on loss:";
            // 
            // useStratCheck
            // 
            this.useStratCheck.AutoSize = true;
            this.useStratCheck.Location = new System.Drawing.Point(312, 205);
            this.useStratCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.useStratCheck.Name = "useStratCheck";
            this.useStratCheck.Size = new System.Drawing.Size(91, 19);
            this.useStratCheck.TabIndex = 17;
            this.useStratCheck.Text = "Use Strategy";
            this.useStratCheck.UseVisualStyleBackColor = true;
            this.useStratCheck.CheckedChanged += new System.EventHandler(this.useStratCheck_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(304, 209);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(182, 165);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(6, 22);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 19);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Use Advanced Startegy";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // showGBombsCheck
            // 
            this.showGBombsCheck.AutoSize = true;
            this.showGBombsCheck.Location = new System.Drawing.Point(7, 75);
            this.showGBombsCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.showGBombsCheck.Name = "showGBombsCheck";
            this.showGBombsCheck.Size = new System.Drawing.Size(129, 19);
            this.showGBombsCheck.TabIndex = 19;
            this.showGBombsCheck.Text = "Show Game Bombs";
            this.showGBombsCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Coin:";
            // 
            // saveLog
            // 
            this.saveLog.AutoSize = true;
            this.saveLog.Enabled = false;
            this.saveLog.Location = new System.Drawing.Point(6, 48);
            this.saveLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveLog.Name = "saveLog";
            this.saveLog.Size = new System.Drawing.Size(103, 19);
            this.saveLog.TabIndex = 22;
            this.saveLog.Text = "Save log to file";
            this.saveLog.UseVisualStyleBackColor = true;
            // 
            // stopAfterLossCheck
            // 
            this.stopAfterLossCheck.AutoSize = true;
            this.stopAfterLossCheck.Location = new System.Drawing.Point(12, 56);
            this.stopAfterLossCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stopAfterLossCheck.Name = "stopAfterLossCheck";
            this.stopAfterLossCheck.Size = new System.Drawing.Size(100, 19);
            this.stopAfterLossCheck.TabIndex = 23;
            this.stopAfterLossCheck.Text = "Stop after loss";
            this.stopAfterLossCheck.UseVisualStyleBackColor = true;
            // 
            // stopAfterGamesChecked
            // 
            this.stopAfterGamesChecked.AutoSize = true;
            this.stopAfterGamesChecked.Location = new System.Drawing.Point(12, 82);
            this.stopAfterGamesChecked.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stopAfterGamesChecked.Name = "stopAfterGamesChecked";
            this.stopAfterGamesChecked.Size = new System.Drawing.Size(80, 19);
            this.stopAfterGamesChecked.TabIndex = 24;
            this.stopAfterGamesChecked.Text = "Stop after:";
            this.stopAfterGamesChecked.UseVisualStyleBackColor = true;
            this.stopAfterGamesChecked.CheckedChanged += new System.EventHandler(this.stopAfterGamesChecked_CheckedChanged);
            // 
            // stopAfterGamesNum
            // 
            this.stopAfterGamesNum.Enabled = false;
            this.stopAfterGamesNum.Location = new System.Drawing.Point(106, 81);
            this.stopAfterGamesNum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stopAfterGamesNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.stopAfterGamesNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stopAfterGamesNum.Name = "stopAfterGamesNum";
            this.stopAfterGamesNum.Size = new System.Drawing.Size(93, 23);
            this.stopAfterGamesNum.TabIndex = 25;
            this.stopAfterGamesNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 83);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "Games";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RestartOnCrashChecked);
            this.groupBox1.Controls.Add(this.stopAfterWinCheck);
            this.groupBox1.Controls.Add(this.stopAfterLossCheck);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.stopAfterGamesNum);
            this.groupBox1.Controls.Add(this.stopAfterGamesChecked);
            this.groupBox1.Location = new System.Drawing.Point(8, 189);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(286, 120);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stops";
            // 
            // RestartOnCrashChecked
            // 
            this.RestartOnCrashChecked.AutoSize = true;
            this.RestartOnCrashChecked.Location = new System.Drawing.Point(133, 31);
            this.RestartOnCrashChecked.Name = "RestartOnCrashChecked";
            this.RestartOnCrashChecked.Size = new System.Drawing.Size(110, 19);
            this.RestartOnCrashChecked.TabIndex = 27;
            this.RestartOnCrashChecked.Text = "Restart on crash";
            this.RestartOnCrashChecked.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.nudDelay);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.showExWindow);
            this.groupBox3.Controls.Add(this.saveLog);
            this.groupBox3.Controls.Add(this.showGBombsCheck);
            this.groupBox3.Location = new System.Drawing.Point(301, 62);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(198, 140);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Extra";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(140, 104);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "ms";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 104);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Delay:";
            // 
            // nudDelay
            // 
            this.nudDelay.Location = new System.Drawing.Point(54, 102);
            this.nudDelay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(79, 23);
            this.nudDelay.TabIndex = 23;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BombCountBox);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.numberofBets);
            this.groupBox4.Controls.Add(this.betCostNUD);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(8, 62);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(286, 122);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General";
            // 
            // BombCountBox
            // 
            this.BombCountBox.Location = new System.Drawing.Point(112, 22);
            this.BombCountBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BombCountBox.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.BombCountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BombCountBox.Name = "BombCountBox";
            this.BombCountBox.Size = new System.Drawing.Size(162, 23);
            this.BombCountBox.TabIndex = 12;
            this.BombCountBox.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // balanceStopperGroup
            // 
            this.balanceStopperGroup.Controls.Add(this.CheckBal);
            this.balanceStopperGroup.Controls.Add(this.balanceStopOver);
            this.balanceStopperGroup.Controls.Add(this.balanceStopOverChecked);
            this.balanceStopperGroup.Controls.Add(this.balanceStopUnder);
            this.balanceStopperGroup.Controls.Add(this.balanceStopUnderChecked);
            this.balanceStopperGroup.Location = new System.Drawing.Point(8, 311);
            this.balanceStopperGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.balanceStopperGroup.Name = "balanceStopperGroup";
            this.balanceStopperGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.balanceStopperGroup.Size = new System.Drawing.Size(274, 84);
            this.balanceStopperGroup.TabIndex = 30;
            this.balanceStopperGroup.TabStop = false;
            this.balanceStopperGroup.Text = "Balance Check";
            // 
            // CheckBal
            // 
            this.CheckBal.Location = new System.Drawing.Point(220, 36);
            this.CheckBal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBal.Name = "CheckBal";
            this.CheckBal.Size = new System.Drawing.Size(50, 27);
            this.CheckBal.TabIndex = 35;
            this.CheckBal.Text = "Check";
            this.CheckBal.UseVisualStyleBackColor = true;
            this.CheckBal.Click += new System.EventHandler(this.CheckBal_Click);
            // 
            // balanceStopOver
            // 
            this.balanceStopOver.DecimalPlaces = 8;
            this.balanceStopOver.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.balanceStopOver.Location = new System.Drawing.Point(94, 26);
            this.balanceStopOver.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.balanceStopOver.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.balanceStopOver.Name = "balanceStopOver";
            this.balanceStopOver.Size = new System.Drawing.Size(122, 23);
            this.balanceStopOver.TabIndex = 4;
            this.balanceStopOver.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // balanceStopOverChecked
            // 
            this.balanceStopOverChecked.AutoSize = true;
            this.balanceStopOverChecked.Location = new System.Drawing.Point(8, 27);
            this.balanceStopOverChecked.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.balanceStopOverChecked.Name = "balanceStopOverChecked";
            this.balanceStopOverChecked.Size = new System.Drawing.Size(78, 19);
            this.balanceStopOverChecked.TabIndex = 3;
            this.balanceStopOverChecked.Text = "Stop Over";
            this.balanceStopOverChecked.UseVisualStyleBackColor = true;
            this.balanceStopOverChecked.CheckedChanged += new System.EventHandler(this.balanceStopOverChecked_CheckedChanged);
            // 
            // balanceStopUnder
            // 
            this.balanceStopUnder.DecimalPlaces = 8;
            this.balanceStopUnder.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.balanceStopUnder.Location = new System.Drawing.Point(94, 52);
            this.balanceStopUnder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.balanceStopUnder.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.balanceStopUnder.Name = "balanceStopUnder";
            this.balanceStopUnder.Size = new System.Drawing.Size(122, 23);
            this.balanceStopUnder.TabIndex = 1;
            this.balanceStopUnder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // balanceStopUnderChecked
            // 
            this.balanceStopUnderChecked.AutoSize = true;
            this.balanceStopUnderChecked.Location = new System.Drawing.Point(8, 53);
            this.balanceStopUnderChecked.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.balanceStopUnderChecked.Name = "balanceStopUnderChecked";
            this.balanceStopUnderChecked.Size = new System.Drawing.Size(85, 19);
            this.balanceStopUnderChecked.TabIndex = 0;
            this.balanceStopUnderChecked.Text = "Stop Under";
            this.balanceStopUnderChecked.UseVisualStyleBackColor = true;
            this.balanceStopUnderChecked.CheckedChanged += new System.EventHandler(this.balanceStopUnderChecked_CheckedChanged);
            // 
            // metaBox
            // 
            this.metaBox.Controls.Add(this.label10);
            this.metaBox.Controls.Add(this.PercentOnLossResetGames);
            this.metaBox.Controls.Add(this.percentOnLossReset);
            this.metaBox.Controls.Add(this.precentOnLoss);
            this.metaBox.Controls.Add(this.label5);
            this.metaBox.Enabled = false;
            this.metaBox.Location = new System.Drawing.Point(287, 387);
            this.metaBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metaBox.Name = "metaBox";
            this.metaBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metaBox.Size = new System.Drawing.Size(210, 86);
            this.metaBox.TabIndex = 31;
            this.metaBox.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 52);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Game";
            // 
            // PercentOnLossResetGames
            // 
            this.PercentOnLossResetGames.Location = new System.Drawing.Point(105, 46);
            this.PercentOnLossResetGames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PercentOnLossResetGames.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PercentOnLossResetGames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PercentOnLossResetGames.Name = "PercentOnLossResetGames";
            this.PercentOnLossResetGames.Size = new System.Drawing.Size(56, 23);
            this.PercentOnLossResetGames.TabIndex = 18;
            this.PercentOnLossResetGames.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // percentOnLossReset
            // 
            this.percentOnLossReset.AutoSize = true;
            this.percentOnLossReset.Location = new System.Drawing.Point(12, 47);
            this.percentOnLossReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.percentOnLossReset.Name = "percentOnLossReset";
            this.percentOnLossReset.Size = new System.Drawing.Size(83, 19);
            this.percentOnLossReset.TabIndex = 17;
            this.percentOnLossReset.Text = "Reset After";
            this.percentOnLossReset.UseVisualStyleBackColor = true;
            // 
            // proxyGroup
            // 
            this.proxyGroup.Controls.Add(this.button2);
            this.proxyGroup.Controls.Add(this.proxyBox);
            this.proxyGroup.Controls.Add(this.useProxy);
            this.proxyGroup.Enabled = false;
            this.proxyGroup.Location = new System.Drawing.Point(515, 412);
            this.proxyGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.proxyGroup.Name = "proxyGroup";
            this.proxyGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.proxyGroup.Size = new System.Drawing.Size(274, 60);
            this.proxyGroup.TabIndex = 32;
            this.proxyGroup.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(240, 20);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 27);
            this.button2.TabIndex = 34;
            this.button2.Text = "C";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // proxyBox
            // 
            this.proxyBox.Location = new System.Drawing.Point(6, 23);
            this.proxyBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.proxyBox.Name = "proxyBox";
            this.proxyBox.Size = new System.Drawing.Size(228, 23);
            this.proxyBox.TabIndex = 0;
            // 
            // useProxy
            // 
            this.useProxy.AutoSize = true;
            this.useProxy.Location = new System.Drawing.Point(12, 3);
            this.useProxy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.useProxy.Name = "useProxy";
            this.useProxy.Size = new System.Drawing.Size(56, 19);
            this.useProxy.TabIndex = 33;
            this.useProxy.Text = "Proxy";
            this.useProxy.UseVisualStyleBackColor = true;
            this.useProxy.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // metaChecked
            // 
            this.metaChecked.AutoSize = true;
            this.metaChecked.Location = new System.Drawing.Point(301, 383);
            this.metaChecked.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metaChecked.Name = "metaChecked";
            this.metaChecked.Size = new System.Drawing.Size(53, 19);
            this.metaChecked.TabIndex = 34;
            this.metaChecked.Text = "Meta";
            this.metaChecked.UseVisualStyleBackColor = true;
            this.metaChecked.CheckedChanged += new System.EventHandler(this.metaChecked_CheckedChanged);
            // 
            // cfgTag
            // 
            this.cfgTag.FormattingEnabled = true;
            this.cfgTag.Items.AddRange(new object[] {
            "Btc",
            "Eth",
            "Ltc",
            "Doge",
            "Bch",
            "Trx",
            "Eos"});
            this.cfgTag.Location = new System.Drawing.Point(107, 31);
            this.cfgTag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cfgTag.Name = "cfgTag";
            this.cfgTag.Size = new System.Drawing.Size(140, 23);
            this.cfgTag.TabIndex = 35;
            this.cfgTag.Text = "Btc";
            this.cfgTag.SelectedIndexChanged += new System.EventHandler(this.cfgTag_SelectedIndexChanged);
            // 
            // SiteLabel
            // 
            this.SiteLabel.AutoSize = true;
            this.SiteLabel.Location = new System.Drawing.Point(284, 36);
            this.SiteLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SiteLabel.Name = "SiteLabel";
            this.SiteLabel.Size = new System.Drawing.Size(29, 15);
            this.SiteLabel.TabIndex = 36;
            this.SiteLabel.Text = "Site:";
            // 
            // SiteConfig
            // 
            this.SiteConfig.FormattingEnabled = true;
            this.SiteConfig.Items.AddRange(new object[] {
            "stake.com",
            "stake.bet",
            "stake.games",
            "staketr.com",
            "staketr2.com",
            "staketr3.com",
            "staketr4.com",
            "staketr5.com",
            "stake.bz",
            "stake.jp",
            "stake.ac",
            "stake.icu"});
            this.SiteConfig.Location = new System.Drawing.Point(326, 31);
            this.SiteConfig.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SiteConfig.Name = "SiteConfig";
            this.SiteConfig.Size = new System.Drawing.Size(173, 23);
            this.SiteConfig.TabIndex = 37;
            this.SiteConfig.Text = "stake.com";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RandomEveryLossChecked);
            this.groupBox5.Controls.Add(this.RandomEveryWinChecked);
            this.groupBox5.Controls.Add(this.RandomEveryGameChecked);
            this.groupBox5.Location = new System.Drawing.Point(8, 399);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(272, 74);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Random Tiles";
            // 
            // RandomEveryLossChecked
            // 
            this.RandomEveryLossChecked.AutoSize = true;
            this.RandomEveryLossChecked.Location = new System.Drawing.Point(133, 25);
            this.RandomEveryLossChecked.Name = "RandomEveryLossChecked";
            this.RandomEveryLossChecked.Size = new System.Drawing.Size(77, 19);
            this.RandomEveryLossChecked.TabIndex = 2;
            this.RandomEveryLossChecked.Text = "Every loss";
            this.RandomEveryLossChecked.UseVisualStyleBackColor = true;
            this.RandomEveryLossChecked.CheckedChanged += new System.EventHandler(this.RandomEveryLossChecked_CheckedChanged);
            // 
            // RandomEveryWinChecked
            // 
            this.RandomEveryWinChecked.AutoSize = true;
            this.RandomEveryWinChecked.Location = new System.Drawing.Point(9, 50);
            this.RandomEveryWinChecked.Name = "RandomEveryWinChecked";
            this.RandomEveryWinChecked.Size = new System.Drawing.Size(76, 19);
            this.RandomEveryWinChecked.TabIndex = 1;
            this.RandomEveryWinChecked.Text = "Every win";
            this.RandomEveryWinChecked.UseVisualStyleBackColor = true;
            this.RandomEveryWinChecked.CheckedChanged += new System.EventHandler(this.RandomEveryWinChecked_CheckedChanged);
            // 
            // RandomEveryGameChecked
            // 
            this.RandomEveryGameChecked.AutoSize = true;
            this.RandomEveryGameChecked.Location = new System.Drawing.Point(9, 25);
            this.RandomEveryGameChecked.Name = "RandomEveryGameChecked";
            this.RandomEveryGameChecked.Size = new System.Drawing.Size(87, 19);
            this.RandomEveryGameChecked.TabIndex = 0;
            this.RandomEveryGameChecked.Text = "Every game";
            this.RandomEveryGameChecked.UseVisualStyleBackColor = true;
            this.RandomEveryGameChecked.CheckedChanged += new System.EventHandler(this.RandomEveryGameChecked_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 507);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.SiteConfig);
            this.Controls.Add(this.SiteLabel);
            this.Controls.Add(this.cfgTag);
            this.Controls.Add(this.useStratCheck);
            this.Controls.Add(this.metaChecked);
            this.Controls.Add(this.proxyGroup);
            this.Controls.Add(this.metaBox);
            this.Controls.Add(this.balanceStopperGroup);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pHash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numberofBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betCostNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precentOnLoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopAfterGamesNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BombCountBox)).EndInit();
            this.balanceStopperGroup.ResumeLayout(false);
            this.balanceStopperGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceStopOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceStopUnder)).EndInit();
            this.metaBox.ResumeLayout(false);
            this.metaBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PercentOnLossResetGames)).EndInit();
            this.proxyGroup.ResumeLayout(false);
            this.proxyGroup.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
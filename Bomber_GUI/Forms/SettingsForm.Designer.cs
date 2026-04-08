using System;
using System.Drawing;
using System.Windows.Forms;

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
            this.OppositeTileChecked = new System.Windows.Forms.CheckBox();
            this.RestartOnCrashChecked = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkInstant = new System.Windows.Forms.CheckBox();
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
            this.label13 = new System.Windows.Forms.Label();
            this.ResetBaseWinCount = new System.Windows.Forms.NumericUpDown();
            this.ResetBaseWinsChecked = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PercentOnWinResetGames = new System.Windows.Forms.NumericUpDown();
            this.percentOnWinResetChecked = new System.Windows.Forms.CheckBox();
            this.precentOnWin = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PercentOnLossResetGames = new System.Windows.Forms.NumericUpDown();
            this.percentOnLossReset = new System.Windows.Forms.CheckBox();
            this.metaChecked = new System.Windows.Forms.CheckBox();
            this.proxyGroup = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.proxyBox = new System.Windows.Forms.TextBox();
            this.useProxy = new System.Windows.Forms.CheckBox();
            this.cfgTag = new System.Windows.Forms.ComboBox();
            this.SiteLabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RandomEveryLossChecked = new System.Windows.Forms.CheckBox();
            this.RandomEveryWinChecked = new System.Windows.Forms.CheckBox();
            this.RandomEveryGameChecked = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SiteConfig = new System.Windows.Forms.TextBox();
            this.stratDisplay = new Bomber_GUI.Forms.SatoshiGrid();
            ((System.ComponentModel.ISupportInitialize)(this.numberofBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betCostNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precentOnLoss)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.ResetBaseWinCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercentOnWinResetGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precentOnWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercentOnLossResetGames)).BeginInit();
            this.proxyGroup.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Api key:";
            // 
            // pHash
            // 
            this.pHash.Location = new System.Drawing.Point(106, 3);
            this.pHash.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.pHash.Name = "pHash";
            this.pHash.Size = new System.Drawing.Size(453, 22);
            this.pHash.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mines:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of guess:";
            // 
            // numberofBets
            // 
            this.numberofBets.Location = new System.Drawing.Point(128, 59);
            this.numberofBets.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
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
            this.numberofBets.Size = new System.Drawing.Size(185, 22);
            this.numberofBets.TabIndex = 8;
            this.numberofBets.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 509);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(561, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // betCostNUD
            // 
            this.betCostNUD.DecimalPlaces = 8;
            this.betCostNUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            524288});
            this.betCostNUD.Location = new System.Drawing.Point(128, 91);
            this.betCostNUD.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.betCostNUD.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.betCostNUD.Name = "betCostNUD";
            this.betCostNUD.Size = new System.Drawing.Size(185, 22);
            this.betCostNUD.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Bet Cost:";
            // 
            // stopAfterWinCheck
            // 
            this.stopAfterWinCheck.AutoSize = true;
            this.stopAfterWinCheck.Location = new System.Drawing.Point(14, 34);
            this.stopAfterWinCheck.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.stopAfterWinCheck.Name = "stopAfterWinCheck";
            this.stopAfterWinCheck.Size = new System.Drawing.Size(108, 20);
            this.stopAfterWinCheck.TabIndex = 13;
            this.stopAfterWinCheck.Text = "Stop after win";
            this.stopAfterWinCheck.UseVisualStyleBackColor = true;
            // 
            // showExWindow
            // 
            this.showExWindow.AutoSize = true;
            this.showExWindow.Enabled = false;
            this.showExWindow.Location = new System.Drawing.Point(261, 24);
            this.showExWindow.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.showExWindow.Name = "showExWindow";
            this.showExWindow.Size = new System.Drawing.Size(170, 20);
            this.showExWindow.TabIndex = 14;
            this.showExWindow.Text = "Show exception window";
            this.showExWindow.UseVisualStyleBackColor = true;
            // 
            // precentOnLoss
            // 
            this.precentOnLoss.Location = new System.Drawing.Point(120, 24);
            this.precentOnLoss.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.precentOnLoss.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.precentOnLoss.Name = "precentOnLoss";
            this.precentOnLoss.Size = new System.Drawing.Size(112, 22);
            this.precentOnLoss.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Percent on loss:";
            // 
            // useStratCheck
            // 
            this.useStratCheck.AutoSize = true;
            this.useStratCheck.Location = new System.Drawing.Point(357, 147);
            this.useStratCheck.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.useStratCheck.Name = "useStratCheck";
            this.useStratCheck.Size = new System.Drawing.Size(107, 20);
            this.useStratCheck.TabIndex = 17;
            this.useStratCheck.Text = "Use Strategy";
            this.useStratCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stratDisplay);
            this.groupBox2.Location = new System.Drawing.Point(352, 147);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox2.Size = new System.Drawing.Size(208, 176);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(263, 24);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 20);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Use Advanced Startegy";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // showGBombsCheck
            // 
            this.showGBombsCheck.AutoSize = true;
            this.showGBombsCheck.Location = new System.Drawing.Point(8, 18);
            this.showGBombsCheck.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.showGBombsCheck.Name = "showGBombsCheck";
            this.showGBombsCheck.Size = new System.Drawing.Size(148, 20);
            this.showGBombsCheck.TabIndex = 19;
            this.showGBombsCheck.Text = "Show Game Bombs";
            this.showGBombsCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Coin:";
            // 
            // saveLog
            // 
            this.saveLog.AutoSize = true;
            this.saveLog.Enabled = false;
            this.saveLog.Location = new System.Drawing.Point(245, 51);
            this.saveLog.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.saveLog.Name = "saveLog";
            this.saveLog.Size = new System.Drawing.Size(117, 20);
            this.saveLog.TabIndex = 22;
            this.saveLog.Text = "Save log to file";
            this.saveLog.UseVisualStyleBackColor = true;
            // 
            // stopAfterLossCheck
            // 
            this.stopAfterLossCheck.AutoSize = true;
            this.stopAfterLossCheck.Location = new System.Drawing.Point(14, 59);
            this.stopAfterLossCheck.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.stopAfterLossCheck.Name = "stopAfterLossCheck";
            this.stopAfterLossCheck.Size = new System.Drawing.Size(114, 20);
            this.stopAfterLossCheck.TabIndex = 23;
            this.stopAfterLossCheck.Text = "Stop after loss";
            this.stopAfterLossCheck.UseVisualStyleBackColor = true;
            // 
            // stopAfterGamesChecked
            // 
            this.stopAfterGamesChecked.AutoSize = true;
            this.stopAfterGamesChecked.Location = new System.Drawing.Point(14, 88);
            this.stopAfterGamesChecked.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.stopAfterGamesChecked.Name = "stopAfterGamesChecked";
            this.stopAfterGamesChecked.Size = new System.Drawing.Size(89, 20);
            this.stopAfterGamesChecked.TabIndex = 24;
            this.stopAfterGamesChecked.Text = "Stop after:";
            this.stopAfterGamesChecked.UseVisualStyleBackColor = true;
            // 
            // stopAfterGamesNum
            // 
            this.stopAfterGamesNum.Enabled = false;
            this.stopAfterGamesNum.Location = new System.Drawing.Point(121, 86);
            this.stopAfterGamesNum.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
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
            this.stopAfterGamesNum.Size = new System.Drawing.Size(106, 22);
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
            this.label7.Location = new System.Drawing.Point(235, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Games";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OppositeTileChecked);
            this.groupBox1.Controls.Add(this.RestartOnCrashChecked);
            this.groupBox1.Controls.Add(this.stopAfterWinCheck);
            this.groupBox1.Controls.Add(this.stopAfterLossCheck);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.stopAfterGamesNum);
            this.groupBox1.Controls.Add(this.stopAfterGamesChecked);
            this.groupBox1.Location = new System.Drawing.Point(9, 202);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Size = new System.Drawing.Size(327, 128);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stops";
            // 
            // OppositeTileChecked
            // 
            this.OppositeTileChecked.AutoSize = true;
            this.OppositeTileChecked.Enabled = false;
            this.OppositeTileChecked.Location = new System.Drawing.Point(152, 59);
            this.OppositeTileChecked.Name = "OppositeTileChecked";
            this.OppositeTileChecked.Size = new System.Drawing.Size(110, 20);
            this.OppositeTileChecked.TabIndex = 28;
            this.OppositeTileChecked.Text = "Opposite Tile";
            this.OppositeTileChecked.UseVisualStyleBackColor = true;
            // 
            // RestartOnCrashChecked
            // 
            this.RestartOnCrashChecked.AutoSize = true;
            this.RestartOnCrashChecked.Location = new System.Drawing.Point(152, 34);
            this.RestartOnCrashChecked.Name = "RestartOnCrashChecked";
            this.RestartOnCrashChecked.Size = new System.Drawing.Size(126, 20);
            this.RestartOnCrashChecked.TabIndex = 27;
            this.RestartOnCrashChecked.Text = "Restart on crash";
            this.RestartOnCrashChecked.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkInstant);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.nudDelay);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.showExWindow);
            this.groupBox3.Controls.Add(this.saveLog);
            this.groupBox3.Controls.Add(this.showGBombsCheck);
            this.groupBox3.Location = new System.Drawing.Point(344, 66);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox3.Size = new System.Drawing.Size(226, 83);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Extra";
            // 
            // checkInstant
            // 
            this.checkInstant.AutoSize = true;
            this.checkInstant.Location = new System.Drawing.Point(8, 36);
            this.checkInstant.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.checkInstant.Name = "checkInstant";
            this.checkInstant.Size = new System.Drawing.Size(110, 20);
            this.checkInstant.TabIndex = 26;
            this.checkInstant.Text = "Instant betting";
            this.checkInstant.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(160, 58);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "ms";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 58);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Delay:";
            // 
            // nudDelay
            // 
            this.nudDelay.Location = new System.Drawing.Point(62, 55);
            this.nudDelay.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nudDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(90, 22);
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
            this.groupBox4.Location = new System.Drawing.Point(9, 66);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox4.Size = new System.Drawing.Size(327, 130);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General";
            // 
            // BombCountBox
            // 
            this.BombCountBox.Location = new System.Drawing.Point(128, 24);
            this.BombCountBox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
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
            this.BombCountBox.Size = new System.Drawing.Size(185, 22);
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
            this.balanceStopperGroup.Location = new System.Drawing.Point(9, 331);
            this.balanceStopperGroup.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.balanceStopperGroup.Name = "balanceStopperGroup";
            this.balanceStopperGroup.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.balanceStopperGroup.Size = new System.Drawing.Size(313, 90);
            this.balanceStopperGroup.TabIndex = 30;
            this.balanceStopperGroup.TabStop = false;
            this.balanceStopperGroup.Text = "Balance Check";
            // 
            // CheckBal
            // 
            this.CheckBal.Location = new System.Drawing.Point(251, 38);
            this.CheckBal.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.CheckBal.Name = "CheckBal";
            this.CheckBal.Size = new System.Drawing.Size(57, 29);
            this.CheckBal.TabIndex = 35;
            this.CheckBal.Text = "Check";
            this.CheckBal.UseVisualStyleBackColor = true;
            // 
            // balanceStopOver
            // 
            this.balanceStopOver.DecimalPlaces = 8;
            this.balanceStopOver.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.balanceStopOver.Location = new System.Drawing.Point(107, 27);
            this.balanceStopOver.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.balanceStopOver.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.balanceStopOver.Name = "balanceStopOver";
            this.balanceStopOver.Size = new System.Drawing.Size(139, 22);
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
            this.balanceStopOverChecked.Location = new System.Drawing.Point(9, 29);
            this.balanceStopOverChecked.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.balanceStopOverChecked.Name = "balanceStopOverChecked";
            this.balanceStopOverChecked.Size = new System.Drawing.Size(89, 20);
            this.balanceStopOverChecked.TabIndex = 3;
            this.balanceStopOverChecked.Text = "Stop Over";
            this.balanceStopOverChecked.UseVisualStyleBackColor = true;
            // 
            // balanceStopUnder
            // 
            this.balanceStopUnder.DecimalPlaces = 8;
            this.balanceStopUnder.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.balanceStopUnder.Location = new System.Drawing.Point(107, 56);
            this.balanceStopUnder.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.balanceStopUnder.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.balanceStopUnder.Name = "balanceStopUnder";
            this.balanceStopUnder.Size = new System.Drawing.Size(139, 22);
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
            this.balanceStopUnderChecked.Location = new System.Drawing.Point(9, 56);
            this.balanceStopUnderChecked.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.balanceStopUnderChecked.Name = "balanceStopUnderChecked";
            this.balanceStopUnderChecked.Size = new System.Drawing.Size(97, 20);
            this.balanceStopUnderChecked.TabIndex = 0;
            this.balanceStopUnderChecked.Text = "Stop Under";
            this.balanceStopUnderChecked.UseVisualStyleBackColor = true;
            // 
            // metaBox
            // 
            this.metaBox.Controls.Add(this.label13);
            this.metaBox.Controls.Add(this.ResetBaseWinCount);
            this.metaBox.Controls.Add(this.ResetBaseWinsChecked);
            this.metaBox.Controls.Add(this.label8);
            this.metaBox.Controls.Add(this.PercentOnWinResetGames);
            this.metaBox.Controls.Add(this.percentOnWinResetChecked);
            this.metaBox.Controls.Add(this.precentOnWin);
            this.metaBox.Controls.Add(this.label9);
            this.metaBox.Controls.Add(this.label10);
            this.metaBox.Controls.Add(this.PercentOnLossResetGames);
            this.metaBox.Controls.Add(this.percentOnLossReset);
            this.metaBox.Controls.Add(this.precentOnLoss);
            this.metaBox.Controls.Add(this.label5);
            this.metaBox.Enabled = false;
            this.metaBox.Location = new System.Drawing.Point(327, 336);
            this.metaBox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.metaBox.Name = "metaBox";
            this.metaBox.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.metaBox.Size = new System.Drawing.Size(240, 168);
            this.metaBox.TabIndex = 31;
            this.metaBox.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(189, 139);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Win";
            // 
            // ResetBaseWinCount
            // 
            this.ResetBaseWinCount.Location = new System.Drawing.Point(130, 136);
            this.ResetBaseWinCount.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.ResetBaseWinCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ResetBaseWinCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ResetBaseWinCount.Name = "ResetBaseWinCount";
            this.ResetBaseWinCount.Size = new System.Drawing.Size(54, 22);
            this.ResetBaseWinCount.TabIndex = 25;
            this.ResetBaseWinCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ResetBaseWinsChecked
            // 
            this.ResetBaseWinsChecked.AutoSize = true;
            this.ResetBaseWinsChecked.Location = new System.Drawing.Point(14, 139);
            this.ResetBaseWinsChecked.Name = "ResetBaseWinsChecked";
            this.ResetBaseWinsChecked.Size = new System.Drawing.Size(118, 20);
            this.ResetBaseWinsChecked.TabIndex = 24;
            this.ResetBaseWinsChecked.Text = "Reset Bet After";
            this.ResetBaseWinsChecked.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 109);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Game";
            // 
            // PercentOnWinResetGames
            // 
            this.PercentOnWinResetGames.Location = new System.Drawing.Point(120, 102);
            this.PercentOnWinResetGames.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.PercentOnWinResetGames.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PercentOnWinResetGames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PercentOnWinResetGames.Name = "PercentOnWinResetGames";
            this.PercentOnWinResetGames.Size = new System.Drawing.Size(64, 22);
            this.PercentOnWinResetGames.TabIndex = 23;
            this.PercentOnWinResetGames.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // percentOnWinResetChecked
            // 
            this.percentOnWinResetChecked.AutoSize = true;
            this.percentOnWinResetChecked.Location = new System.Drawing.Point(14, 104);
            this.percentOnWinResetChecked.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.percentOnWinResetChecked.Name = "percentOnWinResetChecked";
            this.percentOnWinResetChecked.Size = new System.Drawing.Size(95, 20);
            this.percentOnWinResetChecked.TabIndex = 22;
            this.percentOnWinResetChecked.Text = "Reset After";
            this.percentOnWinResetChecked.UseVisualStyleBackColor = true;
            // 
            // precentOnWin
            // 
            this.precentOnWin.Location = new System.Drawing.Point(120, 77);
            this.precentOnWin.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.precentOnWin.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.precentOnWin.Name = "precentOnWin";
            this.precentOnWin.Size = new System.Drawing.Size(112, 22);
            this.precentOnWin.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 78);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Percent on win:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(186, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "Game";
            // 
            // PercentOnLossResetGames
            // 
            this.PercentOnLossResetGames.Location = new System.Drawing.Point(120, 50);
            this.PercentOnLossResetGames.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
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
            this.PercentOnLossResetGames.Size = new System.Drawing.Size(64, 22);
            this.PercentOnLossResetGames.TabIndex = 18;
            this.PercentOnLossResetGames.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // percentOnLossReset
            // 
            this.percentOnLossReset.AutoSize = true;
            this.percentOnLossReset.Location = new System.Drawing.Point(14, 50);
            this.percentOnLossReset.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.percentOnLossReset.Name = "percentOnLossReset";
            this.percentOnLossReset.Size = new System.Drawing.Size(95, 20);
            this.percentOnLossReset.TabIndex = 17;
            this.percentOnLossReset.Text = "Reset After";
            this.percentOnLossReset.UseVisualStyleBackColor = true;
            // 
            // metaChecked
            // 
            this.metaChecked.AutoSize = true;
            this.metaChecked.Location = new System.Drawing.Point(341, 331);
            this.metaChecked.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.metaChecked.Name = "metaChecked";
            this.metaChecked.Size = new System.Drawing.Size(59, 20);
            this.metaChecked.TabIndex = 34;
            this.metaChecked.Text = "Meta";
            this.metaChecked.UseVisualStyleBackColor = true;
            // 
            // proxyGroup
            // 
            this.proxyGroup.Controls.Add(this.button2);
            this.proxyGroup.Controls.Add(this.proxyBox);
            this.proxyGroup.Controls.Add(this.useProxy);
            this.proxyGroup.Enabled = false;
            this.proxyGroup.Location = new System.Drawing.Point(589, 440);
            this.proxyGroup.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.proxyGroup.Name = "proxyGroup";
            this.proxyGroup.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.proxyGroup.Size = new System.Drawing.Size(313, 64);
            this.proxyGroup.TabIndex = 32;
            this.proxyGroup.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 21);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 29);
            this.button2.TabIndex = 34;
            this.button2.Text = "C";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // proxyBox
            // 
            this.proxyBox.Location = new System.Drawing.Point(7, 24);
            this.proxyBox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.proxyBox.Name = "proxyBox";
            this.proxyBox.Size = new System.Drawing.Size(260, 22);
            this.proxyBox.TabIndex = 0;
            // 
            // useProxy
            // 
            this.useProxy.AutoSize = true;
            this.useProxy.Location = new System.Drawing.Point(14, 3);
            this.useProxy.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.useProxy.Name = "useProxy";
            this.useProxy.Size = new System.Drawing.Size(63, 20);
            this.useProxy.TabIndex = 33;
            this.useProxy.Text = "Proxy";
            this.useProxy.UseVisualStyleBackColor = true;
            // 
            // cfgTag
            // 
            this.cfgTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cfgTag.FormattingEnabled = true;
            this.cfgTag.Location = new System.Drawing.Point(105, 34);
            this.cfgTag.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cfgTag.Name = "cfgTag";
            this.cfgTag.Size = new System.Drawing.Size(159, 24);
            this.cfgTag.TabIndex = 35;
            // 
            // SiteLabel
            // 
            this.SiteLabel.AutoSize = true;
            this.SiteLabel.Location = new System.Drawing.Point(340, 36);
            this.SiteLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.SiteLabel.Name = "SiteLabel";
            this.SiteLabel.Size = new System.Drawing.Size(33, 16);
            this.SiteLabel.TabIndex = 36;
            this.SiteLabel.Text = "Site:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RandomEveryLossChecked);
            this.groupBox5.Controls.Add(this.RandomEveryWinChecked);
            this.groupBox5.Controls.Add(this.RandomEveryGameChecked);
            this.groupBox5.Location = new System.Drawing.Point(9, 426);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(313, 78);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Random Tiles";
            // 
            // RandomEveryLossChecked
            // 
            this.RandomEveryLossChecked.AutoSize = true;
            this.RandomEveryLossChecked.Location = new System.Drawing.Point(152, 27);
            this.RandomEveryLossChecked.Name = "RandomEveryLossChecked";
            this.RandomEveryLossChecked.Size = new System.Drawing.Size(92, 20);
            this.RandomEveryLossChecked.TabIndex = 2;
            this.RandomEveryLossChecked.Text = "Every loss";
            this.RandomEveryLossChecked.UseVisualStyleBackColor = true;
            // 
            // RandomEveryWinChecked
            // 
            this.RandomEveryWinChecked.AutoSize = true;
            this.RandomEveryWinChecked.Location = new System.Drawing.Point(10, 53);
            this.RandomEveryWinChecked.Name = "RandomEveryWinChecked";
            this.RandomEveryWinChecked.Size = new System.Drawing.Size(86, 20);
            this.RandomEveryWinChecked.TabIndex = 1;
            this.RandomEveryWinChecked.Text = "Every win";
            this.RandomEveryWinChecked.UseVisualStyleBackColor = true;
            // 
            // RandomEveryGameChecked
            // 
            this.RandomEveryGameChecked.AutoSize = true;
            this.RandomEveryGameChecked.Location = new System.Drawing.Point(10, 27);
            this.RandomEveryGameChecked.Name = "RandomEveryGameChecked";
            this.RandomEveryGameChecked.Size = new System.Drawing.Size(102, 20);
            this.RandomEveryGameChecked.TabIndex = 0;
            this.RandomEveryGameChecked.Text = "Every game";
            this.RandomEveryGameChecked.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(265, 29);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 29);
            this.button3.TabIndex = 36;
            this.button3.Text = "Login";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // SiteConfig
            // 
            this.SiteConfig.Location = new System.Drawing.Point(376, 31);
            this.SiteConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SiteConfig.Name = "SiteConfig";
            this.SiteConfig.Size = new System.Drawing.Size(183, 22);
            this.SiteConfig.TabIndex = 43;
            this.SiteConfig.Text = "stake.com";
            // 
            // stratDisplay
            // 
            this.stratDisplay.GridBorder = false;
            this.stratDisplay.Location = new System.Drawing.Point(24, 24);
            this.stratDisplay.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.stratDisplay.Name = "stratDisplay";
            this.stratDisplay.Size = new System.Drawing.Size(121, 121);
            this.stratDisplay.SquareBorder = true;
            this.stratDisplay.TabIndex = 18;
            this.stratDisplay.Text = "satoshiGrid1";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 541);
            this.Controls.Add(this.SiteConfig);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.metaChecked);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.SiteLabel);
            this.Controls.Add(this.cfgTag);
            this.Controls.Add(this.useStratCheck);
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
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numberofBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betCostNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precentOnLoss)).EndInit();
            this.groupBox2.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.ResetBaseWinCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercentOnWinResetGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precentOnWin)).EndInit();
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
        private Button button3;
        private CheckBox checkInstant;
        private TextBox SiteConfig;
    }
}
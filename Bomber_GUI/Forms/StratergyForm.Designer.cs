namespace Bomber_GUI.Forms
{
    partial class StratergyForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.stratSelector = new stratGrid();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stratSelector
            // 
            this.stratSelector.Location = new System.Drawing.Point(2, 1);
            this.stratSelector.Name = "stratSelector";
            this.stratSelector.Size = new System.Drawing.Size(232, 232);
            this.stratSelector.squareData = new int[] {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0};
            this.stratSelector.SquareSpacing = 6;
            this.stratSelector.TabIndex = 2;
            this.stratSelector.Text = "stratGrid1";
            this.stratSelector.Click += new System.EventHandler(this.stratSelector_Click);
            // 
            // StratergyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 265);
            this.Controls.Add(this.stratSelector);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StratergyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Strategy";
            this.Load += new System.EventHandler(this.StratergyForm_Load);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button button1;
        private stratGrid stratSelector;
    }
}
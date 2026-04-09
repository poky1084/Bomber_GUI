using Bomber_GUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bomber_GUI
{
    public partial class Form1 : Form
    {
        private List<gamePanel> currentPanels = new List<gamePanel>();
        private gamePanel _initGamepanel;
        private int toolstripOffset = 25;
        int tbOffset = 33;
        bool DontExtend = false;
        private int horIndex = 1;
        private int vertIndex = 0;

        public Form1()
        {
            InitializeComponent();
            _initGamepanel = new gamePanel(true);
            _initGamepanel.Parent = this;
            _initGamepanel.Location = new Point(0, toolstripOffset);
            _initGamepanel.OnHistoryToggle += ngp_OnHistoryToggle;
            _initGamepanel.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = _initGamepanel.Height + tbOffset + toolstripOffset;
            this.Width = _initGamepanel.Width + 10;
            this.Text += " - " + Application.ProductVersion;

            using (SettingsForm sf = new SettingsForm(Global.DefaultGameSettings, true))
            {
                _initGamepanel.CheckBalance(Properties.Settings.Default.SiteConfig, Properties.Settings.Default.PlayerHash, Properties.Settings.Default.ConfigTag);
            }
        }

        void AddGamePanel(gamePanel ngp)
        {
            currentPanels.Add(ngp);
            ngp.OnRemove += ngp_OnRemove;
            ngp.OnHistoryToggle += ngp_OnHistoryToggle;
            ngp.Parent = this;
            if (horIndex != 2) // This number is how many game panels wide it will be. Default is 2
            {
                if (!DontExtend)
                    this.Width = (_initGamepanel.Width * (horIndex + 1)) + 10;
                ngp.Location = new Point(ngp.Width * horIndex,
                    (vertIndex * ngp.Height) + toolstripOffset);
                ngp.Show();
            }
            else
            {
                DontExtend = true;
                horIndex = 0;
                vertIndex++;
                this.Height = (_initGamepanel.Height * (vertIndex + 1)) + tbOffset + toolstripOffset;
                ngp.Location = new Point(ngp.Width * horIndex,
                    (vertIndex * ngp.Height) + toolstripOffset);
            }
            horIndex++;
            ngp.Show();
        }

        void ngp_OnRemove(gamePanel sender)
        {
            currentPanels.Remove(sender);
            sender.StopRunning();
            sender.Dispose();
            vertIndex = 0;
            horIndex = 1;
            foreach (gamePanel panel in currentPanels)
            {
                if (horIndex != 2) // This number is how many game panels wide it will be. Default is 2
                {
                    panel.Location = new Point(panel.Width * horIndex,
                        (vertIndex * panel.Height) + toolstripOffset);
                    panel.Show();
                }
                else
                {
                    horIndex = 0;
                    vertIndex++;
                    panel.Location = new Point(panel.Width * horIndex,
                        (vertIndex * panel.Height) + toolstripOffset);
                }
                horIndex++;
            }
            this.Height = (_initGamepanel.Height * (vertIndex + 1)) + tbOffset + toolstripOffset;
            if (currentPanels.Count == 0)
            {
                this.Width = _initGamepanel.Width + 10;
                DontExtend = false;
            }
        }

        /// <summary>
        /// Called whenever a gamePanel's bet history panel is opened or closed.
        /// Re-lays out all panels so the Form resizes to fit.
        /// </summary>
        void ngp_OnHistoryToggle(gamePanel sender, bool visible)
        {
            RefreshLayout();
        }

        /// <summary>
        /// Re-positions all panels (init + additional) in a 2-column grid,
        /// taking each panel's current Height into account (handles history expand/collapse).
        /// </summary>
        void RefreshLayout()
        {
            // Build ordered list: init panel is always index 0
            var allPanels = new List<gamePanel> { _initGamepanel };
            allPanels.AddRange(currentPanels);

            int panelCount = allPanels.Count;
            int maxRows = (int)Math.Ceiling(panelCount / 2.0);
            int[] rowMaxH = new int[maxRows];

            // First pass: compute max height per row
            for (int i = 0; i < panelCount; i++)
            {
                int row = i / 2;
                if (allPanels[i].Height > rowMaxH[row])
                    rowMaxH[row] = allPanels[i].Height;
            }

            // Second pass: position each panel
            for (int i = 0; i < panelCount; i++)
            {
                int row = i / 2;
                int col = i % 2;

                int yOffset = toolstripOffset;
                for (int r = 0; r < row; r++)
                    yOffset += rowMaxH[r];

                allPanels[i].Location = new Point(allPanels[i].Width * col, yOffset);
            }

            // Resize the form to fit all rows
            int totalContentH = rowMaxH.Sum();
            this.Height = totalContentH + tbOffset + toolstripOffset;
            this.Width = (panelCount >= 2 ? _initGamepanel.Width * 2 : _initGamepanel.Width) + 10;

            // Sync internal tracking indices
            int lastCol = (panelCount - 1) % 2;
            int lastRow = (panelCount - 1) / 2;
            horIndex = lastCol + 1;
            vertIndex = lastRow;
            DontExtend = (panelCount >= 2);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            AddGamePanel(new gamePanel());
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            using (SettingsForm sf = new SettingsForm(Global.DefaultGameSettings, true))
            {
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    sf.SaveSettings();
                    _initGamepanel.GameConfig = sf.GameConfig;
                    _initGamepanel.CheckBalance(Properties.Settings.Default.SiteConfig, Properties.Settings.Default.PlayerHash, Properties.Settings.Default.ConfigTag);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomber_GUI.Forms
{
    public partial class StratergyForm : Form
    {
        public int[] StratergyArray { get; private set; }
        public StratergyForm()
        {
            InitializeComponent();

        }

        private void StratergyForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> selectedSquares = new List<int>();
            for (int i = 0; i < stratSelector.squareData.Length; i++)
            {
                if (stratSelector.squareData[i] == 1)
                    selectedSquares.Add(i);
            }
            StratergyArray = selectedSquares.ToArray();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void stratSelector_Click(object sender, EventArgs e)
        {

        }
    }
}

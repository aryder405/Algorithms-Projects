using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reference_Web_Project
{
    /// <summary>
    /// Gets a number input from user that will be used
    /// to show the top X candidates in the graph, scored
    /// by total weights of references.
    /// </summary>
    public partial class Form1 : Form
    {
        public int num { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(comboBox1.Text);
            if (x > 0)
            {
                num = x;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

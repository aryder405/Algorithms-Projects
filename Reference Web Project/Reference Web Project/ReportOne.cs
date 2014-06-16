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
    public partial class ReportOne : Form
    {
        public String name { get; set; }
        public ReportOne()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                name = textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
    }
}

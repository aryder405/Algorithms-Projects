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
    public partial class RemoveRef : Form
    {
        public String name1 { get; private set; }
        public String name2 { get; private set; }

        public RemoveRef()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name1 = fromName.Text;
            name2 = toName.Text;
            if (name1 != null && name2 != null)
            {
               
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill out all forms");
            }
        }
    }
}

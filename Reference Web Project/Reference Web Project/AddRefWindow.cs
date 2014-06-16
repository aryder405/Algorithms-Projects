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
    public partial class AddRefWindow : Form
    {
        public String name1 { get; private set; }
        public String name2 { get; private set; }
        public int refWeight { get; private set; }

        public AddRefWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            name1 = fromName.Text;
            name2 = toName.Text;
            String s = weight.Text.ToLower();
            switch (s)
            {
                case "highly recommended":
                    refWeight = 3;
                    break;
                case "recommended":
                    refWeight = 1;
                    break;
                case "not recommended":
                    refWeight = -3;
                    break;  
            }
            if(name1 != "" && name2 != "" && refWeight != 0){
                this.DialogResult = DialogResult.OK;
                this.Close();
            }else{
                MessageBox.Show("Please fill out all forms");
            }
        }
    }
}

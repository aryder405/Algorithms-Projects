namespace Reference_Web_Project
{
    partial class MainWindow
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.webTable = new System.Windows.Forms.DataGridView();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.Person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference_Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webTable)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Input File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Add Reference";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Remove Reference";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Show Web";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(543, 349);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Save Web";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(14, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Change Reference";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // webTable
            // 
            this.webTable.AllowUserToAddRows = false;
            this.webTable.AllowUserToDeleteRows = false;
            this.webTable.AllowUserToOrderColumns = true;
            this.webTable.AllowUserToResizeRows = false;
            this.webTable.BackgroundColor = System.Drawing.Color.White;
            this.webTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.webTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.webTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Person,
            this.Reference,
            this.Reference_Weight});
            this.webTable.GridColor = System.Drawing.Color.Aqua;
            this.webTable.Location = new System.Drawing.Point(190, 12);
            this.webTable.Name = "webTable";
            this.webTable.ReadOnly = true;
            this.webTable.Size = new System.Drawing.Size(347, 320);
            this.webTable.TabIndex = 11;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(543, 320);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(159, 23);
            this.button7.TabIndex = 13;
            this.button7.Text = "Save as Report";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(543, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(159, 23);
            this.button8.TabIndex = 14;
            this.button8.Text = "Report on one person";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(543, 99);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(159, 23);
            this.button9.TabIndex = 16;
            this.button9.Text = "All Highly Recommended";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(543, 41);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(159, 23);
            this.button10.TabIndex = 17;
            this.button10.Text = "Written about";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(543, 128);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(159, 23);
            this.button11.TabIndex = 18;
            this.button11.Text = "Statistics";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(14, 99);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(158, 23);
            this.button12.TabIndex = 21;
            this.button12.Text = "Remove Person";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(543, 70);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(159, 23);
            this.button13.TabIndex = 23;
            this.button13.Text = "Written By";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // Person
            // 
            this.Person.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Person.HeaderText = "Person";
            this.Person.Name = "Person";
            this.Person.ReadOnly = true;
            this.Person.Width = 65;
            // 
            // Reference
            // 
            this.Reference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference.HeaderText = "Reference Written By";
            this.Reference.Name = "Reference";
            this.Reference.ReadOnly = true;
            // 
            // Reference_Weight
            // 
            this.Reference_Weight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference_Weight.HeaderText = "Reference Weight";
            this.Reference_Weight.Name = "Reference_Weight";
            this.Reference_Weight.ReadOnly = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(543, 157);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(159, 23);
            this.button14.TabIndex = 24;
            this.button14.Text = "Top X Candidates";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(14, 41);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(158, 23);
            this.button15.TabIndex = 25;
            this.button15.Text = "Add a Person";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Reference_Web_Project.Properties.Resources.webImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(714, 384);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.webTable);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.IsMdiContainer = true;
            this.Name = "MainWindow";
            this.Text = "Main Menu";
            ((System.ComponentModel.ISupportInitialize)(this.webTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView webTable;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Person;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference_Weight;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
    }
}


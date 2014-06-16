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
    public partial class MainWindow : Form
    {
        String filename { get; set; }
        AListGraph graph;
        AddRefWindow addref = new AddRefWindow();
        RemoveRef remref = new RemoveRef();
        changeRef changRef = new changeRef();
        ReportOne report = new ReportOne();
        Form1 topCand = new Form1();
        bool ready = false;
        public MainWindow()
        {
            InitializeComponent();
            //addref.MdiParent = this;
        }
        //Input file
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                graph = new AListGraph(filename);
                ready = true;
            }          
        }
        //Print List
        private void button2_Click(object sender, EventArgs e)
        {
            if(ready){
            webTable.Rows.Clear();            
            List<String> webData = graph.getWebData();
            foreach (String s in webData)
            {
                String[] row = s.Split(',');
                webTable.Rows.Add(row[0], row[1], row[2]);
            }
            }
        }

        //Add reference
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (ready && addref.ShowDialog() == DialogResult.OK)
            {
                String n1 = addref.name1;
                String n2 = addref.name2;
                if (n1 != n2)
                    graph.addEdge(n2, n1, addref.refWeight);
                else
                    MessageBox.Show("Cannot add reference to self");
            }
        }
        //remove reference
        private void button4_Click(object sender, EventArgs e)
        {
            if (ready && remref.ShowDialog() == DialogResult.OK)
            {
                if (!graph.removeEdge(remref.name1, remref.name2))
                    MessageBox.Show("Unable to remove that reference");
            }
        }
        //save graph
        private void button5_Click(object sender, EventArgs e)
        {
            if (ready)
            {
                graph.saveGraph();
                MessageBox.Show("Web saved to " + graph.filename);
            }
        }
        //change reference
        private void button6_Click(object sender, EventArgs e)
        {
            if (ready && changRef.ShowDialog() == DialogResult.OK)
            {
                if (!graph.changeRef(changRef.name1, changRef.name2, changRef.refWeight))
                {
                    MessageBox.Show("Unable to change reference, please make sure persons exist");
                }
            }
        }
        //Save to reports
        private void button7_Click(object sender, EventArgs e)
        {
            if (ready)
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;
                    graph.saveToFile(filename);
                }
            }
        }
        //Report on one person
        private void button8_Click(object sender, EventArgs e)
        {
            if (ready && report.ShowDialog() == DialogResult.OK)
            {
                String person = report.name;
                webTable.Rows.Clear();
                List<String> webData = graph.reportOnOnePerson(person);
                foreach (String s in webData)
                {
                    String[] row = s.Split(',');
                    webTable.Rows.Add(row[0], row[1], row[2]);
                }
            }     
        }

        //All highly recommended persons
        private void button9_Click(object sender, EventArgs e)
        {
            if (ready)
            {
                webTable.Rows.Clear();
                List<String> webData = graph.getWebData();
                foreach (String s in webData)
                {
                    String[] row = s.Split(',');
                    String rec = row[2];
                    if (rec.Equals("highly recommend"))
                    {
                        webTable.Rows.Add(row[0], row[1], row[2]);
                    }
                }
            }
        }
        //Written about
        private void button10_Click(object sender, EventArgs e)
        {
            if (ready && report.ShowDialog() == DialogResult.OK)
            {
                String person = report.name;
                webTable.Rows.Clear();
                List<String> webData = graph.getReferencesAbout(person);
                foreach (String s in webData)
                {
                    String[] row = s.Split(',');
                    webTable.Rows.Add("", row[0], row[1]);
                }
            }     
        }
        //Statistics- Total number of persons, references
        private void button11_Click(object sender, EventArgs e)
        {
            if (ready)
            {
                int totalPersons = graph.getAllNames().Count;
                List<int> l = graph.getAllWeights();

                MessageBox.Show("Total number of persons: " + totalPersons + "\nTotal references: " +
                    graph.countEdges() + "\nHighly Recommended: " + l[2] +
                    "\nRecommended: " + l[1] + "\nNot Recommended: " + l[0]);
            }
        }
        //remove person
        private void button12_Click(object sender, EventArgs e)
        {
            if (ready && report.ShowDialog() == DialogResult.OK)
            {
                String name = report.name;
                graph.removePerson(name);
            }
        }
        //written by
        private void button13_Click(object sender, EventArgs e)
        {
            if (ready && report.ShowDialog() == DialogResult.OK)
            {
                String person = report.name;
                webTable.Rows.Clear();
                List<String> webData = graph.getReferencesBy(person);
                foreach (String s in webData)
                {
                    String[] row = s.Split(',');
                    webTable.Rows.Add(row[0], row[1], row[2]);
                }
            }     
        }
        //top x candidates
        private void button14_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (ready && topCand.ShowDialog() == DialogResult.OK)
            {
                x = topCand.num;
                List<String> candidates = graph.getTopCandidates(x);
                String temp = "";
                foreach (String s in candidates)
                {
                    String[] t = s.Split(',');
                    temp += "Name: " + t[0] + " Score: " + t[1] + "\n";
                }
                MessageBox.Show(temp);
            }
        }

        //add one person, no references
        private void button15_Click(object sender, EventArgs e)
        {
            if (ready && report.ShowDialog() == DialogResult.OK)
            {
                String name = report.name;
                graph.addPerson(name);
            }
        }
    }
}

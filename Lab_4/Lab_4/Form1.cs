using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        Stopwatch cl = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cl.Reset();
            OpenFileDialog win1 = new OpenFileDialog();
            win1.InitialDirectory = "\\Mac/Home/Documents/Course_2\bkIT/Lab_4";
            win1.Filter = "txt files (*.txt)|*.txt";//|All files (*.*)|*.*";
            win1.FilterIndex = 2;
            win1.RestoreDirectory = true;
            if (win1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cl.Start();
                    string buf = File.ReadAllText(win1.FileName);
                    List<string> a = new List<string>();
                    string[] buf2 = buf.Split();
                    foreach (string l in buf2)
                    {
                        if (!a.Contains(l))
                            a.Add(l);
                    }
                    a.Sort();
                    cl.Stop();
                    label1.Text = "Opening file, reading and sorting array(ms): "+cl.ElapsedMilliseconds.ToString();
                    addToListBox(a);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR! Couldn't read file from disk!\n Original error: " + ex.Message);
                }
            }
        }
        void addToListBox(List<string> a)
        {

            listBox1.BeginUpdate();
            foreach (string l in a)
            {
                listBox1.Items.Add(l);
            }
            listBox1.EndUpdate();
         }
        private void findb_Click(object sender, EventArgs e)
        {
            cl.Reset();
            cl.Start();
            listBox1.SelectedIndex = listBox1.FindStringExact(textBox1.Text);
            cl.Stop();
            label2.Text = "Searching in ListBox(ms): " + cl.ElapsedMilliseconds.ToString();
        }
    }
}

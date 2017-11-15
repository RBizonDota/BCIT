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

namespace Lab_5
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
                    label1.Text = "Opening file, reading and sorting array(ms): " + cl.ElapsedMilliseconds.ToString();
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
            LevFormlist(textBox1.Text);
        }
        public static int LevDist(string string1, string string2)
        {
            if (string1 == null) throw new ArgumentNullException("string1");
            if (string2 == null) throw new ArgumentNullException("string2");
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1,
                                                m[i, j - 1] + 1),
                                                m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        }
        void LevFormlist(string s)
        {
            cl.Reset();
            int p = 0;
            bool f = int.TryParse(textBox2.Text, out p);
            if (!f || p < 0)
            {
                throw new ArgumentException("Invalid Levenshtain parametr!");
            }
            listBox2.BeginUpdate();
            listBox2.Items.Clear();
            cl.Start();
            foreach (string l in listBox1.Items)
            {
                if (LevDist(s, l) <= p)
                    listBox2.Items.Add(l);
            }
            cl.Stop();
            listBox2.EndUpdate();
            label5.Text = " Making Levenshtein Distanse list(ms): " + cl.ElapsedMilliseconds;
        }
    }
}

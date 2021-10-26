using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleSQLApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            string[] countries = { "Бразилия", "Аргентина", "Чили", "Уругвай", "Колумбия" };
            listBox1.Items.AddRange(countries);
            listBox2.Items.AddRange(countries);

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
        }

        private void exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        Point lastPoint;
        
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sCountry_firstlist = listBox1.SelectedItem.ToString();
            //MessageBox.Show(selectedCountry);
        }
        void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sCountry_secondlist = listBox1.SelectedItem.ToString();
            //MessageBox.Show(selectedCountry);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}

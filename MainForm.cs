using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ExampleSQLApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Fill_lisbox();

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
        }

        private void Fill_lisbox()
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=project_program"))
            {
                connection.Open();

                if (!connection.Ping())
                {
                    MessageBox.Show("Немає підключення до бази даних!");
                    return;
                }

                MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` ", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[1]);
                    listBox2.Items.Add(reader[2]);
                    listBox3.Items.Add(reader[3]);
                }
                connection.Close();
            }
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
            if (listBox2.SelectedItem != null)
            {
                string sCountry_firstlist = listBox1.SelectedItem.ToString();
                text_from.Text = sCountry_firstlist;

                using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=project_program"))
                {
                    connection.Open();

                    if (!connection.Ping())
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `city_from` = '" + listBox1.SelectedItem.ToString() + "'", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[2]);
                        listBox3.Items.Add(reader[3]);
                    }
                    connection.Close();
                }
            }

        }
        void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox2.SelectedItem != null)
            {
                string sCountry_secondlist = listBox2.SelectedItem.ToString();
                text_to.Text = sCountry_secondlist;

                using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=project_program"))
                {
                    connection.Open();

                    if (!connection.Ping())
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `city_to` = '" + listBox2.SelectedItem.ToString() + "'", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox3.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox3.Items.Add(reader[3]);
                    }
                    connection.Close();
                }
            }

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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                string date_selected = listBox3.SelectedItem.ToString();
                textBox_date.Text = date_selected;

                using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=project_program"))
                {
                    connection.Open();

                    if (!connection.Ping())
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `date` = '" + listBox3.SelectedItem.ToString() + "'", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox3.Items.Add(reader[2]);
                    }
                    connection.Close();
                }
            }
        }

        private void textBox1_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            listBox1.SelectedItem = null;
            listBox2.SelectedItem = null;
            listBox3.SelectedItem = null;
            Fill_lisbox();
        }
    }
}

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
           listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
           listBox2.Enabled = false; 
           listBox3.Enabled = false;
        }

        private void Fill_lisbox()
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=busbooking"))
            {
                connection.Open();

                if (!connection.Ping())
                {
                    MessageBox.Show("Немає підключення до бази даних!");
                    return;
                }

                MySqlCommand command = new MySqlCommand("SELECT * FROM `buses`;", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!listBox1.Items.Contains(reader[0]))
                    {
                        listBox1.Items.Add(reader[0]);
                    }
                    if (!listBox2.Items.Contains(reader[1]))
                    {
                        listBox2.Items.Add(reader[1]);
                    }
                    if (!listBox3.Items.Contains(reader[2]))
                    {
                        listBox3.Items.Add(reader[2]);
                    }
                }

                connection.Close();
            }
        }
        private void exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
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
            if (listBox1.SelectedItem != null)
            {
                string sCountry_firstlist = listBox1.SelectedItem.ToString();
                text_from.Text = sCountry_firstlist;

                using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=busbooking"))
                {
                    connection.Open();

                    if (!connection.Ping())
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `buses` WHERE `city_from` = '" + listBox1.SelectedItem.ToString() + "'", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[1]);
                        listBox3.Items.Add(reader[2]);
                    }

                    listBox2.Enabled = true;
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

                using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=busbooking"))
                {
                    connection.Open();

                    if (!connection.Ping())
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `buses` WHERE `city_to` = '" + listBox2.SelectedItem.ToString() + "'", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox3.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0]);
                        listBox3.Items.Add(reader[2]);
                    }

                    listBox3.Enabled = true;
                    connection.Close();
                }
            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                string date_selected = listBox3.SelectedItem.ToString();
                textBox_date.Text = date_selected;

                using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=busbooking"))
                {
                    connection.Open();

                    if (!connection.Ping())
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `buses` WHERE `date` = '" + listBox3.SelectedItem.ToString() + "'", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox3.Items.Add(reader[2]);
                    }
                    connection.Close();
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=busbooking"))
            {
                connection.Open();
                text_from.Clear();
                text_to.Clear();
                textBox_date.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `buses`;", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0]);
                    listBox2.Items.Add(reader[1]);
                    listBox3.Items.Add(reader[2]);
                }

                listBox2.Enabled = false; 
                listBox3.Enabled = false;
                connection.Close();
            }
        }

        private void book_button_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=busbooking"))
            {
                connection.Open();

                if (!connection.Ping())
                {
                    MessageBox.Show("Немає підключення до бази даних!");
                    return;
                }

                
                MySqlCommand command = new MySqlCommand("INSERT INTO `book`(`city_from`, `city_to`, `date`) VALUES(@city_from, @city_to, @date)", connection);


                command.Parameters.Add("@city_from", MySqlDbType.VarChar).Value = text_from.Text;
                command.Parameters.Add("@city_to", MySqlDbType.VarChar).Value = text_to.Text;
                command.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Parse(textBox_date.Text);
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = ;


                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Рейс було успішно заброньовано!");
                    this.Hide();
                    MainForm mainform = new MainForm();
                    mainform.Show();
                }
                else
                {
                    MessageBox.Show("Помилка у бронюванні");
                }

            }
        }
    }
}

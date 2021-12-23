using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Booking
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Fill_lisbox();

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            listBox5.SelectedIndexChanged += listBox5_SelectedIndexChanged;
            dateTimePicker1.MinDate = DateTime.Today;
        }

        private void Fill_lisbox()
        {
            try
            {
                DB DB = new DB();
                DB.OpenConnection();
                

                if (DB.GetConnection() == null)
                {
                    MessageBox.Show("Немає підключення до бази даних!");
                    this.Close();
                    return;
                }
                MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` ", DB.GetConnection());
                
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[1]);
                    listBox2.Items.Add(reader[2]);
                    listBox5.Items.Add(reader[4]);
                }
                dateTimePicker1.CustomFormat = "ddMMMMyyyy dddd";
                DB.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Помилка!");
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

                try
                {
                    DB DB = new DB();
                    DB.OpenConnection();

                    if (DB.GetConnection() == null)
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        this.Close();
                        return;
                    }

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `city_from` = '" + listBox1.SelectedItem.ToString() + "'", DB.GetConnection());
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox2.Items.Clear();
                    listBox5.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[2]);
                        listBox5.Items.Add(reader[4]);
                    }
                    DB.CloseConnection();
                }
                catch
                {
                    MessageBox.Show("Помилка!");
                }
            }

        }
        void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox2.SelectedItem != null)
            {
                string sCountry_secondlist = listBox2.SelectedItem.ToString();
                text_to.Text = sCountry_secondlist;

                try
                {
                    DB DB = new DB();
                    DB.OpenConnection();

                    if (DB.GetConnection() == null)
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `city_to` = '" + listBox2.SelectedItem.ToString() + "'", DB.GetConnection());
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox5.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox5.Items.Add(reader[4]);
                    }
                    DB.CloseConnection();
                }
                catch 
                {
                    MessageBox.Show("Помилка!");
                }
            }

        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox5.SelectedItem != null)
            {
                string _class = listBox5.SelectedItem.ToString();
                textBox_class.Text = _class;

                try
                {
                    DB DB = new DB();
                    DB.OpenConnection();

                    if (DB.GetConnection() == null)
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `class` = '" + listBox5.SelectedItem.ToString() + "'", DB.GetConnection());
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox2.Items.Add(reader[2]);
                    }
                    DB.CloseConnection();
                }
                catch
                {
                    MessageBox.Show("Помилка!");
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            listBox1.SelectedItem = null;
            listBox2.SelectedItem = null;
            listBox5.SelectedItem = null;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox5.Items.Clear();
            text_from.Clear();
            text_to.Clear();
            textBox_date_depart.Clear();
            textBox_class.Clear();
            Fill_lisbox();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            textBox_date_depart.Text = dateTimePicker1.Value.ToString();
            if (dateTimePicker1.Value != null)
            {
                DateTime date = dateTimePicker1.Value;
                try
                {
                    DB DB = new DB();
                    DB.OpenConnection();
                    if(date.Year > 2022)
                        throw new Exception("Не можна більше 2022 року!");

                    if (DB.GetConnection() == null)
                        throw new Exception("Немає підключення до бази даних!");
                    short twice = 0;
                    if (date.Day % 2 == 0)
                        twice = 1;
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `periodicity` = '" + twice + "'", DB.GetConnection());
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox5.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox2.Items.Add(reader[2]);
                        listBox5.Items.Add(reader[4]);
                    }
                    if((text_from.Text != "")&&(text_to.Text != "")&&(textBox_date_depart.Text != "")&&(textBox_class.Text != ""))
                    {
                        MySqlCommand command1 = new MySqlCommand("SELECT `cost` FROM `trains` WHERE `periodicity` = '" + twice + "' AND `class` = '" + textBox_class.Text + "' AND `city_to` = '" + text_from.Text + "' AND `city_from` = '" + text_to.Text +"'", DB.GetConnection());
                        MySqlDataReader reader1 = command1.ExecuteReader();
                        if(reader1.Read())
                        {
                            textBox_cost.Text = reader1[0].ToString();
                        }
                    }
                    DB.CloseConnection();
                }
                catch (Exception x)
                {
                    MessageBox.Show($"Помилка: {x.Message}");
                }
            }
        }
    }
}

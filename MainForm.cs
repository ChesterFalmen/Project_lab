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
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            listBox4.SelectedIndexChanged += listBox4_SelectedIndexChanged;
            listBox5.SelectedIndexChanged += listBox5_SelectedIndexChanged;
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
                    listBox3.Items.Add(reader[3]);
                    listBox4.Items.Add(reader[4]);
                    listBox5.Items.Add(reader[5]);
                }
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
                    listBox3.Items.Clear();
                    listBox5.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[2]);
                        listBox3.Items.Add(reader[3]);
                        listBox5.Items.Add(reader[5]);
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
                    listBox3.Items.Clear();
                    listBox5.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox3.Items.Add(reader[3]);
                        listBox5.Items.Add(reader[5]);
                    }
                    DB.CloseConnection();
                }
                catch 
                {
                    MessageBox.Show("Помилка!");
                }
            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                string date_selected = listBox3.SelectedItem.ToString();
                textBox_date_depart.Text = date_selected;

                try
                {
                    DB DB = new DB();
                    DB.OpenConnection();

                    if (DB.GetConnection() == null)
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }
                    //string selected = listBox3.SelectedItem.ToString();
                    //selected = selected.Replace('.', '-');
                    //Convert.ToDateTime(selected);
                    //SELECT DATE_FORMAT("2008-11-19",'%d.%m.%Y');
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `date_depart` = '" + listBox3.SelectedItem.ToString() + "'", DB.GetConnection());
                    //SELECT* from trains WHERE `date_depart` = '2021-10-01 10:20:00';
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox4.Items.Clear();
                    listBox5.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox2.Items.Add(reader[2]);
                        listBox4.Items.Add(reader[4]);
                        listBox5.Items.Add(reader[5]);
                    }
                    DB.CloseConnection();
                }
                catch
                {
                    MessageBox.Show("Помилка!");
                }
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem != null)
            {
                string date_selected = listBox4.SelectedItem.ToString();
                textBox_date_arrival.Text = date_selected;

                try
                {
                    DB DB = new DB();
                    DB.OpenConnection();

                    if (DB.GetConnection() == null)
                    {
                        MessageBox.Show("Немає підключення до бази даних!");
                        return;
                    }
                    //string selected = listBox3.SelectedItem.ToString();
                    //selected = selected.Replace('.', '-');
                    //Convert.ToDateTime(selected);
                    //SELECT DATE_FORMAT("2008-11-19",'%d.%m.%Y');
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `date_arrival` = '" + listBox4.SelectedItem.ToString() + "'", DB.GetConnection());
                    //SELECT* from trains WHERE `date_depart` = '2021-10-01 10:20:00';
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox5.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox2.Items.Add(reader[2]);
                        listBox3.Items.Add(reader[3]);
                        listBox5.Items.Add(reader[5]);
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
                    //string selected = listBox3.SelectedItem.ToString();
                    //selected = selected.Replace('.', '-');
                    //Convert.ToDateTime(selected);
                    //SELECT DATE_FORMAT("2008-11-19",'%d.%m.%Y');
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `class` = '" + listBox5.SelectedItem.ToString() + "'", DB.GetConnection());
                    //SELECT* from trains WHERE `date_depart` = '2021-10-01 10:20:00';
                    MySqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox4.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[1]);
                        listBox2.Items.Add(reader[2]);
                        listBox3.Items.Add(reader[3]);
                        listBox4.Items.Add(reader[4]);
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
            listBox3.SelectedItem = null;
            listBox4.SelectedItem = null;
            listBox5.SelectedItem = null;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            text_from.Clear();
            text_to.Clear();
            textBox_date_depart.Clear();
            textBox_date_arrival.Clear();
            textBox_class.Clear();
            Fill_lisbox();
        }
    }
}

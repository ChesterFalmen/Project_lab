using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Booking
{
    public partial class MainForm : Form
    {
        Train trains = new Train();
        public MainForm()
        {
            InitializeComponent();
            Fill_listbox();

            listBox_from.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox_to.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            listBox_class.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void Fill_listbox()
        {
            try
            {
                trains.Fill();
                for (int i = 0; i < trains.list_trains.Count; i++)
                {
                    if(!(listBox_from.Items.Contains(trains.list_trains[i].GetFrom())))
                        listBox_from.Items.Add(trains.list_trains[i].GetFrom());
                }
                listBox_from.Enabled = true;
                listBox_to.Enabled = true;
                listBox_class.Enabled = true;
            }
            catch (Exception x)
            {
                MessageBox.Show($"Помилка: {x.Message}");
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
            if (listBox_from.SelectedItem != null)
            {
                try
                {
                    textBox_from.Text = listBox_from.SelectedItem.ToString();
                    listBox_to.Items.Clear();
                    for (int i = 0; i < trains.list_trains.Count; i++)
                    {
                        if (trains.list_trains[i].GetFrom() == listBox_from.Text)
                        {
                            if (!(listBox_to.Items.Contains(trains.list_trains[i].GetTo())))
                                listBox_to.Items.Add(trains.list_trains[i].GetTo());
                        }
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show($"Помилка: {x.Message}");
                }
            }

        }
        void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_to.SelectedItem != null)
            {
                try
                {
                    textBox_to.Text = listBox_to.SelectedItem.ToString();
                    listBox_class.Items.Clear();
                    listBox_from.Enabled = false;
                    for (int i = 0; i < 3; i++)
                    {
                        listBox_class.Items.Add(i+1);
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show($"Помилка: {x.Message}");
                }
            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_class.SelectedItem != null)
            {
                try
                {
                    List<DateTime> dates = new List<DateTime>();

                    textBox_class.Text = listBox_class.SelectedItem.ToString();
                    listBox_to.Enabled = false;

                    dates = trains.FillDate(listBox_from.Text, listBox_to.Text);

                    for (int i = 0; i < dates.Count; i++)
                    {
                        comboBox1.Items.Add(dates[i].ToString("dd.MM.yyyy"));
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show($"Помилка: {x.Message}");
                }
            }
        }
        private void clear_btn_Click(object sender, EventArgs e)
        {
            listBox_from.SelectedItem = null;
            listBox_to.SelectedItem = null;
            listBox_class.SelectedItem = null;
            listBox_from.Items.Clear();
            listBox_to.Items.Clear();
            listBox_class.Items.Clear();
            textBox_from.Clear();
            textBox_to.Clear();
            textBox_date_depart.Clear();
            textBox_class.Clear();
            textBox_name.Clear();
            Fill_listbox();
        }
        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{
        //    //dateTimePicker.Format = DateTimePickerFormat.Custom;
        //    textBox_date_depart.Text = dateTimePicker.Value.ToString();
        //    if (dateTimePicker.Value != null)
        //    {
        //        DateTime date = dateTimePicker.Value;

        //        try
        //        {
        //            DB DB = new DB();
        //            DB.OpenConnection();
        //            if (date.Year > 2022)
        //                throw new Exception("Не можна більше 2022 року!");

        //            if (DB.GetConnection() == null)
        //                throw new Exception("Немає підключення до бази даних!");
        //            short twice = 0;
        //            if (date.Day % 2 == 0)
        //                twice = 1;
        //            //1 - parni, 2 ne parni, 0 - everday
        //            //добавить параметри command sql (з логіна)
        //            MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `periodicity` = '" + twice + "'", DB.GetConnection());
        //            MySqlDataReader reader = command.ExecuteReader();
        //            listBox_from.Items.Clear();
        //            listBox_to.Items.Clear();
        //            listBox_class.Items.Clear();
        //            textBox_cost.Clear();
        //            while (reader.Read())
        //            {
        //                listBox_from.Items.Add(reader[1]);
        //                listBox_to.Items.Add(reader[2]);
        //                listBox_class.Items.Add(reader[4]);
        //            }
        //            DB.CloseConnection();
        //            DB.OpenConnection();
        //            if (DB.GetConnection() == null)
        //                throw new Exception("Немає підключення до бази даних!");
        //            if ((textBox_from.Text != "") && (textBox_to.Text != "") && (textBox_date_depart.Text != "") && (textBox_class.Text != ""))
        //            {
        //                MySqlCommand command1 = new MySqlCommand("SELECT `cost` FROM `trains` WHERE `periodicity` = '" + twice + "' AND `class` = '" + textBox_class.Text + "' AND `city_to` = '" + textBox_to.Text + "' AND `city_from` = '" + textBox_from.Text + "'", DB.GetConnection());
        //                MySqlDataReader reader1 = command1.ExecuteReader();
        //                if (reader1.Read())
        //                {
        //                    textBox_cost.Text = reader1[0].ToString();
        //                }
        //                else
        //                {
        //                    textBox_cost.Clear();
        //                }
        //            }
        //        }
        //        catch (Exception x)
        //        {
        //            MessageBox.Show($"Помилка: {x.Message}");
        //        }
        //    }
        //}
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_date_depart.Text = comboBox1.SelectedItem.ToString();
            textBox_class.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_name.Text == "")
            {
                MessageBox.Show("Введіть ім'я та прізвище!");
            }
            if ((textBox_name.Text != "") && (textBox_from.Text != "") && (textBox_to.Text != "") && (textBox_date_depart.Text != "") && (textBox_class.Text != ""))
            {
                try
                {
                    trains.CreateTicket(textBox_from.Text, textBox_to.Text);
                    //try
                    //{
                    //    if (command.ExecuteNonQuery() == 1)
                    //    {
                    //        MessageBox.Show("Замовлення сформовано успішно!");
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Exception error = new Exception("Щось пішло не так!", ex);
                    //    throw error;
                    //}
                    //finally
                    //{
                    //    listBox_from.SelectedItem = null;
                    //    listBox_to.SelectedItem = null;
                    //    listBox_class.SelectedItem = null;
                    //    listBox_from.Items.Clear();
                    //    listBox_to.Items.Clear();
                    //    listBox_class.Items.Clear();
                    //    textBox_from.Clear();
                    //    textBox_to.Clear();
                    //    textBox_date_depart.Clear();
                    //    textBox_class.Clear();
                    //    textBox_name.Clear();
                    //    Fill_listbox();
                    //}
                }
                catch (Exception x)
                {
                    MessageBox.Show($"Помилка: {x.Message}");
                }
            }
        }

        private void button_date_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem == null) || (comboBox1.Text == ""))
            {
                errorProvider1.SetError(comboBox1, "Введіть дату!");
            }
            else 
            {
                errorProvider1.Clear();
            }
        }
    }
}

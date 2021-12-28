using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Booking
{
    class Train : Trip
    {
        private Int32 _id { get; set; }
        private string _city_from { get; set; }
        private string _city_to { get; set; }
        //private DateTime _date { get; set; }
        private Int32 _class { get; set; }
        private Int16 _periodicity { get; set; }

        public List<Train> list_trains = new List<Train>();

        public Int32 GetID() { return this._id; }
        public string GetFrom() { return this._city_from; }
        public string GetTo() { return this._city_to; }
        //public DateTime GetDate() { return this._date; }
        public Int32 GetClass() { return this._class; }
        public Int16 GetPeriod() { return this._periodicity; }
        Trip trip = new Trip();

        public void Fill()
        {
            if (!(list_trains.Count > 0))
            {
                DB DB = new DB();
                DB.OpenConnection();

                if (DB.GetConnection() == null)
                    throw new Exception("Немає підключення до бази даних!");

                MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` ", DB.GetConnection());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list_trains.Add(new Train() { _id = Convert.ToInt32(reader[0]), _city_from = reader[1].ToString(), _city_to = reader[2].ToString(), _periodicity = Convert.ToInt16(reader[3]) });
                }

                DB.CloseConnection();
            }
        }
        public void FillFrom()
        {
            DB DB = new DB();
            DB.OpenConnection();

            if (DB.GetConnection() == null)
                throw new Exception("Немає підключення до бази даних!");

            MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` ", DB.GetConnection());
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list_trains.Add(new Train() { _city_from = reader[1].ToString()});
            }

            DB.CloseConnection();
        }
        public void FillTo(string city_from)
        {
            DB DB = new DB();
            DB.OpenConnection();

            if (DB.GetConnection() == null)
                throw new Exception("Немає підключення до бази даних!");

            MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `city_from` = '" + city_from + "'", DB.GetConnection());
            MySqlDataReader reader = command.ExecuteReader();
            list_trains.Clear();
            while (reader.Read())
            {
                list_trains.Add(new Train() { _city_to = reader[2].ToString() });
            }

            DB.CloseConnection();
        }
        public List<DateTime> FillDate(string from, string to)
        {
            List<DateTime> dates = new List<DateTime>();
            int id = -1;
            DB DB = new DB();
            DB.OpenConnection();
            if (DB.GetConnection() == null)
                throw new Exception("Немає підключення до бази даних!");
            for (int i = 0; i < list_trains.Count(); i++)
            {
                if((String.Compare(list_trains[i].GetFrom(),from) == 0) && (String.Compare(list_trains[i].GetTo(), to) == 0))
                {
                    id = i;
                    break;
                }
            }
            if (id >= 0)
            {
                MySqlCommand command = new MySqlCommand("SELECT `date` FROM `trip` WHERE `id` = '" + id + "'", DB.GetConnection());
                //command.Parameters.Add("@id", MySqlDbType.Int32).Value = list_trains[id].GetId();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dates.Add(Convert.ToDateTime(reader[0]));
                    trip.Fill(id);
                }
            }

            DB.CloseConnection();
            return dates;
        }
        public void CreateTicket(string from, string to, DateTime date)
        {
            int id = -1;
            DB DB = new DB();
            DB.OpenConnection();
            if (DB.GetConnection() == null)
                throw new Exception("Немає підключення до бази даних!");
            for (int i = 0; i < list_trains.Count(); i++)
            {
                if ((String.Compare(list_trains[i].GetFrom(), from) == 0) && (String.Compare(list_trains[i].GetTo(), to) == 0))
                {
                    id = i;
                    break;
                }
            }
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `trip` WHERE `date` = '" + date.Year + "-" + date.Month +"-"+ date.Day +"' AND `id` = '" + id + "'", DB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            string class_format = null;

            if (table.Rows.Count > 0)
            {
                MessageBox.Show(list_trains[id].GetClass().ToString());
                if(list_trains[id].GetClass() == 1)
                {
                    return;
                }
                MySqlCommand command2 = new MySqlCommand("UPDATE `trip` SET `" + class_format + "` = `" + class_format + "` - 1 WHERE `date` =  '" + date.Year + "-" + date.Month + "-" + date.Day + "'AND `id` = '" + id + "'", DB.GetConnection());
                //MySqlDataReader reader;
                if (command2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Замовлення успішно створене!");
                }
                else
                {
                    MessageBox.Show("Помилка!");
                }
            }
            else 
            {
                MySqlCommand command1 = new MySqlCommand("INSERT INTO `project_program`.`trip` (`id`, `date`, `count_class_first`, `count_class_second`, `count_class_third`) VALUES ('" + id + "', '" + date.Year + "-" + date.Month + "-" + date.Day + "', '10', '15', '25');", DB.GetConnection());
                //command.Parameters.Add("@id", MySqlDbType.Int32).Value = list_trains[id].GetId();
                if (command1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Замовлення успішно створене!");
                }
                else
                {
                    MessageBox.Show("Помилка!");
                }
            }
            DB.CloseConnection();
        }
    }
}

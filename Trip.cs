using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking
{
    class Trip
    {
        private Int32 _id { get; set; }
        private DateTime _date { get; set; }

        public DateTime GetDate() { return this._date; }
        public Int32 GetId() { return this._id; }

        public void SetId(Int32 id) { this._id = id; }
        public void SetDate(DateTime date) { this._date = date; }

        public List<Trip> list_trips = new List<Trip>();

        public void Fill(Int32 id)
        {
            DB DB = new DB();
            DB.OpenConnection();

            if (DB.GetConnection() == null)
                throw new Exception("Немає підключення до бази даних!");

            MySqlCommand command = new MySqlCommand("SELECT `date` FROM `trip` WHERE `id` = '" + id + "'", DB.GetConnection());
            //command.Parameters.Add("@id", MySqlDbType.Int32).Value = list_trains[id].GetId();
            if (command.ExecuteNonQuery() == 1)
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list_trips.Add(new Trip { _id = Convert.ToInt32(reader[0]), _date = Convert.ToDateTime(reader[1]) }) ;
                }
            }
        }
    }
}

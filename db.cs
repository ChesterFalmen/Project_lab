using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Booking
{
    class db
    {
        static string string_connection = "server=localhost;port=3306;username=root;password=;database=project_program";
        MySqlConnection connection = new MySqlConnection(string_connection);


        public bool openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                if (!CheckDbConnection(string_connection))
                {
                    return false;
                }
                else
                {
                    connection.Open();
                    return true;
                }
            }
            else
            {
                connection.Close();
                if (!CheckDbConnection(string_connection))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
        public bool CheckDbConnection(string string_connection)
        {
            try
            {
                using (var connection = new MySqlConnection(string_connection))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

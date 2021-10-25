using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSQLApp
{
    class db
    {
        string string_connection = "server=localhost;port=3306;username=root;password=;database=project_program";
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=project_program");
    
        public bool openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                if(!CheckDbConnection(string_connection))
                {
                    return false;
                }
                else
                {
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
        private bool CheckDbConnection(string string_connection)
        {
            try
            {
                using (var connection = new MySqlConnection(string_connection))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

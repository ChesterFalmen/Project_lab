using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Booking
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }


        Point lastPoint;
        private void mainpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void mainpanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введіть ім'я")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введіть ім'я";
                userNameField.ForeColor = Color.Gray;
            }
        }

        private void userSurNameField_Leave(object sender, EventArgs e)
        {
            if (userSurNameField.Text == "")
            {
                userSurNameField.Text = "Введіть прізвище";
                userSurNameField.ForeColor = Color.Gray;
            }
        }

        private void userSurNameField_Enter(object sender, EventArgs e)
        {
            if (userSurNameField.Text == "Введіть прізвище")
            {
                userSurNameField.Text = "";
                userSurNameField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "username";
                loginField.ForeColor = Color.Gray;
            }
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "username")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.Text = "password";
                passField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "password")
            {
                passField.Text = "";
                passField.ForeColor = Color.Black;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введіть ім'я")
            {
                MessageBox.Show("Введіть ім'я!");
            }
            else if (userSurNameField.Text == "Введіть прізвище")
            {
                MessageBox.Show("Введіть прізвище!");
            }
            else if (loginField.Text == "username")
            {
                MessageBox.Show("Введіть username!");
            }
            else if (passField.Text == "password")
            {
                MessageBox.Show("Введіть password!");
            }
            else
            {
                DB DB = new DB();
                if (!DB.OpenConnection())
                {
                    MessageBox.Show("Немає підключення до бази даних!");
                    return;
                }

                if (IsUserExists())
                { 
                    return; 
                }
                MySqlCommand command = new MySqlCommand("INSERT INTO `project_program`.`users` (`login`, `password`, `name`, `surname`) VALUES (@login, @pass, @name, @surname)", DB.GetConnection());

                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField.Text;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userSurNameField.Text;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт був успішно створений!");
                    this.Hide();
                    LoginForm loginform = new LoginForm();
                    loginform.Show();
                }
                else
                {
                    MessageBox.Show("Аккаунт не був створений!");
                }

                DB.CloseConnection();
            }
        }
        public Boolean IsUserExists()
        {
            DB DB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE  `login` = @uL", DB.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Користувач з такими даними вже існує!\nПридумайте інше!");
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginform = new LoginForm();
            loginform.Show();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleSQLApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool TEST = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (TEST)
            {
                Application.Run(new MainForm());
            }
            else
            {
                Application.Run(new LoginForm());
            }
        }
    }
}

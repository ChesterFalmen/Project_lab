using System.IO;
using System.Windows.Forms;

namespace Booking
{
    public class Con_db
    {
        public string Line { get; set; }
        public Con_db(string line)
        {
            StreamReader sr = new StreamReader("D:\\source\\repos\\Project\\mysql.txt");
            line = sr.ReadLine();
            MessageBox.Show(Line);
            sr.Close();
        }
    }
}

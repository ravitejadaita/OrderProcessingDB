using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form15());
        }
    }
    public class userinsert
    {
        public static int uid = 25;

    }
    public class user_id
    {
        public static int userid=0;

    }
    public class search_word
    {
        public static string strsearch = "";
    }

    public class order_id
    {
        public static int o_id = 555;
    }
}

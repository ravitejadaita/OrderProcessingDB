using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace WindowsFormsApp1
{
    public partial class Form14 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Form14()
        {
            InitializeComponent();
        }
        public void DB_Connect()
        {
            String oradb = "User Id=SYSTEM; Password=Oracle_1;" + "Data Source=localhost:1521/ORCL;";
            conn = new OracleConnection();
            conn.ConnectionString = oradb;
            conn.Open();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select s.userID from User1 s where s.userID not in (select p.userID from places1 p)";
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_testing");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_testing";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you ! We will send invites to all ! ");
            Form11 form11 = new Form11();
            this.Close();
            form11.Show();
        }
    }
}

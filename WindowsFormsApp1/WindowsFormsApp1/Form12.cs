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
    public partial class Form12 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public Form12()
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

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand("Procedure1", conn);
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("uID", "number").Value = user_id.userid;
            comm.Parameters.Add("oID", "number").Value = order_id.o_id;
            comm.ExecuteNonQuery();
            conn.Close();

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "delete from cart1 where userid = " + user_id.userid;
            comm.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Your order has been placed successfully!");
            order_id.o_id++;
            Form11 form11 = new Form11();
            this.Close();
            form11.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "delete from dummyorder1 where orderid = " + order_id.o_id;
            comm.ExecuteNonQuery();
            conn.Close();
            Form6 form6 = new Form6();
            this.Close();
            form6.Show();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select totalamount from dummyorder1 where orderid = " + order_id.o_id;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_participated");
            dt = ds.Tables["Tbl_participated"];
            dr = dt.Rows[0];
            label1.Text += " " + dr["totalamount"];
            conn.Close();
        }
    }
}

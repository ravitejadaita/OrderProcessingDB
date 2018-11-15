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
    public partial class Form4 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Form4()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Close();
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Close();
            form3.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select orderitem1.orderid, orderitem1.itemid, orderitem1.orderdate, orderitem1.order_quantity, orderitem1.totalprice, orderitem1.discountprice from orderitem1, places1 where orderitem1.orderid = places1.orderid and places1.userid = '" + user_id.userid + "'";
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_testing");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_testing";
            conn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            this.Close();
            form13.Show();
        }
    }
}

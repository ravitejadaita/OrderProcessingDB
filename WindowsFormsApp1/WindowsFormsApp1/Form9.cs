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
    public partial class Form9 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public Form9()
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
            Form3 form3 = new Form3();
            this.Close();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into cart1 values ('" + user_id.userid + "','" + textBox1.Text + "','" + textBox2.Text + "')";
            comm.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            MessageBox.Show("Added to cart.");
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from item1";
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_testing");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_testing";
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into addstowishlist1 values ('" + user_id.userid + "','" + textBox1.Text + "')";
            comm.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            MessageBox.Show("Added to wishlist.");
        }
    }
}

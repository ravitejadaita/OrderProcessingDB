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
    public partial class Form7 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public Form7()
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Close();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into cart1 values ('" + user_id.userid + "','" + textBox1.Text + "','" + textBox2.Text + "')";
            comm.ExecuteNonQuery();
            conn.Close();

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "delete from addstowishlist1 where userid ='" + user_id.userid + "' and itemid='" + textBox1.Text + "'";
            comm.ExecuteNonQuery();
            conn.Close();

            textBox1.Text = "";
            textBox2.Text = "";

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select item1.itemid,item1.itemname,item1.type, item1.description, item1.price from item1,addstowishlist1 where item1.itemid = addstowishlist1.itemid and addstowishlist1.userid = '" + user_id.userid + "'";
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_testing");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_testing";
            conn.Close();

            MessageBox.Show("Item has been moved to the cart.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "delete from addstowishlist1 where userid ='" + user_id.userid + "' and itemid='" + textBox1.Text + "'";
            comm.ExecuteNonQuery();
            conn.Close();
            ///

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select item1.itemid,item1.itemname,item1.type, item1.description, item1.price from item1,addstowishlist1 where item1.itemid = addstowishlist1.itemid and addstowishlist1.userid = '" + user_id.userid + "'";
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_testing");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_testing";
            conn.Close();

            textBox1.Text = "";
            MessageBox.Show("Item has been deleted from the wishlist.");
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select item1.itemid, item1.itemname, item1.type, item1.description, item1.price from item1, addstowishlist1 where item1.itemid = addstowishlist1.itemid and addstowishlist1.userid = '" + user_id.userid + "'";
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_testing");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_testing";
            conn.Close();
        }
    }
}

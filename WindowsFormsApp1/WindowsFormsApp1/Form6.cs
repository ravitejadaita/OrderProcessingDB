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
    public partial class Form6 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public Form6()
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
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            MessageBox.Show("The selected item has been deleted.");
            comm.CommandText = "delete from cart1 where userid ='" + user_id.userid + "' and itemid='" + textBox1.Text + "'";      
            comm.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            
            //Loading the grid view again, after deleting from the cart.

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select item1.itemid,item1.itemname,item1.type, item1.description, item1.price from item1,cart1 where item1.itemid = cart1.itemid and cart1.userid = '" + user_id.userid + "'";
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_testing");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_testing";
            conn.Close();

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
            comm = new OracleCommand("Procedure2", conn);
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("uID", "number").Value = user_id.userid;
            comm.Parameters.Add("oID", "number").Value = order_id.o_id;
            comm.ExecuteNonQuery();
            conn.Close();

           

            Form12 form12 = new Form12();
            this.Close();
            form12.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select item1.itemid,item1.itemname,item1.type, item1.description, item1.price, cart1.cart_quantity from item1,cart1 where item1.itemid = cart1.itemid and cart1.userid = '" + user_id.userid+"'";
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_testing");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_testing";
            conn.Close();
        }
    }
}

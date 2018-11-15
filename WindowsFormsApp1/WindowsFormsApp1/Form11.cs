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
    public partial class Form11 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public Form11()
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

        private void Form11_Load(object sender, EventArgs e)
        {
            int od = order_id.o_id - 1; 
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select f.orderID,f.orderdate,f.totalamount from order1 f  where f.orderid =" + od + "and not exists (select itemID from Item1 minus (select itemID from OrderItem1 t where t.orderID=" + od + "))";
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_testing");
            dt = ds.Tables["Tbl_testing"];
         
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Hurray You have purchased all items available ! ");
                this.label4.Text = "Hurray You have purchased all items available ! ";
            }
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rate = 1;
            if (radioButton1.Checked)
                rate = 1;
            else if (radioButton2.Checked)
                rate = 2;
            else if (radioButton3.Checked)
                rate = 3;
            else if (radioButton4.Checked)
                rate = 4;
            else
                rate = 5;

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into review1 values('" + richTextBox1.Text + "'," + rate + ")";
            comm.ExecuteNonQuery();
            conn.Close();
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into addreview1 values(" + user_id.userid + ",'" + richTextBox1.Text + "')";
            comm.ExecuteNonQuery();
            conn.Close();

            Form3 form3 = new Form3();
            this.Close();
            form3.Show();
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            this.Close();
            form14.Show();
        }
    }
}

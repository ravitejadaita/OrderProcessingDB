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
    public partial class Form2 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Form2()
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
            comm.CommandText = "insert into user1 values('" + userinsert.uid + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox7.Text + "'," + textBox6.Text + ")";
            comm.ExecuteNonQuery();
            MessageBox.Show("User created.");
            userinsert.uid++;
            conn.Close();
          
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
          
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

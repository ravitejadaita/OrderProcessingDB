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
    public partial class Form3 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public Form3()
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

        private void button6_Click(object sender, EventArgs e)
        {
            userinsert.uid++;
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search_word.strsearch = textBox1.Text;
            if (search_word.strsearch == "")
                MessageBox.Show("Please enter something to search for.");
            else
            {
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select count(*) as counter from item1 where type like '%" + search_word.strsearch + "%'";
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "Tbl_participated");
                dt = ds.Tables["Tbl_participated"];
                dr = dt.Rows[0];
                conn.Close();

                if (int.Parse(dr["counter"].ToString()) > 1)
                {
                    Form10 form10 = new Form10();
                    this.Close();
                    form10.Show();
                }
                else
                {
                    MessageBox.Show("No items match your search. Try again!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Close();
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            this.Close();
            form7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            this.Close();
            form8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Close();
            form6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            this.Close();
            form9.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

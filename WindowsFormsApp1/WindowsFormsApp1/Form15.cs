using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form15 : Form
    {
        Timer tmr;

        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 3 sec
            tmr.Interval = 3000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 1.5 sec stop the timer
            tmr.Stop();
            //display mainform
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
            //hide this form            
        }
    }
}

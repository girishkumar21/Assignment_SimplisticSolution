using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ATM_Machine
{
    public partial class Mini_Statement : Form

    {
        OleDbConnection con = new OleDbConnection();
        Form1 main = new Form1();

        public string card_num;
        public string pin_num;
        public string acc_hold;


        public string PassingCard
        {
            get { return card_num; }
            set { card_num = value; }

        }
        public string PassingPin
        {
            get { return pin_num; }
            set { pin_num = value; }
        }
        public string PassingHolder
        {
            get { return acc_hold; }
            set { acc_hold = value; }
        }

        public Mini_Statement()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Girish\Documents\ATM_Data.accdb";
        }

        private void Mini_Statement_Load(object sender, EventArgs e)
        {
            btnL1W5.Enabled = false;
            btnL2W5.Enabled = false;
            btnL3W5.Enabled = false;
            btnR1W5.Enabled = false;
            panel1.Visible = false;
        }

        private void btnCancelW5_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();

        }

        private void btnNoW5_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();

        }

        private void btnEnterW5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }


        private void btnClearW5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            lblAccount_Holder.Text = acc_hold;
            lblCard_Number.Text = card_num;
            
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                string query = "select top 5 Transaction_Date, Deposite, Withdraw, Balance  from Statement where Card_Number='"+card_num+"'  order by Transaction_Date desc";
                cmd.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;

             


                

                con.Close();

                
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex); ;
            }
        }

       
       

    }
}

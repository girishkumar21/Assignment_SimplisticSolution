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
    public partial class Transfer : Form

    {
        OleDbConnection con = new OleDbConnection();
        Form1 main = new Form1();


        public string card_num;
        public string pin_num;
        //public int count = 0;

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


        public Transfer()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Girish\Documents\ATM_Data.accdb";
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            btnL1W4.Enabled = false;
            btnL2W4.Enabled = false;
            btnL3W4.Enabled = false;
            btnR1W4.Enabled = false;
            panel1.Visible = false;
        }

        private void btn1W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "1";
        }

        private void btn2W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "2";
        }

        private void btn3W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "3";
        }

        private void btn4W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "4";
        }

        private void btn5W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "5";
        }

        private void btn6W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "6";
        }

        private void btn7W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "7";
        }

        private void btn8W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "8";
        }

        private void btn9W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "9";
        }

        private void btn0W4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = txtTransCard.Text + "0";
        }

        private void btnClearW4_Click(object sender, EventArgs e)
        {
            txtTransCard.Text = "";
        }

        private void btnCancelW4_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void btnNoW4_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void btnEnterW4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void btnYesW4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }


        //================Panel 1====================================================//

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            btnL1P1.Enabled = false;
            btnL2P1.Enabled = false;
            btnL3P1.Enabled = false;
            btnR1P1.Enabled = false;


        }

        private void btn1P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "1";
        }

        private void btn2P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "2";
        }

        private void btn3P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "3";
        }

        private void btn4P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "4";
        }

        private void btn5P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "5";
        }

        private void btn6P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "6";
        }

        private void btn7P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "7";
        }

        private void btn8P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "8";
        }

        private void btn9P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "9";
        }

        private void btn0P1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = txtTransBal.Text + "0";
        }

        private void btnClearP1_Click(object sender, EventArgs e)
        {
            txtTransBal.Text = "";
        }

        private void btnCancelP1_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();

        }

        private void btnNoP1_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void btnEnterP1_Click(object sender, EventArgs e)
        {
            double rcv_card = Convert.ToDouble(txtTransCard.Text);
            double rcv_bal = Convert.ToDouble(txtTransBal.Text);

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;

            //string receiver;

            try
            {

                con.Open();


                cmd.CommandText = "select * from Account where Card_Number = '" + card_num + "' and Pin_Number = '" + pin_num + "'";
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    lblBal.Text = reader["Balance"].ToString();


                }
                reader.Close();
                con.Close();

                double bal = Convert.ToDouble(lblBal.Text);

                if (bal > rcv_bal)
                {
                    double avl_bal = bal - rcv_bal;


                    con.Open();

                    string query = "update Account set Balance='" + avl_bal + "' where Card_Number='" + card_num + "' and Pin_Number='" + pin_num + "' ";
                    //MessageBox.Show(query);
                    cmd.CommandText = query;


                    cmd.ExecuteNonQuery();




                    MessageBox.Show("Successfully Inserted");


                    con.Close();
                }
                else
                {
                    MessageBox.Show("Insufficient Balance");
                }

                con.Open();


                cmd.CommandText = "select * from Account where Card_Number = '" + txtTransCard.Text + "' ";
                OleDbDataReader reader1 = cmd.ExecuteReader();

                while (reader1.Read())
                {

                    lblreceive.Text = reader1["Balance"].ToString();


                }
                reader1.Close();
                con.Close();

                double rece_bal = Convert.ToDouble(lblreceive.Text);

                 rece_bal = rece_bal + rcv_bal;



                 if (rcv_bal < 100000)
                 {

                     con.Open();
                     string query1 = "update Account set Balance='" + rece_bal + "' where Card_Number='" + txtTransCard + "' ";
                     //MessageBox.Show(query);
                     cmd.CommandText = query1;


                     cmd.ExecuteNonQuery();




                     MessageBox.Show("Successfully Inserted");
                     con.Close();

                 }
                 else
                 {
                     MessageBox.Show("Transfer is not Possible at once");
                 }

                


                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }





        }
       
    }
}

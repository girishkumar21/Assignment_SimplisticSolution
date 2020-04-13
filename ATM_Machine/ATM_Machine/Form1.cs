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
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection();
        public static string passed_card;
        public static string pass_pin;

        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Girish\Documents\ATM_Data.accdb";
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            btnL1W1.Enabled = false;
            btnL2W1.Enabled = false;
            btnL3W1.Enabled = false;
            btnR1W1.Enabled = false;


            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            


            

        }

        private void btn1W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "1";

        }

        private void btn2W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "2";
        }

        private void btn3W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "3";
        }

        private void btn4W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "4";
        }

        private void btn5W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "5";
        }

        private void btn6W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "6";
        }

        private void btn7W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "7";
        }

        private void btn8W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "8";
        }

        private void btn9W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "9";
        }

        private void btn0W2_Click(object sender, EventArgs e)
        {
            txtCard.Text = txtCard.Text + "0";
        }

        private void btnCancelW2_Click(object sender, EventArgs e)
        {
            txtCard.Text = "";

        }

        private void btnClearW2_Click(object sender, EventArgs e)
        {
            txtCard.Text = "";
        }

        private void btnNoW2_Click(object sender, EventArgs e)
        {
            txtCard.Text = "";
        }

        private void btnEnterW2_Click(object sender, EventArgs e)
        {
            if (txtCard.Text.Length == 16)
            {
                panel1.Visible = true;

            }
            else
            {
                MessageBox.Show("Invalid Card Number");
            }
        }

        private void btnYesW2_Click(object sender, EventArgs e)
        {
            if (txtCard.Text.Length == 16)
            {
                panel1.Visible = true;

            }
            else
            {
                MessageBox.Show("Invalid Card Number");
            }
        }


        //==============================Window 1 ==========================//




        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            btnL1P1.Enabled = false;
            btnL2P1.Enabled = false;
            btnL3P1.Enabled = false;
            btnR1P1.Enabled = false;

            panel2.Visible = false;
            panel3.Visible = false;
            
        }

        private void btn1P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "1";
        }

        private void btn2P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "2";
        }

        private void btn3P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "3";
        }

        private void btn4P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "4";
        }

        private void btn5P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "5";
        }

        private void btn6P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "6";
        }

        private void btn7P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "7";
        }

        private void btn8P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "8";
        }

        private void btn9P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "9";
        }

        private void btn0P1_Click(object sender, EventArgs e)
        {
            txtPin.Text = txtPin.Text + "0";
        }

        private void btnNoP1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnCancelP1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnClearP1_Click(object sender, EventArgs e)
        {
            txtPin.Text = "";
        }

        private void btnEnterP1_Click(object sender, EventArgs e)
        {
            if (txtPin.Text.Length == 4)
            {
                try
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from Account where Card_Number = '"+txtCard.Text+"' and Pin_Number = '"+txtPin.Text+"'";

                    OleDbDataReader reader = cmd.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        //MessageBox.Show("Welcome User");
                        panel2.Visible = true;
                       // panel1.Visible = false;
                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("Diplicate Entry");
                        panel2.Visible = false;
                        //panel1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Please Check Your Card Number and Pin Number");
                    }





                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Invalid Pin Number");
            }

           // txtPin.Clear();
            //txtCard.Clear();
        }

        private void btnYesP1_Click(object sender, EventArgs e)
        {
            if (txtPin.Text.Length == 4)
            {
                try
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from Account where Card_Number = '" + txtCard.Text + "' and Pin_Number = '" + txtPin.Text + "'";

                    OleDbDataReader reader = cmd.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        //MessageBox.Show("Welcome User");
                        panel2.Visible = true;
                       // panel1.Visible = false;
                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("Diplicate Entry");
                        panel2.Visible = false;
                       // panel1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Please Check Your Card Number and Pin Number");
                    }





                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Invalid Pin Number");
            }

            txtPin.Clear();
            txtCard.Clear();
        }


        //==============================Panel 1 ==========================//


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            lblBal.Visible = false;

            panel3.Visible = false;



            try
            {
                con.Open();


                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Account where Card_Number = '" + txtCard.Text + "' and Pin_Number = '" + txtPin.Text + "'";
                // MessageBox.Show("Connected");

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    lblAcHold.Text = reader["Account_Holder"].ToString();

                }


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            
            
            
        }


        private void btnMini_Click(object sender, EventArgs e)
        {
            Mini_Statement mini = new Mini_Statement();
            mini.PassingCard = txtCard.Text;
            mini.PassingPin = txtPin.Text;
            mini.PassingHolder = lblAcHold.Text;
            

            mini.Show();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnMini.Enabled = false;
            btnChange.Enabled = false;
            btnWithdraw.Enabled = false;
            btnDeposite.Enabled = false;
            btnTransfer.Enabled = false;
            btnCheck.Enabled = false;
            lblAcHold.Visible = false;

            lblMini.Visible = false;
            lblCheck.Visible = false;
            lblChange.Visible = false;
            lblWithdraw.Visible = false;
            lblDeposite.Visible = false;
            lblTransfer.Visible = false;

            lblBal.Visible = true;
            lblBal.Text = "";

            try
            {
                con.Open();


                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Account where Card_Number = '" + txtCard.Text + "' and Pin_Number = '" + txtPin.Text + "'";
               // MessageBox.Show("Connected");
               
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    lblBal.Text =lblBal.Text + "Your Current Balance is: \r\n Rs. " + (reader["Balance"].ToString());
                    
                }
               

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }


        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Change_Pin change = new Change_Pin();
            change.PassingCard = txtCard.Text;
            change.PassingPin = txtPin.Text;
            change.Show();

        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {


            Withdraw withdraw = new Withdraw();

            withdraw.PassingCard = txtCard.Text;
            withdraw.PassingPin = txtPin.Text;
            withdraw.PassingHolder = lblAcHold.Text;
            
            withdraw.Show();

        }

        private void btnDeposite_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Transfer trans = new Transfer();
            trans.PassingCard = txtCard.Text;
            trans.PassingPin = txtPin.Text;
            trans.Show();

        }

        private void btnCancelP2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
           // panel1.Visible = false;


        }

        private void btnEnterP2_Click(object sender, EventArgs e)
        {
            //hide lblbalance
            lblBal.Visible = false;


            btnMini.Enabled = true;
            btnChange.Enabled = true;
            btnWithdraw.Enabled = true;
            btnDeposite.Enabled = true;
            btnTransfer.Enabled = true;
            btnCheck.Enabled = true;

            lblMini.Visible = true;
            lblCheck.Visible = true;
            lblChange.Visible = true;
            lblWithdraw.Visible = true;
            lblDeposite.Visible = true;
            lblTransfer.Visible = true;
            lblAcHold.Visible = true;



        }

        private void btnClearP2_Click(object sender, EventArgs e)
        {
            lblBal.Visible = false;

            btnMini.Enabled = true;
            btnChange.Enabled = true;
            btnWithdraw.Enabled = true;
            btnDeposite.Enabled = true;
            btnTransfer.Enabled = true;
            btnCheck.Enabled = true;

            lblMini.Visible = true;
            lblCheck.Visible = true;
            lblChange.Visible = true;
            lblWithdraw.Visible = true;
            lblDeposite.Visible = true;
            lblTransfer.Visible = true;
            lblAcHold.Visible = true;

            //lblbal hide
        }


        //==============================Panel 2 ==========================//


        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            btnL1P3.Enabled = false;
            btnL2P3.Enabled = false;
            btnL3P3.Enabled = false;
            btnR1P3.Enabled = false;



        }

        private void btn1P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "1";

        }

        private void btn2P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "2";
        }

        private void btn3P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "3";
        }

        private void btn4P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "4";
        }

        private void btn5P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "5";
        }

        private void btn6P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "6";
        }

        private void btn7P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "7";
        }

        private void btn8P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "8";
        }

        private void btn9P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "9";
        }

        private void btn0P3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = txtDeposite.Text + "0";
        }

        private void btnCancelP3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = false;
           

           // txtCard.Clear();
            //txtPin.Clear();
        }

        private void btnClearP3_Click(object sender, EventArgs e)
        {
            txtDeposite.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }

        private void btnEnterP3_Click(object sender, EventArgs e)
        {

           
            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Account where Card_Number = '" + txtCard.Text + "' and Pin_Number = '" + txtPin.Text + "'";
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    lblBalP3.Text = reader["Balance"].ToString();
                    lblDepCount.Text = reader["With_Check"].ToString();
                    
                    

                }
                reader.Close();



                double dep = Convert.ToDouble(txtDeposite.Text);
               double bal = Convert.ToDouble(lblBalP3.Text);
               double hisap = Convert.ToDouble(lblDepCount.Text);
              // double card = Convert.ToDouble(txtCard.Text);


                double avl_bal = dep + bal;
                //int hisap = 1;
                
                

                string query = "update Account set Balance='"+avl_bal+"' where Card_Number='"+txtCard.Text+"' and Pin_Number='"+txtPin.Text+"' ";
               
                
                string query1 = "Insert into Statement(Card_Number, Account_Holder, Deposite, Balance, With_Check) values('"+txtCard.Text+"','"+lblAcHold.Text+"', '"+dep+"','"+avl_bal+"','"+hisap+"')";
                //MessageBox.Show(query);
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();

                hisap++;

                cmd.CommandText = query1;


                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Deposited");
               // hisap = hisap + 1;

                con.Close();
                lblDepCount.Text = Convert.ToString(hisap);

                txtDeposite.Clear();
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          /*  try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Account where Card_Number = '" + txtCard.Text + "' and Pin_Number = '" + txtPin.Text + "'";
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    lblBalP3.Text = reader["Balance"].ToString();

                }
                reader.Close();



                double dep = Convert.ToDouble(txtDeposite.Text);
                double bal = Convert.ToDouble(lblBalP3.Text);

                double avl_bal = dep + bal;


                string query = "update Account set Balance='" + avl_bal + "' where Card_Number='" + txtCard.Text + "' and Pin_Number='" + txtPin.Text + "' ";
                //MessageBox.Show(query);
                cmd.CommandText = query;


                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Inserted");

                con.Close();

                txtDeposite.Clear();
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }*/
        }







        

        
    }
}

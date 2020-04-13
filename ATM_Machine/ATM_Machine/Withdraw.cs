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
    public partial class Withdraw : Form
    {
        OleDbConnection con = new OleDbConnection();
        Form1 main = new Form1();

            public string card_num;
            public string pin_num;
            public string acc_hold;
       // public int count=0;

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




        public Withdraw()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Girish\Documents\ATM_Data.accdb";

        }



        private void Withdraw_Load(object sender, EventArgs e)
        {
            btnL1W2.Enabled = false;
            btnL2W2.Enabled = false;
            btnL3W2.Enabled = false;
            btnR1W2.Enabled = false;


        }

        private void btn1W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "1";
        }

        private void btn2W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "2";
        }

        private void btn3W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "3";
        }

        private void btn4W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "4";
        }

        private void btn5W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "5";
        }

        private void btn6W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "6";
        }

        private void btn7W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "7";
        }

        private void btn8W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "8";
        }

        private void btn9W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "9";
        }

        private void btn0W2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = txtWithdraw.Text + "0";
        }

        private void btnClearW2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = "";
        }

        private void btnCancelW2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            
        }

        private void btnEnterW2_Click(object sender, EventArgs e)
        {
            
            try
            {

              

                //string formattedTime = time.ToString("yyyy, MM, dd, hh, mm, ss");



                double draw = Convert.ToDouble(txtWithdraw.Text);
                if (draw > 10000)
                {
                    MessageBox.Show("Only 10000 or less than 10000 at once");
                    txtWithdraw.Clear();
                }

                else if (draw < 200)
                {
                    MessageBox.Show("Rs. 100 is not Available");
                    txtWithdraw.Clear();
                }

                else
                {


                    con.Open(); 
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "select * from Account where Card_Number = '" + card_num + "' and Pin_Number = '" + pin_num + "'";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        lblBalW2.Text = reader["Balance"].ToString();
                        lblCounter.Text = reader["With_Check"].ToString();
                        

                    }
                    reader.Close();
                    con.Close();

                    double bal = Convert.ToDouble(lblBalW2.Text);

                    double count = Convert.ToDouble(lblCounter.Text);

                    double avl_bal = bal - draw;

                    

              //      if (bal >= draw)
                //    {
                        


                        
                       
                      /*  con.Open();

                        string query = "update Account set Balance='" + avl_bal + "' where Card_Number='" + card_num + "' and Pin_Number='" + pin_num + "' ";
                        //
                        string query1 = "Insert into Statement(Card_Number, Account_Holder, Withdraw, Balance, With_Check) values('" + card_num + "','" + acc_hold + "', '" + draw + "','" + avl_bal + "', '" + count + "')";

                       

                        //MessageBox.Show(query);
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                       // MessageBox.Show("Updated");

                       
                        cmd.CommandText = query1;
                        cmd.ExecuteNonQuery();

                        count++;*/
                        


                        /*string query2 = "update Account set With_Check = '" + count + "' where Card_Number = '" + card_num + "'";

                        cmd.CommandText = query2;
                        cmd.ExecuteNonQuery();


                        MessageBox.Show("Successfully Inserted");
                        lblCounter.Text = Convert.ToString(count);
                        


                        con.Close();*/

                        if (count <= 5)
                        {

                             if (bal >= draw)
                             {
                                  con.Open();

                            string query = "update Account set Balance='" + avl_bal + "' where Card_Number='" + card_num + "' and Pin_Number='" + pin_num + "' ";
                            //
                            string query1 = "Insert into Statement(Card_Number, Account_Holder, Withdraw, Balance, With_Check) values('" + card_num + "','" + acc_hold + "', '" + draw + "','" + avl_bal + "', '" + count + "')";



                            //MessageBox.Show(query);
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                            // MessageBox.Show("Updated");


                            cmd.CommandText = query1;
                            cmd.ExecuteNonQuery();

                            count++;

                                 string query2 = "update Account set With_Check = '" + count + "' where Card_Number = '" + card_num + "'";

                        cmd.CommandText = query2;
                        cmd.ExecuteNonQuery();


                        MessageBox.Show("Successfully Withdrawed");
                        lblCounter.Text = Convert.ToString(count);
                        


                            con.Close();
                             }

                           
                        }
                        else if(count>5)
                        {

                            DateTime endtime = DateTime.Now;
                            string x = Convert.ToString(endtime);
                            DateTime startTime = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(0);
                            startTime.ToShortTimeString();
                            string y = Convert.ToString(startTime);

                        
                             if (x == y)
                             {
                                 con.Open();
                                 
                                 string query3 = "update Account set With_Check ='"+1+"' where Card_Number='"+card_num+"'";
                                 cmd.CommandText = query3;
                                 cmd.ExecuteNonQuery();

                                 con.Close();
                             }
                              else
                             {
                                 MessageBox.Show("You have reached the Withdraw Limit");
                                 this.Close();
                             }

                            
                        }



                        //lblCounter.Text = Convert.ToString(count);

                        //count = count + 1;
                        //lblCounter.Text = Convert.ToString(count);
                    }
                         
                       

                    
                    txtWithdraw.Clear();
                    //this.Close();
                    //count++;

                   



                }





            
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
           



             //


           // MessageBox.Show("Card Number = " + card_num + " and Pin Number = " + pin_num);
        }

        private void btnNoW2_Click(object sender, EventArgs e)
        {
           // Form1 frm = new Form1();
            //frm.Show();
            this.Close();
        }

        private void btnYesW2_Click(object sender, EventArgs e)
        {

        }





        
    }
}

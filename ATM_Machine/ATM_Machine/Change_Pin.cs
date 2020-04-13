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
    public partial class Change_Pin : Form
    {
        OleDbConnection con = new OleDbConnection();
        Form1 main = new Form1();

        public string card_num;
        public string pin_num;
        public int count = 0;

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

        public Change_Pin()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Girish\Documents\ATM_Data.accdb";
        }

        private void Change_Pin_Load(object sender, EventArgs e)
        {
            btnL1W3.Enabled = false;
            btnL2W3.Enabled = false;
            btnL3W3.Enabled = false;
            btnR1W3.Enabled = false;

        }

        private void btn1W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "1";
        }

        private void btn2W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "2";
        }

        private void btn3W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "3";
        }

        private void btn4W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "4";
        }

        private void btn5W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "5";
        }

        private void btn6W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "6";
        }

        private void btn7W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "7";
        }

        private void btn8W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "8";
        }

        private void btn9W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "9";
        }

        private void btn0W3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = txtNewPin.Text + "0";
        }

        private void btnClearW3_Click(object sender, EventArgs e)
        {
            txtNewPin.Text = "";
        }

        private void btnCancelW3_Click(object sender, EventArgs e)
        {
            main.Show();
        }

        private void btnEnterW3_Click(object sender, EventArgs e)
        {
            if (txtNewPin.Text.Length == 4)
            {
                try
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "update Account set Pin_Number = '" + txtNewPin.Text + "' where Card_Number='" + card_num + "'";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pin Changed");

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
                
                
            }
            else
            {
                MessageBox.Show("PIN number should be 4 digit");
                txtNewPin.Clear();
            }
        }

    }
}

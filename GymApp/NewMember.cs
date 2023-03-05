using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace GymApp
{

    public partial class NewMember : Form
    {
        string emailpattern = "^[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
        public NewMember()
        {
            InitializeComponent();
        }



        private void textBox5_Leave(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAddress.Text) == true)
            {
                txtAddress.Focus();
                errorProvider4.SetError(this.txtAddress, "Please Fill Address");

            }
            else
            {
                errorProvider4.Clear();
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {


        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void NewMember_Load(object sender, EventArgs e)
        {

        }



        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFirstName.Text) == true)
            {
                txtFirstName.Focus();
                errorProvider1.SetError(this.txtFirstName, "Please Fill Name");

            }
            else
            {
                errorProvider1.Clear();
            }

        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }



        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtLastName.Text) == true)
            {
                txtLastName.Focus();
                errorProvider2.SetError(this.txtLastName, "Please Fill Last Name");

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text) == true)
            {
                txtEmail.Focus();
                errorProvider3.SetError(this.txtEmail, "Please Enter Mobile Number");

            }
            else
            {
                errorProvider3.Clear();
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String fname = txtFirstName.Text;
            String lname = txtLastName.Text;

            String gender = "";

            bool isChecked = radioButton1.Checked;

            if (isChecked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            String dob = dateTimePickerDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;
            String joindate = dateTimePickerJoinDate.Text;
            String gymtime = comboBoxGymTime.Text;
            String address = txtAddress.Text;
            String membership = comboBoxMembership.Text;

            SqlConnection con = new SqlConnection();
            //con.ConnectionString = "data source = LAPTOP-2EMUFE1E\\SQLEXPRESS database = gym ; integrated security= True";
            con.ConnectionString = "data source = LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;    
            cmd.CommandText = "insert into NewMember (Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,Gymtime,Maddress,MembershipTime) values ('" + fname + "','" + lname + "','" + gender + "','" + dob + "','" + mobile + "','" + email + "','" + joindate + "','" + gymtime + "','" + address + "','" + membership + "')";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS= new DataSet();
            DA.Fill(DS);
            MessageBox.Show("DATA SAVED");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();    
            
            radioButton1.Checked= false;    
            radioButton2.Checked= false;    

            txtMobile.Clear();  
            txtEmail.Clear();

            comboBoxGymTime.ResetText();
            comboBoxMembership.ResetText(); 
            txtAddress.Clear(); 

            dateTimePickerDOB.Value= DateTime.Now;
            dateTimePickerJoinDate.Value= DateTime.Now; 
        }
    }
}
  
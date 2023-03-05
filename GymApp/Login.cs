using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                MessageBox.Show("Bhai username orr password sahi se type kar 😂\r\n", "Abe Yrr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

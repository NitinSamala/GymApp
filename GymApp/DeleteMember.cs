using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{
    public partial class DeleteMember : Form
    {
        public DeleteMember()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete your data. Confirm?","Delete data",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                // con.ConnectionString = "data source = LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security= True";
                con.ConnectionString = "data source= LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "  delete from NewMember where MID = " + txtDelete.Text + "";

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DataSet DS = new DataSet();

                DA.Fill(DS);

                //dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                this.Activate();
                SqlConnection con = new SqlConnection();
                // con.ConnectionString = "data source = LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security= True";
                con.ConnectionString = "data source= LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewMember ";

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DataSet DS = new DataSet();

                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
        }

        private void DeleteMember_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            // con.ConnectionString = "data source = LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security= True";
            con.ConnectionString = "data source= LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewMember ";

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            DataSet DS = new DataSet();

            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }
    }
}

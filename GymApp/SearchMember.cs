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
    public partial class SearchMember : Form
    {
        public SearchMember()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {


                SqlConnection con = new SqlConnection();
                // con.ConnectionString = "data source = LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security= True";
                con.ConnectionString = "data source= LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = " select * from NewMember where MID = " + txtSearch.Text + "";

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DataSet DS = new DataSet();

                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                MessageBox.Show("Please enter Member id","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void SearchMember_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            // con.ConnectionString = "data source = LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security= True";
            con.ConnectionString = "data source= LAPTOP-2EMUFE1E\\SQLEXPRESS; database = gym; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = " select * from NewMember ";

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            DataSet DS = new DataSet();

            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }
    }
}

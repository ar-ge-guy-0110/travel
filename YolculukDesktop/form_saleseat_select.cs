using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace YolculukDesktop
{
    public partial class form_saleseat_select : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        form_yolculuk_main mainwin = (form_yolculuk_main)Application.OpenForms["form_yolculuk_main"];

        int gender;

        public form_saleseat_select()
        {
            InitializeComponent();
        }

        private void form_saleseat_select_Load(object sender, EventArgs e)
        {
            gender = -1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            gender = 0;
            filltheseatandbuy();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            gender = 1;
            filltheseatandbuy();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void filltheseatandbuy()
        {
            /*
            if(gender == 0)
            {
                DataTable bus = new DataTable();
                string sql1 = "SELECT * FROM bus WHERE id = " + class_ProgramMaster.seat_bus_id;
                SqlDataAdapter da = new SqlDataAdapter(sql1, conn);
                da.Fill(bus);

                int bus_ssc = Convert.ToInt32(bus.Rows[0][3]);
                int bus_msc = Convert.ToInt32(bus.Rows[0][4]);

                if(class_ProgramMaster.seat_number >= bus_msc - bus_ssc)
                {

                }



            }
            else if(gender == 1)
            {

            }
            */
            SqlCommand fillandbuytheseat = new SqlCommand("UPDATE bus_seat SET appuser_id = @user WHERE id = @sid", conn);
            fillandbuytheseat.Parameters.AddWithValue("@user", SqlDbType.Int).Value = class_ProgramMaster.logged_user_id;
            fillandbuytheseat.Parameters.AddWithValue("@sid", SqlDbType.Int).Value = class_ProgramMaster.seat_id;
            conn.Open();
            fillandbuytheseat.ExecuteNonQuery();
            conn.Close();

            DataTable fetchtotalgain = new DataTable();
            string sqll = @"SELECT company.id AS CompanyID, bus.id AS BusID, voyage.id AS VoyageID, voyage.total_seat_price FROM company 
            JOIN bus ON company.id = bus.company_id
            JOIN voyage ON bus.id = voyage.bus_id WHERE bus.id = " + class_ProgramMaster.seat_bus_id;
            SqlDataAdapter daa = new SqlDataAdapter(sqll, conn);
            daa.Fill(fetchtotalgain);

            SqlCommand gaincoin = new SqlCommand("UPDATE coin SET totalcoin = totalcoin + @gain WHERE company_id = @cd", conn);
            gaincoin.Parameters.AddWithValue("@gain", SqlDbType.Int).Value = (float)Convert.ToDouble(fetchtotalgain.Rows[0][3]);
            gaincoin.Parameters.AddWithValue("@cd", SqlDbType.Float).Value = Convert.ToInt32(fetchtotalgain.Rows[0][0]);

            conn.Open();
            gaincoin.ExecuteNonQuery();
            conn.Close();

            this.Close();


        }

        private void form_saleseat_select_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainwin.Refresh();
        }
    }
}

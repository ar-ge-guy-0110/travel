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
    public partial class form_pm_routes : Form
    {
        SqlConnection conn = class_dbconnections.connect;
        int route_id;
        public form_pm_routes()
        {
            InitializeComponent();
        }

        private void form_pm_routes_Load(object sender, EventArgs e)
        {
            route_id = -1;
            doldur();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {

                    route_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    txtcompname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                }

            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
                route_id = -1;
            }
        }

        private void doldur()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM route";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void addbutton1_Click(object sender, EventArgs e)
        {


            try
            {
                if(txtcompname.Text != "")
                {
                    DataTable controlroute = new DataTable();
                    string sql = "SELECT * FROM route WHERE route_name = N'" + txtcompname.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlroute);
                    if (controlroute.Rows.Count == 0)
                    {
                        SqlCommand addroute = new SqlCommand("INSERT INTO route(route_name) VALUES(@rn)", conn);
                        addroute.Parameters.AddWithValue("@rn", SqlDbType.NVarChar).Value = txtcompname.Text;
                        conn.Open();
                        addroute.ExecuteNonQuery();
                        conn.Close();
                        doldur();
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde bir güzergah var. Lütfen başka isim deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün bilgileri girdiğinizden emin olunuz.");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deletebutton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (route_id != -1)
                {
                    //nullify the seat's users
                    DataTable fetchroutesvoyagesbuses = new DataTable();
                    string sql1 = "SELECT voyage.departure_route_id, voyage.arrival_route_id, voyage.bus_id FROM voyage WHERE departure_route_id = " + route_id + " OR arrival_route_id = " + route_id;
                    SqlDataAdapter da = new SqlDataAdapter(sql1, conn);
                    da.Fill(fetchroutesvoyagesbuses);

                    foreach(DataRow row in fetchroutesvoyagesbuses.Rows)
                    {
                        SqlCommand emptytheseats = new SqlCommand("UPDATE bus_seat SET appuser_id = NULL WHERE bus_id = @bid", conn);
                        emptytheseats.Parameters.AddWithValue("@bid", SqlDbType.Int).Value = row[2];
                        conn.Open();
                        emptytheseats.ExecuteNonQuery();
                        conn.Close();
                    }

                    //then delete the voyages with this route
                    SqlCommand deleteroutesvoyage = new SqlCommand("DELETE FROM voyage WHERE departure_route_id = @d OR arrival_route_id = @a", conn);
                    deleteroutesvoyage.Parameters.AddWithValue("@d", SqlDbType.Int).Value = route_id;
                    deleteroutesvoyage.Parameters.AddWithValue("@a", SqlDbType.Int).Value = route_id;
                    conn.Open();
                    deleteroutesvoyage.ExecuteNonQuery();
                    conn.Close();



                    //then delete route
                    SqlCommand deleteroute = new SqlCommand("DELETE FROM route WHERE id = @rid", conn);
                    deleteroute.Parameters.AddWithValue("@rid", SqlDbType.Int).Value = route_id;
                    conn.Open();
                    deleteroute.ExecuteNonQuery();
                    conn.Close();

                    doldur();
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz güzergaha çift tıklayıp güzergahı seçili hale getiriniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updatebutton3_Click(object sender, EventArgs e)
        {
            if(route_id != -1 && txtcompname.Text != "")
            {
                try
                {
                    SqlCommand updateroute = new SqlCommand("UPDATE route SET route_name = @rname WHERE id = @id", conn);
                    updateroute.Parameters.AddWithValue("@rname", SqlDbType.NVarChar).Value = txtcompname.Text;
                    updateroute.Parameters.AddWithValue("@id", SqlDbType.Int).Value = route_id;
                    conn.Open();
                    updateroute.ExecuteNonQuery();
                    conn.Close();
                    doldur();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz güzergaha çift tıklayıp güzergahı seçili hale getiriniz. Bilgileri giriniz.");
            }
        }

        private void searchbutton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcompname.Text != "")
                {
                    string search = "SELECT TOP 200 * FROM route WHERE route_name LIKE N'%" + txtcompname.Text + "%'";
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(search, conn);
                    da2.Fill(dt2);
                    dataGridView1.DataSource = dt2;
                }
                else
                {
                    doldur();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

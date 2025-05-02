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
    public partial class form_pm_voyages : Form
    {
        SqlConnection conn = class_dbconnections.connect;
        int voyage_id;

        int companyid;
        float bus_seatprice;
        int busid;
        int departid;
        int arrivid;
        string standart;
        float totalprice;
        public form_pm_voyages()
        {
            InitializeComponent();
        }

        private void form_pm_voyages_Load(object sender, EventArgs e)
        {
            voyage_id = -1;

            companyid = -1;
            bus_seatprice = -1;
            busid = -1;
            departid = -1;
            arrivid = -1;
            standart = totalpricelabel.Text;
            totalprice = -1;

            departuringdateTimePicker.Value = DateTime.Now;
            arrivaldateTimePicker.Value = DateTime.Now;
            departtimePicker1.Value = DateTime.Now;
            arrivaltimePicker1.Value = DateTime.Now;

            try
            {
                //fill comboBox first
                conn.Open();
                SqlCommand comm1 = new SqlCommand("SELECT * FROM company", conn);
                SqlDataReader read1 = comm1.ExecuteReader();
                while (read1.Read())
                {
                    companycomboBox.Items.Add(read1["company_name"]);
                }
                conn.Close();

                conn.Open();
                SqlCommand comm2 = new SqlCommand("SELECT * FROM route", conn);
                SqlDataReader read2 = comm2.ExecuteReader();
                while (read2.Read())
                {
                    wherecomboBox.Items.Add(read2["route_name"]);
                }
                conn.Close();

                doldur();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //fix timepickers
            departtimePicker1.Format = DateTimePickerFormat.Time;
            departtimePicker1.ShowUpDown = true;
            arrivaltimePicker1.Format = DateTimePickerFormat.Time;
            arrivaltimePicker1.ShowUpDown = true;

            //To get the DateTime from both these controls use the following code
            //DateTime myDate = datePortionDateTimePicker.Value.Date +
            //                      timePortionDateTimePicker.Value.TimeOfDay; 

            //To assign the DateTime to both these controls use the following code
            //datePortionDateTimePicker.Value = myDate.Date;
            //timePortionDateTimePicker.Value = myDate.TimeOfDay;


        }

        /*
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        */



        //
        //COMBO BOX, TEXT BOX, LABEL, DATETIMEPICKER, DATAGRIDVIEW FUNCS
        //
        private void companycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (companycomboBox.SelectedIndex != -1)
                {
                    busid = -1;
                    bus_seatprice = -1;
                    totalpricelabel.Text = standart;
                    txtvoyageprice.Text = "";
                    totalprice = -1;

                    DataTable idal = new DataTable();
                    string idalsql = "SELECT id FROM company WHERE company_name = N'" + companycomboBox.SelectedItem.ToString() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                    da.Fill(idal);
                    companyid = Convert.ToInt32(idal.Rows[0][0]);

                    buscomboBox.Items.Clear();
                    conn.Open();
                    SqlCommand comm2 = new SqlCommand("SELECT * FROM bus WHERE company_id = " + companyid, conn);
                    SqlDataReader read2 = comm2.ExecuteReader();
                    while (read2.Read())
                    {
                        buscomboBox.Items.Add(read2["busname"]);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(buscomboBox.SelectedIndex != -1)
                {
                    DataTable idal = new DataTable();
                    string idalsql = "SELECT id, seat_price FROM bus WHERE busname = N'" + buscomboBox.SelectedItem.ToString() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                    da.Fill(idal);
                    busid = Convert.ToInt32(idal.Rows[0][0]);
                    bus_seatprice = (float)Convert.ToDouble(idal.Rows[0][1]);
                    txtvoyageprice.Text = "";
                    totalpricelabel.Text = standart;
                    totalprice = -1;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wherecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (wherecomboBox.SelectedIndex != -1)
                {
                    arrivid = -1;


                    DataTable idal = new DataTable();
                    string idalsql = "SELECT id FROM route WHERE route_name = N'" + wherecomboBox.SelectedItem.ToString() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                    da.Fill(idal);
                    departid = Convert.ToInt32(idal.Rows[0][0]);

                    whichcomboBox.Items.Clear();
                    conn.Open();
                    SqlCommand comm2 = new SqlCommand("SELECT * FROM route WHERE NOT id = " + departid, conn);
                    SqlDataReader read2 = comm2.ExecuteReader();
                    while (read2.Read())
                    {
                        whichcomboBox.Items.Add(read2["route_name"]);
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void whichcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(whichcomboBox.SelectedIndex != -1)
            {
                DataTable idal = new DataTable();
                string idalsql = "SELECT id FROM route WHERE route_name = N'" + whichcomboBox.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                da.Fill(idal);
                arrivid = Convert.ToInt32(idal.Rows[0][0]);
            }


        }

        private void txtvoyageprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //float

            // allows 0-9, dot, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 46 && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void txtvoyageprice_TextChanged(object sender, EventArgs e)
        {
            if(busid != -1)
            {
                if(txtvoyageprice.Text != "")
                {
                    totalpricelabel.Text = standart;
                    //float voyageprice = bus_seatprice + txtvoyageprice
                    totalpricelabel.Text = standart + " " + (bus_seatprice + ((float)Convert.ToDouble(txtvoyageprice.Text)));
                    totalprice = (bus_seatprice + ((float)Convert.ToDouble(txtvoyageprice.Text)));
                }
            }
            else
            {
                if(buscomboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen otobüsü seçiniz.");
                }
                txtvoyageprice.Text = "";

            }
        }

        private void doldur()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT voyage.id AS 'Voyage ID', company.company_name AS 'Company', route.route_name AS 'Departure Point', route2.route_name AS 'Arrival Point', 
            bus.busname AS 'Bus Name', bus.seat_price AS 'Seat Price', voyage.voyage_price AS 'Voyage Price', 
            voyage.total_seat_price AS 'Total Travel Price', voyage.voyage_departure_datetime AS 'Departure Time', 
            voyage.voyage_arrival_datetime AS 'Arrival Time' FROM voyage 
            JOIN route ON route.id = voyage.departure_route_id 
            JOIN route AS route2 ON route2.id = voyage.arrival_route_id 
            JOIN bus ON voyage.bus_id = bus.id 
            JOIN company ON bus.company_id = company.id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {

                    voyage_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    companycomboBox.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    buscomboBox.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    wherecomboBox.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    whichcomboBox.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txtvoyageprice.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    departuringdateTimePicker.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value.ToString());
                    departtimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value.ToString());
                    arrivaldateTimePicker.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[9].Value.ToString());
                    arrivaltimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[9].Value.ToString());

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
                MessageBox.Show(ex.Message);
                voyage_id = -1;
                companycomboBox.SelectedIndex = -1;
                buscomboBox.SelectedIndex = -1;
                wherecomboBox.SelectedIndex = -1;
                whichcomboBox.SelectedIndex = -1;
                txtvoyageprice.Text = "";
                departuringdateTimePicker.Value = DateTime.Now;
                arrivaldateTimePicker.Value = DateTime.Now;
                departtimePicker1.Value = DateTime.Now;
                arrivaltimePicker1.Value = DateTime.Now;
            }
        }



        //
        //BUTTONS
        //

        private void addbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(busid != -1 && departid != -1 && arrivid != -1 && txtvoyageprice.Text != "" && totalpricelabel.Text != standart && departuringdateTimePicker.Checked && arrivaldateTimePicker.Checked && departtimePicker1.Checked && arrivaldateTimePicker.Checked)
                {
                    //control the company's bus not have multiple voyage at the same time.
                    DataTable controlthebuses = new DataTable();
                    string sql = "SELECT bus_id FROM voyage WHERE bus_id = " + busid;
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlthebuses);

                    if(controlthebuses.Rows.Count == 0)
                    {
                        DateTime departtime = departuringdateTimePicker.Value.Date + departtimePicker1.Value.TimeOfDay;
                        DateTime arrivaltime = arrivaldateTimePicker.Value.Date + arrivaltimePicker1.Value.TimeOfDay;

                        SqlCommand addvoyage = new SqlCommand("INSERT INTO voyage(departure_route_id, arrival_route_id, bus_id, voyage_price, total_seat_price, voyage_departure_datetime, voyage_arrival_datetime)" +
                            " VALUES(@dr, @ar, @bid, @voyprice, @total, @dt, @at)", conn);
                        addvoyage.Parameters.AddWithValue("@dr", SqlDbType.Int).Value = departid;
                        addvoyage.Parameters.AddWithValue("@ar", SqlDbType.Int).Value = arrivid;
                        addvoyage.Parameters.AddWithValue("@bid", SqlDbType.Int).Value = busid;
                        addvoyage.Parameters.AddWithValue("@voyprice", SqlDbType.Float).Value = (float) Convert.ToDouble(txtvoyageprice.Text);
                        addvoyage.Parameters.AddWithValue("@total", SqlDbType.Float).Value = totalprice;
                        addvoyage.Parameters.AddWithValue("@dt", SqlDbType.DateTime).Value = departtime;
                        addvoyage.Parameters.AddWithValue("@at", SqlDbType.DateTime).Value = arrivaltime;

                        conn.Open();
                        addvoyage.ExecuteNonQuery();
                        conn.Close();
                        doldur();

                    }
                    else
                    {
                        MessageBox.Show("Şirketin bu otobüsünün halihazırda bir seferi var. Lütfen başka otobüsü kullanın.");
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
            if(voyage_id != -1 && busid != -1)
            {
                try
                {
                    
                    SqlCommand nullifyseatsfromusers = new SqlCommand("UPDATE bus_seat SET appuser_id = NULL WHERE bus_id = @bid", conn);
                    nullifyseatsfromusers.Parameters.AddWithValue("@bid", SqlDbType.Int).Value = busid;
                    conn.Open();
                    nullifyseatsfromusers.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand deletevoyage = new SqlCommand("DELETE FROM voyage WHERE id = @id", conn);
                    deletevoyage.Parameters.AddWithValue("@id", SqlDbType.Int).Value = voyage_id;
                    conn.Open();
                    deletevoyage.ExecuteNonQuery();
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
                MessageBox.Show("Lütfen silmek istediğiniz sefere çift tıklayıp seferi seçili hale getiriniz.");
            }
        }

        private void updatebutton3_Click(object sender, EventArgs e)
        {
            if(voyage_id != -1 && busid != -1 && departid != -1 && arrivid != -1 && txtvoyageprice.Text != "" && totalpricelabel.Text != standart && departuringdateTimePicker.Checked && arrivaldateTimePicker.Checked && departtimePicker1.Checked && arrivaldateTimePicker.Checked)
            {
                try
                {
                    SqlCommand nullifyseatsfromusers = new SqlCommand("UPDATE bus_seat SET appuser_id = NULL WHERE bus_id = @bid", conn);
                    nullifyseatsfromusers.Parameters.AddWithValue("@bid", SqlDbType.Int).Value = busid;
                    conn.Open();
                    nullifyseatsfromusers.ExecuteNonQuery();
                    conn.Close();

                    DateTime departtime = departuringdateTimePicker.Value.Date + departtimePicker1.Value.TimeOfDay;
                    DateTime arrivaltime = arrivaldateTimePicker.Value.Date + arrivaltimePicker1.Value.TimeOfDay;

                    SqlCommand updatevoyage = new SqlCommand("UPDATE voyage SET departure_route_id = @dr, arrival_route_id = @ar, bus_id = @bid, voyage_price = @vp, total_seat_price = @tp, voyage_departure_datetime = @dt, voyage_arrival_datetime = @at WHERE id = @id", conn);
                    updatevoyage.Parameters.AddWithValue("@dr", SqlDbType.Int).Value = departid;
                    updatevoyage.Parameters.AddWithValue("@ar", SqlDbType.Int).Value = arrivid;
                    updatevoyage.Parameters.AddWithValue("@bid", SqlDbType.Int).Value = busid;
                    updatevoyage.Parameters.AddWithValue("@vp", SqlDbType.Float).Value = (float)Convert.ToDouble(txtvoyageprice.Text);
                    updatevoyage.Parameters.AddWithValue("@tp", SqlDbType.Float).Value = totalprice;
                    updatevoyage.Parameters.AddWithValue("@dt", SqlDbType.DateTime).Value = departtime;
                    updatevoyage.Parameters.AddWithValue("@at", SqlDbType.DateTime).Value = arrivaltime;
                    updatevoyage.Parameters.AddWithValue("@id", SqlDbType.Int).Value = voyage_id;

                    conn.Open();
                    updatevoyage.ExecuteNonQuery();
                    conn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz sefere çift tıklayıp seferi seçili hale getiriniz.");
            }
        }

        private void searchbutton4_Click(object sender, EventArgs e)
        {
            string search = "";


            string cmd_start = "SELECT TOP 200";
            string cmd_middle = @" voyage.id AS 'Voyage ID', company.company_name AS 'Company', route.route_name AS 'Departure Point', route2.route_name AS 'Arrival Point', 
                                  bus.busname AS 'Bus Name', bus.seat_price AS 'Seat Price', voyage.voyage_price AS 'Voyage Price', 
                                  voyage.total_seat_price AS 'Total Travel Price', voyage.voyage_departure_datetime AS 'Departure Time', 
                                  voyage.voyage_arrival_datetime AS 'Arrival Time' ";
            string cmd_end = @"FROM voyage 
                             JOIN route ON route.id = voyage.departure_route_id 
                             JOIN route AS route2 ON route2.id = voyage.arrival_route_id 
                             JOIN bus ON voyage.bus_id = bus.id 
                             JOIN company ON bus.company_id = company.id WHERE";

            int cmdend_length = cmd_end.Length;

            if (companycomboBox.SelectedIndex != -1)
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " company.company_name LIKE N'%" + companycomboBox.SelectedItem.ToString() + "%'";
            }

            if (buscomboBox.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " bus.busname LIKE N'%" + buscomboBox.SelectedItem.ToString() + "%'";
            }

            if (wherecomboBox.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " route.route_name LIKE N'%" + wherecomboBox.SelectedItem.ToString() + "%'";
            }

            if (whichcomboBox.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " route2.route_name LIKE N'%" + whichcomboBox.SelectedItem.ToString() + "%'";
            }

            if (txtvoyageprice.Text != "")
            {
                float voyageprice = (float) Convert.ToDouble(txtvoyageprice.Text);

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " voyage.voyage_price <= " + voyageprice;
            }

            if (departuringdateTimePicker.Checked && arrivaldateTimePicker.Checked && (departuringdateTimePicker.Value != arrivaldateTimePicker.Value))
            {
                DateTime departtime = departuringdateTimePicker.Value.Date + departtimePicker1.Value.TimeOfDay;
                DateTime arrivaltime = arrivaldateTimePicker.Value.Date + arrivaltimePicker1.Value.TimeOfDay;

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " voyage_departure_datetime >= '" + departtime + "' AND voyage_arrival_datetime <= '" + arrivaltime + "'";
            }


            search = cmd_start + cmd_middle + cmd_end;

            if (companycomboBox.SelectedIndex != -1 || buscomboBox.SelectedIndex != -1 || wherecomboBox.SelectedIndex != -1 || whichcomboBox.SelectedIndex != -1 || txtvoyageprice.Text != "" || (departuringdateTimePicker.Checked && arrivaldateTimePicker.Checked && (departuringdateTimePicker.Value != arrivaldateTimePicker.Value)))
            {
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

        private void listallbutton1_Click(object sender, EventArgs e)
        {
            doldur();
        }

        private void clearbutton1_Click(object sender, EventArgs e)
        {
            voyage_id = -1;
            companycomboBox.SelectedIndex = -1;
            buscomboBox.SelectedIndex = -1;
            wherecomboBox.SelectedIndex = -1;
            whichcomboBox.SelectedIndex = -1;
            txtvoyageprice.Text = "";
            departuringdateTimePicker.Value = DateTime.Now;
            arrivaldateTimePicker.Value = DateTime.Now;
            departtimePicker1.Value = DateTime.Now;
            arrivaltimePicker1.Value = DateTime.Now;
            totalpricelabel.Text = standart;
        }
    }
}

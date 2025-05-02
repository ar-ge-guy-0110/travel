using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace YolculukDesktop
{
    public partial class form_pm_buses : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        int company_id;
        int bus_id;
        public form_pm_buses()
        {
            InitializeComponent();
        }

        private void form_pm_buses_Load(object sender, EventArgs e)
        {
            doldur();
            doldur2();
            company_id = -1;
            bus_id = -1;

        }

        private void doldur()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM company";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        }

        private void doldur2()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM bus";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {


            try
            {
                if (dataGridView1.CurrentRow != null)
                {

                    company_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    buspanel.Visible = true;

                }

            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
                company_id = -1;
                buspanel.Visible = false;
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {

                    bus_id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                    txtbusname.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    txtsscount.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                    txtsmcount.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                    txtseatprice.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                    class_ProgramMaster.this_bus_id = bus_id;

                }

            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
                bus_id = -1;
            }
        }

        private void txtsscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int

            // allows 0-9, backspace
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
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

        private void txtsmcount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int

            // allows 0-9, backspace
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
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

        private void txtseatprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void addbutton1_Click(object sender, EventArgs e)
        {

            try
            {
                //otobüs ekle
                if ( company_id != -1 && txtbusname.Text != "" && txtsscount.Text != "" && txtsmcount.Text != "" && txtseatprice.Text != "")
                {
                    DataTable controlbuses = new DataTable();
                    string sql = "SELECT * FROM bus WHERE company_id = " + company_id + " AND busname = N'" + txtbusname.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlbuses);

                    if (controlbuses.Rows.Count == 0)
                    {
                        int idbull;

                        SqlCommand addbus = new SqlCommand("INSERT INTO bus(company_id, busname, single_seat_count, tworthree_seat_count, seat_price) VALUES(@cid, @busname, @sscount, @mscount, @sp) SELECT SCOPE_IDENTITY()", conn);
                        addbus.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = company_id;
                        addbus.Parameters.AddWithValue("@busname", SqlDbType.NVarChar).Value = txtbusname.Text;
                        addbus.Parameters.AddWithValue("@sscount", SqlDbType.Int).Value = Convert.ToInt32(txtsscount.Text);
                        addbus.Parameters.AddWithValue("@mscount", SqlDbType.Int).Value = Convert.ToInt32(txtsmcount.Text);
                        addbus.Parameters.AddWithValue("@sp", SqlDbType.Float).Value = (float) Convert.ToDouble(txtseatprice.Text);
                        conn.Open();
                        idbull = Convert.ToInt32(addbus.ExecuteScalar());
                        conn.Close();
                        doldur2();


                        //add bus's seats
                        int sc = Convert.ToInt32(txtsscount.Text) + Convert.ToInt32(txtsmcount.Text);
                        for(int c = 1; c <= sc; c++)
                        {
                            SqlCommand addseattobus = new SqlCommand("INSERT INTO bus_seat(seat_number, bus_id) VALUES(@sn, @bsid)", conn);
                            addseattobus.Parameters.AddWithValue("@sn", SqlDbType.Int).Value = c;
                            addseattobus.Parameters.AddWithValue("@bsid", SqlDbType.Int).Value = idbull;
                            conn.Open();
                            addseattobus.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu firmanın bu ada sahip otobüsü bulunmaktadır. Lütfen otobüse başka bir ad veriniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bilgileri doğru girdiğinizden emin olunuz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deletebutton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bus_id != -1)
                {
                    //delete the voyages first,
                    SqlCommand deletebussvoyage = new SqlCommand("DELETE FROM voyage WHERE bus_id = @bid", conn);
                    deletebussvoyage.Parameters.AddWithValue("@bid", SqlDbType.Int).Value = bus_id;
                    conn.Open();
                    deletebussvoyage.ExecuteNonQuery();
                    conn.Close();



                    //then delete buses but first, delete buses seats...
                    SqlCommand deletebusseats = new SqlCommand("DELETE FROM bus_seat WHERE bus_id = @bsid", conn);
                    deletebusseats.Parameters.AddWithValue("@bsid", SqlDbType.Int).Value = bus_id;
                    conn.Open();
                    deletebusseats.ExecuteNonQuery();
                    conn.Close();


                    SqlCommand deletebuses = new SqlCommand("DELETE FROM bus WHERE id = @bid", conn);
                    deletebuses.Parameters.AddWithValue("@bid", SqlDbType.Int).Value = bus_id;
                    conn.Open();
                    deletebuses.ExecuteNonQuery();
                    conn.Close();

                    doldur2();
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz otobüse çift tıklayıp otobüsü seçili hale getiriniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updatebutton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (bus_id != -1)
                {

                    if(txtbusname.Text != "" && txtsscount.Text != "" && txtsmcount.Text != "" && txtseatprice.Text != "")
                    {
                        DialogResult areyousure = MessageBox.Show("Bu otobüs güncellenirse, otobüse bağlı seferler ve koltuklar silinecek ve tekrar oluşturulacak. Emin misiniz?", "Emin misiniz!?", MessageBoxButtons.YesNo);
                        if (areyousure == DialogResult.Yes)
                        {
                            //delete the voyages first,
                            SqlCommand deletebussvoyage = new SqlCommand("DELETE FROM voyage WHERE bus_id = @bid", conn);
                            deletebussvoyage.Parameters.AddWithValue("@bid", SqlDbType.Int).Value = bus_id;
                            conn.Open();
                            deletebussvoyage.ExecuteNonQuery();
                            conn.Close();



                            //delete buses seats...
                            SqlCommand deletebusseats = new SqlCommand("DELETE FROM bus_seat WHERE bus_id = @bsid", conn);
                            deletebusseats.Parameters.AddWithValue("@bsid", SqlDbType.Int).Value = bus_id;
                            conn.Open();
                            deletebusseats.ExecuteNonQuery();
                            conn.Close();


                            //update bus
                            SqlCommand updatebus = new SqlCommand("UPDATE bus SET busname = @bname, single_seat_count = @ssc, tworthree_seat_count = @msc, seat_price = @sp WHERE id = @bsid", conn);
                            updatebus.Parameters.AddWithValue("@bname", SqlDbType.NVarChar).Value = txtbusname.Text;
                            updatebus.Parameters.AddWithValue("@ssc", SqlDbType.Int).Value = Convert.ToInt32(txtsscount.Text);
                            updatebus.Parameters.AddWithValue("@msc", SqlDbType.Int).Value = Convert.ToInt32(txtsmcount.Text);
                            updatebus.Parameters.AddWithValue("@sp", SqlDbType.Float).Value = (float) Convert.ToDouble(txtseatprice.Text);
                            updatebus.Parameters.AddWithValue("@bsid", SqlDbType.Int).Value = bus_id;
                            conn.Open();
                            updatebus.ExecuteNonQuery();
                            conn.Close();

                            //add bus's seats
                            int sc = Convert.ToInt32(txtsscount.Text) + Convert.ToInt32(txtsmcount.Text);
                            for (int c = 1; c <= sc; c++)
                            {
                                SqlCommand addseattobus = new SqlCommand("INSERT INTO bus_seat(seat_number, bus_id) VALUES(@sn, @bsid)", conn);
                                addseattobus.Parameters.AddWithValue("@sn", SqlDbType.Int).Value = c;
                                addseattobus.Parameters.AddWithValue("@bsid", SqlDbType.Int).Value = bus_id;
                                conn.Open();
                                addseattobus.ExecuteNonQuery();
                                conn.Close();
                            }

                            bus_id = -1;
                            doldur2();
                        }
                        else
                        {
                            MessageBox.Show("İşlem başarıyla iptal edildi.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bilgilerin hepsini girdiğinizden emin olunuz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz otobüse çift tıklayıp otobüsü seçili hale getiriniz.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchbutton4_Click(object sender, EventArgs e)
        {
            string search = "";


            string cmd_start = "SELECT";
            string cmd_middle = @" * ";
            string cmd_end = @"FROM bus WHERE";

            int cmdend_length = cmd_end.Length;

            if (txtbusname.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " busname LIKE '%" + txtbusname.Text + "%'";
            }

            if (txtsscount.Text != "")
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " single_seat_count LIKE '%" + Convert.ToInt32(txtsscount.Text) + "%'";
            }

            if (txtsmcount.Text != "")
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tworthree_seat_count LIKE '%" + Convert.ToInt32(txtsmcount.Text) + "%'";
            }

            if (txtseatprice.Text != "")
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " seat_price LIKE '%" + Convert.ToInt32(txtseatprice.Text) + "%'";
            }

            search = cmd_start + cmd_middle + cmd_end;

            if (txtbusname.Text != "" || txtsscount.Text != "" || txtsmcount.Text != "" || txtseatprice.Text != "")
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(search, conn);
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
            }
            else
            {
                doldur2();
            }
        }

        private void listallbutton1_Click(object sender, EventArgs e)
        {
            doldur2();
        }

        private void searchbycompanybutton2_Click(object sender, EventArgs e)
        {
            string search = "";


            string cmd_start = "SELECT";
            string cmd_middle = @" * ";
            string cmd_end = @"FROM bus WHERE";

            int cmdend_length = cmd_end.Length;

            if (txtbusname.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " busname LIKE '%" + txtbusname.Text + "%'";
            }

            if (txtsscount.Text != "")
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " single_seat_count LIKE '%" + Convert.ToInt32(txtsscount.Text) + "%'";
            }

            if (txtsmcount.Text != "")
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tworthree_seat_count LIKE '%" + Convert.ToInt32(txtsmcount.Text) + "%'";
            }

            if (txtseatprice.Text != "")
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " seat_price LIKE '%" + Convert.ToInt32(txtseatprice.Text) + "%'";
            }

            search = cmd_start + cmd_middle + cmd_end;

            if (txtbusname.Text != "" || txtsscount.Text != "" || txtsmcount.Text != "" || txtseatprice.Text != "")
            {
                search += " AND company_id = " + company_id;
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(search, conn);
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    string sql = "SELECT * FROM bus WHERE company_id = " + company_id;
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void seethebusbutton3_Click(object sender, EventArgs e)
        {
            if(bus_id != -1)
            {
                Form seethebus = new form_seethebus();
                seethebus.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen görmek istediğiniz otobüsü seçiniz.");
            }

        }


    }
}

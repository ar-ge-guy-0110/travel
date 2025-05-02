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
using System.IO;

namespace YolculukDesktop
{
    public partial class form_pm_companies : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        int company_id;

        //paths
        string imgLoc = "";
        SqlCommand command;

        public form_pm_companies()
        {
            InitializeComponent();
        }

        private void form_pm_companies_Load(object sender, EventArgs e)
        {
            company_id = -1;
            doldur();
        }

        private void addbutton1_Click(object sender, EventArgs e)
        {

            try
            {
                //firma ekle
                if (txtcompname.Text != "")
                {
                    DataTable controlcomp = new DataTable();
                    string sql = "SELECT * FROM company WHERE company_name = N'" + txtcompname.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlcomp);

                    if (controlcomp.Rows.Count == 0)
                    {
                        int idbull;
                        SqlCommand addcomp = new SqlCommand("INSERT INTO company(company_name) VALUES(@c) SELECT SCOPE_IDENTITY()", conn);
                        addcomp.Parameters.AddWithValue("@c", SqlDbType.NVarChar).Value = txtcompname.Text;
                        conn.Open();
                        idbull = Convert.ToInt32(addcomp.ExecuteScalar());
                        conn.Close();

                        SqlCommand addcompcoin = new SqlCommand("INSERT INTO coin(company_id, totalcoin) VALUES(@cid, @tc)", conn);
                        addcompcoin.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = idbull;
                        addcompcoin.Parameters.AddWithValue("@tc", SqlDbType.Float).Value = 0;
                        conn.Open();
                        addcompcoin.ExecuteNonQuery();
                        conn.Close();
                        doldur();
                    }
                    else
                    {
                        MessageBox.Show("Bu firma adı kullanılmaktadır.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bilgileri doğru girdiğinizden emin olunuz.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deletebutton2_Click(object sender, EventArgs e)
        {
            //firma sil



            try
            {
                if (company_id != -1)
                {
                    //delete the voyages first,
                    //but first things first, fetch those from companies and buses.
                    DataTable fetchvoyg = new DataTable();
                    string sql = @"SELECT company.id AS CompanyID, bus.id AS BusID, voyage.id AS VoyageID FROM company 
                             JOIN bus ON company.id = bus.company_id 
                             JOIN voyage ON bus.id = voyage.bus_id WHERE company_id = " + company_id;
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(fetchvoyg);

                    foreach (DataRow row in fetchvoyg.Rows)
                    {
                        SqlCommand deletecompsvoyage = new SqlCommand("DELETE FROM voyage WHERE id = @vid", conn);
                        deletecompsvoyage.Parameters.AddWithValue("@vid", SqlDbType.Int).Value = row[2];
                        conn.Open();
                        deletecompsvoyage.ExecuteNonQuery();
                        conn.Close();
                    }


                    //then delete buses but first, delete buses seats...
                    DataTable fetchseats = new DataTable();
                    string sql2 = @"SELECT company.id AS CompanyID, bus.id AS BusID, bus_seat.id AS BusSeatID FROM company 
                              JOIN bus ON company.id = bus.company_id 
                              JOIN bus_seat ON bus.id = bus_seat.bus_id WHERE company_id = " + company_id;
                    da.SelectCommand.CommandText = sql2;
                    da.Fill(fetchseats);

                    foreach (DataRow row2 in fetchseats.Rows)
                    {
                        SqlCommand deletecompsseats = new SqlCommand("DELETE FROM bus_seat WHERE id = @bsid", conn);
                        deletecompsseats.Parameters.AddWithValue("@bsid", SqlDbType.Int).Value = row2[2];
                        conn.Open();
                        deletecompsseats.ExecuteNonQuery();
                        conn.Close();
                    }

                    SqlCommand deletebuses = new SqlCommand("DELETE FROM bus WHERE company_id = @cid", conn);
                    deletebuses.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = company_id;
                    conn.Open();
                    deletebuses.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand deletecoin = new SqlCommand("DELETE FROM coin WHERE company_id = @id", conn);
                    deletecoin.Parameters.AddWithValue("@id", SqlDbType.Int).Value = company_id;
                    conn.Open();
                    deletecoin.ExecuteNonQuery();
                    conn.Close();

                    //in the end, delete the company...
                    SqlCommand deletethecompany = new SqlCommand("DELETE FROM company WHERE id = @id", conn);
                    deletethecompany.Parameters.AddWithValue("@id", SqlDbType.Int).Value = company_id;
                    conn.Open();
                    deletethecompany.ExecuteNonQuery();
                    conn.Close();

                    doldur();
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz firmaya çift tıklayıp firmayı seçili hale getiriniz.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updatebutton3_Click(object sender, EventArgs e)
        {
            //firma güncelle


            try
            {
                if (company_id != -1 && txtcompname.Text != "")
                {
                    SqlCommand updatecompany = new SqlCommand("UPDATE company SET company_name = @cname WHERE id = @id", conn);
                    updatecompany.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = txtcompname.Text;
                    updatecompany.Parameters.AddWithValue("@id", SqlDbType.Int).Value = company_id;
                    conn.Open();
                    updatecompany.ExecuteNonQuery();
                    conn.Close();
                    doldur();

                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz firmaya çift tıklayıp firmayı seçili hale getiriniz ve adı yazınız.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchbutton4_Click(object sender, EventArgs e)
        {
            //firma ara


            try
            {
                if (txtcompname.Text != "")
                {
                    string search = "SELECT TOP 200 * FROM company WHERE company_name LIKE N'%" + txtcompname.Text + "%'";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void doldur()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM company";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                if (dataGridView1.CurrentRow != null)
                {

                    company_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    txtcompname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                }

            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
                company_id = -1;
            }
        }

        private void browsebutton4_Click(object sender, EventArgs e)
        {
            //browse images
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                dlg.Title = "Select an Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void savebutton3_Click(object sender, EventArgs e)
        {
            //save image from company
            if (company_id != -1)
            {
                DataTable imagecontrol = new DataTable();
                string idhasimage = "SELECT company_id FROM images_company WHERE company_id = " + company_id;
                SqlDataAdapter da = new SqlDataAdapter(idhasimage, conn);
                da.Fill(imagecontrol);

                if (imagecontrol.Rows.Count == 1)
                {
                    imgLoc = "";
                    company_id = -1;
                    pictureBox1.Image = null;
                }
            }


            if (company_id != -1 && imgLoc != "" && pictureBox1.Image != null)
            {

                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    string sql = "INSERT INTO images_company(company_id, image) VALUES(" + company_id + ", @img)";
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@img", img));
                    int x = command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show(x.ToString() + "record(s) saved.");

                    imgLoc = "";
                    company_id = -1;
                    pictureBox1.Image = null;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen nesneyi ve resmi seçin. Eğer seçiliyse bu nesnenin resmi var demektir.");
            }
        }

        private void showbutton2_Click(object sender, EventArgs e)
        {
            //show the company's image
            try
            {
                if (company_id != -1)
                {
                    string sql = "SELECT image FROM images_company WHERE company_id = " + company_id;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] img = (byte[])(reader[0]);
                        if (img == null)
                        {
                            pictureBox1.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu nesnenin resmi yok.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen resmini görmek istediğiniz nesneyi çift tıklayarak seçili hale getiriniz.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void deletebutton1_Click(object sender, EventArgs e)
        {
            //delete company's image
            if (company_id != -1)
            {
                DialogResult areyousure = MessageBox.Show("Bu resim silinecek. Emin misiniz?", "Emin misiniz!?", MessageBoxButtons.YesNo);
                if (areyousure == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand deleteimage = new SqlCommand("DELETE FROM images_company WHERE company_id = @btid", conn);
                        deleteimage.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = company_id;
                        conn.Open();
                        deleteimage.ExecuteNonQuery();
                        conn.Close();
                        pictureBox1.Image = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen resmini silmek istediğiniz nesneyi çift tıklayarak seçili hale getiriniz.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtcompname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form gainin = new form_company_gains();
            gainin.ShowDialog();
        }
    }
}

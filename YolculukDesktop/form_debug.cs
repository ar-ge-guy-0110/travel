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
using System.IO;

namespace YolculukDesktop
{
    public partial class form_debug : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        int imgid;
        SqlCommand command;
        string imgLoc = "";

        public form_debug()
        {
            InitializeComponent();
        }

        private void form_debug_Load(object sender, EventArgs e)
        {
            imgid = -1;
            doldur();
        }

        private void doldur()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM images_misc";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                dlg.Title = "Select an Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgLoc;
                    pictureBox2.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (imgLoc != "" && pictureBox1.Image != null)
            {

                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    string sql = "INSERT INTO images_misc(image_name, image) VALUES(@iname, @img)";
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@img", img));
                    command.Parameters.Add(new SqlParameter("@iname", textBox1.Text));
                    int x = command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show(x.ToString() + "record(s) saved.");

                    imgLoc = "";
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select the image.");
            }
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgid != -1)
                {
                    string sql = "SELECT image FROM images_misc WHERE id = " + imgid;
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
                            pictureBox2.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            pictureBox1.Image = Image.FromStream(ms);
                            pictureBox2.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bunun resmi yok.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select the image.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (imgid != -1)
            {
                DialogResult areyousure = MessageBox.Show("This picture will be deleted. Are you sure?", "Sure!", MessageBoxButtons.YesNo);
                if (areyousure == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand deleteimage = new SqlCommand("DELETE FROM images_misc WHERE id = @btid", conn);
                        deleteimage.Parameters.AddWithValue("@btid", SqlDbType.Int).Value = imgid;
                        conn.Open();
                        deleteimage.ExecuteNonQuery();
                        conn.Close();
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the image.");
            }
            dataGridView1.Refresh();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {

                    imgid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                }

            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
                imgid = -1;
            }
        }
    }
}

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
    public partial class form_user_register : Form
    {
        SqlConnection conn = class_dbconnections.connect;
        public form_user_register()
        {
            InitializeComponent();
        }

        private void form_user_register_Load(object sender, EventArgs e)
        {
            infoLabel1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtemail.Text != "" && txtpassword.Text != "")
                {
                    bool isEmail = false;
                    foreach (char c in txtemail.Text)
                    {
                        if (c == 64)
                        {
                            isEmail = true;
                        }
                    }

                    if (isEmail)
                    {
                        DataTable accounts = new DataTable();
                        string sql = "SELECT email FROM appuser WHERE email = N'" + txtemail.Text + "'";
                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                        da.Fill(accounts);

                        if (accounts.Rows.Count == 0)
                        {
                            SqlCommand add = new SqlCommand("INSERT INTO appuser(email, password) VALUES(@e, @p)", conn);
                            add.Parameters.AddWithValue("@e", SqlDbType.NVarChar).Value = txtemail.Text;
                            add.Parameters.AddWithValue("@p", SqlDbType.NVarChar).Value = txtpassword.Text;



                            conn.Open();
                            add.ExecuteNonQuery();
                            conn.Close();

                            infoLabel1.Text = "Kayıt Başarılı. Giriş Yapabilirsiniz.";
                        }
                        else
                        {
                            infoLabel1.Text = "Bu hesap zaten kayıtlı!";
                        }
                    }
                    else
                    {
                        infoLabel1.Text = "E-postanızı doğru giriniz!";
                    }
                }
                else
                {
                    infoLabel1.Text = "Lütfen bilgilerinizi eksiksiz giriniz!";
                }
            }
            catch
            {
                MessageBox.Show("Oops...There was an error. Please retry for another time.");
            }
        }
    }
}

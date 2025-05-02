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
    public partial class form_user_login : Form
    {
        SqlConnection conn = class_dbconnections.connect;
        public form_user_login()
        {
            InitializeComponent();
        }

        private void form_user_login_Load(object sender, EventArgs e)
        {
            infoLabel1.Text = "";
            class_ProgramMaster.mainloginform = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtemail.Text != "" && txtpassword.Text != "")
            {

                DataTable accounts = new DataTable();
                string sql = "SELECT * FROM appuser WHERE email = N'" + txtemail.Text + "' AND " + "password = N'" + txtpassword.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(accounts);

                if (accounts.Rows.Count == 1)
                {
                    infoLabel1.Text = "";
                    class_ProgramMaster.logged_user = accounts.Rows[0][1].ToString();
                    class_ProgramMaster.logged_user_id = Convert.ToInt32(accounts.Rows[0][0]);
                    class_ProgramMaster.logged_user_authority = Convert.ToInt32(accounts.Rows[0][3]);

                    if(class_ProgramMaster.logged_user_authority == 1)
                    {
                        infoLabel1.Text = "Siz müşterisiniz.";
                        this.Hide();
                        Form customerpanel = new form_yolculuk_main();
                        customerpanel.ShowDialog();
                    }
                    else if(class_ProgramMaster.logged_user_authority == 2)
                    {
                        infoLabel1.Text = "Siz sistem yöneticisiniz.";
                        this.Hide();
                        Form adminpanel = new form_pm_panel();
                        adminpanel.ShowDialog();


                    }
                }
                else
                {
                    infoLabel1.Text = "Kayıtlarımızda böyle bir hesap bulunamadı.";
                }

            }
            else
            {
                infoLabel1.Text = "Lütfen bilgilerinizi eksiksiz giriniz!";
            }
        }

        private void registerlabel_MouseEnter(object sender, EventArgs e)
        {
            registerlabel.ForeColor = Color.FromArgb(45, 106, 237);
        }

        private void registerlabel_MouseLeave(object sender, EventArgs e)
        {
            registerlabel.ForeColor = Color.FromArgb(45, 146, 237);
        }

        private void registerlabel_Click(object sender, EventArgs e)
        {
            Form form_user_register = new form_user_register();
            form_user_register.ShowDialog();
        }
    }
}

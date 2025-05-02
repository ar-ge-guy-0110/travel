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
    public partial class form_company_gains : Form
    {
        SqlConnection conn = class_dbconnections.connect;
        public form_company_gains()
        {
            InitializeComponent();
        }

        private void form_company_gains_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void doldur()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT company.id, company.company_name, coin.totalcoin FROM company JOIN coin ON company.id = coin.company_id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void searchbutton4_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtcompname.Text != "")
                {
                    if(textBox1.Text != "")
                    {
                        string search = "SELECT company.id, company.company_name, coin.totalcoin FROM company JOIN coin ON company.id = coin.company_id WHERE company_name LIKE N'%" + txtcompname.Text + "%' AND totalcoin <= " + ((float)Convert.ToDouble(textBox1.Text));
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(search, conn);
                        da2.Fill(dt2);
                        dataGridView1.DataSource = dt2;

                    }
                    else
                    {
                        string search = "SELECT TOP 200 * FROM company WHERE company_name LIKE N'%" + txtcompname.Text + "%'";
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(search, conn);
                        da2.Fill(dt2);
                        dataGridView1.DataSource = dt2;
                    }
                }
                else
                {
                    if (textBox1.Text != "")
                    {
                        string search = "SELECT company.id, company.company_name, coin.totalcoin FROM company JOIN coin ON company.id = coin.company_id WHERE totalcoin <= " + ((float)Convert.ToDouble(textBox1.Text));
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(search, conn);
                        da2.Fill(dt2);
                        dataGridView1.DataSource = dt2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doldur();
        }
    }
}

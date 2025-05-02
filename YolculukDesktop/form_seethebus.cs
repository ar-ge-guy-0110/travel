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
    public partial class form_seethebus : Form
    {
        SqlConnection conn = class_dbconnections.connect;
        public form_seethebus()
        {
            InitializeComponent();
        }

        private void form_seethebus_Load(object sender, EventArgs e)
        {
            DataTable fetchseatimg = new DataTable();
            string sql1 = "SELECT image FROM images_misc WHERE image_name = 'adad'";
            SqlDataAdapter da = new SqlDataAdapter(sql1, conn);
            da.Fill(fetchseatimg);

            DataTable busseats = new DataTable();
            string sql2 = "SELECT * FROM bus_seat WHERE bus_id = " + class_ProgramMaster.this_bus_id;
            da.SelectCommand.CommandText = sql2;
            da.Fill(busseats);

            DataTable fetchbusseatconf = new DataTable();
            string sql3 = "SELECT single_seat_count, tworthree_seat_count FROM bus WHERE id = " + class_ProgramMaster.this_bus_id;
            da.SelectCommand.CommandText = sql3;
            da.Fill(fetchbusseatconf);

            int singleseatcount = Convert.ToInt32(fetchbusseatconf.Rows[0][0]);
            //int multipleseatcount = Convert.ToInt32(fetchbusseatconf.Rows[0][1]);

            int dtcounter = 0;
            int multiseatcounter = 0;
            foreach(DataRow row in busseats.Rows)
            {
                dtcounter++;
                if (dtcounter <= singleseatcount)
                {
                    try
                    {
                        //create picturebox and its label; then add controls
                        PictureBox p = addpicturebox(Convert.ToInt32(row[1]), row[0].ToString() + "-" + row[2].ToString() + "-");
                        singleflow.Controls.Add(p);
                        //p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                        Label l = addlabel(dtcounter, row[1].ToString());
                        p.Controls.Add(l);
                        Point pmiddle = new Point(p.Width / 2 - l.Width / 2, p.Height / 2 - l.Height / 2);
                        l.Location = pmiddle;
                        l.BringToFront();
                        //l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                        //add picturebox image
                        byte[] img;
                        if (fetchseatimg.Rows.Count == 0)
                        {
                            img = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                        }
                        else
                        {
                            img = (byte[])fetchseatimg.Rows[0][0];
                        }

                        if (img != null)
                        {
                            MemoryStream ms = new MemoryStream(img);
                            p.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            p.Image = null;
                        }
                        //cloth_image.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    multiseatcounter++;
                    try
                    {
                        //create picturebox and its label; then add controls
                        PictureBox p = addpicturebox(Convert.ToInt32(row[1]), row[0].ToString() + "-" + row[2].ToString() + "-");
                        multiflow.Controls.Add(p);
                        //p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                        Label l = addlabel(dtcounter, row[1].ToString());
                        p.Controls.Add(l);
                        Point pmiddle = new Point(p.Width / 2 - l.Width / 2, p.Height / 2 - l.Height / 2);
                        l.Location = pmiddle;
                        l.BringToFront();
                        //l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                        if(multiseatcounter % 3 == 0)
                        {
                            PictureBox whitebox = addpicturebox(dtcounter, "whitebox");
                            multiflow.Controls.Add(whitebox);
                        }


                        //add picturebox image
                        byte[] img;
                        if (fetchseatimg.Rows.Count == 0)
                        {
                            img = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                        }
                        else
                        {
                            img = (byte[])fetchseatimg.Rows[0][0];
                        }

                        if (img != null)
                        {
                            MemoryStream ms = new MemoryStream(img);
                            p.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            p.Image = null;
                        }
                        //cloth_image.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }



            }

        }

        PictureBox addpicturebox(int i, string name)
        {
            PictureBox p = new PictureBox();
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Name = name + i.ToString();
            //p.BackColor = Color.FromArgb(30, 28, 38);
            p.Width = 34;
            p.Height = 50;
            p.Margin = new Padding(3);

            /*
            ContextMenu cm = new ContextMenu();

            MenuItem itemtokensubmenu = new MenuItem();
            itemtokensubmenu.Name = name + i;
            itemtokensubmenu.Text = "Add to Combination Template";

            itemtokensubmenu.Click += new System.EventHandler(this.addToTemplate);

            cm.Name = "conmenu" + name + i;
            cm.MenuItems.Add(itemtokensubmenu);

            p.ContextMenu = cm;
            */

            return p;
        }

        Label addlabel(int i, string name)  // int id, int name
        {


            Label l = new Label();
            l.Name = name + "-" + i.ToString();
            l.Text = name;
            l.TextAlign = ContentAlignment.MiddleCenter;
            //l.ForeColor = Color.FromArgb(252, 160, 0);
            //l.BackColor = Color.FromArgb(30, 28, 38);
            l.Font = new Font("Arial", 8, FontStyle.Regular);
            //l.ImageAlign = ContentAlignment.MiddleCenter;
            l.Width = 20;
            l.Height = 15;
            //l.Location = new Point(start, end);
            //l.Margin = new Padding(5);



            return l;
        }
    }
}

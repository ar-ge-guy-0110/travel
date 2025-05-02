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
    public partial class form_yolculuk_main : Form
    {
        SqlConnection conn = class_dbconnections.connect;

        int departid;
        int arrivid;

        public static DialogResult dia { get; set; }

        public form_yolculuk_main()
        {
            InitializeComponent();
        }

        private void form_yolculuk_main_Load(object sender, EventArgs e)
        {
            departid = -1;
            arrivid = -1;

            //load comboboxes
            conn.Open();
            SqlCommand comm2 = new SqlCommand("SELECT * FROM route", conn);
            SqlDataReader read2 = comm2.ExecuteReader();
            while (read2.Read())
            {
                comboBox1.Items.Add(read2["route_name"]);
            }
            conn.Close();



            //load imagesmisc
            DataTable imgmisc = new DataTable();
            string imgfetch = "SELECT image FROM images_misc WHERE image_name = 'otobusbos'";
            SqlDataAdapter da2 = new SqlDataAdapter(imgfetch, conn);
            da2.Fill(imgmisc);

            DataTable fetchseatimg = new DataTable();
            string sql11 = "SELECT image FROM images_misc WHERE image_name = 'adad'";
            SqlDataAdapter daa = new SqlDataAdapter(sql11, conn);
            daa.Fill(fetchseatimg);

            byte[] imgotobus = (byte[])imgmisc.Rows[0][0];

            //load essential datatable
            DataTable voyages = new DataTable();
            string essentialsql = @"SELECT voyage.id AS 'Voyage ID', company.id AS 'Company ID', voyage.departure_route_id AS 'DepartureID', 
            voyage.arrival_route_id AS 'ArrivalID', voyage.bus_id AS 'BusID', images_company.image AS 'Company Image', 
            company.company_name AS 'Company', 
            route.route_name AS 'Departure Point', 
            route2.route_name AS 'Arrival Point', 
            bus.busname AS 'Bus Name', bus.seat_price AS 'Seat Price', voyage.voyage_price AS 'Voyage Price', 
            voyage.total_seat_price AS 'Total Travel Price', voyage.voyage_departure_datetime AS 'Departure Time', 
            voyage.voyage_arrival_datetime AS 'Arrival Time' FROM voyage 
            JOIN route ON route.id = voyage.departure_route_id 
            JOIN route AS route2 ON route2.id = voyage.arrival_route_id 
            JOIN bus ON voyage.bus_id = bus.id 
            JOIN company ON bus.company_id = company.id 
            LEFT JOIN images_company ON company.id = images_company.company_id";
            SqlDataAdapter da = new SqlDataAdapter(essentialsql, conn);
            da.Fill(voyages);
            //load all voyages
            int dtcounter = 0;
            foreach (DataRow row in voyages.Rows)
            {
                dtcounter++;
                //add motherpanel
                Panel motherpanel = addMotherPanel("motherpanel", dtcounter);
                flowbuses.Controls.Add(motherpanel);

                //add to motherpanel company pic
                PictureBox companypic = addCompanyPic("company", dtcounter);
                motherpanel.Controls.Add(companypic);
                companypic.Location = new Point(22, 13);
                companypic.Left = 22;
                companypic.Top = 13;




                //add company image

                byte[] img;
                if (row.IsNull(5))
                {
                    img = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                }
                else
                {
                    img = (byte[])row[5];
                }

                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    companypic.Image = Image.FromStream(ms);
                }
                else
                {
                    companypic.Image = null;
                }

                //add labels
                Label whichtimes = addLabel("timelabel", dtcounter, "Kalkış: " + row[13].ToString() + " || Tahmini Varış: " + row[14].ToString());
                motherpanel.Controls.Add(whichtimes);
                whichtimes.Location = new Point(151, 13);



                Label whichroutes = addLabel("routelabel", dtcounter, "Kalkış Yeri: " + row[7].ToString() + " || Varış Yeri: " + row[8].ToString());
                motherpanel.Controls.Add(whichroutes);
                whichroutes.Location = new Point(456, 13);

                Label totalprice = addLabelSpecial("pricelabel", dtcounter, 79, 25, 15, row[12].ToString() + " ₺");
                motherpanel.Controls.Add(totalprice);
                totalprice.Location = new Point(721, 42);

                //add child panel
                Panel childpan = addChildPanel("childpanel", dtcounter, 257, 788);
                motherpanel.Controls.Add(childpan);
                childpan.Location = new Point(22, 115);
                MemoryStream ms2 = new MemoryStream(imgotobus);
                childpan.BackgroundImage = Image.FromStream(ms2);
                childpan.BackgroundImageLayout = ImageLayout.Center;

                //add flows
                FlowLayoutPanel childpansmultiflow = multiflow("multiflow", dtcounter);
                childpan.Controls.Add(childpansmultiflow);
                childpansmultiflow.Location = new Point(179, 38);

                FlowLayoutPanel childpanssingleflow = singleflow("singleflow", dtcounter);
                childpan.Controls.Add(childpanssingleflow);
                childpanssingleflow.Location = new Point(179, 168);


                //////////add seats baby!
                DataTable busseats = new DataTable();
                string sql2 = "SELECT * FROM bus_seat WHERE bus_id = " + Convert.ToInt32(row[4]);
                da.SelectCommand.CommandText = sql2;
                da.Fill(busseats);

                DataTable fetchbusseatconf = new DataTable();
                string sql3 = "SELECT single_seat_count, tworthree_seat_count FROM bus WHERE id = " + Convert.ToInt32(row[4]);
                da.SelectCommand.CommandText = sql3;
                da.Fill(fetchbusseatconf);

                int singleseatcount = Convert.ToInt32(fetchbusseatconf.Rows[0][0]);
                int multiseatcounter = 0;
                int dtcounter2 = 0;



                foreach (DataRow row2 in busseats.Rows)
                {
                    dtcounter2++;
                    if (dtcounter2 <= singleseatcount)
                    {
                        try
                        {
                            //create picturebox and its label; then add controls
                            PictureBox p = addseat(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_");
                            p.DoubleClick += new System.EventHandler(this.seatClick);
                            childpanssingleflow.Controls.Add(p);
                            //p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                            Label l = addseatnum(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_", dtcounter2);
                            l.Click += new System.EventHandler(this.seatnumClick);
                            p.Controls.Add(l);
                            Point pmiddle = new Point(p.Width / 2 - l.Width / 2, p.Height / 2 - l.Height / 2);
                            l.Location = pmiddle;
                            l.BringToFront();
                            //l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                            //add picturebox image
                            byte[] imgg;
                            if (fetchseatimg.Rows.Count == 0)
                            {
                                imgg = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                            }
                            else
                            {
                                imgg = (byte[])fetchseatimg.Rows[0][0];
                            }

                            if (imgg != null)
                            {
                                MemoryStream mss = new MemoryStream(imgg);
                                p.Image = Image.FromStream(mss);
                            }
                            else
                            {
                                p.Image = null;
                            }
                            //cloth_image.Clear();

                            if(!row2.IsNull(3))
                            {
                                if(Convert.ToInt32(row2[3]) == class_ProgramMaster.logged_user_id)
                                {
                                    p.BackColor = Color.FromArgb(133, 240, 84);
                                }
                                else
                                {
                                    p.BackColor = Color.FromArgb(214, 84, 75);
                                }

                            }
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
                            PictureBox p = addseat(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_");
                            p.Click += new System.EventHandler(this.seatClick);
                            childpansmultiflow.Controls.Add(p);
                            //p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                            Label l = addseatnum(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_", dtcounter2);
                            p.Controls.Add(l);
                            l.Click += new System.EventHandler(this.seatnumClick);
                            Point pmiddle = new Point(p.Width / 2 - l.Width / 2, p.Height / 2 - l.Height / 2);
                            l.Location = pmiddle;
                            l.BringToFront();
                            //l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                            if (multiseatcounter % 3 == 0)
                            {
                                PictureBox whitebox = addseat(dtcounter, "whitebox");
                                childpansmultiflow.Controls.Add(whitebox);
                            }


                            //add picturebox image
                            byte[] imggg;
                            if (fetchseatimg.Rows.Count == 0)
                            {
                                imggg = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                            }
                            else
                            {
                                imggg = (byte[])fetchseatimg.Rows[0][0];
                            }

                            if (imggg != null)
                            {
                                MemoryStream msss = new MemoryStream(imggg);
                                p.Image = Image.FromStream(msss);
                            }
                            else
                            {
                                p.Image = null;
                            }
                            //cloth_image.Clear();

                            if (!row2.IsNull(3))
                            {
                                if (Convert.ToInt32(row2[3]) == class_ProgramMaster.logged_user_id)
                                {
                                    p.BackColor = Color.FromArgb(133, 240, 84);
                                }
                                else
                                {
                                    p.BackColor = Color.FromArgb(214, 84, 75);
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }



                }











            }
        }

        private void form_yolculuk_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            class_ProgramMaster.mainloginform.Show();
        }

        Panel addMotherPanel(string name, int id)
        {
            Panel pan = new Panel();
            pan.Name = name + "-" + id;
            pan.Width = 828; //828
            pan.Height = 418; //418
            pan.Margin = new Padding(2);
            pan.BackColor = Color.FromArgb(243, 247, 248);
            pan.Visible = true;
            pan.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            //pan.BorderStyle = BorderStyle.None;






            return pan;
        }

        Panel addChildPanel(string name, int id, int height, int width)
        {
            Panel pan = new Panel();
            pan.Name = name + "-" + id;
            pan.Width = width; //828
            pan.Height = height; //418
            pan.Margin = new Padding(2);
            pan.BackColor = Color.FromArgb(243, 247, 248);
            pan.Visible = true;
            pan.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            //pan.BorderStyle = BorderStyle.None;






            return pan;
        }

        PictureBox addCompanyPic(string company_name, int company_id)
        {
            PictureBox pic = new PictureBox();
            pic.Name = company_name + "-" + company_id;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Width = 123;
            pic.Height = 96;
            pic.Margin = new Padding(2);


            return pic;
        }

        Label addLabel(string label_name, int id, string text)
        {
            Label labb = new Label();
            labb.Name = label_name + "-" + id;
            labb.Text = text;
            labb.TextAlign = ContentAlignment.MiddleCenter;
            labb.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            labb.AutoSize = false;
            labb.Width = 200;
            labb.Height = 80;




            return labb;
        }

        Label addLabelSpecial(string label_name, int id, int width, int height, int fontsize, string text)
        {
            Label labb = new Label();
            labb.Name = label_name + "-" + id;
            labb.Text = text;
            labb.TextAlign = ContentAlignment.MiddleCenter;
            labb.Font = new Font("Microsoft Sans Serif", fontsize, FontStyle.Regular);
            labb.Width = width;
            labb.Height = height;



            return labb;
        }

        FlowLayoutPanel multiflow(string name, int id)
        {
            FlowLayoutPanel flowpanel = new FlowLayoutPanel();
            flowpanel.Name = name + "-" + id;
            flowpanel.Width = 552; //828
            flowpanel.Height = 124; //418
            //flowpanel.Margin = new Padding(2);
            flowpanel.BackColor = Color.FromArgb(243, 247, 248);
            flowpanel.Visible = true;
            flowpanel.FlowDirection = FlowDirection.TopDown;

            return flowpanel;

        }

        FlowLayoutPanel singleflow(string name, int id)
        {
            FlowLayoutPanel flowpanel = new FlowLayoutPanel();
            flowpanel.Name = name + "-" + id;
            flowpanel.Width = 552; //828
            flowpanel.Height = 59; //418
            //flowpanel.Margin = new Padding(2);
            flowpanel.BackColor = Color.FromArgb(243, 247, 248);
            flowpanel.Visible = true;
            flowpanel.FlowDirection = FlowDirection.LeftToRight;

            return flowpanel;

        }

        PictureBox addseat(int i, string name)
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

        Label addseatnum(int i, string name, int seatnumber)  // int id, int name
        {


            Label l = new Label();
            l.Name = name + i.ToString();
            l.Text = seatnumber.ToString();
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



        //
        //DYNAMIC CONTROLS
        //

        void seatClick(object sender, EventArgs e)
        {
            PictureBox currentseat = (PictureBox)sender;
            int seat_id;
            int seat_number;
            int seat_bus_id;
            int user_id = class_ProgramMaster.logged_user_id;

            string seatdecode = currentseat.Name;
            seat_id = Convert.ToInt32(seatdecode.Substring(0, seatdecode.IndexOf("-")));
            //MessageBox.Show(seat_id.ToString());
            seat_number = Convert.ToInt32(seatdecode.Substring(seatdecode.IndexOf("-") + 1, seatdecode.IndexOf("_") - seatdecode.IndexOf("-") - 1));
            //MessageBox.Show(seat_number.ToString());
            seat_bus_id = Convert.ToInt32(seatdecode.Substring(seatdecode.IndexOf("_") + 1, seatdecode.Length - seatdecode.IndexOf("_") - 1));
            //MessageBox.Show(seat_bus_id.ToString());
            class_ProgramMaster.seat_id = seat_id;
            class_ProgramMaster.seat_number = seat_number;
            class_ProgramMaster.seat_bus_id = seat_bus_id;
            

            
            
            DataTable controlseat2 = new DataTable();
            string sql2 = "SELECT * FROM bus_seat WHERE bus_id = " + seat_bus_id + " appuser_id = " + class_ProgramMaster.logged_user_id;
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, conn);
            da2.Fill(controlseat2);


            if (controlseat2.Rows.Count == 0)
            {
                DataTable controlseat = new DataTable();
                string sql = "SELECT * FROM bus_seat WHERE id = " + seat_id + " appuser_id = NULL";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(controlseat);

                if (controlseat.Rows.Count != 0)
                {
                    Form saleseat = new form_saleseat_select();
                    dia = saleseat.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bu koltuk alınmıştır!");
                }
            }
            else
            {
                MessageBox.Show("Bu otobüste en fazla bir koltuk alabilirsiniz!");
            }


            class_ProgramMaster.mainyolculuk = this;


        }

        void seatnumClick(object sender, EventArgs e)
        {
            Label currentseatnumber = (Label)sender;
            //PictureBox thisss = (PictureBox)currentseatnumber.Parent;

            int seat_id;
            int seat_number;
            int seat_bus_id;
            int user_id = class_ProgramMaster.logged_user_id;

            string seatdecode = currentseatnumber.Name;
            seat_id = Convert.ToInt32(seatdecode.Substring(0, seatdecode.IndexOf("-")));
            //MessageBox.Show(seat_id.ToString());
            seat_bus_id = Convert.ToInt32(seatdecode.Substring(seatdecode.IndexOf("-") + 1, seatdecode.IndexOf("_") - seatdecode.IndexOf("-") - 1));
            //MessageBox.Show(seat_number.ToString());
            seat_number = Convert.ToInt32(seatdecode.Substring(seatdecode.IndexOf("_") + 1, seatdecode.Length - seatdecode.IndexOf("_") - 1));
            //MessageBox.Show(seat_bus_id.ToString());
            class_ProgramMaster.seat_id = seat_id;
            class_ProgramMaster.seat_number = seat_number;
            class_ProgramMaster.seat_bus_id = seat_bus_id;



            DataTable controlseat2 = new DataTable();
            string sql2 = "SELECT * FROM bus_seat WHERE bus_id = " + seat_bus_id + " AND appuser_id = " + class_ProgramMaster.logged_user_id;
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, conn);
            da2.Fill(controlseat2);


            if (controlseat2.Rows.Count == 0)
            {
                DataTable controlseat = new DataTable();
                string sql = "SELECT * FROM bus_seat WHERE id = " + seat_id + " AND appuser_id is NULL";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(controlseat);

                if (controlseat.Rows.Count != 0)
                {
                    Form saleseat = new form_saleseat_select();
                    dia = saleseat.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bu koltuk alınmıştır!");
                }
            }
            else
            {
                MessageBox.Show("Bu otobüste en fazla bir koltuk alabilirsiniz!");
            }

            class_ProgramMaster.mainyolculuk = this;
        }



        ///MISC

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    arrivid = -1;


                    DataTable idal = new DataTable();
                    string idalsql = "SELECT id FROM route WHERE route_name = N'" + comboBox1.SelectedItem.ToString() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                    da.Fill(idal);
                    departid = Convert.ToInt32(idal.Rows[0][0]);

                    comboBox2.Items.Clear();
                    conn.Open();
                    SqlCommand comm2 = new SqlCommand("SELECT * FROM route WHERE NOT id = " + departid, conn);
                    SqlDataReader read2 = comm2.ExecuteReader();
                    while (read2.Read())
                    {
                        comboBox2.Items.Add(read2["route_name"]);
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                DataTable idal = new DataTable();
                string idalsql = "SELECT id FROM route WHERE route_name = N'" + comboBox2.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                da.Fill(idal);
                arrivid = Convert.ToInt32(idal.Rows[0][0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(departid != -1 && arrivid != -1 && dateTimePicker1.Checked)
            {
                List<Control> listControls = new List<Control>();

                foreach (Control control in flowbuses.Controls)
                {
                    listControls.Add(control);
                }

                foreach (Control control in listControls)
                {
                    flowbuses.Controls.Remove(control);
                    control.Dispose();
                }



                //load imagesmisc
                DataTable imgmisc = new DataTable();
                string imgfetch = "SELECT image FROM images_misc WHERE image_name = 'otobusbos'";
                SqlDataAdapter da2 = new SqlDataAdapter(imgfetch, conn);
                da2.Fill(imgmisc);

                DataTable fetchseatimg = new DataTable();
                string sql11 = "SELECT image FROM images_misc WHERE image_name = 'adad'";
                SqlDataAdapter daa = new SqlDataAdapter(sql11, conn);
                daa.Fill(fetchseatimg);

                byte[] imgotobus = (byte[])imgmisc.Rows[0][0];

                //load essential datatable
                DataTable voyages = new DataTable();
                string essentialsql = @"SELECT voyage.id AS 'Voyage ID', company.id AS 'Company ID', voyage.departure_route_id AS 'DepartureID', 
                voyage.arrival_route_id AS 'ArrivalID', voyage.bus_id AS 'BusID', images_company.image AS 'Company Image', 
                company.company_name AS 'Company', 
                route.route_name AS 'Departure Point', 
                route2.route_name AS 'Arrival Point', 
                bus.busname AS 'Bus Name', bus.seat_price AS 'Seat Price', voyage.voyage_price AS 'Voyage Price', 
                voyage.total_seat_price AS 'Total Travel Price', voyage.voyage_departure_datetime AS 'Departure Time', 
                voyage.voyage_arrival_datetime AS 'Arrival Time' FROM voyage 
                JOIN route ON route.id = voyage.departure_route_id 
                JOIN route AS route2 ON route2.id = voyage.arrival_route_id 
                JOIN bus ON voyage.bus_id = bus.id 
                JOIN company ON bus.company_id = company.id 
                LEFT JOIN images_company ON company.id = images_company.company_id WHERE route.route_name = N'" + comboBox1.SelectedItem.ToString() + "' AND route2.route_name = N'" + comboBox2.SelectedItem.ToString() + "' AND voyage.voyage_departure_datetime >= '" + dateTimePicker1.Value.Date + "'";
                SqlDataAdapter da = new SqlDataAdapter(essentialsql, conn);
                da.Fill(voyages);
                //load all voyages
                int dtcounter = 0;
                foreach (DataRow row in voyages.Rows)
                {
                    dtcounter++;
                    //add motherpanel
                    Panel motherpanel = addMotherPanel("motherpanel", dtcounter);
                    flowbuses.Controls.Add(motherpanel);

                    //add to motherpanel company pic
                    PictureBox companypic = addCompanyPic("company", dtcounter);
                    motherpanel.Controls.Add(companypic);
                    companypic.Location = new Point(22, 13);
                    companypic.Left = 22;
                    companypic.Top = 13;




                    //add company image

                    byte[] img;
                    if (row.IsNull(5))
                    {
                        img = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                    }
                    else
                    {
                        img = (byte[])row[5];
                    }

                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        companypic.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        companypic.Image = null;
                    }

                    //add labels
                    Label whichtimes = addLabel("timelabel", dtcounter, "Kalkış: " + row[13].ToString() + " || Tahmini Varış: " + row[14].ToString());
                    motherpanel.Controls.Add(whichtimes);
                    whichtimes.Location = new Point(151, 13);



                    Label whichroutes = addLabel("routelabel", dtcounter, "Kalkış Yeri: " + row[7].ToString() + " || Varış Yeri: " + row[8].ToString());
                    motherpanel.Controls.Add(whichroutes);
                    whichroutes.Location = new Point(456, 13);

                    Label totalprice = addLabelSpecial("pricelabel", dtcounter, 79, 25, 15, row[12].ToString() + " ₺");
                    motherpanel.Controls.Add(totalprice);
                    totalprice.Location = new Point(721, 42);

                    //add child panel
                    Panel childpan = addChildPanel("childpanel", dtcounter, 257, 788);
                    motherpanel.Controls.Add(childpan);
                    childpan.Location = new Point(22, 115);
                    MemoryStream ms2 = new MemoryStream(imgotobus);
                    childpan.BackgroundImage = Image.FromStream(ms2);
                    childpan.BackgroundImageLayout = ImageLayout.Center;

                    //add flows
                    FlowLayoutPanel childpansmultiflow = multiflow("multiflow", dtcounter);
                    childpan.Controls.Add(childpansmultiflow);
                    childpansmultiflow.Location = new Point(179, 38);

                    FlowLayoutPanel childpanssingleflow = singleflow("singleflow", dtcounter);
                    childpan.Controls.Add(childpanssingleflow);
                    childpanssingleflow.Location = new Point(179, 168);


                    //////////add seats baby!
                    DataTable busseats = new DataTable();
                    string sql2 = "SELECT * FROM bus_seat WHERE bus_id = " + Convert.ToInt32(row[4]);
                    da.SelectCommand.CommandText = sql2;
                    da.Fill(busseats);

                    DataTable fetchbusseatconf = new DataTable();
                    string sql3 = "SELECT single_seat_count, tworthree_seat_count FROM bus WHERE id = " + Convert.ToInt32(row[4]);
                    da.SelectCommand.CommandText = sql3;
                    da.Fill(fetchbusseatconf);

                    int singleseatcount = Convert.ToInt32(fetchbusseatconf.Rows[0][0]);
                    int multiseatcounter = 0;
                    int dtcounter2 = 0;



                    foreach (DataRow row2 in busseats.Rows)
                    {
                        dtcounter2++;
                        if (dtcounter2 <= singleseatcount)
                        {
                            try
                            {
                                //create picturebox and its label; then add controls
                                PictureBox p = addseat(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_");
                                p.DoubleClick += new System.EventHandler(this.seatClick);
                                childpanssingleflow.Controls.Add(p);
                                //p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                                Label l = addseatnum(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_", dtcounter2);
                                l.Click += new System.EventHandler(this.seatnumClick);
                                p.Controls.Add(l);
                                Point pmiddle = new Point(p.Width / 2 - l.Width / 2, p.Height / 2 - l.Height / 2);
                                l.Location = pmiddle;
                                l.BringToFront();
                                //l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                                //add picturebox image
                                byte[] imgg;
                                if (fetchseatimg.Rows.Count == 0)
                                {
                                    imgg = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                                }
                                else
                                {
                                    imgg = (byte[])fetchseatimg.Rows[0][0];
                                }

                                if (imgg != null)
                                {
                                    MemoryStream mss = new MemoryStream(imgg);
                                    p.Image = Image.FromStream(mss);
                                }
                                else
                                {
                                    p.Image = null;
                                }
                                //cloth_image.Clear();

                                if (!row2.IsNull(3))
                                {
                                    if (Convert.ToInt32(row2[3]) == class_ProgramMaster.logged_user_id)
                                    {
                                        p.BackColor = Color.FromArgb(133, 240, 84);
                                    }
                                    else
                                    {
                                        p.BackColor = Color.FromArgb(214, 84, 75);
                                    }

                                }
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
                                PictureBox p = addseat(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_");
                                p.Click += new System.EventHandler(this.seatClick);
                                childpansmultiflow.Controls.Add(p);
                                //p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                                Label l = addseatnum(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_", dtcounter2);
                                p.Controls.Add(l);
                                l.Click += new System.EventHandler(this.seatnumClick);
                                Point pmiddle = new Point(p.Width / 2 - l.Width / 2, p.Height / 2 - l.Height / 2);
                                l.Location = pmiddle;
                                l.BringToFront();
                                //l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                                if (multiseatcounter % 3 == 0)
                                {
                                    PictureBox whitebox = addseat(dtcounter, "whitebox");
                                    childpansmultiflow.Controls.Add(whitebox);
                                }


                                //add picturebox image
                                byte[] imggg;
                                if (fetchseatimg.Rows.Count == 0)
                                {
                                    imggg = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                                }
                                else
                                {
                                    imggg = (byte[])fetchseatimg.Rows[0][0];
                                }

                                if (imggg != null)
                                {
                                    MemoryStream msss = new MemoryStream(imggg);
                                    p.Image = Image.FromStream(msss);
                                }
                                else
                                {
                                    p.Image = null;
                                }
                                //cloth_image.Clear();

                                if (!row2.IsNull(3))
                                {
                                    if (Convert.ToInt32(row2[3]) == class_ProgramMaster.logged_user_id)
                                    {
                                        p.BackColor = Color.FromArgb(133, 240, 84);
                                    }
                                    else
                                    {
                                        p.BackColor = Color.FromArgb(214, 84, 75);
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }



                    }


                }





            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz.");
            }













        }











        private void button2_Click(object sender, EventArgs e)
        {
            List<Control> listControls = new List<Control>();

            foreach (Control control in flowbuses.Controls)
            {
                listControls.Add(control);
            }

            foreach (Control control in listControls)
            {
                flowbuses.Controls.Remove(control);
                control.Dispose();
            }

            //load imagesmisc
            DataTable imgmisc = new DataTable();
            string imgfetch = "SELECT image FROM images_misc WHERE image_name = 'otobusbos'";
            SqlDataAdapter da2 = new SqlDataAdapter(imgfetch, conn);
            da2.Fill(imgmisc);

            DataTable fetchseatimg = new DataTable();
            string sql11 = "SELECT image FROM images_misc WHERE image_name = 'adad'";
            SqlDataAdapter daa = new SqlDataAdapter(sql11, conn);
            daa.Fill(fetchseatimg);

            byte[] imgotobus = (byte[])imgmisc.Rows[0][0];

            //load essential datatable
            DataTable voyages = new DataTable();
            string essentialsql = @"SELECT voyage.id AS 'Voyage ID', company.id AS 'Company ID', voyage.departure_route_id AS 'DepartureID', 
            voyage.arrival_route_id AS 'ArrivalID', voyage.bus_id AS 'BusID', images_company.image AS 'Company Image', 
            company.company_name AS 'Company', 
            route.route_name AS 'Departure Point', 
            route2.route_name AS 'Arrival Point', 
            bus.busname AS 'Bus Name', bus.seat_price AS 'Seat Price', voyage.voyage_price AS 'Voyage Price', 
            voyage.total_seat_price AS 'Total Travel Price', voyage.voyage_departure_datetime AS 'Departure Time', 
            voyage.voyage_arrival_datetime AS 'Arrival Time' FROM voyage 
            JOIN route ON route.id = voyage.departure_route_id 
            JOIN route AS route2 ON route2.id = voyage.arrival_route_id 
            JOIN bus ON voyage.bus_id = bus.id 
            JOIN company ON bus.company_id = company.id 
            LEFT JOIN images_company ON company.id = images_company.company_id";
            SqlDataAdapter da = new SqlDataAdapter(essentialsql, conn);
            da.Fill(voyages);
            //load all voyages
            int dtcounter = 0;
            foreach (DataRow row in voyages.Rows)
            {
                dtcounter++;
                //add motherpanel
                Panel motherpanel = addMotherPanel("motherpanel", dtcounter);
                flowbuses.Controls.Add(motherpanel);

                //add to motherpanel company pic
                PictureBox companypic = addCompanyPic("company", dtcounter);
                motherpanel.Controls.Add(companypic);
                companypic.Location = new Point(22, 13);
                companypic.Left = 22;
                companypic.Top = 13;




                //add company image

                byte[] img;
                if (row.IsNull(5))
                {
                    img = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                }
                else
                {
                    img = (byte[])row[5];
                }

                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    companypic.Image = Image.FromStream(ms);
                }
                else
                {
                    companypic.Image = null;
                }

                //add labels
                Label whichtimes = addLabel("timelabel", dtcounter, "Kalkış: " + row[13].ToString() + " || Tahmini Varış: " + row[14].ToString());
                motherpanel.Controls.Add(whichtimes);
                whichtimes.Location = new Point(151, 13);



                Label whichroutes = addLabel("routelabel", dtcounter, "Kalkış Yeri: " + row[7].ToString() + " || Varış Yeri: " + row[8].ToString());
                motherpanel.Controls.Add(whichroutes);
                whichroutes.Location = new Point(456, 13);

                Label totalprice = addLabelSpecial("pricelabel", dtcounter, 79, 25, 15, row[12].ToString() + " ₺");
                motherpanel.Controls.Add(totalprice);
                totalprice.Location = new Point(721, 42);

                //add child panel
                Panel childpan = addChildPanel("childpanel", dtcounter, 257, 788);
                motherpanel.Controls.Add(childpan);
                childpan.Location = new Point(22, 115);
                MemoryStream ms2 = new MemoryStream(imgotobus);
                childpan.BackgroundImage = Image.FromStream(ms2);
                childpan.BackgroundImageLayout = ImageLayout.Center;

                //add flows
                FlowLayoutPanel childpansmultiflow = multiflow("multiflow", dtcounter);
                childpan.Controls.Add(childpansmultiflow);
                childpansmultiflow.Location = new Point(179, 38);

                FlowLayoutPanel childpanssingleflow = singleflow("singleflow", dtcounter);
                childpan.Controls.Add(childpanssingleflow);
                childpanssingleflow.Location = new Point(179, 168);


                //////////add seats baby!
                DataTable busseats = new DataTable();
                string sql2 = "SELECT * FROM bus_seat WHERE bus_id = " + Convert.ToInt32(row[4]);
                da.SelectCommand.CommandText = sql2;
                da.Fill(busseats);

                DataTable fetchbusseatconf = new DataTable();
                string sql3 = "SELECT single_seat_count, tworthree_seat_count FROM bus WHERE id = " + Convert.ToInt32(row[4]);
                da.SelectCommand.CommandText = sql3;
                da.Fill(fetchbusseatconf);

                int singleseatcount = Convert.ToInt32(fetchbusseatconf.Rows[0][0]);
                int multiseatcounter = 0;
                int dtcounter2 = 0;



                foreach (DataRow row2 in busseats.Rows)
                {
                    dtcounter2++;
                    if (dtcounter2 <= singleseatcount)
                    {
                        try
                        {
                            //create picturebox and its label; then add controls
                            PictureBox p = addseat(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_");
                            p.DoubleClick += new System.EventHandler(this.seatClick);
                            childpanssingleflow.Controls.Add(p);
                            //p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                            Label l = addseatnum(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_", dtcounter2);
                            l.Click += new System.EventHandler(this.seatnumClick);
                            p.Controls.Add(l);
                            Point pmiddle = new Point(p.Width / 2 - l.Width / 2, p.Height / 2 - l.Height / 2);
                            l.Location = pmiddle;
                            l.BringToFront();
                            //l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                            //add picturebox image
                            byte[] imgg;
                            if (fetchseatimg.Rows.Count == 0)
                            {
                                imgg = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                            }
                            else
                            {
                                imgg = (byte[])fetchseatimg.Rows[0][0];
                            }

                            if (imgg != null)
                            {
                                MemoryStream mss = new MemoryStream(imgg);
                                p.Image = Image.FromStream(mss);
                            }
                            else
                            {
                                p.Image = null;
                            }
                            //cloth_image.Clear();

                            if (!row2.IsNull(3))
                            {
                                if (Convert.ToInt32(row2[3]) == class_ProgramMaster.logged_user_id)
                                {
                                    p.BackColor = Color.FromArgb(133, 240, 84);
                                }
                                else
                                {
                                    p.BackColor = Color.FromArgb(214, 84, 75);
                                }

                            }
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
                            PictureBox p = addseat(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_");
                            p.Click += new System.EventHandler(this.seatClick);
                            childpansmultiflow.Controls.Add(p);
                            //p.DoubleClick += new System.EventHandler(this.picboxDoubleClick);


                            Label l = addseatnum(Convert.ToInt32(row2[1]), row2[0].ToString() + "-" + row2[2].ToString() + "_", dtcounter2);
                            p.Controls.Add(l);
                            l.Click += new System.EventHandler(this.seatnumClick);
                            Point pmiddle = new Point(p.Width / 2 - l.Width / 2, p.Height / 2 - l.Height / 2);
                            l.Location = pmiddle;
                            l.BringToFront();
                            //l.DoubleClick += new System.EventHandler(this.labelDoubleClick);

                            if (multiseatcounter % 3 == 0)
                            {
                                PictureBox whitebox = addseat(dtcounter, "whitebox");
                                childpansmultiflow.Controls.Add(whitebox);
                            }


                            //add picturebox image
                            byte[] imggg;
                            if (fetchseatimg.Rows.Count == 0)
                            {
                                imggg = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z/C/HgAGgwJ/lK3Q6wAAAABJRU5ErkJggg==");
                            }
                            else
                            {
                                imggg = (byte[])fetchseatimg.Rows[0][0];
                            }

                            if (imggg != null)
                            {
                                MemoryStream msss = new MemoryStream(imggg);
                                p.Image = Image.FromStream(msss);
                            }
                            else
                            {
                                p.Image = null;
                            }
                            //cloth_image.Clear();

                            if (!row2.IsNull(3))
                            {
                                if (Convert.ToInt32(row2[3]) == class_ProgramMaster.logged_user_id)
                                {
                                    p.BackColor = Color.FromArgb(133, 240, 84);
                                }
                                else
                                {
                                    p.BackColor = Color.FromArgb(214, 84, 75);
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }



                }


            }
        }
























    }
}


namespace YolculukDesktop
{
    partial class form_pm_buses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_pm_buses));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buspanel = new System.Windows.Forms.Panel();
            this.txtbusname = new System.Windows.Forms.TextBox();
            this.txtsscount = new System.Windows.Forms.TextBox();
            this.txtsmcount = new System.Windows.Forms.TextBox();
            this.txtseatprice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchbutton4 = new System.Windows.Forms.Button();
            this.updatebutton3 = new System.Windows.Forms.Button();
            this.deletebutton2 = new System.Windows.Forms.Button();
            this.addbutton1 = new System.Windows.Forms.Button();
            this.listallbutton1 = new System.Windows.Forms.Button();
            this.searchbycompanybutton2 = new System.Windows.Forms.Button();
            this.seethebusbutton3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.buspanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(276, 538);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // buspanel
            // 
            this.buspanel.Controls.Add(this.dataGridView2);
            this.buspanel.Controls.Add(this.seethebusbutton3);
            this.buspanel.Controls.Add(this.searchbycompanybutton2);
            this.buspanel.Controls.Add(this.listallbutton1);
            this.buspanel.Controls.Add(this.searchbutton4);
            this.buspanel.Controls.Add(this.updatebutton3);
            this.buspanel.Controls.Add(this.deletebutton2);
            this.buspanel.Controls.Add(this.addbutton1);
            this.buspanel.Controls.Add(this.label4);
            this.buspanel.Controls.Add(this.label3);
            this.buspanel.Controls.Add(this.label2);
            this.buspanel.Controls.Add(this.label1);
            this.buspanel.Controls.Add(this.txtseatprice);
            this.buspanel.Controls.Add(this.txtsmcount);
            this.buspanel.Controls.Add(this.txtsscount);
            this.buspanel.Controls.Add(this.txtbusname);
            this.buspanel.Location = new System.Drawing.Point(285, 12);
            this.buspanel.Name = "buspanel";
            this.buspanel.Size = new System.Drawing.Size(687, 538);
            this.buspanel.TabIndex = 1;
            this.buspanel.Visible = false;
            // 
            // txtbusname
            // 
            this.txtbusname.Location = new System.Drawing.Point(173, 18);
            this.txtbusname.MaxLength = 100;
            this.txtbusname.Name = "txtbusname";
            this.txtbusname.Size = new System.Drawing.Size(150, 26);
            this.txtbusname.TabIndex = 0;
            // 
            // txtsscount
            // 
            this.txtsscount.Location = new System.Drawing.Point(173, 50);
            this.txtsscount.MaxLength = 10;
            this.txtsscount.Name = "txtsscount";
            this.txtsscount.Size = new System.Drawing.Size(150, 26);
            this.txtsscount.TabIndex = 1;
            this.txtsscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsscount_KeyPress);
            // 
            // txtsmcount
            // 
            this.txtsmcount.Location = new System.Drawing.Point(173, 82);
            this.txtsmcount.MaxLength = 10;
            this.txtsmcount.Name = "txtsmcount";
            this.txtsmcount.Size = new System.Drawing.Size(150, 26);
            this.txtsmcount.TabIndex = 2;
            this.txtsmcount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsmcount_KeyPress);
            // 
            // txtseatprice
            // 
            this.txtseatprice.Location = new System.Drawing.Point(173, 114);
            this.txtseatprice.MaxLength = 10;
            this.txtseatprice.Name = "txtseatprice";
            this.txtseatprice.Size = new System.Drawing.Size(150, 26);
            this.txtseatprice.TabIndex = 3;
            this.txtseatprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtseatprice_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Otobüs Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tekli Koltuk Sayısı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Çoklu Koltuk Sayısı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Koltuk Ücreti:";
            // 
            // searchbutton4
            // 
            this.searchbutton4.Location = new System.Drawing.Point(329, 112);
            this.searchbutton4.Name = "searchbutton4";
            this.searchbutton4.Size = new System.Drawing.Size(150, 26);
            this.searchbutton4.TabIndex = 11;
            this.searchbutton4.Text = "Ara";
            this.searchbutton4.UseVisualStyleBackColor = true;
            this.searchbutton4.Click += new System.EventHandler(this.searchbutton4_Click);
            // 
            // updatebutton3
            // 
            this.updatebutton3.Location = new System.Drawing.Point(329, 80);
            this.updatebutton3.Name = "updatebutton3";
            this.updatebutton3.Size = new System.Drawing.Size(150, 26);
            this.updatebutton3.TabIndex = 10;
            this.updatebutton3.Text = "Güncelle";
            this.updatebutton3.UseVisualStyleBackColor = true;
            this.updatebutton3.Click += new System.EventHandler(this.updatebutton3_Click);
            // 
            // deletebutton2
            // 
            this.deletebutton2.Location = new System.Drawing.Point(329, 50);
            this.deletebutton2.Name = "deletebutton2";
            this.deletebutton2.Size = new System.Drawing.Size(150, 26);
            this.deletebutton2.TabIndex = 9;
            this.deletebutton2.Text = "Sil";
            this.deletebutton2.UseVisualStyleBackColor = true;
            this.deletebutton2.Click += new System.EventHandler(this.deletebutton2_Click);
            // 
            // addbutton1
            // 
            this.addbutton1.Location = new System.Drawing.Point(329, 18);
            this.addbutton1.Name = "addbutton1";
            this.addbutton1.Size = new System.Drawing.Size(150, 26);
            this.addbutton1.TabIndex = 8;
            this.addbutton1.Text = "Ekle";
            this.addbutton1.UseVisualStyleBackColor = true;
            this.addbutton1.Click += new System.EventHandler(this.addbutton1_Click);
            // 
            // listallbutton1
            // 
            this.listallbutton1.Location = new System.Drawing.Point(485, 18);
            this.listallbutton1.Name = "listallbutton1";
            this.listallbutton1.Size = new System.Drawing.Size(150, 26);
            this.listallbutton1.TabIndex = 12;
            this.listallbutton1.Text = "Hepsini Listele";
            this.listallbutton1.UseVisualStyleBackColor = true;
            this.listallbutton1.Click += new System.EventHandler(this.listallbutton1_Click);
            // 
            // searchbycompanybutton2
            // 
            this.searchbycompanybutton2.Location = new System.Drawing.Point(485, 50);
            this.searchbycompanybutton2.Name = "searchbycompanybutton2";
            this.searchbycompanybutton2.Size = new System.Drawing.Size(150, 26);
            this.searchbycompanybutton2.TabIndex = 13;
            this.searchbycompanybutton2.Text = "Firmaya Göre Ara";
            this.searchbycompanybutton2.UseVisualStyleBackColor = true;
            this.searchbycompanybutton2.Click += new System.EventHandler(this.searchbycompanybutton2_Click);
            // 
            // seethebusbutton3
            // 
            this.seethebusbutton3.Location = new System.Drawing.Point(485, 79);
            this.seethebusbutton3.Name = "seethebusbutton3";
            this.seethebusbutton3.Size = new System.Drawing.Size(150, 58);
            this.seethebusbutton3.TabIndex = 14;
            this.seethebusbutton3.Text = "Otobüsü Görüntüle";
            this.seethebusbutton3.UseVisualStyleBackColor = true;
            this.seethebusbutton3.Click += new System.EventHandler(this.seethebusbutton3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(4, 164);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(680, 371);
            this.dataGridView2.TabIndex = 15;
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // form_pm_buses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.buspanel);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form_pm_buses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici Paneli: Otobüsler - Yolculuk";
            this.Load += new System.EventHandler(this.form_pm_buses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.buspanel.ResumeLayout(false);
            this.buspanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel buspanel;
        private System.Windows.Forms.TextBox txtseatprice;
        private System.Windows.Forms.TextBox txtsmcount;
        private System.Windows.Forms.TextBox txtsscount;
        private System.Windows.Forms.TextBox txtbusname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button searchbutton4;
        private System.Windows.Forms.Button updatebutton3;
        private System.Windows.Forms.Button deletebutton2;
        private System.Windows.Forms.Button addbutton1;
        private System.Windows.Forms.Button listallbutton1;
        private System.Windows.Forms.Button searchbycompanybutton2;
        private System.Windows.Forms.Button seethebusbutton3;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}
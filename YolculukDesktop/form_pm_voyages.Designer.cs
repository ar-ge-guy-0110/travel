
namespace YolculukDesktop
{
    partial class form_pm_voyages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_pm_voyages));
            this.buscomboBox = new System.Windows.Forms.ComboBox();
            this.wherecomboBox = new System.Windows.Forms.ComboBox();
            this.whichcomboBox = new System.Windows.Forms.ComboBox();
            this.companycomboBox = new System.Windows.Forms.ComboBox();
            this.txtvoyageprice = new System.Windows.Forms.TextBox();
            this.totalpricelabel = new System.Windows.Forms.Label();
            this.departuringdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.arrivaldateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchbutton4 = new System.Windows.Forms.Button();
            this.updatebutton3 = new System.Windows.Forms.Button();
            this.deletebutton2 = new System.Windows.Forms.Button();
            this.addbutton1 = new System.Windows.Forms.Button();
            this.clearbutton1 = new System.Windows.Forms.Button();
            this.listallbutton1 = new System.Windows.Forms.Button();
            this.departtimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.arrivaltimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buscomboBox
            // 
            this.buscomboBox.FormattingEnabled = true;
            this.buscomboBox.Location = new System.Drawing.Point(194, 46);
            this.buscomboBox.Name = "buscomboBox";
            this.buscomboBox.Size = new System.Drawing.Size(150, 28);
            this.buscomboBox.TabIndex = 0;
            this.buscomboBox.SelectedIndexChanged += new System.EventHandler(this.buscomboBox_SelectedIndexChanged);
            // 
            // wherecomboBox
            // 
            this.wherecomboBox.FormattingEnabled = true;
            this.wherecomboBox.Location = new System.Drawing.Point(194, 80);
            this.wherecomboBox.Name = "wherecomboBox";
            this.wherecomboBox.Size = new System.Drawing.Size(150, 28);
            this.wherecomboBox.TabIndex = 1;
            this.wherecomboBox.SelectedIndexChanged += new System.EventHandler(this.wherecomboBox_SelectedIndexChanged);
            // 
            // whichcomboBox
            // 
            this.whichcomboBox.FormattingEnabled = true;
            this.whichcomboBox.Location = new System.Drawing.Point(194, 114);
            this.whichcomboBox.Name = "whichcomboBox";
            this.whichcomboBox.Size = new System.Drawing.Size(150, 28);
            this.whichcomboBox.TabIndex = 2;
            this.whichcomboBox.SelectedIndexChanged += new System.EventHandler(this.whichcomboBox_SelectedIndexChanged);
            // 
            // companycomboBox
            // 
            this.companycomboBox.FormattingEnabled = true;
            this.companycomboBox.Location = new System.Drawing.Point(194, 12);
            this.companycomboBox.Name = "companycomboBox";
            this.companycomboBox.Size = new System.Drawing.Size(150, 28);
            this.companycomboBox.TabIndex = 3;
            this.companycomboBox.SelectedIndexChanged += new System.EventHandler(this.companycomboBox_SelectedIndexChanged);
            // 
            // txtvoyageprice
            // 
            this.txtvoyageprice.Location = new System.Drawing.Point(194, 149);
            this.txtvoyageprice.MaxLength = 10;
            this.txtvoyageprice.Name = "txtvoyageprice";
            this.txtvoyageprice.Size = new System.Drawing.Size(150, 26);
            this.txtvoyageprice.TabIndex = 4;
            this.txtvoyageprice.TextChanged += new System.EventHandler(this.txtvoyageprice_TextChanged);
            this.txtvoyageprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtvoyageprice_KeyPress);
            // 
            // totalpricelabel
            // 
            this.totalpricelabel.AutoSize = true;
            this.totalpricelabel.Location = new System.Drawing.Point(2, 185);
            this.totalpricelabel.Name = "totalpricelabel";
            this.totalpricelabel.Size = new System.Drawing.Size(186, 20);
            this.totalpricelabel.TabIndex = 5;
            this.totalpricelabel.Text = "Toplam Yolculuk Ücreti:";
            // 
            // departuringdateTimePicker
            // 
            this.departuringdateTimePicker.Location = new System.Drawing.Point(194, 210);
            this.departuringdateTimePicker.Name = "departuringdateTimePicker";
            this.departuringdateTimePicker.Size = new System.Drawing.Size(71, 26);
            this.departuringdateTimePicker.TabIndex = 6;
            // 
            // arrivaldateTimePicker
            // 
            this.arrivaldateTimePicker.Location = new System.Drawing.Point(194, 242);
            this.arrivaldateTimePicker.Name = "arrivaldateTimePicker";
            this.arrivaldateTimePicker.Size = new System.Drawing.Size(71, 26);
            this.arrivaldateTimePicker.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Firma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nereden:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nereye:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Otobüs:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Sefer Ücreti:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Kalkış Tarihi:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tahmini Varış Tarihi:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(400, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(572, 537);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // searchbutton4
            // 
            this.searchbutton4.Location = new System.Drawing.Point(194, 368);
            this.searchbutton4.Name = "searchbutton4";
            this.searchbutton4.Size = new System.Drawing.Size(150, 26);
            this.searchbutton4.TabIndex = 19;
            this.searchbutton4.Text = "Ara";
            this.searchbutton4.UseVisualStyleBackColor = true;
            this.searchbutton4.Click += new System.EventHandler(this.searchbutton4_Click);
            // 
            // updatebutton3
            // 
            this.updatebutton3.Location = new System.Drawing.Point(194, 336);
            this.updatebutton3.Name = "updatebutton3";
            this.updatebutton3.Size = new System.Drawing.Size(150, 26);
            this.updatebutton3.TabIndex = 18;
            this.updatebutton3.Text = "Güncelle";
            this.updatebutton3.UseVisualStyleBackColor = true;
            this.updatebutton3.Click += new System.EventHandler(this.updatebutton3_Click);
            // 
            // deletebutton2
            // 
            this.deletebutton2.Location = new System.Drawing.Point(194, 306);
            this.deletebutton2.Name = "deletebutton2";
            this.deletebutton2.Size = new System.Drawing.Size(150, 26);
            this.deletebutton2.TabIndex = 17;
            this.deletebutton2.Text = "Sil";
            this.deletebutton2.UseVisualStyleBackColor = true;
            this.deletebutton2.Click += new System.EventHandler(this.deletebutton2_Click);
            // 
            // addbutton1
            // 
            this.addbutton1.Location = new System.Drawing.Point(194, 274);
            this.addbutton1.Name = "addbutton1";
            this.addbutton1.Size = new System.Drawing.Size(150, 26);
            this.addbutton1.TabIndex = 16;
            this.addbutton1.Text = "Ekle";
            this.addbutton1.UseVisualStyleBackColor = true;
            this.addbutton1.Click += new System.EventHandler(this.addbutton1_Click);
            // 
            // clearbutton1
            // 
            this.clearbutton1.Location = new System.Drawing.Point(194, 432);
            this.clearbutton1.Name = "clearbutton1";
            this.clearbutton1.Size = new System.Drawing.Size(150, 50);
            this.clearbutton1.TabIndex = 20;
            this.clearbutton1.Text = "Seçimleri Temizle";
            this.clearbutton1.UseVisualStyleBackColor = true;
            this.clearbutton1.Click += new System.EventHandler(this.clearbutton1_Click);
            // 
            // listallbutton1
            // 
            this.listallbutton1.Location = new System.Drawing.Point(194, 400);
            this.listallbutton1.Name = "listallbutton1";
            this.listallbutton1.Size = new System.Drawing.Size(150, 26);
            this.listallbutton1.TabIndex = 21;
            this.listallbutton1.Text = "Hepsini Listele";
            this.listallbutton1.UseVisualStyleBackColor = true;
            this.listallbutton1.Click += new System.EventHandler(this.listallbutton1_Click);
            // 
            // departtimePicker1
            // 
            this.departtimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.departtimePicker1.Location = new System.Drawing.Point(271, 210);
            this.departtimePicker1.Name = "departtimePicker1";
            this.departtimePicker1.Size = new System.Drawing.Size(115, 26);
            this.departtimePicker1.TabIndex = 22;
            // 
            // arrivaltimePicker1
            // 
            this.arrivaltimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.arrivaltimePicker1.Location = new System.Drawing.Point(271, 242);
            this.arrivaltimePicker1.Name = "arrivaltimePicker1";
            this.arrivaltimePicker1.Size = new System.Drawing.Size(115, 26);
            this.arrivaltimePicker1.TabIndex = 23;
            // 
            // form_pm_voyages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.arrivaltimePicker1);
            this.Controls.Add(this.departtimePicker1);
            this.Controls.Add(this.listallbutton1);
            this.Controls.Add(this.clearbutton1);
            this.Controls.Add(this.searchbutton4);
            this.Controls.Add(this.updatebutton3);
            this.Controls.Add(this.deletebutton2);
            this.Controls.Add(this.addbutton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.arrivaldateTimePicker);
            this.Controls.Add(this.departuringdateTimePicker);
            this.Controls.Add(this.totalpricelabel);
            this.Controls.Add(this.txtvoyageprice);
            this.Controls.Add(this.companycomboBox);
            this.Controls.Add(this.whichcomboBox);
            this.Controls.Add(this.wherecomboBox);
            this.Controls.Add(this.buscomboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form_pm_voyages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici Paneli: Seferler - Yolculuk";
            this.Load += new System.EventHandler(this.form_pm_voyages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox buscomboBox;
        private System.Windows.Forms.ComboBox wherecomboBox;
        private System.Windows.Forms.ComboBox whichcomboBox;
        private System.Windows.Forms.ComboBox companycomboBox;
        private System.Windows.Forms.TextBox txtvoyageprice;
        private System.Windows.Forms.Label totalpricelabel;
        private System.Windows.Forms.DateTimePicker departuringdateTimePicker;
        private System.Windows.Forms.DateTimePicker arrivaldateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button searchbutton4;
        private System.Windows.Forms.Button updatebutton3;
        private System.Windows.Forms.Button deletebutton2;
        private System.Windows.Forms.Button addbutton1;
        private System.Windows.Forms.Button clearbutton1;
        private System.Windows.Forms.Button listallbutton1;
        private System.Windows.Forms.DateTimePicker departtimePicker1;
        private System.Windows.Forms.DateTimePicker arrivaltimePicker1;
    }
}
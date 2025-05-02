
namespace YolculukDesktop
{
    partial class form_pm_companies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_pm_companies));
            this.txtcompname = new System.Windows.Forms.TextBox();
            this.addbutton1 = new System.Windows.Forms.Button();
            this.deletebutton2 = new System.Windows.Forms.Button();
            this.updatebutton3 = new System.Windows.Forms.Button();
            this.searchbutton4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.deletebutton1 = new System.Windows.Forms.Button();
            this.showbutton2 = new System.Windows.Forms.Button();
            this.savebutton3 = new System.Windows.Forms.Button();
            this.browsebutton4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcompname
            // 
            this.txtcompname.Location = new System.Drawing.Point(105, 12);
            this.txtcompname.MaxLength = 100;
            this.txtcompname.Name = "txtcompname";
            this.txtcompname.Size = new System.Drawing.Size(150, 26);
            this.txtcompname.TabIndex = 0;
            this.txtcompname.TextChanged += new System.EventHandler(this.txtcompname_TextChanged);
            // 
            // addbutton1
            // 
            this.addbutton1.Location = new System.Drawing.Point(105, 44);
            this.addbutton1.Name = "addbutton1";
            this.addbutton1.Size = new System.Drawing.Size(150, 26);
            this.addbutton1.TabIndex = 1;
            this.addbutton1.Text = "Ekle";
            this.addbutton1.UseVisualStyleBackColor = true;
            this.addbutton1.Click += new System.EventHandler(this.addbutton1_Click);
            // 
            // deletebutton2
            // 
            this.deletebutton2.Location = new System.Drawing.Point(105, 76);
            this.deletebutton2.Name = "deletebutton2";
            this.deletebutton2.Size = new System.Drawing.Size(150, 26);
            this.deletebutton2.TabIndex = 2;
            this.deletebutton2.Text = "Sil";
            this.deletebutton2.UseVisualStyleBackColor = true;
            this.deletebutton2.Click += new System.EventHandler(this.deletebutton2_Click);
            // 
            // updatebutton3
            // 
            this.updatebutton3.Location = new System.Drawing.Point(105, 106);
            this.updatebutton3.Name = "updatebutton3";
            this.updatebutton3.Size = new System.Drawing.Size(150, 26);
            this.updatebutton3.TabIndex = 3;
            this.updatebutton3.Text = "Güncelle";
            this.updatebutton3.UseVisualStyleBackColor = true;
            this.updatebutton3.Click += new System.EventHandler(this.updatebutton3_Click);
            // 
            // searchbutton4
            // 
            this.searchbutton4.Location = new System.Drawing.Point(105, 138);
            this.searchbutton4.Name = "searchbutton4";
            this.searchbutton4.Size = new System.Drawing.Size(150, 26);
            this.searchbutton4.TabIndex = 4;
            this.searchbutton4.Text = "Ara";
            this.searchbutton4.UseVisualStyleBackColor = true;
            this.searchbutton4.Click += new System.EventHandler(this.searchbutton4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Firma Adı:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(279, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(328, 538);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(620, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Resim Ekle";
            // 
            // deletebutton1
            // 
            this.deletebutton1.Location = new System.Drawing.Point(728, 402);
            this.deletebutton1.Name = "deletebutton1";
            this.deletebutton1.Size = new System.Drawing.Size(150, 26);
            this.deletebutton1.TabIndex = 12;
            this.deletebutton1.Text = "Resmi Sil";
            this.deletebutton1.UseVisualStyleBackColor = true;
            this.deletebutton1.Click += new System.EventHandler(this.deletebutton1_Click);
            // 
            // showbutton2
            // 
            this.showbutton2.Location = new System.Drawing.Point(728, 370);
            this.showbutton2.Name = "showbutton2";
            this.showbutton2.Size = new System.Drawing.Size(150, 26);
            this.showbutton2.TabIndex = 11;
            this.showbutton2.Text = "Resmi Göster";
            this.showbutton2.UseVisualStyleBackColor = true;
            this.showbutton2.Click += new System.EventHandler(this.showbutton2_Click);
            // 
            // savebutton3
            // 
            this.savebutton3.Location = new System.Drawing.Point(728, 340);
            this.savebutton3.Name = "savebutton3";
            this.savebutton3.Size = new System.Drawing.Size(150, 26);
            this.savebutton3.TabIndex = 10;
            this.savebutton3.Text = "Resmi Kaydet";
            this.savebutton3.UseVisualStyleBackColor = true;
            this.savebutton3.Click += new System.EventHandler(this.savebutton3_Click);
            // 
            // browsebutton4
            // 
            this.browsebutton4.Location = new System.Drawing.Point(728, 308);
            this.browsebutton4.Name = "browsebutton4";
            this.browsebutton4.Size = new System.Drawing.Size(150, 26);
            this.browsebutton4.TabIndex = 9;
            this.browsebutton4.Text = "Resim Yükle";
            this.browsebutton4.UseVisualStyleBackColor = true;
            this.browsebutton4.Click += new System.EventHandler(this.browsebutton4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "Kazançlar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(624, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 258);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // form_pm_companies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deletebutton1);
            this.Controls.Add(this.showbutton2);
            this.Controls.Add(this.savebutton3);
            this.Controls.Add(this.browsebutton4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchbutton4);
            this.Controls.Add(this.updatebutton3);
            this.Controls.Add(this.deletebutton2);
            this.Controls.Add(this.addbutton1);
            this.Controls.Add(this.txtcompname);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form_pm_companies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici Paneli: Firmalar - Yolculuk";
            this.Load += new System.EventHandler(this.form_pm_companies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcompname;
        private System.Windows.Forms.Button addbutton1;
        private System.Windows.Forms.Button deletebutton2;
        private System.Windows.Forms.Button updatebutton3;
        private System.Windows.Forms.Button searchbutton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deletebutton1;
        private System.Windows.Forms.Button showbutton2;
        private System.Windows.Forms.Button savebutton3;
        private System.Windows.Forms.Button browsebutton4;
        private System.Windows.Forms.Button button1;
    }
}
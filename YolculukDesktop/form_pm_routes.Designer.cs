
namespace YolculukDesktop
{
    partial class form_pm_routes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_pm_routes));
            this.searchbutton4 = new System.Windows.Forms.Button();
            this.updatebutton3 = new System.Windows.Forms.Button();
            this.deletebutton2 = new System.Windows.Forms.Button();
            this.addbutton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcompname = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchbutton4
            // 
            this.searchbutton4.Location = new System.Drawing.Point(8, 158);
            this.searchbutton4.Name = "searchbutton4";
            this.searchbutton4.Size = new System.Drawing.Size(150, 26);
            this.searchbutton4.TabIndex = 15;
            this.searchbutton4.Text = "Ara";
            this.searchbutton4.UseVisualStyleBackColor = true;
            this.searchbutton4.Click += new System.EventHandler(this.searchbutton4_Click);
            // 
            // updatebutton3
            // 
            this.updatebutton3.Location = new System.Drawing.Point(8, 126);
            this.updatebutton3.Name = "updatebutton3";
            this.updatebutton3.Size = new System.Drawing.Size(150, 26);
            this.updatebutton3.TabIndex = 14;
            this.updatebutton3.Text = "Güncelle";
            this.updatebutton3.UseVisualStyleBackColor = true;
            this.updatebutton3.Click += new System.EventHandler(this.updatebutton3_Click);
            // 
            // deletebutton2
            // 
            this.deletebutton2.Location = new System.Drawing.Point(8, 96);
            this.deletebutton2.Name = "deletebutton2";
            this.deletebutton2.Size = new System.Drawing.Size(150, 26);
            this.deletebutton2.TabIndex = 13;
            this.deletebutton2.Text = "Sil";
            this.deletebutton2.UseVisualStyleBackColor = true;
            this.deletebutton2.Click += new System.EventHandler(this.deletebutton2_Click);
            // 
            // addbutton1
            // 
            this.addbutton1.Location = new System.Drawing.Point(8, 64);
            this.addbutton1.Name = "addbutton1";
            this.addbutton1.Size = new System.Drawing.Size(150, 26);
            this.addbutton1.TabIndex = 12;
            this.addbutton1.Text = "Ekle";
            this.addbutton1.UseVisualStyleBackColor = true;
            this.addbutton1.Click += new System.EventHandler(this.addbutton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Güzergah Adı:";
            // 
            // txtcompname
            // 
            this.txtcompname.Location = new System.Drawing.Point(8, 32);
            this.txtcompname.MaxLength = 100;
            this.txtcompname.Name = "txtcompname";
            this.txtcompname.Size = new System.Drawing.Size(150, 26);
            this.txtcompname.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(234, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(338, 341);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // form_pm_routes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcompname);
            this.Controls.Add(this.searchbutton4);
            this.Controls.Add(this.updatebutton3);
            this.Controls.Add(this.deletebutton2);
            this.Controls.Add(this.addbutton1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form_pm_routes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici Paneli: Güzergahlar - Yolculuk";
            this.Load += new System.EventHandler(this.form_pm_routes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchbutton4;
        private System.Windows.Forms.Button updatebutton3;
        private System.Windows.Forms.Button deletebutton2;
        private System.Windows.Forms.Button addbutton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcompname;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
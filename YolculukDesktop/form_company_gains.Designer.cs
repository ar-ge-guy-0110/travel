
namespace YolculukDesktop
{
    partial class form_company_gains
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_company_gains));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.searchbutton4 = new System.Windows.Forms.Button();
            this.txtcompname = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(369, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(603, 538);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Firma Adı:";
            // 
            // searchbutton4
            // 
            this.searchbutton4.Location = new System.Drawing.Point(213, 76);
            this.searchbutton4.Name = "searchbutton4";
            this.searchbutton4.Size = new System.Drawing.Size(150, 26);
            this.searchbutton4.TabIndex = 7;
            this.searchbutton4.Text = "Ara";
            this.searchbutton4.UseVisualStyleBackColor = true;
            this.searchbutton4.Click += new System.EventHandler(this.searchbutton4_Click);
            // 
            // txtcompname
            // 
            this.txtcompname.Location = new System.Drawing.Point(213, 12);
            this.txtcompname.MaxLength = 100;
            this.txtcompname.Name = "txtcompname";
            this.txtcompname.Size = new System.Drawing.Size(150, 26);
            this.txtcompname.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(213, 44);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 26);
            this.textBox1.TabIndex = 9;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kazanç:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 26);
            this.button1.TabIndex = 11;
            this.button1.Text = "Hepsini Getir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // form_company_gains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchbutton4);
            this.Controls.Add(this.txtcompname);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form_company_gains";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firmalar: Kazançlar - Yolculuk";
            this.Load += new System.EventHandler(this.form_company_gains_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchbutton4;
        private System.Windows.Forms.TextBox txtcompname;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
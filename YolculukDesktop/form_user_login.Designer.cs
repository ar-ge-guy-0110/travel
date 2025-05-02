
namespace YolculukDesktop
{
    partial class form_user_login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_user_login));
            this.button1 = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.registerlabel = new System.Windows.Forms.Label();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Giriş Yap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(104, 157);
            this.txtpassword.MaxLength = 100;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(150, 26);
            this.txtpassword.TabIndex = 2;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(104, 125);
            this.txtemail.MaxLength = 100;
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(150, 26);
            this.txtemail.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "E-Posta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Şifre:";
            // 
            // registerlabel
            // 
            this.registerlabel.AutoSize = true;
            this.registerlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.registerlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(146)))), ((int)(((byte)(237)))));
            this.registerlabel.Location = new System.Drawing.Point(50, 218);
            this.registerlabel.Name = "registerlabel";
            this.registerlabel.Size = new System.Drawing.Size(264, 17);
            this.registerlabel.TabIndex = 6;
            this.registerlabel.Text = "Hesabın yok mu? Burdan kaydolabilirsin.";
            this.registerlabel.Click += new System.EventHandler(this.registerlabel_Click);
            this.registerlabel.MouseEnter += new System.EventHandler(this.registerlabel_MouseEnter);
            this.registerlabel.MouseLeave += new System.EventHandler(this.registerlabel_MouseLeave);
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.infoLabel1.Location = new System.Drawing.Point(50, 235);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(23, 17);
            this.infoLabel1.TabIndex = 7;
            this.infoLabel1.Text = "---";
            // 
            // form_user_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 362);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.registerlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form_user_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yolculuk - Giriş Yap";
            this.Load += new System.EventHandler(this.form_user_login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label registerlabel;
        private System.Windows.Forms.Label infoLabel1;
    }
}


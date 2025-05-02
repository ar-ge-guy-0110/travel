
namespace YolculukDesktop
{
    partial class form_pm_panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_pm_panel));
            this.firmatanimbutton = new System.Windows.Forms.Button();
            this.otobustanimbutton = new System.Windows.Forms.Button();
            this.guztanimbutton = new System.Windows.Forms.Button();
            this.sefertanimbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firmatanimbutton
            // 
            this.firmatanimbutton.Location = new System.Drawing.Point(12, 12);
            this.firmatanimbutton.Name = "firmatanimbutton";
            this.firmatanimbutton.Size = new System.Drawing.Size(150, 150);
            this.firmatanimbutton.TabIndex = 0;
            this.firmatanimbutton.Text = "Firma Tanımları";
            this.firmatanimbutton.UseVisualStyleBackColor = true;
            this.firmatanimbutton.Click += new System.EventHandler(this.firmatanimbutton_Click);
            // 
            // otobustanimbutton
            // 
            this.otobustanimbutton.Location = new System.Drawing.Point(168, 12);
            this.otobustanimbutton.Name = "otobustanimbutton";
            this.otobustanimbutton.Size = new System.Drawing.Size(150, 150);
            this.otobustanimbutton.TabIndex = 1;
            this.otobustanimbutton.Text = "Otobüs Tanımları";
            this.otobustanimbutton.UseVisualStyleBackColor = true;
            this.otobustanimbutton.Click += new System.EventHandler(this.otobustanimbutton_Click);
            // 
            // guztanimbutton
            // 
            this.guztanimbutton.Location = new System.Drawing.Point(324, 12);
            this.guztanimbutton.Name = "guztanimbutton";
            this.guztanimbutton.Size = new System.Drawing.Size(150, 150);
            this.guztanimbutton.TabIndex = 2;
            this.guztanimbutton.Text = "Güzergah Tanımları";
            this.guztanimbutton.UseVisualStyleBackColor = true;
            this.guztanimbutton.Click += new System.EventHandler(this.guztanimbutton_Click);
            // 
            // sefertanimbutton
            // 
            this.sefertanimbutton.Location = new System.Drawing.Point(480, 12);
            this.sefertanimbutton.Name = "sefertanimbutton";
            this.sefertanimbutton.Size = new System.Drawing.Size(150, 150);
            this.sefertanimbutton.TabIndex = 3;
            this.sefertanimbutton.Text = "Sefer Tanımları";
            this.sefertanimbutton.UseVisualStyleBackColor = true;
            this.sefertanimbutton.Click += new System.EventHandler(this.sefertanimbutton_Click);
            // 
            // form_pm_panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 262);
            this.Controls.Add(this.sefertanimbutton);
            this.Controls.Add(this.guztanimbutton);
            this.Controls.Add(this.otobustanimbutton);
            this.Controls.Add(this.firmatanimbutton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form_pm_panel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici Paneli - Yolculuk";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_pm_panel_FormClosed);
            this.Load += new System.EventHandler(this.form_pm_panel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button firmatanimbutton;
        private System.Windows.Forms.Button otobustanimbutton;
        private System.Windows.Forms.Button guztanimbutton;
        private System.Windows.Forms.Button sefertanimbutton;
    }
}
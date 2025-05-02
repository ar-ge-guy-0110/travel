
namespace YolculukDesktop
{
    partial class form_seethebus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_seethebus));
            this.panel1 = new System.Windows.Forms.Panel();
            this.multiflow = new System.Windows.Forms.FlowLayoutPanel();
            this.singleflow = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.multiflow);
            this.panel1.Controls.Add(this.singleflow);
            this.panel1.Location = new System.Drawing.Point(70, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 257);
            this.panel1.TabIndex = 0;
            // 
            // multiflow
            // 
            this.multiflow.AutoScroll = true;
            this.multiflow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.multiflow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.multiflow.Location = new System.Drawing.Point(179, 38);
            this.multiflow.Name = "multiflow";
            this.multiflow.Size = new System.Drawing.Size(552, 124);
            this.multiflow.TabIndex = 1;
            // 
            // singleflow
            // 
            this.singleflow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.singleflow.Location = new System.Drawing.Point(179, 168);
            this.singleflow.Name = "singleflow";
            this.singleflow.Size = new System.Drawing.Size(552, 59);
            this.singleflow.TabIndex = 0;
            // 
            // form_seethebus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(984, 312);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form_seethebus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Otobüsü Gör - Yolculuk";
            this.Load += new System.EventHandler(this.form_seethebus_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel singleflow;
        private System.Windows.Forms.FlowLayoutPanel multiflow;
    }
}
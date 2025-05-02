
namespace YolculukDesktop
{
    partial class denemeform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(denemeform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.multiflow = new System.Windows.Forms.FlowLayoutPanel();
            this.singleflow = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.panel1.Location = new System.Drawing.Point(120, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 418);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "yolculuk ne kadar sürer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(456, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "nerden nereye";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(721, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "70.5 TL";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Onayla";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 96);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.multiflow);
            this.panel2.Controls.Add(this.singleflow);
            this.panel2.Location = new System.Drawing.Point(22, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(788, 257);
            this.panel2.TabIndex = 2;
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
            // denemeform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1010, 560);
            this.Controls.Add(this.panel1);
            this.Name = "denemeform";
            this.Text = "denemeform";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel multiflow;
        private System.Windows.Forms.FlowLayoutPanel singleflow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
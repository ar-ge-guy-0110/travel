
namespace YolculukDesktop
{
    partial class form_yolculuk_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_yolculuk_main));
            this.flowbuses = new System.Windows.Forms.FlowLayoutPanel();
            this.selectionpanel = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.selectionpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowbuses
            // 
            this.flowbuses.AutoScroll = true;
            this.flowbuses.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowbuses.Location = new System.Drawing.Point(446, 13);
            this.flowbuses.Name = "flowbuses";
            this.flowbuses.Size = new System.Drawing.Size(926, 738);
            this.flowbuses.TabIndex = 0;
            // 
            // selectionpanel
            // 
            this.selectionpanel.Controls.Add(this.button2);
            this.selectionpanel.Controls.Add(this.button1);
            this.selectionpanel.Controls.Add(this.label3);
            this.selectionpanel.Controls.Add(this.label2);
            this.selectionpanel.Controls.Add(this.label1);
            this.selectionpanel.Controls.Add(this.dateTimePicker1);
            this.selectionpanel.Controls.Add(this.comboBox2);
            this.selectionpanel.Controls.Add(this.comboBox1);
            this.selectionpanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.selectionpanel.Location = new System.Drawing.Point(13, 13);
            this.selectionpanel.Name = "selectionpanel";
            this.selectionpanel.Size = new System.Drawing.Size(412, 356);
            this.selectionpanel.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(56, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(300, 33);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(56, 92);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(300, 33);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(56, 147);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(300, 31);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(53, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kalkış Noktası:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(53, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Varış Noktası:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(53, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Yolculuk Tarihi:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Otobüs Bileti Bul";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(56, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 50);
            this.button2.TabIndex = 7;
            this.button2.Text = "Hepsini Getir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // form_yolculuk_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 762);
            this.Controls.Add(this.selectionpanel);
            this.Controls.Add(this.flowbuses);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form_yolculuk_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yolculuk Yap! - Yolculuk";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_yolculuk_main_FormClosed);
            this.Load += new System.EventHandler(this.form_yolculuk_main_Load);
            this.selectionpanel.ResumeLayout(false);
            this.selectionpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowbuses;
        private System.Windows.Forms.Panel selectionpanel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
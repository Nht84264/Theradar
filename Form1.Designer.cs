
namespace Theradar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bttieudiet = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnguoc = new System.Windows.Forms.RadioButton();
            this.rbtthuan = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtthang = new System.Windows.Forms.RadioButton();
            this.rbttron = new System.Windows.Forms.RadioButton();
            this.rbtxoanoc = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.trackbarspeed = new System.Windows.Forms.TrackBar();
            this.ptron = new System.Windows.Forms.PictureBox();
            this.pthang = new System.Windows.Forms.PictureBox();
            this.pxoanoc = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoSprial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptron)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pthang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxoanoc)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(22, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(830, 138);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 28);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Chọn mục tiêu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(591, 137);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Đưa dữ liệu vào";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bttieudiet
            // 
            this.bttieudiet.Location = new System.Drawing.Point(723, 137);
            this.bttieudiet.Name = "bttieudiet";
            this.bttieudiet.Size = new System.Drawing.Size(101, 28);
            this.bttieudiet.TabIndex = 5;
            this.bttieudiet.Text = "Tiêu diệt";
            this.bttieudiet.UseVisualStyleBackColor = true;
            this.bttieudiet.Click += new System.EventHandler(this.bttieudiet_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(461, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(465, 119);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Số liệu";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Phân loại";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Góc";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Khoảng cách";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Độ cao";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Vận tốc";
            this.columnHeader6.Width = 90;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnguoc);
            this.panel1.Controls.Add(this.rbtthuan);
            this.panel1.Location = new System.Drawing.Point(22, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 70);
            this.panel1.TabIndex = 7;
            // 
            // rbtnguoc
            // 
            this.rbtnguoc.AutoSize = true;
            this.rbtnguoc.Location = new System.Drawing.Point(9, 40);
            this.rbtnguoc.Name = "rbtnguoc";
            this.rbtnguoc.Size = new System.Drawing.Size(147, 24);
            this.rbtnguoc.TabIndex = 1;
            this.rbtnguoc.TabStop = true;
            this.rbtnguoc.Text = "Quét chiều ngược";
            this.rbtnguoc.UseVisualStyleBackColor = true;
            this.rbtnguoc.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbtthuan
            // 
            this.rbtthuan.AutoSize = true;
            this.rbtthuan.Location = new System.Drawing.Point(9, 10);
            this.rbtthuan.Name = "rbtthuan";
            this.rbtthuan.Size = new System.Drawing.Size(142, 24);
            this.rbtthuan.TabIndex = 0;
            this.rbtthuan.TabStop = true;
            this.rbtthuan.Text = "Quét chiều thuận";
            this.rbtthuan.UseVisualStyleBackColor = true;
            this.rbtthuan.CheckedChanged += new System.EventHandler(this.rbtthuan_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbtthang);
            this.panel3.Controls.Add(this.rbttron);
            this.panel3.Controls.Add(this.rbtxoanoc);
            this.panel3.Location = new System.Drawing.Point(22, 318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(413, 57);
            this.panel3.TabIndex = 8;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // rbtthang
            // 
            this.rbtthang.AutoSize = true;
            this.rbtthang.Location = new System.Drawing.Point(9, 21);
            this.rbtthang.Name = "rbtthang";
            this.rbtthang.Size = new System.Drawing.Size(104, 24);
            this.rbtthang.TabIndex = 9;
            this.rbtthang.TabStop = true;
            this.rbtthang.Text = "Quét thẳng";
            this.rbtthang.UseVisualStyleBackColor = true;
            this.rbtthang.CheckedChanged += new System.EventHandler(this.rbtthang_CheckedChanged);
            // 
            // rbttron
            // 
            this.rbttron.AutoSize = true;
            this.rbttron.Location = new System.Drawing.Point(135, 21);
            this.rbttron.Name = "rbttron";
            this.rbttron.Size = new System.Drawing.Size(93, 24);
            this.rbttron.TabIndex = 10;
            this.rbttron.TabStop = true;
            this.rbttron.Text = "Quét tròn";
            this.rbttron.UseVisualStyleBackColor = true;
            this.rbttron.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // rbtxoanoc
            // 
            this.rbtxoanoc.AutoSize = true;
            this.rbtxoanoc.Location = new System.Drawing.Point(273, 21);
            this.rbtxoanoc.Name = "rbtxoanoc";
            this.rbtxoanoc.Size = new System.Drawing.Size(118, 24);
            this.rbtxoanoc.TabIndex = 11;
            this.rbtxoanoc.TabStop = true;
            this.rbtxoanoc.Text = "Quét xoắn ốc";
            this.rbtxoanoc.UseVisualStyleBackColor = true;
            this.rbtxoanoc.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tốc độ quét";
            // 
            // trackbarspeed
            // 
            this.trackbarspeed.Location = new System.Drawing.Point(295, 408);
            this.trackbarspeed.Name = "trackbarspeed";
            this.trackbarspeed.Size = new System.Drawing.Size(140, 56);
            this.trackbarspeed.TabIndex = 10;
            this.trackbarspeed.Scroll += new System.EventHandler(this.trackbarspeed_Scroll);
            // 
            // ptron
            // 
            this.ptron.BackColor = System.Drawing.SystemColors.Highlight;
            this.ptron.Location = new System.Drawing.Point(485, 172);
            this.ptron.Name = "ptron";
            this.ptron.Size = new System.Drawing.Size(413, 300);
            this.ptron.TabIndex = 11;
            this.ptron.TabStop = false;
            this.ptron.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pthang
            // 
            this.pthang.BackColor = System.Drawing.SystemColors.Highlight;
            this.pthang.Location = new System.Drawing.Point(465, 345);
            this.pthang.Name = "pthang";
            this.pthang.Size = new System.Drawing.Size(418, 140);
            this.pthang.TabIndex = 12;
            this.pthang.TabStop = false;
            // 
            // pxoanoc
            // 
            this.pxoanoc.BackColor = System.Drawing.SystemColors.Highlight;
            this.pxoanoc.Location = new System.Drawing.Point(470, 185);
            this.pxoanoc.Name = "pxoanoc";
            this.pxoanoc.Size = new System.Drawing.Size(413, 300);
            this.pxoanoc.TabIndex = 13;
            this.pxoanoc.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 477);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Đồ án I - Nguyễn Hữu Thắng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Số vòng";
            // 
            // txtNoSprial
            // 
            this.txtNoSprial.Location = new System.Drawing.Point(307, 449);
            this.txtNoSprial.Name = "txtNoSprial";
            this.txtNoSprial.Size = new System.Drawing.Size(119, 27);
            this.txtNoSprial.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 516);
            this.Controls.Add(this.txtNoSprial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pxoanoc);
            this.Controls.Add(this.pthang);
            this.Controls.Add(this.ptron);
            this.Controls.Add(this.trackbarspeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bttieudiet);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Hiển thị Radar";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptron)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pthang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxoanoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bttieudiet;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnguoc;
        private System.Windows.Forms.RadioButton rbtthuan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbtxoanoc;
        private System.Windows.Forms.RadioButton rbtthang;
        private System.Windows.Forms.RadioButton rbttron;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackbarspeed;
        private System.Windows.Forms.PictureBox ptron;
        private System.Windows.Forms.PictureBox pthang;
        private System.Windows.Forms.PictureBox pxoanoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoSprial;
    }
}


namespace QuanLyNhanVienLVTN
{
    partial class LichLamViec
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnToDay = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlMatrix = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnSunday = new System.Windows.Forms.Button();
            this.btnSaturday = new System.Windows.Forms.Button();
            this.btnFriday = new System.Windows.Forms.Button();
            this.btnThursday = new System.Windows.Forms.Button();
            this.btnWensday = new System.Windows.Forms.Button();
            this.btnTuesday = new System.Windows.Forms.Button();
            this.btnMonday = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.btnToDay.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnToDay);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(15, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 414);
            this.panel1.TabIndex = 0;
            // 
            // btnToDay
            // 
            this.btnToDay.Controls.Add(this.button1);
            this.btnToDay.Controls.Add(this.dtpkDate);
            this.btnToDay.Location = new System.Drawing.Point(3, 3);
            this.btnToDay.Name = "btnToDay";
            this.btnToDay.Size = new System.Drawing.Size(736, 33);
            this.btnToDay.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(428, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hôm nay";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpkDate
            // 
            this.dtpkDate.Location = new System.Drawing.Point(222, 7);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(200, 20);
            this.dtpkDate.TabIndex = 0;
            this.dtpkDate.ValueChanged += new System.EventHandler(this.dtpkDate_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlMatrix);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(24, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 361);
            this.panel2.TabIndex = 1;
            // 
            // pnlMatrix
            // 
            this.pnlMatrix.BackColor = System.Drawing.Color.LightGray;
            this.pnlMatrix.Location = new System.Drawing.Point(96, 69);
            this.pnlMatrix.Name = "pnlMatrix";
            this.pnlMatrix.Size = new System.Drawing.Size(484, 224);
            this.pnlMatrix.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNext);
            this.panel3.Controls.Add(this.btnPrevious);
            this.panel3.Controls.Add(this.btnSunday);
            this.panel3.Controls.Add(this.btnSaturday);
            this.panel3.Controls.Add(this.btnFriday);
            this.panel3.Controls.Add(this.btnThursday);
            this.panel3.Controls.Add(this.btnWensday);
            this.panel3.Controls.Add(this.btnTuesday);
            this.panel3.Controls.Add(this.btnMonday);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(670, 43);
            this.panel3.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(603, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(64, 37);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Tháng sau";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(3, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(64, 37);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "Tháng trước";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnSunday
            // 
            this.btnSunday.BackColor = System.Drawing.Color.White;
            this.btnSunday.FlatAppearance.BorderSize = 0;
            this.btnSunday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSunday.Location = new System.Drawing.Point(513, 3);
            this.btnSunday.Name = "btnSunday";
            this.btnSunday.Size = new System.Drawing.Size(64, 37);
            this.btnSunday.TabIndex = 6;
            this.btnSunday.Text = "Chủ nhật";
            this.btnSunday.UseVisualStyleBackColor = false;
            // 
            // btnSaturday
            // 
            this.btnSaturday.BackColor = System.Drawing.Color.White;
            this.btnSaturday.FlatAppearance.BorderSize = 0;
            this.btnSaturday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaturday.Location = new System.Drawing.Point(443, 3);
            this.btnSaturday.Name = "btnSaturday";
            this.btnSaturday.Size = new System.Drawing.Size(64, 37);
            this.btnSaturday.TabIndex = 5;
            this.btnSaturday.Text = "Thứ 7";
            this.btnSaturday.UseVisualStyleBackColor = false;
            // 
            // btnFriday
            // 
            this.btnFriday.BackColor = System.Drawing.Color.White;
            this.btnFriday.FlatAppearance.BorderSize = 0;
            this.btnFriday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFriday.Location = new System.Drawing.Point(373, 3);
            this.btnFriday.Name = "btnFriday";
            this.btnFriday.Size = new System.Drawing.Size(64, 37);
            this.btnFriday.TabIndex = 4;
            this.btnFriday.Text = "Thứ 6";
            this.btnFriday.UseVisualStyleBackColor = false;
            // 
            // btnThursday
            // 
            this.btnThursday.BackColor = System.Drawing.Color.White;
            this.btnThursday.FlatAppearance.BorderSize = 0;
            this.btnThursday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThursday.Location = new System.Drawing.Point(303, 3);
            this.btnThursday.Name = "btnThursday";
            this.btnThursday.Size = new System.Drawing.Size(64, 37);
            this.btnThursday.TabIndex = 3;
            this.btnThursday.Text = "Thứ 5";
            this.btnThursday.UseVisualStyleBackColor = false;
            // 
            // btnWensday
            // 
            this.btnWensday.BackColor = System.Drawing.Color.White;
            this.btnWensday.FlatAppearance.BorderSize = 0;
            this.btnWensday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWensday.Location = new System.Drawing.Point(233, 3);
            this.btnWensday.Name = "btnWensday";
            this.btnWensday.Size = new System.Drawing.Size(64, 37);
            this.btnWensday.TabIndex = 2;
            this.btnWensday.Text = "Thứ 4";
            this.btnWensday.UseVisualStyleBackColor = false;
            // 
            // btnTuesday
            // 
            this.btnTuesday.BackColor = System.Drawing.Color.White;
            this.btnTuesday.FlatAppearance.BorderSize = 0;
            this.btnTuesday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuesday.Location = new System.Drawing.Point(163, 3);
            this.btnTuesday.Name = "btnTuesday";
            this.btnTuesday.Size = new System.Drawing.Size(64, 37);
            this.btnTuesday.TabIndex = 1;
            this.btnTuesday.Text = "Thứ 3";
            this.btnTuesday.UseVisualStyleBackColor = false;
            // 
            // btnMonday
            // 
            this.btnMonday.BackColor = System.Drawing.Color.White;
            this.btnMonday.FlatAppearance.BorderSize = 0;
            this.btnMonday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonday.Location = new System.Drawing.Point(93, 3);
            this.btnMonday.Name = "btnMonday";
            this.btnMonday.Size = new System.Drawing.Size(64, 37);
            this.btnMonday.TabIndex = 0;
            this.btnMonday.Text = "Thứ 2";
            this.btnMonday.UseVisualStyleBackColor = false;
            this.btnMonday.Click += new System.EventHandler(this.btnMonday_Click);
            // 
            // LichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(813, 428);
            this.Controls.Add(this.panel1);
            this.Name = "LichLamViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch_làm_việc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LichLamViec_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LichLamViec_FormClosed);
            this.Load += new System.EventHandler(this.LichLamViec_Load);
            this.panel1.ResumeLayout(false);
            this.btnToDay.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel btnToDay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSunday;
        private System.Windows.Forms.Button btnSaturday;
        private System.Windows.Forms.Button btnFriday;
        private System.Windows.Forms.Button btnThursday;
        private System.Windows.Forms.Button btnWensday;
        private System.Windows.Forms.Button btnTuesday;
        private System.Windows.Forms.Button btnMonday;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Panel pnlMatrix;
    }
}
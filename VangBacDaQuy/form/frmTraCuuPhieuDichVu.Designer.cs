namespace VangBacDaQuy.form
{
    partial class frmTraCuuPhieuDichVu
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
            this.dgvTraCuuPhieuDichVu = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboMaKH = new System.Windows.Forms.ComboBox();
            this.cboSoPhieu = new System.Windows.Forms.ComboBox();
            this.txbTenKH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXoaPhieu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtmNgayLap = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuuPhieuDichVu)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTraCuuPhieuDichVu
            // 
            this.dgvTraCuuPhieuDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraCuuPhieuDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraCuuPhieuDichVu.Location = new System.Drawing.Point(0, 140);
            this.dgvTraCuuPhieuDichVu.Name = "dgvTraCuuPhieuDichVu";
            this.dgvTraCuuPhieuDichVu.RowHeadersWidth = 51;
            this.dgvTraCuuPhieuDichVu.RowTemplate.Height = 24;
            this.dgvTraCuuPhieuDichVu.Size = new System.Drawing.Size(800, 220);
            this.dgvTraCuuPhieuDichVu.TabIndex = 4;
            this.dgvTraCuuPhieuDichVu.Click += new System.EventHandler(this.dgvTraCuuPhieuDichVu_Click);
            this.dgvTraCuuPhieuDichVu.DoubleClick += new System.EventHandler(this.dgvTraCuuPhieuDichVu_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtmNgayLap);
            this.panel2.Controls.Add(this.cboMaKH);
            this.panel2.Controls.Add(this.cboSoPhieu);
            this.panel2.Controls.Add(this.txbTenKH);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 140);
            this.panel2.TabIndex = 0;
            // 
            // cboMaKH
            // 
            this.cboMaKH.FormattingEnabled = true;
            this.cboMaKH.Location = new System.Drawing.Point(537, 43);
            this.cboMaKH.Name = "cboMaKH";
            this.cboMaKH.Size = new System.Drawing.Size(178, 24);
            this.cboMaKH.TabIndex = 1;
            this.cboMaKH.SelectedIndexChanged += new System.EventHandler(this.cboMaKH_SelectedIndexChanged);
            this.cboMaKH.Click += new System.EventHandler(this.cboMaKH_Click);
            // 
            // cboSoPhieu
            // 
            this.cboSoPhieu.FormattingEnabled = true;
            this.cboSoPhieu.Location = new System.Drawing.Point(159, 43);
            this.cboSoPhieu.Name = "cboSoPhieu";
            this.cboSoPhieu.Size = new System.Drawing.Size(178, 24);
            this.cboSoPhieu.TabIndex = 0;
            this.cboSoPhieu.Click += new System.EventHandler(this.cboSoPhieu_Click);
            // 
            // txbTenKH
            // 
            this.txbTenKH.Location = new System.Drawing.Point(537, 89);
            this.txbTenKH.Name = "txbTenKH";
            this.txbTenKH.Size = new System.Drawing.Size(178, 22);
            this.txbTenKH.TabIndex = 3;
            this.txbTenKH.Click += new System.EventHandler(this.txbTenKH_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tên khách hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã khách hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày lập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số phiếu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(261, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRA CỨU PHIẾU DỊCH VỤ";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(159, 45);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 23);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(558, 44);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 23);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXoaPhieu);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 360);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 90);
            this.panel1.TabIndex = 1;
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.Location = new System.Drawing.Point(355, 44);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.Size = new System.Drawing.Size(90, 23);
            this.btnXoaPhieu.TabIndex = 6;
            this.btnXoaPhieu.Text = "Xóa Phiếu";
            this.btnXoaPhieu.UseVisualStyleBackColor = true;
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(22, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nháy đúp một dòng để xam chi tiết phiếu dịch vụ.";
            // 
            // dtmNgayLap
            // 
            this.dtmNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmNgayLap.Location = new System.Drawing.Point(159, 88);
            this.dtmNgayLap.Name = "dtmNgayLap";
            this.dtmNgayLap.Size = new System.Drawing.Size(178, 22);
            this.dtmNgayLap.TabIndex = 5;
            // 
            // frmTraCuuPhieuDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTraCuuPhieuDichVu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTraCuuPhieuDichVu";
            this.Text = "TraCuuPhieuDichVu";
            this.Load += new System.EventHandler(this.frmTraCuuPhieuDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuuPhieuDichVu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTraCuuPhieuDichVu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbTenKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboMaKH;
        private System.Windows.Forms.ComboBox cboSoPhieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXoaPhieu;
        private System.Windows.Forms.DateTimePicker dtmNgayLap;
    }
}
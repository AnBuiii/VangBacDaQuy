namespace VangBacDaQuy.form
{
    partial class frmSanPham
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbMaLoaiSp = new System.Windows.Forms.ComboBox();
            this.txbTenLoaiSp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbSL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbDongia = new System.Windows.Forms.TextBox();
            this.txbTenSp = new System.Windows.Forms.TextBox();
            this.txbMaSp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvPhieuBanHang = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvPhieuMuaHang = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuBanHang)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuaHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 604);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 67);
            this.panel1.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(547, 33);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(655, 34);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 23);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(424, 33);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 23);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(301, 33);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 23);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(178, 33);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 23);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa\r\n";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(55, 34);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbMaLoaiSp);
            this.panel2.Controls.Add(this.txbTenLoaiSp);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txbSL);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txbDongia);
            this.panel2.Controls.Add(this.txbTenSp);
            this.panel2.Controls.Add(this.txbMaSp);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1094, 179);
            this.panel2.TabIndex = 0;
            // 
            // cbMaLoaiSp
            // 
            this.cbMaLoaiSp.FormattingEnabled = true;
            this.cbMaLoaiSp.Location = new System.Drawing.Point(534, 80);
            this.cbMaLoaiSp.Name = "cbMaLoaiSp";
            this.cbMaLoaiSp.Size = new System.Drawing.Size(166, 24);
            this.cbMaLoaiSp.TabIndex = 9;
            this.cbMaLoaiSp.TextChanged += new System.EventHandler(this.cbMaLoaiSp_TextChanged);
            // 
            // txbTenLoaiSp
            // 
            this.txbTenLoaiSp.Location = new System.Drawing.Point(888, 83);
            this.txbTenLoaiSp.Name = "txbTenLoaiSp";
            this.txbTenLoaiSp.ReadOnly = true;
            this.txbTenLoaiSp.Size = new System.Drawing.Size(156, 22);
            this.txbTenLoaiSp.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(735, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tên loại sản phẩm";
            // 
            // txbSL
            // 
            this.txbSL.Location = new System.Drawing.Point(888, 116);
            this.txbSL.Name = "txbSL";
            this.txbSL.Size = new System.Drawing.Size(156, 22);
            this.txbSL.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số lượng còn lại";
            // 
            // txbDongia
            // 
            this.txbDongia.Location = new System.Drawing.Point(534, 116);
            this.txbDongia.Name = "txbDongia";
            this.txbDongia.Size = new System.Drawing.Size(166, 22);
            this.txbDongia.TabIndex = 3;
            // 
            // txbTenSp
            // 
            this.txbTenSp.Location = new System.Drawing.Point(173, 116);
            this.txbTenSp.Name = "txbTenSp";
            this.txbTenSp.Size = new System.Drawing.Size(178, 22);
            this.txbTenSp.TabIndex = 1;
            // 
            // txbMaSp
            // 
            this.txbMaSp.Location = new System.Drawing.Point(173, 74);
            this.txbMaSp.Name = "txbMaSp";
            this.txbMaSp.Size = new System.Drawing.Size(178, 22);
            this.txbMaSp.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đơn giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã loại sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã sản phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(261, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH MỤC SẢN PHẨM";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.Location = new System.Drawing.Point(0, 179);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(1094, 425);
            this.dgvSanPham.TabIndex = 1;
            this.dgvSanPham.Click += new System.EventHandler(this.dgvSanPham_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 426);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1094, 178);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(550, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(541, 172);
            this.panel4.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "phiếu mua hàng";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(541, 172);
            this.panel3.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "phiếu bán hàng";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvPhieuBanHang);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(541, 172);
            this.panel5.TabIndex = 1;
            // 
            // dgvPhieuBanHang
            // 
            this.dgvPhieuBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuBanHang.Location = new System.Drawing.Point(0, 20);
            this.dgvPhieuBanHang.Name = "dgvPhieuBanHang";
            this.dgvPhieuBanHang.RowHeadersWidth = 51;
            this.dgvPhieuBanHang.RowTemplate.Height = 24;
            this.dgvPhieuBanHang.Size = new System.Drawing.Size(541, 152);
            this.dgvPhieuBanHang.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "phiếu bán hàng";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvPhieuMuaHang);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(541, 172);
            this.panel6.TabIndex = 1;
            // 
            // dgvPhieuMuaHang
            // 
            this.dgvPhieuMuaHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuaHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuMuaHang.Location = new System.Drawing.Point(0, 20);
            this.dgvPhieuMuaHang.Name = "dgvPhieuMuaHang";
            this.dgvPhieuMuaHang.RowHeadersWidth = 51;
            this.dgvPhieuMuaHang.RowTemplate.Height = 24;
            this.dgvPhieuMuaHang.Size = new System.Drawing.Size(541, 152);
            this.dgvPhieuMuaHang.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "phiếu mua hàng";
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 671);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmSanPham";
            this.Text = "frmSanPham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuBanHang)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuaHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.TextBox txbTenSp;
        private System.Windows.Forms.TextBox txbMaSp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txbSL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbDongia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMaLoaiSp;
        private System.Windows.Forms.TextBox txbTenLoaiSp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvPhieuMuaHang;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvPhieuBanHang;
        private System.Windows.Forms.Label label10;
    }
}
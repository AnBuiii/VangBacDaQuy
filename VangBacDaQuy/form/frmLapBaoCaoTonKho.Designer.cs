﻿namespace VangBacDaQuy.form
{
    partial class frmLapBaoCaoTonKho
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
            this.dgvBaoCaoTonKho = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbNam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuatBaoCao = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboThang = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTonKho)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBaoCaoTonKho
            // 
            this.dgvBaoCaoTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCaoTonKho.Location = new System.Drawing.Point(0, 111);
            this.dgvBaoCaoTonKho.Name = "dgvBaoCaoTonKho";
            this.dgvBaoCaoTonKho.RowHeadersWidth = 51;
            this.dgvBaoCaoTonKho.RowTemplate.Height = 24;
            this.dgvBaoCaoTonKho.Size = new System.Drawing.Size(800, 249);
            this.dgvBaoCaoTonKho.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboThang);
            this.panel2.Controls.Add(this.txbNam);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 111);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txbNam
            // 
            this.txbNam.Location = new System.Drawing.Point(386, 61);
            this.txbNam.Name = "txbNam";
            this.txbNam.Size = new System.Drawing.Size(143, 22);
            this.txbNam.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Năm: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tháng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(262, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO TỒN KHO";
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.Location = new System.Drawing.Point(123, 34);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(111, 23);
            this.btnXuatBaoCao.TabIndex = 0;
            this.btnXuatBaoCao.Text = "Xuất Báo Cáo";
            this.btnXuatBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(547, 34);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(111, 23);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Location = new System.Drawing.Point(345, 34);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(111, 23);
            this.btnInBaoCao.TabIndex = 3;
            this.btnInBaoCao.Text = "In Báo Cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Controls.Add(this.btnInBaoCao);
            this.panel1.Controls.Add(this.btnXuatBaoCao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 360);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 90);
            this.panel1.TabIndex = 5;
            // 
            // cboThang
            // 
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboThang.Location = new System.Drawing.Point(116, 62);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(143, 24);
            this.cboThang.TabIndex = 4;
            // 
            // frmLapBaoCaoTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBaoCaoTonKho);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLapBaoCaoTonKho";
            this.Text = "BaoCaoTonKho";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTonKho)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBaoCaoTonKho;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbNam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXuatBaoCao;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboThang;
    }
}
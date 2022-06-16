namespace VangBacDaQuy.form
{
    partial class frmQuyDinh
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
            this.lbNameFrn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butClose = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPhanTramTraTruoc = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butChinhSua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNameFrn
            // 
            this.lbNameFrn.AutoSize = true;
            this.lbNameFrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameFrn.Location = new System.Drawing.Point(156, 22);
            this.lbNameFrn.Name = "lbNameFrn";
            this.lbNameFrn.Size = new System.Drawing.Size(109, 25);
            this.lbNameFrn.TabIndex = 0;
            this.lbNameFrn.Text = "Quy Định";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butClose);
            this.panel1.Controls.Add(this.butHuy);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbPhanTramTraTruoc);
            this.panel1.Controls.Add(this.butLuu);
            this.panel1.Controls.Add(this.butChinhSua);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 291);
            this.panel1.TabIndex = 1;
            // 
            // butClose
            // 
            this.butClose.AutoSize = true;
            this.butClose.Location = new System.Drawing.Point(236, 129);
            this.butClose.Margin = new System.Windows.Forms.Padding(1);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(45, 23);
            this.butClose.TabIndex = 13;
            this.butClose.Text = "Đóng";
            this.butClose.UseVisualStyleBackColor = true;
            // 
            // butHuy
            // 
            this.butHuy.AutoSize = true;
            this.butHuy.ForeColor = System.Drawing.Color.Coral;
            this.butHuy.Location = new System.Drawing.Point(171, 129);
            this.butHuy.Margin = new System.Windows.Forms.Padding(1);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(36, 23);
            this.butHuy.TabIndex = 12;
            this.butHuy.Text = "Hủy";
            this.butHuy.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPhanTramTraTruoc
            // 
            this.txbPhanTramTraTruoc.Location = new System.Drawing.Point(93, 81);
            this.txbPhanTramTraTruoc.Margin = new System.Windows.Forms.Padding(1);
            this.txbPhanTramTraTruoc.Name = "txbPhanTramTraTruoc";
            this.txbPhanTramTraTruoc.Size = new System.Drawing.Size(86, 20);
            this.txbPhanTramTraTruoc.TabIndex = 10;
            // 
            // butLuu
            // 
            this.butLuu.AutoSize = true;
            this.butLuu.Location = new System.Drawing.Point(93, 129);
            this.butLuu.Margin = new System.Windows.Forms.Padding(1);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(35, 23);
            this.butLuu.TabIndex = 9;
            this.butLuu.Text = "Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            // 
            // butChinhSua
            // 
            this.butChinhSua.AutoSize = true;
            this.butChinhSua.Location = new System.Drawing.Point(210, 81);
            this.butChinhSua.Margin = new System.Windows.Forms.Padding(1);
            this.butChinhSua.Name = "butChinhSua";
            this.butChinhSua.Size = new System.Drawing.Size(45, 23);
            this.butChinhSua.TabIndex = 8;
            this.butChinhSua.Text = "Sửa";
            this.butChinhSua.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Phần trăm tiền phải trả trước cho từng loại dịch vụ (0-100%)";
            // 
            // frmQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 291);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbNameFrn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "frmQuyDinh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmQuyDinh";
            this.Load += new System.EventHandler(this.frmQuyDinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNameFrn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butHuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPhanTramTraTruoc;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butChinhSua;
        private System.Windows.Forms.Label label1;
    }
}
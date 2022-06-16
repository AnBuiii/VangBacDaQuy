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
            this.label1 = new System.Windows.Forms.Label();
            this.butChinhSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.txbPhanTramTraTruoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butHuy = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(759, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phần trăm tiền phải trả trước cho từng loại dịch vụ (0-100%)";
            // 
            // butChinhSua
            // 
            this.butChinhSua.AutoSize = true;
            this.butChinhSua.Location = new System.Drawing.Point(445, 166);
            this.butChinhSua.Name = "butChinhSua";
            this.butChinhSua.Size = new System.Drawing.Size(120, 42);
            this.butChinhSua.TabIndex = 1;
            this.butChinhSua.Text = "Sửa";
            this.butChinhSua.UseVisualStyleBackColor = true;
            this.butChinhSua.Click += new System.EventHandler(this.butChinhSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.AutoSize = true;
            this.butLuu.Location = new System.Drawing.Point(133, 281);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(75, 42);
            this.butLuu.TabIndex = 2;
            this.butLuu.Text = "Lưu";
            this.butLuu.UseVisualStyleBackColor = true;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // txbPhanTramTraTruoc
            // 
            this.txbPhanTramTraTruoc.Location = new System.Drawing.Point(133, 166);
            this.txbPhanTramTraTruoc.Name = "txbPhanTramTraTruoc";
            this.txbPhanTramTraTruoc.Size = new System.Drawing.Size(224, 38);
            this.txbPhanTramTraTruoc.TabIndex = 3;
            this.txbPhanTramTraTruoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPhanTramTraTruoc_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butHuy
            // 
            this.butHuy.AutoSize = true;
            this.butHuy.ForeColor = System.Drawing.Color.Coral;
            this.butHuy.Location = new System.Drawing.Point(342, 281);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(75, 42);
            this.butHuy.TabIndex = 5;
            this.butHuy.Text = "Hủy";
            this.butHuy.UseVisualStyleBackColor = true;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butClose
            // 
            this.butClose.AutoSize = true;
            this.butClose.Location = new System.Drawing.Point(515, 281);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(120, 42);
            this.butClose.TabIndex = 6;
            this.butClose.Text = "Đóng";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // frmQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbPhanTramTraTruoc);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butChinhSua);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuyDinh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmQuyDinh";
            this.Load += new System.EventHandler(this.frmQuyDinh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butChinhSua;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.TextBox txbPhanTramTraTruoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butHuy;
        private System.Windows.Forms.Button butClose;
    }
}
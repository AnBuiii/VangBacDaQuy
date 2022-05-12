using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace VangBacDaQuy.form
{
    public partial class frmPhieuMuaHang : Form
    {
        DataTable dtChiTietPhieuMuaHang;
        public frmPhieuMuaHang()
        {
            this.MaximizeBox = false;
            InitializeComponent();
            textBox_ProductName.ReadOnly=true;
            LoadDataGridView();
        }
        private void updateProductID()
        {
            string sql, ProductTypeID;
            sql = "select MALOAISP from LOAISANPHAM where TENLOAISP = N'"+comboBox_productType.Text+"'";
            ProductTypeID = Class.Functions.GetFieldValues(sql);
            sql = "select MASP from SANPHAM where MALOAISP ='" + ProductTypeID + "'";
            Class.Functions.FillCombo(sql, comboBox_ProductID, "MASP", "MASP");
            
        }

        private void updateProductType()
        {
            string sql;
            sql = "select TENLOAISP from LOAISANPHAM";
            Class.Functions.FillCombo(sql, comboBox_productType, "TENLOAISP", "TENLOAISP");
        }
        private void updateProductDetail()
        {
            string sql;
            sql = "select DONGIA from SANPHAM where MASP='" + comboBox_ProductID.Text + "'";
            textBox_Price.Text = Class.Functions.GetFieldValues(sql).Remove(Class.Functions.GetFieldValues(sql).Length - 6, 5);
            sql = "select TENSP from SANPHAM where MASP='" + comboBox_ProductID.Text + "'";
            textBox_ProductName.Text = Class.Functions.GetFieldValues(sql);
        }
 
        private void formReload(string text)
        {
            string sql;
            sql = "select SOPHIEU from PHIEUMUAHANG where SOPHIEU='" + text + "'";
            if(Class.Functions.CheckKey(sql))
            {
                textBox_ID.Text = text;
                sql= "select NGAYLAP from PHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
                dateTimePicker_date.Value = Convert.ToDateTime(Class.Functions.GetFieldValues(sql));
                sql = "select MANCC from PHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
                textBox_NCC.Text= Class.Functions.GetFieldValues(sql);
                sql = "select DIACHI from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
                textBox_Address.Text= Class.Functions.GetFieldValues(sql);
                sql = "select SODT from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
                textBox_SDT.Text = Class.Functions.GetFieldValues(sql);
                sql = "select TONGTIEN from PHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
                textBox_Total.Text= Class.Functions.GetFieldValues(sql).Remove(Class.Functions.GetFieldValues(sql).Length-6,5);
                LoadDataGridView();
                button_Save.Enabled = true;
                button_Delete.Enabled = true;
            }
        }

        private void LoadDataGridView()
        { 
            string sql;
            sql = "SELECT SANPHAM.MASP, TENSP, TENLOAISP, REPLACE(CAST(DONGIA as varchar(31)),'.00',''), CHITIETPHIEUMUAHANG.SOLUONG, CHITIETPHIEUMUAHANG.SOLUONG*DONGIA AS THANHTIEN" +
                   " FROM SANPHAM, CHITIETPHIEUMUAHANG, LOAISANPHAM" +
                    " WHERE SANPHAM.MASP = CHITIETPHIEUMUAHANG.MASP AND SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP AND SOPHIEU = '" + textBox_ID.Text + "'";
            //sql = "SELECT MASP, TENSP, MALOAISP, DONGIA FROM SANPHAM";
            dtChiTietPhieuMuaHang = Class.Functions.GetDataToDataTable(sql);
            dataGridView_List.DataSource = dtChiTietPhieuMuaHang;
            dataGridView_List.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView_List.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView_List.Columns[2].HeaderText = "Loại sản phẩm";
            dataGridView_List.Columns[3].HeaderText = "Đơn giá";
            dataGridView_List.Columns[4].HeaderText = "Số lượng";
            dataGridView_List.Columns[5].HeaderText = "Thành tiền";
            dataGridView_List.AllowUserToAddRows = false;
        }      

        private void dataGridView_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_List.Rows[e.RowIndex];             
                comboBox_ProductID.Text = row.Cells[0].Value.ToString();
                textBox_ProductName.Text = row.Cells[1].Value.ToString();
                comboBox_productType.Text = row.Cells[2].Value.ToString();
                textBox_Price.Text = row.Cells[3].Value.ToString();
                textBox_quantity.Text = row.Cells[4].Value.ToString();
                textBox_totalPrice.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string sql;
            int TotalNew=Convert.ToInt32(textBox_Total.Text);
            sql = "select SOPHIEU from PHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
            if (!Class.Functions.CheckKey(sql))
            {
                sql = "INSERT INTO CHITIETPHIEUMUAHANG VALUES('" + comboBox_ProductID.Text + "','" + textBox_ID.Text + "'," + textBox_quantity.Text + ")";
                Class.Functions.RunSQL(sql);
                LoadDataGridView();
                if (dataGridView_List.RowCount > 0)
                    button_Save.Enabled = true;
                TotalNew += Convert.ToInt32(textBox_totalPrice.Text);
            }
            else
                MessageBox.Show("Phiếu đã tồn tại. Vui lòng thay đổi số phiếu.");
        }

        private void textBox_quantity_TextChanged(object sender, EventArgs e)
        {
            int TotalPrice, quantity;
            if (textBox_quantity.Text != "")
            {
                quantity = Convert.ToInt32(textBox_quantity.Text);
                string pricetext = textBox_Price.Text;
                int price = Convert.ToInt32(pricetext);
                TotalPrice = quantity * price;
                textBox_totalPrice.Text = Convert.ToString(TotalPrice);               
            }
            if(!string.IsNullOrEmpty(textBox_ID.Text)&&!string.IsNullOrEmpty(textBox_quantity.Text))
                button_Add.Enabled = true;
        }

        private void comboBox_ProductID_TextChanged(object sender, EventArgs e)
        {
            updateProductDetail();
        }

        private void frmPhieuMuaHang_Load(object sender, EventArgs e)
        {
            ResetFormState();
        }

        private void ResetFormState()
        {
            textBox_ID.Text = "";
            dateTimePicker_date.Value = DateTime.Now;
            textBox_SDT.Text = "";
            textBox_Address.Text = "";
            textBox_NCC.Text = "";
            textBox_quantity.Text = "";
            textBox_totalPrice.Text = "0";
            textBox_Total.Text = "0";
            textBox_SearchID.Text = "";
            button_Add.Enabled = false;
            button_Delete.Enabled = false;
            button_Print.Enabled = false;
            button_Save.Enabled = false;
            updateProductType();
            updateProductID();
            updateProductDetail();
        }

        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            formReload(textBox_ID.Text);
            button_Save.Enabled = true;
            if (!string.IsNullOrEmpty(textBox_ID.Text) && !string.IsNullOrEmpty(textBox_quantity.Text))
                button_Add.Enabled = true;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            formReload(textBox_SearchID.Text);
            
        }

        private void comboBox_productType_TextChanged(object sender, EventArgs e)
        {
            updateProductID();
        }

        private void textBox_NCC_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "select MANCC from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
            if (Class.Functions.CheckKey(sql))
            {
                sql = "select SODT from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
                textBox_SDT.Text = Class.Functions.GetFieldValues(sql);
                sql = "select DIACHI from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
                textBox_Address.Text = Class.Functions.GetFieldValues(sql);
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_ID.Text) && !string.IsNullOrEmpty(textBox_NCC.Text)
                && !string.IsNullOrEmpty(dateTimePicker_date.Value.ToString()) && !string.IsNullOrEmpty(textBox_SDT.Text)
                && !string.IsNullOrEmpty(textBox_Address.Text) && button_Add.Enabled == true)
            {
                string sql;
                sql = "select SOPHIEU from PHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
                if (!Class.Functions.CheckKey(sql))
                {
                    sql = "INSERT INTO PHIEUMUAHANG VALUES('" + textBox_ID.Text + "','" + dateTimePicker_date.Value.ToString("dd/MM/yyyy")
                        + "','" + textBox_NCC.Text + "','" + textBox_Total.Text + "')";
                    Class.Functions.RunSQL(sql);
                    LoadDataGridView();
                    if (dataGridView_List.RowCount > 0)
                        button_Save.Enabled = true;
                }
                else
                    MessageBox.Show("Phiếu đã tồn tại. Vui lòng thay đổi số phiếu.");
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi lưu.");
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                string sql;
                sql = "delete from PHIEUBANHANG where SOPHIEU='" + textBox_ID.Text + "')";
                Class.Functions.RunSQL(sql);
                ResetFormState();  
            }
        }
    }
}

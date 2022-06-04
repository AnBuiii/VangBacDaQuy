using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VangBacDaQuy.form;

namespace VangBacDaQuy
{
    public partial class Main : Form
    {
        
        public static List<String> permission = new List<string>();
        frmPhieuMuaHang lpmh = null;
        frmPhieuBanHang lpbh = null;
        frmPhieuDichVu lpdv = null;
        frmTraCuuPhieuDichVu tcpdv = null;
        frmLapBaoCaoTonKho lbctk = null;
        frmSanPham sp = null;
        frmDichVu dv = null;
        frmKhachHang kh = null;
        frmNhaCungCap ncc = null;
        frmLoaiSanPham lsp = null;
        frmTaiKhoan tk = null;

        public Main()
        {          
            InitializeComponent();
        }
        

        private void Main_Load(object sender, EventArgs e)
        {
            Class.Functions.User = "";
            Class.Functions.Connect();
            frmDangNhap login = new frmDangNhap();
            login.ShowDialog();

            loadMainPanel();
            string sql = "declare @THANG INT = MONTH(GETDATE()) declare @NAM INT = YEAR(GETDATE()) EXEC DBO.TAOBAOCAO @THANG, @NAM" ;
            Class.Functions.RunSQL(sql);
            chart1.Titles.Add("Thống kê sản phẩm bán ra tháng này");
            chart2.Titles.Add("Thống kê sản phẩm mua vào tháng này");


        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect();
            Application.Exit();    
        }
        private void phiếuMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Class.Functions.CheckPermission("CN02"))
            {
                MessageBox.Show("Bạn không có quyền");
                return;
            }
            closePeviousForm(lpmh);
            if (lpmh == null || lpmh.IsDisposed) lpmh = new frmPhieuMuaHang();
            lpmh.MdiParent = this;
            lpmh.Dock = DockStyle.Fill;
            lpmh.Show();
            lpmh.FormClosing += mdiChildClose;
            mainPanel.Visible = false;
        }
        
        

        private void phiếuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Class.Functions.CheckPermission("CN01"))
            {
                MessageBox.Show("Bạn không có quyền");
                return;
            }
            closePeviousForm(lpbh);
            if (lpbh == null || lpbh.IsDisposed) lpbh = new frmPhieuBanHang();
            lpbh.MdiParent = this;
            lpbh.Dock = DockStyle.Fill;
            lpbh.Show();
            lpbh.FormClosing += mdiChildClose;
            mainPanel.Visible = false;
        }

        private void phiếuDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Class.Functions.CheckPermission("CN03"))
            {
                MessageBox.Show("Bạn không có quyền");
                return;
            }
            closePeviousForm(lpdv);
            if (lpdv == null || lpdv.IsDisposed) lpdv = new frmPhieuDichVu();
            lpdv.MdiParent = this;
            lpdv.Dock = DockStyle.Fill;
            lpdv.Show();
            lpdv.FormClosing += mdiChildClose;
            mainPanel.Visible = false;
        }

        private void tồnKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Class.Functions.CheckPermission("CN05"))
            {
                MessageBox.Show("Bạn không có quyền");
                return;
            }
            closePeviousForm(lbctk);
            if (lbctk == null || lbctk.IsDisposed) lbctk = new frmLapBaoCaoTonKho();
            lbctk.MdiParent = this;
            lbctk.Dock = DockStyle.Fill;
            lbctk.Show();
            lbctk.FormClosing += mdiChildClose;
            mainPanel.Visible = false;
        }

        private void phiếuDịchVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closePeviousForm(tcpdv);
            if (tcpdv == null || tcpdv.IsDisposed) tcpdv = new frmTraCuuPhieuDichVu();
            tcpdv.MdiParent = this;
            tcpdv.Dock = DockStyle.Fill;
            tcpdv.Show();
            tcpdv.FormClosing += mdiChildClose;
            mainPanel.Visible = false;
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(sp);
            if (sp == null || sp.IsDisposed) sp = new frmSanPham();
            sp.MdiParent = this;
            sp.Dock = DockStyle.Fill;
            sp.Show();
            sp.FormClosing += mdiChildClose;
            mainPanel.Visible = false;
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(kh);
            if (kh == null || kh.IsDisposed) kh = new frmKhachHang();
            kh.MdiParent = this;
            kh.Dock = DockStyle.Fill;
            kh.Show();
            kh.FormClosing += mdiChildClose;
            mainPanel.Visible = false;
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(ncc);
            if (ncc == null || ncc.IsDisposed) ncc = new frmNhaCungCap();
            ncc.MdiParent = this;
            ncc.Dock = DockStyle.Fill;
            ncc.Show();
            ncc.FormClosing += mdiChildClose;
            mainPanel.Visible = false;
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(dv);
            if (dv == null || dv.IsDisposed) dv = new frmDichVu();
            dv.MdiParent = this;
            dv.Dock = DockStyle.Fill;
            dv.Show();
            dv.FormClosing += mdiChildClose;
            mainPanel.Visible = false;
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

            closePeviousForm(lsp);
            if (lsp == null || lsp.IsDisposed) lsp = new frmLoaiSanPham();
            lsp.MdiParent = this;
            lsp.Dock = DockStyle.Fill;
            lsp.Show();
            lsp.FormClosing += mdiChildClose;
            mainPanel.Visible = false;

        }
        private void closePeviousForm(Form open)
        {
            foreach(Form form in this.MdiChildren) if(form != open )form.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Class.Functions.CheckPermission("CN00"))
            {
                MessageBox.Show("Bạn không có quyền");
                return;
            }
            closePeviousForm(tk);
            if (tk == null || tk.IsDisposed) tk = new frmTaiKhoan();
            tk.MdiParent = this;
            tk.Dock = DockStyle.Fill;
            tk.Show();
            tk.FormClosing += mdiChildClose;
            mainPanel.Visible = false;

        }

        private void lậpBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Class.Functions.CheckPermission("CN04"))
            {
                lậpBáoCáoToolStripMenuItem.HideDropDown();
                MessageBox.Show("Bạn không có quyền");              
                return;
            }
            
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren) form.Close();
            Class.Functions.User = "";
            loadMainPanel();
            frmDangNhap login = new frmDangNhap();
            login.ShowDialog();
            loadMainPanel();
            
            
        }
        public void loadMainPanel()
        {
            lbTenDangNhap.Text = Class.Functions.User;
            if(lbTenDangNhap.Text == "")
            {
                đăngXuấtToolStripMenuItem.Text = "Đăng nhập";
                lbMessage.Text = "Hãy đăng nhập";
            } else
            {
                đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
                lbMessage.Text = "Xin chào";
            }
            loadChart();
            mainPanel.Visible = true;
            
        }
        private void mdiChildClose(object sender, EventArgs e)
        {
            loadMainPanel();
        }

        private void Main_ControlRemoved(object sender, ControlEventArgs e)
        {
            MessageBox.Show("asd");
        }
        private void loadChart()
        {
            String sql;
            sql = "select tensp, sum(CHITIETPHIEUBANHANG.SOLUONG) as soluong from SANPHAM, CHITIETPHIEUBANHANG, PHIEUBANHANG where SANPHAM.MASP = CHITIETPHIEUBANHANG.MASP AND CHITIETPHIEUBANHANG.SOPHIEU = PHIEUBANHANG.SOPHIEU and month(PHIEUBANHANG.NGAYLAP) = month(getdate()) and year(PHIEUBANHANG.NGAYLAP) = year(getdate()) GROUP BY TENSP";
            chart1 = Class.Functions.GetDataToChart(sql, chart1,"TENSP", "SOLUONG", false);
            

            sql = "select tensp, sum(CHITIETPHIEUMUAHANG.SOLUONG) as soluong from SANPHAM, CHITIETPHIEUMUAHANG, PHIEUMUAHANG where SANPHAM.MASP = CHITIETPHIEUMUAHANG.MASP AND CHITIETPHIEUMUAHANG.SOPHIEU = PHIEUMUAHANG.SOPHIEU and month(PHIEUMUAHANG.NGAYLAP) = month(getdate()) and year(PHIEUMUAHANG.NGAYLAP) = year(getdate()) GROUP BY TENSP";
            chart2 = Class.Functions.GetDataToChart(sql, chart2, "TENSP", "SOLUONG", false);
            

        }
    }
}   

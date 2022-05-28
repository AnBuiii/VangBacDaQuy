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

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect();
            Application.Exit();    
        }
        private void phiếuMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(lpmh);
            if (lpmh == null || lpmh.IsDisposed) lpmh = new frmPhieuMuaHang();
            lpmh.MdiParent = this;
            lpmh.Dock = DockStyle.Fill;
            lpmh.Show();
        }

        private void phiếuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(lpbh);
            if (lpbh == null || lpbh.IsDisposed) lpbh = new frmPhieuBanHang();
            lpbh.MdiParent = this;
            lpbh.Dock = DockStyle.Fill;
            lpbh.Show();
        }

        private void phiếuDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(lpdv);
            if (lpdv == null || lpdv.IsDisposed) lpdv = new frmPhieuDichVu();
            lpdv.MdiParent = this;
            lpdv.Dock = DockStyle.Fill;
            lpdv.Show();
        }

        private void tồnKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closePeviousForm(lbctk);
            if (lbctk == null || lbctk.IsDisposed) lbctk = new frmLapBaoCaoTonKho();
            lbctk.MdiParent = this;
            lbctk.Dock = DockStyle.Fill;
            lbctk.Show();
        }

        private void phiếuDịchVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closePeviousForm(tcpdv);
            if (tcpdv == null || tcpdv.IsDisposed) tcpdv = new frmTraCuuPhieuDichVu();
            tcpdv.MdiParent = this;
            tcpdv.Dock = DockStyle.Fill;
            tcpdv.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(sp);
            if (sp == null || sp.IsDisposed) sp = new frmSanPham();
            sp.MdiParent = this;
            sp.Dock = DockStyle.Fill;
            sp.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(kh);
            if (kh == null || kh.IsDisposed) kh = new frmKhachHang();
            kh.MdiParent = this;
            kh.Dock = DockStyle.Fill;
            kh.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(ncc);
            if (ncc == null || ncc.IsDisposed) ncc = new frmNhaCungCap();
            ncc.MdiParent = this;
            ncc.Dock = DockStyle.Fill;
            ncc.Show();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(dv);
            if (dv == null || dv.IsDisposed) dv = new frmDichVu();
            dv.MdiParent = this;
            dv.Dock = DockStyle.Fill;
            dv.Show();
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closePeviousForm(lsp);
            if (lsp == null || lsp.IsDisposed) lsp = new frmLoaiSanPham();
            lsp.MdiParent = this;
            lsp.Dock = DockStyle.Fill;
            lsp.Show();
        }
        private void closePeviousForm(Form open)
        {
            foreach(Form form in this.MdiChildren) if(form != open )form.Close();
        }
    }
}

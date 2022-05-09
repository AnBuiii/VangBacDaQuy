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

        public Main()
        {
            InitializeComponent();
        }

        private void phiếuMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lpmh == null || lpmh.IsDisposed) lpmh = new frmPhieuMuaHang();
            lpmh.MdiParent = this;
            lpmh.Dock = DockStyle.Fill;
            lpmh.Show();
        }

        private void phiếuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lpbh == null || lpbh.IsDisposed) lpbh = new frmPhieuBanHang();
            lpbh.MdiParent = this;
            lpbh.Dock = DockStyle.Fill;
            lpbh.Show();
        }

        private void phiếuDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lpdv == null || lpdv.IsDisposed ) lpdv = new frmPhieuDichVu();
            lpdv.MdiParent = this;
            lpdv.Dock = DockStyle.Fill;
            lpdv.Show();
        }

        private void tồnKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lbctk == null || lbctk.IsDisposed) lbctk = new frmLapBaoCaoTonKho();
            lbctk.MdiParent = this;
            lbctk.Dock = DockStyle.Fill;
            lbctk.Show();
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

        private void phiếuDịchVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tcpdv == null || tcpdv.IsDisposed) tcpdv = new frmTraCuuPhieuDichVu();
            tcpdv.MdiParent = this;
            tcpdv.Dock = DockStyle.Fill;
            tcpdv.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp == null || sp.IsDisposed) sp = new frmSanPham();
            sp.MdiParent = this;
            sp.Dock = DockStyle.Fill;
            sp.Show();
        }
    }
}

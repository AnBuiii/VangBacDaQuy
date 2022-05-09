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
        frmLapPhieuMuaHang lpmh = null;
        frmLapPhieuBanHang lpbh = null;
        frmLapPhieuDichVu lpdv = null;
        frmTraCuuPhieuDichVu tcpdv = null;
        frmLapBaoCaoTonKho lbctk = null;

        public Main()
        {
            InitializeComponent();
        }

        private void phiếuMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lpmh == null || lpmh.IsDisposed) lpmh = new frmLapPhieuMuaHang();
            lpmh.MdiParent = this;
            lpmh.Dock = DockStyle.Fill;
            lpmh.Show();
        }

        private void phiếuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lpbh == null || lpbh.IsDisposed) lpbh = new frmLapPhieuBanHang();
            lpbh.MdiParent = this;
            lpbh.Dock = DockStyle.Fill;
            lpbh.Show();
        }

        private void phiếuDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lpdv == null || lpdv.IsDisposed ) lpdv = new frmLapPhieuDichVu();
            lpdv.MdiParent = this;
            lpdv.Dock = DockStyle.Fill;
            lpdv.Show();
        }

        private void traCứuPhiếuDịchBụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tcpdv == null || tcpdv.IsDisposed ) tcpdv = new frmTraCuuPhieuDichVu();
            tcpdv.MdiParent = this;
            tcpdv.Dock = DockStyle.Fill;
            tcpdv.Show();

        }

        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lbctk == null || lbctk.IsDisposed ) lbctk = new frmLapBaoCaoTonKho();
            lbctk.MdiParent = this;
            lbctk.Dock = DockStyle.Fill;
            lbctk.Show();
        }
    }
}

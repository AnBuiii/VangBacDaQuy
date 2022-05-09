using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VangBacDaQuy.controller;

namespace VangBacDaQuy.form
{
    public partial class frmLapPhieuMuaHang : Form
    {
        ctlFrmLapPhieuDichVuController controller = new ctlFrmLapPhieuDichVuController();
        public frmLapPhieuMuaHang()
        {
            InitializeComponent();
        }

        private void frmLaphieuMuaHang_Load(object sender, EventArgs e)
        {

        }
    }
}

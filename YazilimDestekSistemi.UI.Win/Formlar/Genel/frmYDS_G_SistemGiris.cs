using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazilimDestekSistemi.UI.Win.Formlar.Genel
{
    public partial class frmYDS_G_SistemGiris : DevExpress.XtraEditors.XtraForm
    {
        public bool sunucuBilgisiTanimli = false;

        public frmYDS_G_SistemGiris()
        {
            InitializeComponent();
        }

        private void btnKullanici_ItemClick(object sender, TileItemEventArgs e)
        {
            frmYDS_G_AnaForm frmYDS_G_AF = new frmYDS_G_AnaForm();
            frmYDS_G_AF.Show();

            this.Hide();

            notifyIcon.Visible = true;
        }

        private void btnAdmin_ItemClick(object sender, TileItemEventArgs e)
        {
            grpGiris.Visible = false;
            grpAdmin.Visible = true;
        }

        private void btnKapat_ItemClick(object sender, TileItemEventArgs e)
        {
            Application.Exit();
        }

        private void btnSunucu_ItemClick(object sender, TileItemEventArgs e)
        {
            //frmYDS_SunucuBilgileri frmYDS_SB = new frmYDS_SunucuBilgileri();
            //frmYDS_SB.ShowDialog();

            //if (frmYDS_SB.sunucuBilgisiTanimli == true)
            //{
            //    sunucuBilgisiTanimli = true;
            //}
        }

        private void btnGeriDon_ItemClick(object sender, TileItemEventArgs e)
        {
            grpGiris.Visible = true;
            grpAdmin.Visible = false;
        }

        private void btnUygulamayiKapat_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;  // NotifyIcon'ı gizle
            Application.Exit();  // Uygulamayı kapat
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;  // Formu normal boyuta getirin
            notifyIcon.Visible = false;  // NotifyIcon'ı gizle
        }
    }
}
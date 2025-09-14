using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazilimDestekSistemi.UI.Win.Fonksiyonlar;
using YazilimDestekSistemi.UI.Win.Formlar.Genel.TemelFormlar;
using YazilimDestekSistemi.UI.Win.Formlar.SistemYonetimi;

namespace YazilimDestekSistemi.UI.Win.Formlar.Genel
{
    public partial class frmYDS_G_AnaForm : DevExpress.XtraEditors.XtraForm
    {
        public frmYDS_G_AnaForm()
        {
            InitializeComponent();

            this.Text = "YDS"; // BaglantiBilgileri.ConnectionAdı + " - Yazılım Destek Sistemi | " + BaglantiBilgileri.MevcutSurum + " ( " + BaglantiBilgileri.SurumTarihi + " )";

            tmrZamanYonetimi.Start();

            PcIsletimSistemi();

            #region Sistem Bilgileri

            #region Sistem Bilgilerini Alma 

            BaglantiBilgileri.MevcutSurum = this.Tag.ToString();
            
            BaglantiBilgileri.ExeYolu = AppDomain.CurrentDomain.BaseDirectory;

            BaglantiBilgileri.PcAdi = System.Net.Dns.GetHostName();

            string isletimSistemi = PcIsletimSistemi();
            BaglantiBilgileri.IsletimSistemi = isletimSistemi;
            
            string isletimSistemiSurum = Environment.OSVersion.ToString();
            BaglantiBilgileri.IsletimSistemiSurum = isletimSistemiSurum;
            
            string hostName = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);
            // İlk IPv4 adresini al
            IPAddress ipAddress = addresses.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            BaglantiBilgileri.IpAdresi = ipAddress?.ToString();
            
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // MAC adresini al, isteğe bağlı olarak filtreleyebilirsiniz
                if (networkInterface.OperationalStatus == OperationalStatus.Up && !networkInterface.Description.ToLowerInvariant().Contains("sanal"))
                {
                    BaglantiBilgileri.MacAdresi = networkInterface.GetPhysicalAddress().ToString();
                   
                    break; // Eğer bir MAC adresi bulunduysa döngüden çıkabilirsiniz
                }
            }

            #endregion

            #region Sistem Bilgilerini Aktarma

            //txtConnectionAdi.Text = BaglantiBilgileri.ConnectionAdı;
            txtSpId.Text = BaglantiBilgileri.SpId;
            txtSurumveTarihi.Text = BaglantiBilgileri.MevcutSurum + " ( " + BaglantiBilgileri.SurumTarihi + " )";
            txtBilgisayarAdi.Text = BaglantiBilgileri.PcAdi;
            txtIpAdresi.Text = BaglantiBilgileri.IpAdresi;
            txtMacAdresi.Text = BaglantiBilgileri.MacAdresi;
            txtIsletimSistemi.Text = BaglantiBilgileri.IsletimSistemi;
            txtIsletimSistemiSurumu.Text = BaglantiBilgileri.IsletimSistemiSurum;

            // this.Text = BaglantiBilgileri.ConnectionAdı + " - Yazılım Destek Sistemi | " + BaglantiBilgileri.MevcutSurum + " ( " + BaglantiBilgileri.SurumTarihi + " )";

            this.Text = "Mi - Yazılım Destek Sistemi | " + BaglantiBilgileri.MevcutSurum + " ( " + BaglantiBilgileri.SurumTarihi + " )";

            #endregion

            #endregion

            XtraForm12 frmYDS_G_TF_TIF = new XtraForm12();
            frmYDS_G_TF_TIF.MdiParent = this;
            frmYDS_G_TF_TIF.Show();

            AcikEkranlariListele();
        }

        #region Fonksiyonlar

        private void tmrZamanYonetimi_Tick(object sender, EventArgs e)
        {
            lblTarih.Visible = true;
            lblGun.Visible = true;
            lblSaat.Visible = true;

            lblTarih.Text = Convert.ToString(DateTime.Now.ToShortDateString());

            string[] gunler = { "Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi" };

            DayOfWeek bugun = DateTime.Now.DayOfWeek;

            string gunIsmi = gunler[(int)bugun];

            lblGun.Text = gunIsmi;

            lblSaat.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
        }

        private string PcIsletimSistemi()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("ProductName");
                        if (value != null)
                        {
                            return value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //logOlustur.HataExLog("Ana Form", "Liste", "Sorgulama", "frmYDS_AnaForm_v2", "PcIsletimSistemi", "HATA - 00001", "Exception",
                //                     ex.Message, ex.InnerException?.Message ?? "", ex.StackTrace, ex.Source, ex.TargetSite?.ToString() ?? "", ex.HelpLink ?? "", ex.Data?.ToString() ?? "", "");

                MesajKutusu.Tamam(2, $"HATA - 00001 : Exception \r\n\r\n" + ex.Message + " !\r\n\r\nBilgi İşlem Birimi ile irtibata geçiniz.", "Hata Mesajı", 10000);
            }
            return "Bilinmiyor";
        }

        public void AcikEkranlariListele()
        {
            // Listeyi sıfırla
            nbgAcikEkranlar.ItemLinks.Clear();

            // Açık formları sırayla ekle
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name != "frmYDS_AnaForm")
                {
                    NavBarItem formItem = new NavBarItem
                    {
                        Caption = openForm.Text,
                        Name = "btnOpenForm_" + openForm.Name
                    };

                    formItem.LinkClicked += (sender, e) =>
                    {
                        //logOlustur.SistemLog(formItem.Caption, "Erişim", "Açık Forma Geçiş", "frmYDS_AnaForm_v2", formItem.Name + "_LinkClicked", "");

                        try
                        {
                            openForm.BringToFront();
                            openForm.Focus();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Forma geçiş sırasında hata oluştu: " + ex.Message);
                        }
                    };

                    nbgAcikEkranlar.ItemLinks.Add(formItem);
                }
            }

            int acikEkranAdet = nbgAcikEkranlar.ItemLinks.Count() - 1;
            string acikEkranAdetYazi = acikEkranAdet.ToString();

            nbgAcikEkranlar.Caption = $"AÇIK EKRANLAR ( {acikEkranAdetYazi} )";
        }

        #endregion

        #region MdiManager İşlemleri

        private void xtraTabbedMdiManager_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pmMdiManager.ShowPopup(Control.MousePosition);
            }
        }

        private void btnAktifSekmeHaricTumSekmeleriKapat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Name != "frmMOS_SK_I_Baslangic" && childForm != this.ActiveMdiChild)
                {
                    childForm.Close();
                }
            }
        }

        private void btnTumSekmeleriKapat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Name != "frmMOS_SK_I_Baslangic")
                {
                    childForm.Close();
                }
            }
        }

        #endregion

        private void FormuAc<T>(string formAdi) where T : Form, new()
        {
            var form = Application.OpenForms[formAdi] as T;

            if (form == null)
            {
                form = new T
                {
                    MdiParent = this
                };

                form.FormClosed += (s, args) => AcikEkranlariListele();

                var yukleMethod = typeof(T).GetMethod("Yukle");
                yukleMethod?.Invoke(form, null);

                form.Show();
                AcikEkranlariListele();
            }
            else
            {
                form.BringToFront();
            }
        }

        private void btnKullaniciKartlari_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormuAc<frmYDS_SY_KullaniciKartlari>("frmYDS_SY_KullaniciKartlari");
        }
        private void btnKullaniciGrupListesi_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormuAc<frmYDS_SY_KullaniciGrupKartlari>("frmYDS_SY_KullaniciGrupKartlari");
        }
    }
}
using System;
using YazilimDestekSistemi.Bll.Genel.SistemYonetimi;
using YazilimDestekSistemi.Common.Fonksiyonlar;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.Model.Veriler.SistemYonetimi;
using YazilimDestekSistemi.UI.Win.Fonksiyonlar;
using YazilimDestekSistemi.UI.Win.Formlar.Genel.TemelFormlar;

namespace YazilimDestekSistemi.UI.Win.Formlar.SistemYonetimi
{
    public partial class frmYDS_SY_KullaniciGrupKartlari : frmYDS_G_TF_TemelIslemFormu
    {
        int _mdiTip;
        string _surum;
        DateTime _kayitTarihi;

        public frmYDS_SY_KullaniciGrupKartlari()
        {
            InitializeComponent();

            DataLayoutControl = ydsDataLayoutControl;
            Bll = new SY_KullaniciGrupBll(ydsDataLayoutControl);
            KartTuru = KartTuru.KullaniciGrup;
            KartTuruKodOnEk = KartTuruKodOnEk.KullaniciGrup;
            KartTuruYetkiKod = KartTuruYetkiKod.KullaniciGrup;

            EventsLoad();
            _mdiTip = 0;

            grpFormBaslik.Text = "Kullanıcı Grup Kartları";
            grpFormBaslik.CustomHeaderButtons[0].Properties.SuperTip = 
                SuperToolTip.SuperToolTipOlustur(KartTuruMenuYol.KullaniciGrup.NumaralandirmaAdi(), KartTuruYetkiKod.KullaniciGrup.NumaralandirmaAdi());
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            TabloDegerTuru = typeof(SY_KullaniciGrup);
            Grid = grid;
            KartTuru = KartTuru.KullaniciGrup;
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            //var liste = ((SY_KullaniciBll)Bll).Liste(FiltreFonksiyonlari.Filtre<SY_Kullanici>(AktifKartlariGoster));

            //Tablo.GridControl.DataSource = liste;

            //Tablo.ViewCaption = $"Kullanıcı Listesi ({liste.Count()})";

            Tablo.GridControl.DataSource = ((SY_KullaniciGrupBll)Bll).Liste(FiltreFonksiyonlari.Filtre<SY_KullaniciGrup>(AktifKartlariGoster));
        }

        protected internal override void DetayYukle()
        {
            EskiVeri = IslemTuru == IslemTuru.VeriEkleme ? new SY_KullaniciGrup() : ((SY_KullaniciGrupBll)Bll).Tekil(FiltreFonksiyonlari.Filtre<SY_KullaniciGrup>(Id));
            //NesneyiKontrollereBagla();

            if (IslemTuru == IslemTuru.VeriEkleme)
            {
                _surum = "1";
                //_kayitEdenId = 1;
                _kayitTarihi = DateTime.Now;
                //_degistirenId = null;
                //_degisimTarihi = null;
            }
            else
            {
                //_kayitEdenId = _kayitEdenIdMevcut;
                //_kayitTarihi = _kayitTarihiMevcut;
                //_degistirenId = 1;
                //_degisimTarihi = DateTime.Now;

                Kod = txtKod.Text;
                Surum = _surum;
                //KullaniciAdi = txtKullaniciAdi.Text;
                Ad = txtAdi.Text;

                //KayitEdenId = _kayitEdenIdMevcut;
                //KayitTarihi = _kayitTarihiMevcut;

                //DegistirenId = _degistirenIdMevcut;
                //DegisimTarihi = _degisimTarihiMevcut;
            }

            if (IslemTuru != IslemTuru.VeriEkleme) return;

            txtKod.Text = ((SY_KullaniciGrupBll)Bll).YeniKodVer();
            txtAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            if (IslemTuru == IslemTuru.VeriGuncelleme)
            {
                var veri = (SY_KullaniciGrup)EskiVeri;

                if (veri != null)
                {
                    txtKod.Text = veri.Kod;
                    txtAdi.Text = veri.KullaniciGrupAdi;
                    cbxYetkiSeviyesi.SelectedIndex = veri.YetkiSeviyesi;

                    //btnIl.Id = veri.IlId;
                    //btnIl.Text = veri.IlAdi;
                    //btnIlce.Id = veri.IlceId;
                    //btnIlce.Text = veri.IlceAdi;
                    //txtAciklama.Text = veri.Aciklama;
                    //_kayitEdenIdMevcut = veri.KayitEdenId;
                    //_kayitTarihiMevcut = (DateTime)veri.KayitTarihi;

                    //if (IslemTuru == IslemTuru.VeriGuncelleme && !String.IsNullOrEmpty(veri.Surum) && Convert.ToInt32(veri.Surum) > 1)
                    //{
                    //    _degistirenIdMevcut = veri.DegistirenId;
                    //    _degisimTarihiMevcut = (DateTime)veri.DegisimTarihi;
                    //    _surum = veri.Surum;
                    //}

                    toggleDurum.IsOn = veri.Durum;
                }

            }

        }

        protected override void GuncelNesneOlustur()
        {
            int.TryParse(txtSurum.Text, out int mevcutSurum);

            DateTime kayitTarihi = DateTime.TryParse(dtKayitTarihi.EditValue?.ToString(), out DateTime dt)
                ? dt
                : DateTime.Now;

            YeniVeri = new SY_KullaniciGrup
            {
                Id = Id,
                Kod = txtKod.Text,
                KullaniciGrupAdi = txtAdi.Text,
                YetkiSeviyesi = cbxYetkiSeviyesi.SelectedIndex,
                Aciklama = bAciklama.Text,
                KayitEdenId = 1,
                KayitTarihi = kayitTarihi,
                Surum = (mevcutSurum + 1).ToString(),
                Durum = toggleDurum.IsOn
            };
        }

        private void tablo_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            int ozellikId = (int)tablo.FocusedRowHandle;

            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                pmSagClick.ShowPopup(grid.PointToScreen(e.Point));
            }
        }

        private void tablo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SatirDegisti(e.FocusedRowHandle);
        }

    }
}
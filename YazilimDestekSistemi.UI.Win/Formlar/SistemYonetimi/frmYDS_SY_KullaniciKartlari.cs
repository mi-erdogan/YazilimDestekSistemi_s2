using System;
using YazilimDestekSistemi.Bll.Genel.SistemYonetimi;
using YazilimDestekSistemi.Common.Fonksiyonlar;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.Model.Dto.SistemYonetimi;
using YazilimDestekSistemi.Model.Veriler.SistemYonetimi;
using YazilimDestekSistemi.UI.Win.Fonksiyonlar;
using YazilimDestekSistemi.UI.Win.Formlar.Genel.TemelFormlar;
using YazilimDestekSistemi.UI.Win.Goster;
using YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller;

namespace YazilimDestekSistemi.UI.Win.Formlar.SistemYonetimi
{
    public partial class frmYDS_SY_KullaniciKartlari : frmYDS_G_TF_TemelIslemFormu
    {
        int _mdiTip;
        string _surum;
        DateTime _kayitTarihi;

        private TabloVerileriniKontroleAktar tabloVerileriniKontroleAktar;

        public frmYDS_SY_KullaniciKartlari()
        {
            InitializeComponent();

            tabloVerileriniKontroleAktar = new TabloVerileriniKontroleAktar(this);

            DataLayoutControl = ydsDataLayoutControl;
            Bll = new SY_KullaniciBll(ydsDataLayoutControl);
            KartTuru = KartTuru.Kullanici;
            KartTuruKodOnEk = KartTuruKodOnEk.Kullanici;
            KartTuruYetkiKod = KartTuruYetkiKod.Kullanici;
            EventsLoad();

            _mdiTip = 0;

            grpFormBaslik.Text = "Kullanıcı Kartları";
            grpFormBaslik.CustomHeaderButtons[0].Properties.SuperTip = 
                SuperToolTip.SuperToolTipOlustur(KartTuruMenuYol.Kullanici.NumaralandirmaAdi(), KartTuruYetkiKod.Kullanici.NumaralandirmaAdi());
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            TabloDeger = tablo.TabloDegeri;
            TabloDegerTuru = typeof(SY_Kullanici);
            Grid = grid;
            KartTuru = KartTuru.Kullanici;
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((SY_KullaniciBll)Bll).Liste(FiltreFonksiyonlari.Filtre<SY_Kullanici>(AktifKartlariGoster));
        }

        protected internal override void DetayYukle()
        {
            EskiVeri = IslemTuru == IslemTuru.VeriEkleme ? new SY_KullaniciT() : ((SY_KullaniciBll)Bll).Tekil(FiltreFonksiyonlari.Filtre<SY_Kullanici>(Id));
            NesneyiKontrollereBagla();

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

            txtKod.Text = ((SY_KullaniciBll)Bll).YeniKodVer();
            txtKullaniciAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            if (IslemTuru == IslemTuru.VeriGuncelleme)
            {
                //    var veri = (SY_KullaniciT)EskiVeri;

                //    if (veri != null)
                //    {
                //        txtKod.Text = veri.Kod;
                //        txtKullaniciAdi.Text = veri.KullaniciAdi;
                //        txtKullaniciSifre.Text = veri.Sifre;
                //        txtAdi.Text = veri.Adi;
                //        txtSoyadi.Text = veri.Soyadi;

                //        cbxYetkiSeviyesi.SelectedIndex = veri.YetkiSeviyesi;
                //        txtPinKodu.Text = Convert.ToString(veri.PinKodu);
                //        txtDomain.Text = veri.Domain;
                //        txtDomainKullaniciAdi.Text = veri.DomainKullaniciAdi;
                //        txtDomainKullaniciSifre.Text = veri.DomainKullaniciSifre;
                //        txtEPostaAdresi.Text = veri.EPostaAdresi;
                //        txtTelefon.Text = veri.Telefon;
                //        txtDahili.Text = veri.Dahili;
                //        txtCepTelefonu.Text = veri.CepTelefonu;
                //        txtKisaKodu.Text = veri.KisaKod;

                //        btnKullaniciGrubu.Id = veri.SY_KullaniciGrupId;
                //        btnKullaniciGrubu.Text = veri.KullaniciGrupAdi ?? null;
                //        //btnIlce.Id = veri.IlceId;
                //        //btnIlce.Text = veri.IlceAdi;
                //        //txtAciklama.Text = veri.Aciklama;
                //        //_kayitEdenIdMevcut = veri.KayitEdenId;
                //        //_kayitTarihiMevcut = (DateTime)veri.KayitTarihi;
                //        _surum = veri.Surum;
                //        //if (IslemTuru == IslemTuru.VeriGuncelleme && !String.IsNullOrEmpty(veri.Surum) && Convert.ToInt32(veri.Surum) > 1)
                //        //{
                //        //    _degistirenIdMevcut = veri.DegistirenId;
                //        //    _degisimTarihiMevcut = (DateTime)veri.DegisimTarihi;
                //        //    _surum = veri.Surum;
                //        //}

                //        toggleDurum.IsOn = veri.Durum;
                //    }

                var eski = EskiVeri as SY_Kullanici;

                if (eski != null)
                {
                    var veri = new SY_KullaniciT
                    {
                        Id = eski.Id,
                        Kod = eski.Kod,
                        KullaniciAdi = eski.KullaniciAdi,
                        Sifre = eski.Sifre,
                        Adi = eski.Adi,
                        Soyadi = eski.Soyadi,
                        YetkiSeviyesi = eski.YetkiSeviyesi,
                        PinKodu = eski.PinKodu,
                        Domain = eski.Domain,
                        DomainKullaniciAdi = eski.DomainKullaniciAdi,
                        DomainKullaniciSifre = eski.DomainKullaniciSifre,
                        EPostaAdresi = eski.EPostaAdresi,
                        Telefon = eski.Telefon,
                        Dahili = eski.Dahili,
                        CepTelefonu = eski.CepTelefonu,
                        KisaKod = eski.KisaKod,
                        SY_KullaniciGrupId = eski.SY_KullaniciGrupId,
                        KullaniciGrupAdi = eski.SY_KullaniciGrup?.KullaniciGrupAdi,
                        Surum = eski.Surum,
                        Durum = eski.Durum
                    };

                    txtKod.Text = veri.Kod;
                    txtKullaniciAdi.Text = veri.KullaniciAdi;
                    txtKullaniciSifre.Text = veri.Sifre;
                    txtAdi.Text = veri.Adi;
                    txtSoyadi.Text = veri.Soyadi;

                    cbxYetkiSeviyesi.SelectedIndex = veri.YetkiSeviyesi;
                    txtPinKodu.Text = veri.PinKodu.ToString();
                    txtDomain.Text = veri.Domain;
                    txtDomainKullaniciAdi.Text = veri.DomainKullaniciAdi;
                    txtDomainKullaniciSifre.Text = veri.DomainKullaniciSifre;
                    txtEPostaAdresi.Text = veri.EPostaAdresi;
                    txtTelefon.Text = veri.Telefon;
                    txtDahili.Text = veri.Dahili;
                    txtCepTelefonu.Text = veri.CepTelefonu;
                    txtKisaKodu.Text = veri.KisaKod;

                    btnKullaniciGrubu.Id = veri.SY_KullaniciGrupId;
                    btnKullaniciGrubu.Text = veri.KullaniciGrupAdi ?? "";

                    _surum = veri.Surum;
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

            YeniVeri = new SY_Kullanici
            {
                Id = Id,
                Kod = txtKod.Text,
                KullaniciAdi = txtKullaniciAdi.Text,
                Sifre = txtKullaniciSifre.Text,
                Adi = txtAdi.Text,
                Soyadi = txtSoyadi.Text,
                YetkiSeviyesi = cbxYetkiSeviyesi.SelectedIndex,
                SY_KullaniciGrupId = btnKullaniciGrubu.Id,

                Domain = txtDomain.Text,
                DomainKullaniciAdi = txtDomainKullaniciAdi.Text,
                DomainKullaniciSifre = txtDomainKullaniciSifre.Text,
                EPostaAdresi = txtEPostaAdresi.Text,
                Telefon = txtTelefon.Text,
                Dahili = txtDahili.Text,
                CepTelefonu = txtCepTelefonu.Text,
                KisaKod = txtKisaKodu.Text,
                Aciklama = bAciklama.Text,
                KayitEdenId = 1,
                KayitTarihi = kayitTarihi,
                Surum = (mevcutSurum + 1).ToString(),
                Durum = toggleDurum.IsOn
            };
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is YdsButtonEdit)) return;

            using (var sec = new SecimFonksiyonlari())
            {
                if (sender == btnKullaniciGrubu)
                    sec.Sec(btnKullaniciGrubu);
                //else if (sender == btnUnvani)
                //    sec.Sec(btnUnvani);
            }
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
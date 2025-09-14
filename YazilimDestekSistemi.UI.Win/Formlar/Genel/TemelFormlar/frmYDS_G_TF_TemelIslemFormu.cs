using DevExpress.XtraEditors;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using YazilimDestekSistemi.Bll.Arayuzler;
using YazilimDestekSistemi.Bll.Fonksiyonlar;
using YazilimDestekSistemi.Bll.Genel.SistemYonetimi;
using YazilimDestekSistemi.Common.Fonksiyonlar;
using YazilimDestekSistemi.Common.MesajKutulari;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.Model.Veriler.SistemYonetimi;
using YazilimDestekSistemi.Model.Veriler.Temel;
using YazilimDestekSistemi.UI.Win.Arayuzler;
using YazilimDestekSistemi.UI.Win.Fonksiyonlar;
using YazilimDestekSistemi.UI.Win.Goster;
using YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller;
using YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Tablolar;

namespace YazilimDestekSistemi.UI.Win.Formlar.Genel.TemelFormlar
{
    public partial class frmYDS_G_TF_TemelIslemFormu : DevExpress.XtraEditors.XtraForm
    {
        #region Değişkenler 

        bool _islemYapildi;
        bool _islemYapilmadi;
        protected internal IslemTuru IslemTuru;
        protected internal long Id;
        protected internal string Adi;
        protected internal bool YenilemeYapilacak;
        protected YdsDataLayoutControl DataLayoutControl;
        protected YdsDataLayoutControl[] DataLayoutControls;
        //public ITemelFormGoster FormGoster;

        protected ITemelBll Bll;
        protected KartTuru KartTuru;
        protected KartTuruKodOnEk KartTuruKodOnEk;
        protected KartTuruYetkiKod KartTuruYetkiKod;
        protected TemelVeri EskiVeri;
        protected TemelVeri YeniVeri;
        protected bool Yuklendi = false;
        protected bool KayitSonrasiFormuKapat = false;

        protected string Kod;
        protected string Surum;
        protected string Ad;
        protected long KayitEdenId;
        protected DateTime KayitTarihi;
        protected long? DegistirenId;
        protected DateTime? DegisimTarihi;

        //public ITemelFormGoster FormGoster;
        protected internal GridView Tablo;
        protected internal string TabloDeger;
        public Type TabloDegerTuru { get; protected set; }
        protected internal GridControl Grid;
        protected bool AktifKartlariGoster = true;
        public bool AktifKayitlarListelendi = true;
        protected internal bool CokluSecim = false;
        protected internal TemelVeri SecilenVeri;
        protected ControlNavigator Navigator;
        protected internal long? SeciliGelecekId;

        private TabloVerileriniKontroleAktar tabloVerileriniKontroleAktar;

        #endregion

        public frmYDS_G_TF_TemelIslemFormu()
        {
            InitializeComponent();
        }

        protected void EventsLoad()
        {
            // Form Events
            Load += frmYDS_G_TF_TemelIslemFormu_Load;

            if (Tablo != null)
            {
                Tablo.DoubleClick += Tablo_DoubleClick;
                Tablo.KeyDown += Tablo_KeyDown;
            }

            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;
                control.GotFocus += Control_GotFocus;
                control.Leave += Control_Leave;

                switch (control)
                {
                    case YdsButtonEdit ydsButtonEdit:
                        ydsButtonEdit.IdChanced += Control_IdChanced;
                        ydsButtonEdit.ButtonClick += Control_ButtonClick;
                        ydsButtonEdit.DoubleClick += Control_DoubleClick;
                        break;

                    case BaseEdit baseEdit:
                        baseEdit.EditValueChanged += Control_EditValueChanged;
                        break;
                }
            }

            if (DataLayoutControls == null)
            {
                if (DataLayoutControl == null) return;
                foreach (Control control in DataLayoutControl.Controls)
                    ControlEvents(control);
            }
            else
            {
                foreach (var layout in DataLayoutControls)
                    foreach (Control control in layout.Controls)
                    {
                        ControlEvents(control);
                    }
            }
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            statusBarKisaYol.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            statusBarKisaYolAciklama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            var type = sender.GetType();

            if (type == typeof(YdsButtonEdit) || type == typeof(ydsGridView) || type == typeof(YdsPictureEdit) || type == typeof(YdsComboBoxEdit) || type == typeof(YdsDateEdit))
            {
                statusBarKisaYol.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                statusBarKisaYolAciklama.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                statusBarAciklama.Caption = ((IStatusBarAciklama)sender).StatusBarAciklama;
                statusBarKisaYol.Caption = ((IStatusBarKisaYol)sender).StatusBarKisaYol;
                statusBarKisaYolAciklama.Caption = ((IStatusBarKisaYol)sender).StatusBarKisaYolAciklama;
            }
            else if (sender is IStatusBarAciklama ctrl)
                statusBarAciklama.Caption = ctrl.StatusBarAciklama;
        }

        private void Control_EditValueChanged(object sender, EventArgs e)
        {
            if (!Yuklendi) return;
            GuncelNesneOlustur();
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            SecimYap(sender);
        }

        private void Control_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SecimYap(sender);
        }

        private void Control_IdChanced(object sender, IdChancedEventArgs e)
        {
            if (!Yuklendi) return;
            GuncelNesneOlustur();
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            if (sender is YdsButtonEdit ydsButtonEdit)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete when e.Control && e.Shift:
                        ydsButtonEdit.Id = null;
                        ydsButtonEdit.EditValue = null;
                        break;

                    case Keys.F4:
                    case Keys.Down when e.Modifiers == Keys.Alt:
                        SecimYap(ydsButtonEdit);
                        break;
                }
            }
            if (sender is YdsComboBoxEdit ydsComboBoxEdit)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete when e.Control && e.Shift:
                        ydsComboBoxEdit.SelectedIndex = -1;
                        break;

                    case Keys.F4:
                    case Keys.Down when e.Modifiers == Keys.Alt:
                        SecimYap(ydsComboBoxEdit);
                        break;
                }
            }
        }

        private void frmYDS_G_TF_TemelIslemFormu_Load(object sender, EventArgs e)
        {
            //Yuklendi = true;

            tabloVerileriniKontroleAktar = new TabloVerileriniKontroleAktar(this);

            grpFormBaslik.CustomHeaderButtons[1].Properties.SuperTip = SuperToolTip.SuperToolTipOlustur("Kapat (ESC)", "Aktif olan formun kapatılmasını sağlar.");

            //DegiskenleriDoldur();
            //GuncelNesneOlustur();
            // SablonYukle();
            // ButonGizleGoster();
            //Id = IslemTuru.IdOlustur(EskiVeri);
        }

        public void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();

            Tablo.OptionsSelection.MultiSelect = CokluSecim;
            Navigator.NavigatableControl = Tablo.GridControl;

            Cursor.Current = Cursors.WaitCursor;

            Listele();

            Cursor.Current = DefaultCursor;
        }

        protected internal virtual void DetayYukle()
        {

        }

        protected virtual void Listele()
        {

        }

        private void Tablo_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            IslemTuruSec();

            Cursor.Current = DefaultCursor;
        }

        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    IslemTuruSec();
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void IslemTuruSec()
        {
            if (!IsMdiChild)
            {
                VeriSec();
            }
            else
            {
                btnDuzenle.PerformClick();
            }
        }

        private void VeriSec()
        {
            if (CokluSecim == true)
            {

            }
            else
                SecilenVeri = Tablo.GetRow<TemelVeri>();
           
            DialogResult = DialogResult.OK;
            Close();
        }

        protected virtual void SecimYap(object sender)
        {

        }

        private void VerilSil()
        {

        }

        private void GeriAl()
        {

        }

        private bool Kaydet(bool kapanis)
        {
            string mesajBaslik = kapanis ? "Güvenlik Mesajı" : "İşlem Mesajı";
            string mesajKodu = kapanis ? "G00001" : "İ00001";
            string mesajIcerik = " Yapılan Değişiklikler Kayıt Edilecektir.\n Onaylıyor Musunuz :?";
            string mesajIslem = kapanis ? "Ekrandan Çıkış" : "Kayıt İşlemi";

            var sonuc = Mesajlar.KayitMesaji();

            if (sonuc == DialogResult.Yes)
                return KayitIslemi();

            if (sonuc == DialogResult.No && kapanis)
                btnKaydet.Enabled = false;

            return true;
        }

        private bool KayitIslemi()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool sonuc = false;
            switch (IslemTuru)
            {
                case IslemTuru.VeriEkleme:
                    if (VeriEkleme())
                        sonuc = KayitSonrasiIslemler();
                    break;

                case IslemTuru.VeriGuncelleme:
                    if (VeriGuncelleme())
                        sonuc = KayitSonrasiIslemler();
                    break;
            }

            return sonuc;
        }

        private bool KayitSonrasiIslemler()
        {
            EskiVeri = YeniVeri;
            YenilemeYapilacak = true;
            ButonEtkinlestirmeDurumu();

            if (KayitSonrasiFormuKapat)
                Close();
            else
                IslemTuru = (IslemTuru == IslemTuru.VeriEkleme) ? IslemTuru.VeriGuncelleme : IslemTuru;

            KaydiGriddeBulVeSec(YeniVeri.Id);

            return true;
        }

        private void KaydiGriddeBulVeSec(long id)
        {
            Grid.Enabled = true;
            Navigator.Enabled = true;

            Yukle(); 

            Tablo.ClearSelection(); 

            var rowHandle = Tablo.LocateByValue("Id", id);

            if (rowHandle >= 0)
            {
                Tablo.FocusedRowHandle = rowHandle;
                Tablo.MakeRowVisible(rowHandle);
                Tablo.SelectRow(rowHandle);      

                //SatirDegisti(rowHandle);
            }
        }

        protected virtual bool VeriEkleme()
        {
            //return ((ITemelGenelBll)Bll).Ekle(YeniVeri);
            try
            {
                bool sonuc = ((ITemelGenelBll)Bll).Ekle(YeniVeri);
                Debug.WriteLine($"Ekle() sonucu: {YeniVeri}");
                return sonuc;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ekle() işlemi hata verdi: {ex.Message}");
                return false;
            }
        }

        protected virtual bool VeriGuncelleme()
        {
            if (YeniVeri != null)
            {
                if (!string.IsNullOrEmpty(EskiVeri.Surum))
                {
                    // Surum boş değilse, sayısal değeri arttırmak için önce integer'a çevirmemiz gerekebilir
                    if (int.TryParse(EskiVeri.Surum, out int surumValue))
                    {
                        // Surum'u +1 arttır
                        YeniVeri.Surum = (surumValue + 1).ToString();
                    }
                }
            }

            return ((ITemelGenelBll)Bll).Guncelle(EskiVeri, YeniVeri);
        }

        protected virtual void NesneyiKontrollereBagla()
        {

        }

        protected virtual void GuncelNesneOlustur()
        {

        }

        protected virtual void DegiskenleriDoldur()
        {

        }

        //protected virtual void DuzenlemeFormunuGoster(long id)
        //{
        //    if (KartTuru == null)
        //    {
        //        Mesajlar.HataMesaji("Kart Türü BOŞ geliyor");
        //    }
        //    else
        //    {
        //        var result = FormGoster.DuzenlemeFormunuOndeGoster(KartTuru, id); // Form Detay Bilgileri parametre olarak eklenecek.
        //    }
        //}

        protected virtual void TabPaneSecilenSayfaDegismeDurumu(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {

        }

        protected internal virtual void ButonEtkinlestirmeDurumu()
        {
            if (!Yuklendi)
                XtraMessageBox.Show("KayitIslemi Veri Yük - " + Yuklendi);
            return;

            YazilimDestekSistemi.UI.Win.Fonksiyonlar.GenelFonksiyonlar.EtkinButonDurumu(btnYeni, btnDuzenle, btnKaydet, btnVazgec, EskiVeri, YeniVeri);
        }

        private void btnKapat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grpFormBaslik_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Tag.ToString() == "Kapat")
            {
                this.Close();
            }
        }

        
        private void btnAktifKayitlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AktifKartlariGoster = true;

            this.Yukle();

            var caption = Tablo.ViewCaption.Replace(" (Pasif Kayıtlar)", "").Trim();

            Tablo.ViewCaption = caption;

            btnPasifKayitlar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnAktifKayitlar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnPasifKayitlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AktifKartlariGoster = false;

            this.Yukle();

            var caption = Tablo.ViewCaption.Replace(" (Pasif Kayıtlar)", "").Trim();

            Tablo.ViewCaption = caption + " (Pasif Kayıtlar)";

            btnPasifKayitlar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            btnAktifKayitlar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void btnDetayGoster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlSag.Visible = true;
            tabloVerileriniKontroleAktar = new TabloVerileriniKontroleAktar(this);
            Yuklendi = true;
            DegiskenleriDoldur();
            GuncelNesneOlustur();
            // SablonYukle();
            // ButonGizleGoster();
            //Id = IslemTuru.IdOlustur(EskiVeri);

            btnDetayGoster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnDetayGizle.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            //if (Tablo.FocusedRowHandle >= 0)
            //    SatirDegisti(Tablo.FocusedRowHandle);
        }

        private void btnDetayGizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnlSag.Visible = false;

            Yuklendi = false;

            btnDetayGoster.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnDetayGizle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Yukle();
        }

        private void btnExceleAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DosyaIslemleri.TabloDisariAktar(Tablo, DosyaTuru.ExcelFormatli, "Excel Listesi", Text);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            IslemTuru = IslemTuru.VeriEkleme;

            Grid.Enabled = false;
            Navigator.Enabled = false;

            FormuTemizle();

            DetayYukle();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet(false);
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            GeriAl();

            Grid.Enabled = true;
            Navigator.Enabled = true;
            Tablo.GetFocusedRow();
            if (Tablo.FocusedRowHandle >= 0)
                SatirDegisti();
        }

        protected virtual void FormuTemizle(Control container = null)
        {
            if (container == null)
                container = this;

            foreach (Control ctrl in container.Controls)
            {
                if (ctrl.HasChildren)
                {
                    FormuTemizle(ctrl); // recursive
                }

                if (ctrl is ITemizlenebilir temizlenebilir && !temizlenebilir.Temizlenebilir)
                    continue;

                switch (ctrl)
                {
                    case YdsTextEdit txt:
                        txt.Text = string.Empty;
                        break;
                    case YdsMemoEdit txm:
                        txm.Text = string.Empty;
                        break;
                    case YdsComboBoxEdit cbx:
                        cbx.SelectedIndex = -1;
                        break;
                    case YdsDateEdit dt:
                        dt.EditValue = null;
                        break;
                    case YdsCheckEdit chk:
                        chk.Checked = false;
                        break;
                    case YdsButtonEdit btn:
                        btn.Id = null;
                        btn.Text = string.Empty;
                        break;
                    case YdsToggleSwitch tgl:
                        tgl.IsOn = true;
                        break;
                }
            }
        }

        protected void SatirDegisti()
        {
            if (TabloDegerTuru == null) return;

            var method = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(m =>
                    m.Name == "SatirDegisti" &&
                    m.IsGenericMethodDefinition &&
                    m.GetParameters().Length == 0);

            if (method == null) return;

            var genericMethod = method.MakeGenericMethod(TabloDegerTuru);
            genericMethod.Invoke(this, null);
        }

        //protected void SatirDegisti()
        //{
        //    if (TabloDegerTuru == null) return;

        //    var method = GetType().GetMethod("SatirDegisti", BindingFlags.Instance | BindingFlags.NonPublic);
        //    if (method == null) return;

        //    var genericMethod = method.MakeGenericMethod(TabloDegerTuru);
        //    genericMethod.Invoke(this, null);
        //}

        //protected virtual void SatirDegisti<T>() where T : TemelVeri
        //{
        //    var entity = Tablo.GetFocusedRow() as T;
        //    if (entity == null) return;

        //    EskiVeri = entity;
        //}

        protected virtual void SatirDegisti(int rowHandle)
        {
            var entity = Tablo.GetRow(rowHandle);
            if (entity == null)
                return;

            if (!TabloDegerTuru.IsInstanceOfType(entity))
                return;

            FormuTemizle();

            IslemTuru = IslemTuru.VeriGuncelleme;

            if (tabloVerileriniKontroleAktar != null)
                tabloVerileriniKontroleAktar.KontrolleriNesnedenDoldur(entity, this);

            var typedEntity = (TemelVeri)entity;
            Id = typedEntity.Id;

            DetayYukle();
            //EskiVeri = entity;
        }

    }
}
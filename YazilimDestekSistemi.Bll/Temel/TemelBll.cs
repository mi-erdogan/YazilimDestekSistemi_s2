using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using YazilimDestekSistemi.Bll.Arayuzler;
using YazilimDestekSistemi.Bll.Fonksiyonlar;
using YazilimDestekSistemi.Common.Fonksiyonlar;
using YazilimDestekSistemi.Common.MesajKutulari;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.DAL.Arayuzler;
using YazilimDestekSistemi.Model.Veriler.Temel;

namespace YazilimDestekSistemi.Bll.Temel
{
    public class TemelBll<T, TBaglam> : ITemelBll where T : TemelVeri where TBaglam : DbContext
    {
        private readonly Control _ctrl;
        private IUnitOfWork<T> _uow;
        protected TemelBll()
        {

        }

        protected TemelBll(Control ctrl)
        {
            _ctrl = ctrl;
        }

        protected TResult TemelTekil<TResult>(Expression<Func<T, bool>> filtre, Expression<Func<T, TResult>> secim)
        {
            GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
            return _uow.Rep.Bul(filtre, secim);
        }

        protected IQueryable<TResult> TemelListe<TResult>(Expression<Func<T, bool>> filtre, Expression<Func<T, TResult>> secim)
        {
            GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
            return _uow.Rep.Sec(filtre, secim);
        }

        protected bool TemelEkle(TemelVeri veri, Expression<Func<T, bool>> filtre)
        {
            bool kayitSonucu;
            GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
            _uow.Rep.Ekle(veri.VeriDonustur<T>());

            try
            {
                kayitSonucu = _uow.Kaydet();
                Debug.WriteLine($"Veritabanı kaydetme sonucu: {kayitSonucu}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Veritabanı kaydetme hatası: {ex.Message}");
            }

            return _uow.Kaydet();
        }

        protected bool TemelGuncelle(TemelVeri eskiVeri, TemelVeri yeniVeri, Expression<Func<T, bool>> filtre)
        {
            GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);

            var degisenAlanlar = eskiVeri.DegisenAlanlariGetir(yeniVeri);

            if (degisenAlanlar.Count == 0) return true;
            _uow.Rep.Guncelle(yeniVeri.VeriDonustur<T>(), degisenAlanlar);

            return _uow.Kaydet();
        }


        protected bool TemelSil(TemelVeri veri, KartTuru kartTuru, string formKodu, string formAdi, bool mesajVer = true)
        {
            GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);

            if (mesajVer)
                if (Mesajlar.Sil(kartTuru.NumaralandirmaAdi()) != DialogResult.Yes) return false;

            //frmMOS_G_MesajKutusu frmMOS_G_MKS = new frmMOS_G_MesajKutusu(7, 0, "Silme Mesajı", formKodu, formAdi, " I00001", "Tanım Eksik",
            //                                                                                                                                                                                               " Seçmiş olduğunuz " + kartTuru.NumaralandirmaAdi() + " silinecektir." +
            //                                                                                                                                                                                               Environment.NewLine + // Alt Satıra İn
            //                                                                                                                                                                                               " Onaylıyor Musunuz :?");
            //frmMOS_G_MKS.ShowDialog();
            //if(!frmMOS_G_MKS.islemYapildi) return false;

            _uow.Rep.Sil(veri.VeriDonustur<T>());

            return _uow.Kaydet();
        }

        protected string TemelYeniKodVer(KartTuruKodOnEk kartTuru, Expression<Func<T, string>> filtre, Expression<Func<T, bool>> where = null)
        {
            GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
            return _uow.Rep.YeniKodVer(kartTuru, filtre, where);
        }


        private bool disposedValue;

        public void Dispose()
        {
            _ctrl?.Dispose();
            _uow?.Dispose();
        }
    }
}
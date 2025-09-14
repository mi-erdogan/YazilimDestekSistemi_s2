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
using NLog;

namespace YazilimDestekSistemi.Bll.Temel
{
    public class TemelBll<T, TBaglam> : ITemelBll where T : TemelVeri where TBaglam : DbContext
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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
            try
            {
                GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
                return _uow.Rep.Bul(filtre, secim);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "TemelTekil hatasi");
                throw;
            }
        }

        protected IQueryable<TResult> TemelListe<TResult>(Expression<Func<T, bool>> filtre, Expression<Func<T, TResult>> secim)
        {
            try
            {
                GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
                return _uow.Rep.Sec(filtre, secim);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "TemelListe hatasi");
                throw;
            }
        }

        protected bool TemelEkle(TemelVeri veri, Expression<Func<T, bool>> filtre)
        {
            try
            {
                GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
                _uow.Rep.Ekle(veri.VeriDonustur<T>());
                var kayitSonucu = _uow.Kaydet();
                Logger.Debug("TemelEkle sonucu: {sonuc}", kayitSonucu);
                return kayitSonucu;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "TemelEkle hatasi");
                throw;
            }
        }

        protected bool TemelGuncelle(TemelVeri eskiVeri, TemelVeri yeniVeri, Expression<Func<T, bool>> filtre)
        {
            try
            {
                GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
                var degisenAlanlar = eskiVeri.DegisenAlanlariGetir(yeniVeri);
                if (degisenAlanlar.Count == 0) return true;
                _uow.Rep.Guncelle(yeniVeri.VeriDonustur<T>(), degisenAlanlar);
                return _uow.Kaydet();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "TemelGuncelle hatasi");
                throw;
            }
        }


        protected bool TemelSil(TemelVeri veri, KartTuru kartTuru, string formKodu, string formAdi, bool mesajVer = true)
        {
            try
            {
                GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
                if (mesajVer)
                    if (Mesajlar.Sil(kartTuru.NumaralandirmaAdi()) != DialogResult.Yes) return false;
                _uow.Rep.Sil(veri.VeriDonustur<T>());
                return _uow.Kaydet();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "TemelSil hatasi");
                throw;
            }
        }

        protected string TemelYeniKodVer(KartTuruKodOnEk kartTuru, Expression<Func<T, string>> filtre, Expression<Func<T, bool>> where = null)
        {
            try
            {
                GenelFonksiyonlar.UnitOfWorkOlustur<T, TBaglam>(ref _uow);
                return _uow.Rep.YeniKodVer(kartTuru, filtre, where);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "TemelYeniKodVer hatasi");
                throw;
            }
        }


        private bool disposedValue;

        public void Dispose()
        {
            _ctrl?.Dispose();
            _uow?.Dispose();
        }
    }
}
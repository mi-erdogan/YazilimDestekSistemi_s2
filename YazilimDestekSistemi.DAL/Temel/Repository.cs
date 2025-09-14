using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using YazilimDestekSistemi.Common.Fonksiyonlar;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.DAL.Arayuzler;
using NLog;

namespace YazilimDestekSistemi.DAL.Temel
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly DbContext _baglam;
        private readonly DbSet<T> _vtSet;

        public Repository(DbContext baglam)
        {
            if (baglam == null) return;
            _baglam = baglam;
            _vtSet = _baglam.Set<T>();
        }



        public void Ekle(T veri)
        {
            try
            {
                _baglam.Entry(veri).State = EntityState.Added;
            }
            catch (Exception ex)
            {
                try { Logger.Error(ex, "Ekle hatasi"); } catch { }
                throw;
            }
        }

        public void Ekle(IEnumerable<T> veriler)
        {
            foreach (var veri in veriler)
                _baglam.Entry(veri).State = EntityState.Added;
        }


        public void Guncelle(T veri)
        {
            try
            {
                _baglam.Entry(veri).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                try { Logger.Error(ex, "Guncelle hatasi"); } catch { }
                throw;
            }
        }

        public void Guncelle(T veri, IEnumerable<string> degisenAlanlar)
        {
            _vtSet.Attach(veri);

            var entry = _baglam.Entry(veri);
            foreach (var degisenAlan in degisenAlanlar)
                entry.Property(degisenAlan).IsModified = true;
        }

        public void Guncelle(IEnumerable<T> veriler)
        {
            foreach (var veri in veriler)
                _baglam.Entry(veri).State = EntityState.Modified;
        }

        public void Sil(T veri)
        {
            try
            {
                _baglam.Entry(veri).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                try { Logger.Error(ex, "Sil hatasi"); } catch { }
                throw;
            }
        }

        public void Sil(IEnumerable<T> veriler)
        {
            foreach (var veri in veriler)
                _baglam.Entry(veri).State = EntityState.Deleted;
        }


        public TResult Bul<TResult>(Expression<Func<T, bool>> filtre, Expression<Func<T, TResult>> secim)
        {
            // Filtre null ise; Git Seçim kısmında yer alan datanın ilk değerini dön Kayıt Yoksa null dön.
            // null değilse  filtreyi uygula, Git Seçim kısmında yer alan datanın ilk değerini dön Kayıt Yoksa null dön.

            return filtre == null ? _vtSet.Select(secim).FirstOrDefault() : _vtSet.Where(filtre).Select(secim).FirstOrDefault();
        }

        public System.Linq.IQueryable<TResult> Sec<TResult>(Expression<Func<T, bool>> filtre, Expression<Func<T, TResult>> secim)
        {
            return filtre == null ? _vtSet.Select(secim) : _vtSet.Where(filtre).Select(secim);
        }

        public string YeniKodVer(KartTuruKodOnEk kartTuru, Expression<Func<T, string>> filtre, Expression<Func<T, bool>> where = null)
        {
            string Kod()
            {
                string kod = null;

                var kodDizi = kartTuru.NumaralandirmaAdi().Split(' ');

                for (int i = 0; i < kodDizi.Length; i++)
                {
                    kod += kodDizi[i];

                    if (i + 1 < kodDizi.Length - 1)
                    {
                        kod += " ";
                    }
                }

                return kod += " - 0000000000001";
            }

            string YeniKodVer(string kod)
            {
                var sayisalDegerler = "";

                foreach (var karakter in kod)
                {
                    if (char.IsDigit(karakter))
                        sayisalDegerler += karakter;
                    else
                        sayisalDegerler = "";
                }

                var artisSonrasiDeger = (int.Parse(sayisalDegerler) + 1).ToString();

                var fark = kod.Length - artisSonrasiDeger.Length;

                if (fark < 0)
                    fark = 0;

                var yeniDeger = kod.Substring(0, fark);

                yeniDeger += artisSonrasiDeger;

                return yeniDeger;
            }

            var maksimumKod = where == null ? _vtSet.Max(filtre) : _vtSet.Where(where).Max(filtre);

            return maksimumKod == null ? Kod() : YeniKodVer(maksimumKod);
        }

        private bool _disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposedValue)
            {
                if (disposing)
                    _baglam.Dispose();

                this._disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
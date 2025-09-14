using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using YazilimDestekSistemi.Common.Numaralandirmalar;

namespace YazilimDestekSistemi.DAL.Arayuzler
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Ekle(T veri);
        void Ekle(IEnumerable<T> veriler);

        void Guncelle(T veri);
        void Guncelle(T veri, IEnumerable<string> degisenAlanlar);
        void Guncelle(IEnumerable<T> veriler);

        void Sil(T veri);
        void Sil(IEnumerable<T> veriler);

        TResult Bul<TResult>(Expression<Func<T, bool>> filtre, Expression<Func<T, TResult>> secim);

        IQueryable<TResult> Sec<TResult>(Expression<Func<T, bool>> filtre, Expression<Func<T, TResult>> secim);

        string YeniKodVer(KartTuruKodOnEk kartTuru, Expression<Func<T, string>> filtre, Expression<Func<T, bool>> where = null);
    }
}
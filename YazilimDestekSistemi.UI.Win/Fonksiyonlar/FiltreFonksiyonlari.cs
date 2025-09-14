using System;
using System.Linq.Expressions;
using YazilimDestekSistemi.Model.Veriler.Temel;

namespace YazilimDestekSistemi.UI.Win.Fonksiyonlar
{
    public class FiltreFonksiyonlari
    {
        public static Expression<Func<T, bool>> Filtre<T>(bool aktifKartlariGoster) where T : TemelVeri
        {
            return x => x.Durum == aktifKartlariGoster;
        }

        public static Expression<Func<T, bool>> Filtre<T>(long id) where T : TemelVeri
        {
            return x => x.Id == id;
        }
    }
}
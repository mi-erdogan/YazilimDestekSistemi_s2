using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using YazilimDestekSistemi.DAL.Arayuzler;
using YazilimDestekSistemi.DAL.Temel;
using YazilimDestekSistemi.Model.Veriler.Temel.Arayuzler;

namespace YazilimDestekSistemi.Bll.Fonksiyonlar
{
    public static class GenelFonksiyonlar
    {
        public static IList<string> DegisenAlanlariGetir<T>(this T eskiVeri, T yeniVeri)
        {
            IList<string> alanlar = new List<string>();

            foreach (var prop in yeniVeri.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                // null degerler karşılaştıralamayacağı için string.Empty ekliyoruz.
                var eskiDeger = prop.GetValue(eskiVeri) ?? string.Empty;
                var yeniDeger = prop.GetValue(yeniVeri) ?? string.Empty;

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(eskiVeri.ToString()))
                        eskiDeger = new byte[] { 0 };
                    if (string.IsNullOrEmpty(yeniVeri.ToString()))
                        yeniDeger = new byte[] { 0 };

                    if (((byte[])eskiDeger).Length != ((byte[])yeniDeger).Length)
                        alanlar.Add(prop.Name);
                }
                else if (!yeniDeger.Equals(eskiDeger))
                    alanlar.Add(prop.Name);
            }

            return alanlar;
        }

        public static string BaglantiDizesiniAl()
        {
            return ConfigurationManager.ConnectionStrings["YdsBaglam"].ConnectionString;
        }

        private static TBaglam BaglamOlustur<TBaglam>() where TBaglam : DbContext
        {
            return (TBaglam)Activator.CreateInstance(typeof(TBaglam), BaglantiDizesiniAl());
        }

        public static void UnitOfWorkOlustur<T, TBaglam>(ref IUnitOfWork<T> uow) where T : class, ITemelVeri where TBaglam : DbContext
        {
            uow?.Dispose();
            uow = new UnitOfWork<T>(BaglamOlustur<TBaglam>());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using YazilimDestekSistemi.DAL.Arayuzler;
using YazilimDestekSistemi.DAL.Temel;
using YazilimDestekSistemi.Model.Veriler.Temel.Arayuzler;
using NLog;

namespace YazilimDestekSistemi.Bll.Fonksiyonlar
{
    public static class GenelFonksiyonlar
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["YdsBaglam"]?.ConnectionString;
                if (string.IsNullOrWhiteSpace(cs))
                    throw new InvalidOperationException("Connection string 'YdsBaglam' bulunamadi veya bos.");
                return cs;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Baglanti dizesi alinamadi");
                throw;
            }
        }

        private static TBaglam BaglamOlustur<TBaglam>() where TBaglam : DbContext
        {
            try
            {
                var instance = (TBaglam)Activator.CreateInstance(typeof(TBaglam), BaglantiDizesiniAl());
                Logger.Debug("DbContext olusturuldu: {context}", typeof(TBaglam).Name);
                return instance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "DbContext olusturma hatasi: {context}", typeof(TBaglam).Name);
                throw;
            }
        }

        public static void UnitOfWorkOlustur<T, TBaglam>(ref IUnitOfWork<T> uow) where T : class, ITemelVeri where TBaglam : DbContext
        {
            try
            {
                uow?.Dispose();
                uow = new UnitOfWork<T>(BaglamOlustur<TBaglam>());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "UnitOfWork olusturma hatasi");
                throw;
            }
        }
    }
}
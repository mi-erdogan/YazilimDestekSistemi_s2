using System;
using System.ComponentModel;

namespace YazilimDestekSistemi.Common.Fonksiyonlar
{
    public static class NumaralandirmaFonksiyonlari
    {
        private static T SifatGetir<T>(this Enum deger) where T : Attribute
        {
            if (deger == null) return null;

            var uyeBilgisi = deger.GetType().GetMember(deger.ToString());
            var sifat = uyeBilgisi[0].GetCustomAttributes(typeof(T), false);
            return (T)sifat[0];
        }

        public static string NumaralandirmaAdi(this Enum deger)
        {
            if (deger == null) return null;

            var sifat = deger.SifatGetir<DescriptionAttribute>();
            return sifat == null ? deger.ToString() : sifat.Description;
        }
    }
}
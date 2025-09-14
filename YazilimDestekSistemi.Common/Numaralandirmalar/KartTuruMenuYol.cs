using System.ComponentModel;

namespace YazilimDestekSistemi.Common.Numaralandirmalar
{
    public enum KartTuruMenuYol
    {
        [Description("Sistem Yönetimi > Kullanici Kartları")]
        Kullanici = 1,

        [Description("Sistem Yönetimi > Kullanici Grup Kartları")]
        KullaniciGrup = 2,

        [Description("DH > Tanımlar > İlçe Kartları")]
        Ilce = 3,

        [Description("DH > Tanımlar > Ulke Kartları")]
        Ulke = 4,
    }
}
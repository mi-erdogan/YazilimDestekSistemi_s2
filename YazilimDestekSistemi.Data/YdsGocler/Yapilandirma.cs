using System.Data.Entity.Migrations;
using YazilimDestekSistemi.Data.Baglamlar;

namespace YazilimDestekSistemi.Data.YdsGocler
{
    public class Yapilandirma : DbMigrationsConfiguration<YdsBaglam>
    {
        public Yapilandirma()
        {
            AutomaticMigrationsEnabled = true;
            // Veri kaybı olması durumuna izin veriyoruz. Okul'da yer alan Long tipinde Id yi İnt Tipine dönüştürürken long 111222333444 ise int 11122233344 olarak güncelleyebilir.
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
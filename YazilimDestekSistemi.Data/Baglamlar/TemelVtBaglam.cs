using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace YazilimDestekSistemi.Data.Baglamlar
{
    public class TemelVtBaglam<TBaglam, TYapilandirma> : DbContext where TBaglam : DbContext where TYapilandirma : DbMigrationsConfiguration<TBaglam>, new()
    {
        private static string _adVeYaBaglantiDizesi = typeof(TBaglam).Name;
        public TemelVtBaglam() : base(_adVeYaBaglantiDizesi)
        {

        }

        public TemelVtBaglam(string baglantiDizesi) : base(baglantiDizesi)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TBaglam, TYapilandirma>());
            _adVeYaBaglantiDizesi = baglantiDizesi;
        }
    }
}
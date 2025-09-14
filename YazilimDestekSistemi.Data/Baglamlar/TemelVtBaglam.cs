using System.Data.Entity;
using System.Data.Entity.Migrations;
using NLog;

namespace YazilimDestekSistemi.Data.Baglamlar
{
    public class TemelVtBaglam<TBaglam, TYapilandirma> : DbContext where TBaglam : DbContext where TYapilandirma : DbMigrationsConfiguration<TBaglam>, new()
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static string _adVeYaBaglantiDizesi = typeof(TBaglam).Name;
        public TemelVtBaglam() : base(_adVeYaBaglantiDizesi)
        {

        }

        public TemelVtBaglam(string baglantiDizesi) : base(baglantiDizesi)
        {
            try
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<TBaglam, TYapilandirma>());
                _adVeYaBaglantiDizesi = baglantiDizesi;
                Logger.Debug("DbContext init. ConnStrNameOrValue set: {value}", _adVeYaBaglantiDizesi);
            }
            catch (System.Exception ex)
            {
                try { Logger.Error(ex, "DbContext initializer error"); } catch { }
                throw;
            }
        }
    }
}
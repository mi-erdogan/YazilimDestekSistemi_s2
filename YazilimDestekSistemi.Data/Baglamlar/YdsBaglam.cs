using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using YazilimDestekSistemi.Data.YdsGocler;
using YazilimDestekSistemi.Model.Veriler.SistemYonetimi;
using YazilimDestekSistemi.Model.Veriler.Temel;

namespace YazilimDestekSistemi.Data.Baglamlar
{
    public class YdsBaglam : TemelVtBaglam<YdsBaglam, Yapilandirma>
    {
        public YdsBaglam()
        {
            //Ilgili tabloda Select yapınca FK olan Tabloların da bütün datalarını select etmeyi engelliyor.
            Configuration.LazyLoadingEnabled = false;
        }

        public YdsBaglam(string baglantiDizesi) : base(baglantiDizesi)
        {
            //Ilgili tabloda Select yapınca FK olan Tabloların da bütün datalarını select etmeyi engelliyor.
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tablo isimlerinin çoğullaştırılmasını engelliyor. (DH_T_Il tablosunu DH_T_Ils olarak create etmeyi engelliyor.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Bağlı tabloların silinmesini engelliyor. ( İl tablosundan bir İl silinirse, İlçe tanımından (Bağlı) silmeyi engelliyor. 
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // SY_Kullanici -> TemelVeri (Self-referencing) ilişkileri düzgün tanımlanıyor

            //modelBuilder.Entity<TemelVeri>()
            //    .HasOptional(t => t.Degistiren)
            //     .WithMany()
            //    .HasForeignKey(t => t.DegistirenId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<TemelVeri>()
            //    .HasRequired(t => t.KayitEden)
            //    .WithMany()
            //    .HasForeignKey(t => t.KayitEdenId)
            //    .WillCascadeOnDelete(false);
        }

        #region Uzak Destek

        //public DbSet<IK_T_Okul> IK_T_Okul { get; set; }

        #endregion

        #region Yazılım Destek

        //public DbSet<DH_T_Ulke> DH_T_Ulke { get; set; }
        #endregion

        #region Sistem Yönetimi

        public DbSet<SY_Kullanici> SY_Kullanici { get; set; }

        public DbSet<SY_KullaniciGrup> SY_KullaniciGrup { get; set; }
        #endregion
    }
}
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using YazilimDestekSistemi.Common.MesajKutulari;
using YazilimDestekSistemi.DAL.Arayuzler;

namespace YazilimDestekSistemi.DAL.Temel
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DbContext _baglam;
        public UnitOfWork(DbContext baglam)
        {
            if (baglam == null) return;
            _baglam = baglam;
        }

        public IRepository<T> Rep => new Repository<T>(_baglam); // => return demek.

        public bool Kaydet()
        {
            try
            {
                _baglam.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (SqlException)ex.InnerException?.InnerException;

                if (sqlEx == null)
                {
                    Mesajlar.HataMesaji(ex.Message);

                    //frmMOS_G_MesajKutusu frmMOS_G_MK = new frmMOS_G_MesajKutusu(3, 1, "Hata Mesajı", "VT", "Veritabanı",  " H00001", "SqlException Hatası",
                    //                                                                                                                                                                                  ex.Message,
                    //                                                                                                                                                                                  "", 
                    //                                                                                                                                                                                  " Bilgi İşlem Birimi ile iletişime geçiniz.");
                    //frmMOS_G_MK.ShowDialog();

                    return false;
                }

                switch (sqlEx.Number)
                {
                    case 208:
                        Mesajlar.HataMesaji("İşlem yapmak istediğiniz Tablo Veritabanında bulunamadı");
                        //frmMOS_G_MesajKutusu frmMOS_G_MK_208 = new frmMOS_G_MesajKutusu(3, 1, "Hata Mesajı", "", "Veritabanı", " H00001", "SqlException Hatası",
                        //                                                                                                                                                                                  " İşlem yapmak istediğiniz Tablo Veritabanında bulunamadı",
                        //                                                                                                                                                                                  " Tablo Eksik",
                        //                                                                                                                                                                                  " Bilgi İşlem Birimi ile iletişime geçiniz.");
                        //frmMOS_G_MK_208.ShowDialog();
                        break;

                    case 547:
                        Mesajlar.HataMesaji("Seçilen Kartın işlem görmüş hareketleri var.");
                        //frmMOS_G_MesajKutusu frmMOS_G_MK_547 = new frmMOS_G_MesajKutusu(3, 1, "Hata Mesajı", "", "Veritabanı", " H00001", "SqlException Hatası",
                        //                                                                                                                                                                                  " Seçilen Kartın işlem görmüş hareketleri var." +
                        //                                                                                                                                                                                  Environment.NewLine + // Alt Satıra İn
                        //                                                                                                                                                                                  " ! ! ! ! Kart Silinemez ! ! ! !",
                        //                                                                                                                                                                                  " Tabloda yer alan veri silinemez",
                        //                                                                                                                                                                                  " Önce işlem görmüş hareketleri siliniz." +
                        //                                                                                                                                                                                  Environment.NewLine +
                        //                                                                                                                                                                                  " Bilgi İşlem Birimi ile iletişime geçiniz.");
                        //frmMOS_G_MK_547.ShowDialog();
                        break;

                    case 2601:
                    case 2627:
                        Mesajlar.HataMesaji("Girmiş olduğunuz Id daha önce kullanılmıştır.");
                        //frmMOS_G_MesajKutusu frmMOS_G_MK_2601_2627 = new frmMOS_G_MesajKutusu(3, 1, "Hata Mesajı", "", "Veritabanı", " H00001", "SqlException Hatası",
                        //                                                                                                                                                                                  " Girmiş olduğunuz Id daha önce kullanılmıştır.",
                        //                                                                                                                                                                                  " Aynı Id bilgisine sahip farklı bir Kart tanımlıdır.",
                        //                                                                                                                                                                                  " Bilgi İşlem Birimi ile iletişime geçiniz.");
                        //frmMOS_G_MK_2601_2627.ShowDialog();
                        break;

                    case 4060:
                        Mesajlar.HataMesaji("İşlem yapmak istediğiniz Veritabanı Sunucuda bulunamadı.");
                        //frmMOS_G_MesajKutusu frmMOS_G_MK_4060 = new frmMOS_G_MesajKutusu(3, 1, "Hata Mesajı", "", "Veritabanı", " H00001", "SqlException Hatası",
                        //                                                                                                                                                                                  " İşlem yapmak istediğiniz Veritabanı Sunucuda bulunamadı.",
                        //                                                                                                                                                                                  " Veritabanı Eksik.",
                        //                                                                                                                                                                                  " Bilgi İşlem Birimi ile iletişime geçiniz.");
                        //frmMOS_G_MK_4060.ShowDialog();
                        break;

                    case 18456:
                        Mesajlar.HataMesaji("Server'a bağlanılmak istenilen Kullanıcı Adı veya Şifre hatalıdır.");
                        //frmMOS_G_MesajKutusu frmMOS_G_MK_18456 = new frmMOS_G_MesajKutusu(3, 1, "Hata Mesajı", "", "Veritabanı", " H00001", "SqlException Hatası",
                        //                                                                                                                                                                                  " Server'a bağlanılmak istenilen Kullanıcı Adı veya Şifre hatalıdır.",
                        //                                                                                                                                                                                  " Kullanıcı Adı veya Şifre hatalı girilmiş olabilir." +
                        //                                                                                                                                                                                  Environment.NewLine +
                        //                                                                                                                                                                                  " Kullanıcı Adı veya Şifre bilgisi değiştirilmiş olabilir.",
                        //                                                                                                                                                                                  " Bilgi İşlem Birimi ile iletişime geçiniz.");
                        //frmMOS_G_MK_18456.ShowDialog();
                        break;

                    default:
                        Mesajlar.HataMesaji(sqlEx.Message);
                        //frmMOS_G_MesajKutusu frmMOS_G_MK = new frmMOS_G_MesajKutusu(3, 1, "Hata Mesajı", "", "Veritabanı", " H00001", "SqlException Hatası",
                        //                                                                                                                                                                                  sqlEx.Message,
                        //                                                                                                                                                                                  " Bilinmeyen Hata.",
                        //                                                                                                                                                                                  " Bilgi İşlem Birimi ile iletişime geçiniz.");
                        //frmMOS_G_MK.ShowDialog();
                        break;
                }

                return false;
            }
            catch (Exception ex)
            {
                Mesajlar.HataMesaji(ex.Message);
                //frmMOS_G_MesajKutusu frmMOS_G_MK = new frmMOS_G_MesajKutusu(3, 1, "Hata Mesajı", "", "Veritabanı", " H00001", "SqlException Hatası",
                //                                                                                                                                                                                          ex.Message,
                //                                                                                                                                                                                          " Bilinmeyen Hata.",
                //                                                                                                                                                                                          " Bilgi İşlem Birimi ile iletişime geçiniz.");
                //frmMOS_G_MK.ShowDialog();

                return false;
            }

            return true;
        }


        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposedValue)
            {
                if (disposing)
                    _baglam.Dispose();

                this._disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}
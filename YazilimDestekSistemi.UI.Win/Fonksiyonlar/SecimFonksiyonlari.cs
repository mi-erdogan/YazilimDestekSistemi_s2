using DevExpress.XtraEditors;
using System;
using YazilimDestekSistemi.Common.Numaralandirmalar;
using YazilimDestekSistemi.Model.Veriler.SistemYonetimi;
using YazilimDestekSistemi.UI.Win.Formlar.SistemYonetimi;
using YazilimDestekSistemi.UI.Win.Goster;
using YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller;

namespace YazilimDestekSistemi.UI.Win.Fonksiyonlar
{
    public class SecimFonksiyonlari : IDisposable
    {
        private YdsButtonEdit _btnEdit;
        private YdsButtonEdit _prmEdit;

        public void Sec(YdsButtonEdit btnEdit)
        {
            _btnEdit = btnEdit;
            SecimYap();
        }

        public void Sec(YdsButtonEdit btnEdit, YdsButtonEdit prmEdit)
        {
            _btnEdit = btnEdit;
            _prmEdit = prmEdit;
            SecimYap();
        }

        private void SecimYap()
        {
            switch (_btnEdit.Name)
            {
                case "btnKullaniciGrubu":
                    KullaniciGrubuSec(_btnEdit.Id ?? 0);
                    break;

                case "btnIl":
                    // IlSec(); // eğer açılacaksa benzer mantıkla ekle
                    break;

                case "btnIlce":
                    // IlceSec(); // eğer açılacaksa benzer mantıkla ekle
                    break;
            }
        }

        private void KullaniciGrubuSec(long _btnEditId)
        {
            var veri = (SY_KullaniciGrup)FormDetaylariniGoster<frmYDS_SY_KullaniciGrupKartlari>.ListeFormunuEnOndeGoster(KartTuru.KullaniciGrup, _btnEditId);

            if (veri != null)
            {
                _btnEdit.Id = veri.Id;
                _btnEdit.EditValue = veri.KullaniciGrupAdi;
            }
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
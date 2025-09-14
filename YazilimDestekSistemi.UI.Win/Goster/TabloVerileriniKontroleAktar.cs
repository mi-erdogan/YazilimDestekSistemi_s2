using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazilimDestekSistemi.UI.Win.Arayuzler;
using YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller;

namespace YazilimDestekSistemi.UI.Win.Goster
{
    public class TabloVerileriniKontroleAktar
    {
        private Control _parentControl;

        public TabloVerileriniKontroleAktar(Control parentControl)
        {
            _parentControl = parentControl ?? throw new ArgumentNullException(nameof(parentControl));
        }

        public void KontrolleriNesnedenDoldur(object entity, Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl.HasChildren)
                    KontrolleriNesnedenDoldur(entity, ctrl);

                KontroleDegerAtaNesneden(ctrl, entity);
            }
        }

        private void KontroleDegerAtaNesneden(Control ctrl, object entity)
        {
            var kolonAdi = GetKolonAdi(ctrl);
            if (string.IsNullOrEmpty(kolonAdi))
                return;

            var propInfo = entity.GetType().GetProperty(kolonAdi);
            if (propInfo == null)
                return;

            var deger = propInfo.GetValue(entity);

            switch (ctrl)
            {
                case YdsTextEdit txt:
                    txt.Text = deger?.ToString() ?? "";
                    break;
                case YdsMemoEdit txm:
                    txm.Text = deger?.ToString() ?? "";
                    break;
                case YdsComboBoxEdit cbx:
                    if (deger != null && int.TryParse(deger.ToString(), out int idx))
                        cbx.SelectedIndex = idx;
                    else
                        cbx.SelectedIndex = -1;
                    break;
                case YdsDateEdit dt:
                    if (deger is DateTime dtValue)
                        dt.EditValue = dtValue;
                    else
                        dt.EditValue = null;
                    break;
                case YdsCheckEdit chk:
                    if (deger is bool b)
                        chk.Checked = b;
                    else
                        chk.Checked = false;
                    break;
                case YdsButtonEdit btn:
                    if (deger != null && long.TryParse(deger.ToString(), out long id))
                        btn.Id = id;
                    else
                        btn.Id = null;
                    break;
                case YdsToggleSwitch tgl:
                    if (deger != null && bool.TryParse(deger.ToString(), out bool isOn))
                        tgl.IsOn = isOn;
                    else
                        tgl.IsOn = true; // veya varsayılan değer neyse
                    break;
            }
        }

        private string GetKolonAdi(Control ctrl)
        {
            // Eğer TabloKolonDegeri özelliği set edilmiş ve doluysa onu kullan
            var prop = ctrl.GetType().GetProperty("TabloKolonDegeri");
            if (prop != null)
            {
                var deger = prop.GetValue(ctrl) as string;
                if (!string.IsNullOrEmpty(deger))
                    return deger;
            }

            // Kontrol ismine göre kolon adı çıkarma (prefix kaldırma)
            string name = ctrl.Name;

            var prefixUzunluklari = new Dictionary<string, int>
             {
                 { "txt", 3 },
                 { "cbx", 3 },
                 { "dt", 2 },
                 { "chk", 3 },
                 { "tgl", 3 },
                 { "btn", 3 }
             };

            foreach (var kvp in prefixUzunluklari)
            {
                if (name.StartsWith(kvp.Key, StringComparison.OrdinalIgnoreCase))
                    return name.Substring(kvp.Value);
            }

            return null; // Kolon adı bulunamadı
        }

    }
}
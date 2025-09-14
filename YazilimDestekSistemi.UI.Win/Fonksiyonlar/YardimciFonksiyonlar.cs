using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using YazilimDestekSistemi.Model.Veriler.Temel;
using YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller;

namespace YazilimDestekSistemi.UI.Win.Fonksiyonlar
{
    internal class YardimciFonksiyonlar
    {
        public static void FormuTemizle(Control container)
        {
            if (container == null) return;

            foreach (Control ctrl in container.Controls)
            {
                if (ctrl.HasChildren)
                    FormuTemizle(ctrl);

                switch (ctrl)
                {
                    case YdsTextEdit txt: txt.Text = string.Empty; break;
                    case YdsMemoEdit txm: txm.Text = string.Empty; break;
                    case YdsComboBoxEdit cbx: cbx.SelectedIndex = -1; break;
                    case YdsDateEdit dt: dt.EditValue = null; break;
                    case YdsCheckEdit chk: chk.Checked = false; break;
                    case YdsButtonEdit btn: btn.Id = null; btn.Text = string.Empty; break;
                    case YdsToggleSwitch tgl: tgl.IsOn = true; break;
                }
            }
        }

        public static void SatiriSec<T>(GridView grid, long id) where T : TemelVeri
        {
            var rowHandle = grid.LocateByValue("Id", id);
            if (rowHandle >= 0)
            {
                grid.FocusedRowHandle = rowHandle;
                grid.MakeRowVisible(rowHandle);
                grid.SelectRow(rowHandle);
            }
        }
    }
}
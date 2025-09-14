using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Kontroller
{
    public class YdsDataLayoutControl : DataLayoutControl
    {
        [ToolboxItem(true)]

        public YdsDataLayoutControl()
        {
            // DataLayoutControl un default focuslanmasını kaldırıp, form taborder ı geçerli kılıyoruz.
            OptionsFocus.EnableAutoTabOrder = false;

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new ydsLayoutControlImplementor(this);
        }
    }

    internal class ydsLayoutControlImplementor : LayoutControlImplementor
    {
        public ydsLayoutControlImplementor(ILayoutControlOwner controlOwner) : base(controlOwner)
        {
        }

        public override BaseLayoutItem CreateLayoutItem(LayoutGroup parent)
        {
            var item = base.CreateLayoutItem(parent);
            item.AppearanceItemCaption.ForeColor = Color.Maroon;
            item.TextVisible = false;
            return item;
        }

        public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
        {
            var grup = base.CreateLayoutGroup(parent);
            grup.LayoutMode = LayoutMode.Table;
            grup.TextVisible = false;
            grup.Padding = new DevExpress.XtraLayout.Utils.Padding(3);

            grup.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = SizeType.Absolute;
            grup.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 150;
            grup.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = SizeType.Absolute;
            grup.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 3;
            grup.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Percent, Width = 100 });
            grup.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Absolute, Width = 15 });
            grup.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Absolute, Width = 125 });

            grup.OptionsTableLayoutGroup.RowDefinitions.Clear();

            grup.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
            {
                SizeType = SizeType.Absolute,
                Height = 37
            });

            for (int i = 0; i < 8; i++)
            {
                grup.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                {
                    SizeType = SizeType.Absolute,
                    Height = 32
                });

                if (i + 1 != 8) continue;
                grup.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                {
                    SizeType = SizeType.Percent,
                    Height = 100
                });
            }

            return grup;
        }
    }
}
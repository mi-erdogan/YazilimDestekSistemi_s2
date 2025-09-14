using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using System.ComponentModel;
using System.Drawing;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Tablolar
{
    [ToolboxItem(true)]
    public class YdsBandedGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            var view = (ydsBandedGridView)CreateView("ydsBandedGridView");

            

            view.Appearance.BandPanel.ForeColor = Color.DarkCyan;
            view.Appearance.BandPanel.Font = new Font(new FontFamily("Jura"), 15f, FontStyle.Bold);
            view.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            view.BandPanelRowHeight = 36;

            view.Appearance.ViewCaption.ForeColor = Color.Maroon;
            view.Appearance.ViewCaption.Font = new Font(new FontFamily("Kelly Slab"), 15f, FontStyle.Bold);

            view.Appearance.HeaderPanel.ForeColor = Color.Maroon;
            view.Appearance.HeaderPanel.Font = new Font(new FontFamily("Jura"), 8.25f);
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            view.Appearance.FooterPanel.ForeColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Jura"), 8.25f, FontStyle.Bold);

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("The Beizer");

            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false;

            view.OptionsNavigation.EnterMoveNextColumn = true;

            view.OptionsPrint.AutoWidth = false;
            view.OptionsPrint.PrintFooter = false;
            view.OptionsPrint.PrintGroupFooter = false;

            view.OptionsView.ShowViewCaption = true;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.RowAutoHeight = true;
            view.OptionsView.ShowFooter = true;
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;

            var column = new[]
            {
                new ydsBandedGridColumn
                 {
                     Caption = "Id",
                     FieldName = "Id",
                     OptionsColumn = { AllowEdit = false, ShowInCustomizationForm = false },
                     Visible = false
                },
                new ydsBandedGridColumn
                {
                    Caption = "Kod",
                    FieldName = "Kod",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 1",
                    FieldName = "OzelKod1",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 2",
                    FieldName = "OzelKod2",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 3",
                    FieldName = "OzelKod3",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 4",
                    FieldName = "OzelKod4",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },

                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 5",
                    FieldName = "OzelKod5",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 6",
                    FieldName = "OzelKod6",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 7",
                    FieldName = "OzelKod7",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 8",
                    FieldName = "OzelKod8",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 9",
                    FieldName = "OzelKod9",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 10",
                    FieldName = "OzelKod10",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 11",
                    FieldName = "OzelKod11",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 12",
                    FieldName = "OzelKod12",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 13",
                    FieldName = "OzelKod13",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 14",
                    FieldName = "OzelKod14",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 15",
                    FieldName = "OzelKod15",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 16",
                    FieldName = "OzelKod16",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 17",
                    FieldName = "OzelKod17",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 18",
                    FieldName = "OzelKod18",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 19",
                    FieldName = "OzelKod19",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 20",
                    FieldName = "OzelKod20",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 21",
                    FieldName = "OzelKod21",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 22",
                    FieldName = "OzelKod22",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 23",
                    FieldName = "OzelKod23",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 24",
                    FieldName = "OzelKod24",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 25",
                    FieldName = "OzelKod25",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 26",
                    FieldName = "OzelKod26",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 27",
                    FieldName = "OzelKod27",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 28",
                    FieldName = "OzelKod28",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 29",
                    FieldName = "OzelKod29",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 30",
                    FieldName = "OzelKod30",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 31",
                    FieldName = "OzelKod31",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 32",
                    FieldName = "OzelKod32",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 33",
                    FieldName = "OzelKod33",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 34",
                    FieldName = "OzelKod34",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 35",
                    FieldName = "OzelKod35",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 36",
                    FieldName = "OzelKod36",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 37",
                    FieldName = "OzelKod37",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 38",
                    FieldName = "OzelKod38",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 39",
                    FieldName = "OzelKod39",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 40",
                    FieldName = "OzelKod40",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 41",
                    FieldName = "OzelKod41",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 42",
                    FieldName = "OzelKod42",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 43",
                    FieldName = "OzelKod43",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 44",
                    FieldName = "OzelKod44",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 45",
                    FieldName = "OzelKod45",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 46",
                    FieldName = "OzelKod46",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 47",
                    FieldName = "OzelKod47",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 48",
                    FieldName = "OzelKod48",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 49",
                    FieldName = "OzelKod49",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                },
                new ydsBandedGridColumn
                {
                    Caption = "Özel Kod 50",
                    FieldName = "OzelKod50",
                    Visible = true,
                    Width = 250,
                    OptionsColumn = { AllowEdit = false },
                    AppearanceCell = { TextOptions = { HAlignment = HorzAlignment.Center }, Options = { UseTextOptions = true} }
                }
            };

            view.Columns.AddRange(column);

            return view;
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new ydsBandedGridInfoRegistrator());
        }

        private class ydsBandedGridInfoRegistrator : BandedGridInfoRegistrator
        {
            public override string ViewName => "mBandedGridView";
            public override BaseView CreateView(GridControl grid) => new ydsBandedGridView(grid);
        }
    }

    public class ydsBandedGridView : BandedGridView //, IStatusBarKisaYol
    {
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }

        public ydsBandedGridView()
        {

        }

        public ydsBandedGridView(GridControl ownerGrid) : base(ownerGrid)
        {
        }

        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column);

            // Kolon Edit Nullsa devam et.
            if (column.ColumnEdit == null) return;

            // Kolon Edit Tarih seçili ise
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                ((RepositoryItemDateEdit)column.ColumnEdit).Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            }
        }

        protected override GridColumnCollection CreateColumnCollection()
        {
            return new ydsGridColumnCollection(this);
        }

        private class ydsGridColumnCollection : BandedGridColumnCollection
        {
            public ydsGridColumnCollection(ColumnView view) : base(view)
            {

            }

            protected override GridColumn CreateColumn()
            {
                var column = new ydsBandedGridColumn();
                column.OptionsColumn.AllowEdit = false;

                return column;
            }
        }
    }

    public class ydsBandedGridColumn : BandedGridColumn //, IStatusBarKisaYol
    {
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}
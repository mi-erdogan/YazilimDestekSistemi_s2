using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using System.Drawing;
using YazilimDestekSistemi.UI.Win.Arayuzler;

namespace YazilimDestekSistemi.UI.Win.KullaniciKontrolleri.Tablolar
{
    [ToolboxItem(true)]
    public class YdsGridControl : GridControl, IStatusBarKisaYol
    {

        public string TabloDegeri { get; set; }
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }

        protected override BaseView CreateDefaultView()
        {
            var view = (ydsGridView)CreateView("ydsGridView");

            view.Appearance.ViewCaption.ForeColor = Color.Maroon;
            view.Appearance.ViewCaption.Font = new Font(new FontFamily("Kelly Slab"), 19f, FontStyle.Bold);
            // view.Appearance.ViewCaption.Font.Bold = true;

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("The Beizer");

            view.Appearance.HeaderPanel.ForeColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Jura"), 13f);
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            view.Appearance.FooterPanel.ForeColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Jura"), 13f, FontStyle.Bold);

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
            //view.OptionsView.ShowFooter = true;
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;

            var idcolumn = new ydsGridColumn
            {
                Caption = "Id",
                FieldName = "Id"
            };
            idcolumn.OptionsColumn.AllowEdit = false;
            idcolumn.OptionsColumn.ShowInCustomizationForm = false;
            idcolumn.Visible = false;

            view.Columns.Add(idcolumn);

            var kodcolumn = new ydsGridColumn
            {
                Caption = "Kod",
                FieldName = "Kod"
            };
            kodcolumn.OptionsColumn.AllowEdit = false;
            kodcolumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            kodcolumn.AppearanceCell.Options.UseTextOptions = true;
            kodcolumn.Visible = true;
            kodcolumn.Width = 250;

            view.Columns.Add(kodcolumn);


            var kodcolumn1 = new ydsGridColumn
            {
                Caption = "Kod1",
                FieldName = "Kod1"
            };
            kodcolumn.OptionsColumn.AllowEdit = false;
            kodcolumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            kodcolumn.AppearanceCell.Options.UseTextOptions = true;
            kodcolumn.Visible = true;
            kodcolumn.Width = 250;

            view.Columns.Add(kodcolumn1);

            return view;
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new mGridInfoRegistrator());
        }

        private class mGridInfoRegistrator : GridInfoRegistrator
        {
            public override string ViewName => "ydsGridView";
            public override BaseView CreateView(GridControl grid) => new ydsGridView(grid);
        }
    }

    public class ydsGridView : GridView
    {
        public ydsGridView()
        {

        }

        public ydsGridView(GridControl ownerGrid) : base(ownerGrid)
        {

        }

        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        public string TabloDegeri { get; set; }

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

        private class ydsGridColumnCollection : GridColumnCollection
        {
            public ydsGridColumnCollection(ColumnView view) : base(view)
            {
            }

            protected override GridColumn CreateColumn()
            {
                var column = new ydsGridColumn();
                column.OptionsColumn.AllowEdit = false;

                return column;
            }
        }
    }

    public class ydsGridColumn : GridColumn //, IStatusBarKisaYol
    {

        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        public string TabloDegeri { get; set; }
    }
}
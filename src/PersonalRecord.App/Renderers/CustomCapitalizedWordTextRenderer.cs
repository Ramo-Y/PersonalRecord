namespace PersonalRecord.App.Renderers
{
    using Syncfusion.Maui.DataGrid;

    public class CustomCapitalizedWordTextRenderer : DataGridTextBoxCellRenderer
    {
        public override void OnInitializeEditView(DataColumnBase dataColumn, SfDataGridEntry view)
        {
            base.OnInitializeEditView(dataColumn, view);
            if (view != null && view is Entry entry)
            {
                entry.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeWord);
            }
        }
    }
}
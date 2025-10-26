namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class ImportExportView : ContentPage
    {
        public ImportExportView(ImportExportViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
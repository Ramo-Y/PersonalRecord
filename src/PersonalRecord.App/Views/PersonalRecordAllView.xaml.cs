namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.Renderers;
    using PersonalRecord.App.ViewModels;

    public partial class PersonalRecordAllView : ContentPage
    {
        public PersonalRecordAllView(PersonalRecordAllViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

            dataGrid.CellRenderers.Remove("Text");
            dataGrid.CellRenderers.Add("Text", new CustomCapitalizedSentenceTextRenderer());
        }
    }
}
namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.Renderers;
    using PersonalRecord.App.ViewModels;

    public partial class MovementsView : ContentPage
    {
        public MovementsView(MovementsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

            dataGrid.CellRenderers.Remove("Text");
            dataGrid.CellRenderers.Add("Text", new CustomTextRenderer());
        }
    }
}
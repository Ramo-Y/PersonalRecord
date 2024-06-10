namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class MovementsView : ContentPage
    {
        public MovementsView(MovementsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
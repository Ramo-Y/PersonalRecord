namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class WorkoutsView : ContentPage
    {
        public WorkoutsView(WorkoutsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class MovementRecordsView : ContentPage
    {
        public MovementRecordsView(MovementRecordsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
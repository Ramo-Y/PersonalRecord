namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class MovementRecordMaxesView : ContentPage
    {
        public MovementRecordMaxesView(MovementRecordMaxesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
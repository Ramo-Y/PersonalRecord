namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class MovementRecordAllView : ContentPage
    {
        public MovementRecordAllView(MovementRecordAllViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
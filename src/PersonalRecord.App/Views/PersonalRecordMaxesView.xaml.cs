namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class PersonalRecordMaxesView : ContentPage
    {
        public PersonalRecordMaxesView(PersonalRecordMaxesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
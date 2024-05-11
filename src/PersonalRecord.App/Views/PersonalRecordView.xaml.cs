namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class PersonalRecordView : ContentPage
    {
        public PersonalRecordView(PersonalRecordViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
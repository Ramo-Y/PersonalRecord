namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class PersonalRecordAllView : ContentPage
    {
        public PersonalRecordAllView(PersonalRecordAllViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
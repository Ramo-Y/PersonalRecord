namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
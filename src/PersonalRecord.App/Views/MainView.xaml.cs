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

        private void hamburgerButton_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }
    }
}
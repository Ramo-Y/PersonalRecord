namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.Renderers;
    using PersonalRecord.App.ViewModels;

    public partial class MovementsView : ContentPage
    {
        private readonly MovementsViewModel _viewModel;

        public MovementsView(MovementsViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = viewModel;
            viewModel.SelectMovement += OnSelected;

            dataGrid.CellRenderers.Remove("Text");
            dataGrid.CellRenderers.Add("Text", new CustomCapitalizedWordTextRenderer());
        }

        private void OnSelected(object sender, EventArgs e)
        {
            var selectedIndex = dataGrid.SelectedIndex;
            dataGrid.ScrollToRowIndex(selectedIndex);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Shell.Current.Navigating += OnNavigating;
        }

        protected override void OnDisappearing()
        {
            Shell.Current.Navigating -= OnNavigating;
            _viewModel.SelectMovement -= OnSelected;
            base.OnDisappearing();
        }

        private void OnNavigating(object sender, ShellNavigatingEventArgs args)
        {
            if (_viewModel.HasUnsavedChanges)
            {
                // Pause navigation
                var deferral = args.GetDeferral();
                _viewModel.HasUnsavedChangesPopupIsOpen = true;
            }
        }
    }
}
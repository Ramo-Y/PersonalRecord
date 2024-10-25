namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class ExerciseView : ContentPage
    {
        private readonly ExerciseViewModel _viewModel;
        public ExerciseView(ExerciseViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
            viewModel.SelectExercise += OnSelected;
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
            _viewModel.SelectExercise -= OnSelected;
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
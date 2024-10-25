namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class ExerciseView : ContentPage
    {
        public ExerciseView(ExerciseViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
using PersonalRecord.App.ViewModels;

namespace PersonalRecord.App.Views
{
    public partial class StatsView : ContentPage
    {
        public StatsView(StatsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
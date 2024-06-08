namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class MovementRecordDetailView : ContentPage
    {
        public MovementRecordDetailView(MovementRecordDetailViewModel viewmodel)
        {
            InitializeComponent();

            BindingContext = viewmodel;
        }
    }
}
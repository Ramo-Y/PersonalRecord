namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.ViewModels;

    public partial class PersonalRecordDetailView : ContentPage
    {
        public PersonalRecordDetailView(PersonalRecordDetailViewModel viewmodel)
        {
            InitializeComponent();

            BindingContext = viewmodel;
            
            customEntry.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence);
        }
    }
}
namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using PersonalRecord.Domain.Models.Entities;

    public class SettingsViewModel : ObservableObject
    {
        private Setting _setting;

        public SettingsViewModel()
        {
            // TODO: load from Firestore
            Setting = new Setting
            {
                Unit = "kg",
                DateFormat = "yyyy-MM-dd"
            };
        }

        public Setting Setting
        {
            get => _setting;
            set => SetProperty(ref _setting, value);
        }
    }
}
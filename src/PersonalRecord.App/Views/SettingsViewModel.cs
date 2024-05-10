namespace PersonalRecord.App.Views
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public class SettingsViewModel : ObservableObject
    {
        private ObservableCollection<Unit> _unitItems;

        public SettingsViewModel()
        {
            UnitItems =
            [
                new()
                {
                    UnitID = Guid.NewGuid(),
                    Name = "kg"
                }
            ];
        }

        public ObservableCollection<Unit> UnitItems
        {
            get => _unitItems;
            set => SetProperty(ref _unitItems, value);
        }
    }
}
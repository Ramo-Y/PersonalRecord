namespace PersonalRecord.App.Views
{
    using PersonalRecord.App.Bases;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public class SettingsViewModel : ViewModelBase
    {
        private ObservableCollection<Unit> _unitItems;

        public SettingsViewModel()
        {
            UnitItems = [];
        }

        public ObservableCollection<Unit> UnitItems
        {
            get => _unitItems;
            set
            {
                if (_unitItems != value)
                {
                    _unitItems = value;
                    OnPropertyChanged(nameof(UnitItems));
                }
            }
        }
    }
}
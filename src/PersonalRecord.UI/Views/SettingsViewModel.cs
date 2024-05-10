namespace PersonalRecord.UI.Views
{
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.UI.Bases;
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
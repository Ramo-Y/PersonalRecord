namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public class MovementRecordsViewModel : ObservableObject
    {
        private ObservableCollection<MovementRecord> _movementRecords;

        public MovementRecordsViewModel(INavigationService navigationService)
        {

        }

        public ObservableCollection<MovementRecord> MovementRecords
        {
            get => _movementRecords;
            set => SetProperty(ref _movementRecords, value);
        }
    }
}
﻿namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.ObjectModel;

    public partial class MovementRecordMaxesViewModel : ObservableObject, IQueryAttributable
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRepository _movementRepository;
        private readonly IMovementRecordRepository _movementRecordRepository;
        private readonly ISettingsService _settingsService;

        private ObservableCollection<MovementRecord> _movementRecords;
        private ObservableCollection<Movement> _movements;

        private Setting _setting;

        public MovementRecordMaxesViewModel(
            INavigationService navigationService,
            IMovementRepository movementRepository,
            IMovementRecordRepository movementRecordRepository,
            ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _movementRepository = movementRepository;
            _movementRecordRepository = movementRecordRepository;
            _settingsService = settingsService;

            Movements = [];
            MovementRecords = [];

            LoadItems();
        }

        public Setting Setting
        {
            get => _setting;
            set => SetProperty(ref _setting, value);
        }

        public ObservableCollection<MovementRecord> MovementRecords
        {
            get => _movementRecords;
            set => SetProperty(ref _movementRecords, value);
        }

        public ObservableCollection<Movement> Movements
        {
            get => _movements;
            set => SetProperty(ref _movements, value);
        }

        private void LoadItems()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                Movements.Clear();
                var movements = await _movementRepository.GetAllMovementsAsync();
                foreach (var movement in movements)
                {
                    Movements.Add(movement);
                }

                MovementRecords.Clear();
                var movementRecords = await _movementRecordRepository.GetAllMovementRecordsAsync();
                var highest = movementRecords.OrderByDescending(m => m.MvrWeight).DistinctBy(m => m.Movement).ToList();
                foreach (var movementRecord in highest)
                {
                    MovementRecords.Add(movementRecord);
                }

                Setting = _settingsService.LoadSettings();
            });
        }

        [RelayCommand]
        public async Task GoToMovementRecordDetailsViewAsync()
        {
            await _navigationService.GoToAsync(Routes.MovementRecordDetailView);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Any())
            {
                query.TryGetValue(NavigationConstants.RELOAD, out var reloadValue);
                var reload = reloadValue as bool?;
                if (reload.Equals(true))
                {
                    LoadItems();
                }
            }
        }
    }
}
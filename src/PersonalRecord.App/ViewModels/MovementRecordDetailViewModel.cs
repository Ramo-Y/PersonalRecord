﻿namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.App.Interfaces;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Infrastructure.Constants;
    using System.Collections.ObjectModel;

    public partial class MovementRecordDetailViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRepository _movementRepository;

        private ObservableCollection<Movement> _movements;

        private MovementRecord _movementRecord;

        public MovementRecordDetailViewModel(
            INavigationService navigationService,
            IMovementRepository movementRepository)
        {
            _navigationService = navigationService;
            _movementRepository = movementRepository;

            Movements = [];

            LoadItems();

            // TODO: Depending on situation, can be loaded if it's editing, or a new one
            // INFO: For now, we use 1RM, maybe later a custom rep count can be added
            MovementRecord = new MovementRecord
            {
                Date = DateTime.Now,
                Reps = DefaultConstants.DEFAULT_REP_COUNT
            };
        }

        private void LoadItems()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var movements = await _movementRepository.GetAllMovementsAsync();
                foreach (var movement in movements)
                {
                    Movements.Add(movement);
                }
            });
        }

        public MovementRecord MovementRecord
        {
            get => _movementRecord;
            set => SetProperty(ref _movementRecord, value);
        }

        public ObservableCollection<Movement> Movements
        {
            get => _movements;
            set => SetProperty(ref _movements, value);
        }

        [RelayCommand]
        public async Task GoToMovementRecordsView()
        {
            await _navigationService.GoToAsync(Routes.MovementRecordsView);
        }
    }
}
namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Infrastructure.Resources.Languages;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public partial class MovementRecordAllViewModel : ObservableObject, IQueryAttributable
    {
        private readonly INavigationService _navigationService;
        private readonly IMovementRecordRepository _movementRecordRepository;
        private readonly ISettingsService _settingsService;
        private readonly IPromptService _promptService;

        [ObservableProperty]
        private ObservableCollection<MovementRecord> _movementRecords;

        [ObservableProperty]
        private Setting _setting;

        public MovementRecordAllViewModel(
            INavigationService navigationService,
            IMovementRecordRepository movementRecordRepository,
            ISettingsService settingsService,
            IPromptService promptService)
        {
            _navigationService = navigationService;
            _movementRecordRepository = movementRecordRepository;
            _settingsService = settingsService;
            _promptService = promptService;

            MovementRecords = [];

            LoadItems();
        }

        private void LoadItems()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                MovementRecords.Clear();
                var movementRecords = await _movementRecordRepository.GetAllMovementRecordsAsync();
                foreach (var movementRecord in movementRecords)
                {
                    MovementRecords.Add(movementRecord);
                }

                Setting = _settingsService.LoadSettings();
            });
        }

        [RelayCommand]
        public async Task DeleteEntryAsync(MovementRecord movementRecord)
        {
            var deleteConfirmation = await _promptService.ShowConfirmationAsync(
                AppResources.DeleteEntryTitle,
                AppResources.DeleteAskForConfirmation,
                AppResources.Delete,
                AppResources.Cancel);
            if (deleteConfirmation)
            {
                await _movementRecordRepository.DeleteMovementRecordAsync(movementRecord);
                MovementRecords.Remove(movementRecord);
            }
        }

        [RelayCommand]
        public async Task SaveAndGoBackAsync()
        {
            await _movementRecordRepository.UpdateAllEntriesAsync(MovementRecords);
            await _navigationService.GoBackAsync();
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
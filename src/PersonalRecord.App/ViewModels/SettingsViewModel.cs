﻿namespace PersonalRecord.App.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.ObjectModel;

    public class SettingsViewModel : ObservableObject
    {
        private Setting _setting;

        private ObservableCollection<Movement> _movements;

        public SettingsViewModel()
        {
            // TODO: load from Firestore
            Setting = new Setting
            {
                Unit = "kg",
                DateFormat = "yyyy-MM-dd"
            };

            Movements =
            [
                new()
                {
                    Name = "Deadlift",
                },
                new()
                {
                    Name = "Backsquat",
                }
            ];
        }

        public ObservableCollection<Movement> Movements
        {
            get => _movements;
            set => SetProperty(ref _movements, value);
        }

        public Setting Setting
        {
            get => _setting;
            set => SetProperty(ref _setting, value);
        }
    }
}
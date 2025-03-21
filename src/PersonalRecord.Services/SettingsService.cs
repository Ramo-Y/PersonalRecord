﻿namespace PersonalRecord.Services
{
    using CommunityToolkit.Mvvm.Messaging;
    using PersonalRecord.Infrastructure;
    using PersonalRecord.Infrastructure.Constants;
    using PersonalRecord.Services.Events;
    using PersonalRecord.Services.Interfaces;

    public class SettingsService : ISettingsService
    {
        public Setting LoadSettings()
        {
            var setting = GetSettingFromPreferences();
            return setting;
        }

        public void UpdateSettings(Setting newSetting)
        {
            var currentSetting = GetSettingFromPreferences();
            if (currentSetting.Language != newSetting.Language)
            {
                UpdatePreferences(newSetting);
                WeakReferenceMessenger.Default.Send(new LanguageChangedMessage());
                
                return;
            }

            UpdatePreferences(newSetting);
        }

        private Setting GetSettingFromPreferences()
        {
            var setting = new Setting()
            {
                WeightUnit = Preferences.Default.Get(nameof(Setting.WeightUnit), DefaultConstants.DEFAULT_WEIGHT_UNIT),
                WeightUnitFormat = Preferences.Default.Get(nameof(Setting.WeightUnitFormat), DefaultConstants.DEFAULT_WEIGHT_UNIT_FORMAT),
                DistanceUnit = Preferences.Default.Get(nameof(Setting.DistanceUnit), DefaultConstants.DEFAULT_DISTANCE_UNIT),
                DateFormat = Preferences.Default.Get(nameof(Setting.DateFormat), DefaultConstants.DEFAULT_DATE_FORMAT),
                Language = (Language)Preferences.Default.Get(nameof(Setting.Language), DefaultConstants.DEFAULT_LANGUAGE)
            };

            return setting;
        }

        private void UpdatePreferences(Setting newSetting)
        {
            Preferences.Default.Set(nameof(Setting.WeightUnit), newSetting.WeightUnit);
            Preferences.Default.Set(nameof(Setting.WeightUnitFormat), $"{DefaultConstants.UNIT_FORMAT_PREFIX}{newSetting.WeightUnit}");
            Preferences.Default.Set(nameof(Setting.DistanceUnit), newSetting.DistanceUnit);
            Preferences.Default.Set(nameof(Setting.DateFormat), newSetting.DateFormat);
            Preferences.Default.Set(nameof(Setting.Language), (int)newSetting.Language);
        }
    }
}
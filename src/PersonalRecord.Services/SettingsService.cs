namespace PersonalRecord.Services
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
                Unit = Preferences.Default.Get(nameof(Setting.Unit), DefaultConstants.DEFAULT_UNIT),
                DateFormat = Preferences.Default.Get(nameof(Setting.DateFormat), DefaultConstants.DEFAULT_DATE_FORMAT),
                UnitFormat = Preferences.Default.Get(nameof(Setting.UnitFormat), DefaultConstants.DEFAULT_UNIT_FORMAT),
                Language = (Language)Preferences.Default.Get(nameof(Setting.Language), DefaultConstants.DEFAULT_LANGUAGE)
            };

            return setting;
        }

        private void UpdatePreferences(Setting newSetting)
        {
            Preferences.Default.Set(nameof(Setting.Unit), newSetting.Unit);
            Preferences.Default.Set(nameof(Setting.DateFormat), newSetting.DateFormat);
            Preferences.Default.Set(nameof(Setting.UnitFormat), newSetting.UnitFormat);
            Preferences.Default.Set(nameof(Setting.Language), (int)newSetting.Language);
        }
    }
}
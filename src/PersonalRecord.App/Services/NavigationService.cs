namespace PersonalRecord.App.Services
{
    using Microsoft.Maui.Controls;
    using PersonalRecord.App.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NavigationService : INavigationService
    {
        public async Task GoToAsync(ShellNavigationState state)
        {
            await Shell.Current.GoToAsync(state);
        }

        public async Task GoToAsync(ShellNavigationState state, string parameterName, string parameterValue)
        {
            await Shell.Current.GoToAsync($"{state}?{parameterName}={parameterValue}");
        }

        public async Task GoToAsync(ShellNavigationState state, Dictionary<string, object> navigationParameter)
        {
            await Shell.Current.GoToAsync(state, navigationParameter);
        }

        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
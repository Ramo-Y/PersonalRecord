namespace PersonalRecord.Services.Services
{
    using Microsoft.Maui.Controls;
    using PersonalRecord.Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NavigationService : INavigationService
    {
        public async Task GoToAsync(ShellNavigationState state)
        {
            await Shell.Current.GoToAsync(state);
        }

        public async Task GoToMainViewAsync()
        {
            // INFO: https://stackoverflow.com/questions/73547988/maui-relative-routing-to-shell-elements-is-currently-not-supported
            await Shell.Current.GoToAsync("//MainView");
        }

        public async Task GoToAsync(ShellNavigationState state, string parameterName, string parameterValue)
        {
            await Shell.Current.GoToAsync($"{state.Location}?{parameterName}={parameterValue}");
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
namespace PersonalRecord.Services
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

        public async Task GoBackAsync(ShellNavigationQueryParameters parameters)
        {
            await Shell.Current.GoToAsync("..", parameters);
        }
    }
}
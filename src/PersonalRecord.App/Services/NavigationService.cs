namespace PersonalRecord.App.Services
{
    using Microsoft.Maui.Controls;
    using PersonalRecord.App.Interfaces;
    using System.Threading.Tasks;

    public class NavigationService : INavigationService
    {
        public Task GoBackAsync() => Shell.Current.GoToAsync("..");

        public Task GoToAsync(ShellNavigationState state) => Shell.Current.GoToAsync(state);
    }
}
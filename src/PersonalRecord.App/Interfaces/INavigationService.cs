namespace PersonalRecord.App.Interfaces
{
    public interface INavigationService
    {
        Task GoToAsync(ShellNavigationState state);

        Task GoBackAsync();
    }
}
namespace PersonalRecord.Services.Interfaces
{
    public interface INavigationService
    {
        Task GoToAsync(ShellNavigationState state);

        Task GoToMainViewAsync();

        Task GoToAsync(ShellNavigationState state, string parameterName, string parameterValue);
        
        Task GoToAsync(ShellNavigationState state, Dictionary<string, object> navigationParameter);

        Task GoBackAsync();
    }
}
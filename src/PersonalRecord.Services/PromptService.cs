namespace PersonalRecord.Services
{
    using PersonalRecord.Services.Interfaces;
    using System;
    using System.Threading.Tasks;

    public class PromptService : IPromptService
    {
        public async Task ShowAlertAsync(string title, string message, string cancel = "OK")
        {
            await Application.Current!.MainPage!.DisplayAlert(title, message, cancel);
            return;
        }

        public async Task<bool> ShowConfirmationAsync(string title, string message, string accept = "Yes", string cancel = "No")
        {
            return await Application.Current!.MainPage!.DisplayAlert(title, message, accept, cancel);
        }

        public void ShowAlert(string title, string message, string cancel = "OK")
        {
            Application.Current!.MainPage!.Dispatcher.Dispatch(async () =>
            {
                await ShowAlertAsync(title, message, cancel);
            });
        }

        public void ShowConfirmation(string title, string message, Action<bool> callback, string accept = "Yes", string cancel = "No")
        {
            Application.Current!.MainPage!.Dispatcher.Dispatch(async () =>
            {
                bool answer = await ShowConfirmationAsync(title, message, accept, cancel);
                callback(answer);
            });
        }

        public async Task ShowPromptAsync(string title, string message)
        {
            await Application.Current!.MainPage!.DisplayPromptAsync(title, message);
        }
    }
}
namespace PersonalRecord.App.Platforms.Android.Handlers
{
    using AndroidX.AppCompat.Widget;
    using Microsoft.Maui.Controls.Compatibility.Platform.Android;
    using Microsoft.Maui.Handlers;
    using PersonalRecord.Infrastructure.Constants;

    public class CustomEntryHandler : EntryHandler
    {
        protected override void ConnectHandler(AppCompatEditText platformView)
        {
            base.ConnectHandler(platformView);
            platformView.FocusChange += PlatformView_FocusChange;
            SetColor(platformView);
        }

        private void PlatformView_FocusChange(object? sender, global::Android.Views.View.FocusChangeEventArgs e)
        {
            if (sender is AppCompatEditText entry)
            {
                SetColor(entry);
            }
        }

        private void SetColor(AppCompatEditText platformView)
        {
            if (platformView.IsFocused)
            {
                platformView.BackgroundTintList = global::Android.Content.Res.ColorStateList.ValueOf(Color.FromArgb(ColorConstants.SYNCFUSION_UNDERLINE_COLOR).ToAndroid());
            }
            else
            {
                platformView.BackgroundTintList = global::Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
            }
        }
    }
}
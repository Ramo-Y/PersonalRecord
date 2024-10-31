namespace PersonalRecord.App.Converters
{
    using System.Globalization;

    public class IsEnabledToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isEnabled)
            {
                if (!isEnabled)
                {
                    return Colors.Gray;
                }

                var plattformTheme = App.Current!.PlatformAppTheme;
                if (plattformTheme == AppTheme.Dark)
                {
                    return Colors.White;
                }
                else
                {
                    return Colors.Black;
                }
            }

            return Colors.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
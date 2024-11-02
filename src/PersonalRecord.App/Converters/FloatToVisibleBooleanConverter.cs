namespace PersonalRecord.App.Converters
{
    using System.Globalization;

    public class FloatToVisibleBooleanConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is float floatValue && floatValue != 0)
            {
                return true;
            }

            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
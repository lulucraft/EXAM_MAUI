using System.Globalization;

namespace EXAM_MAUI.Converters
{
    public class BooleanToYesNoConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? "oui" : "non";
            }
            return "non";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                return stringValue.Equals("oui", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}

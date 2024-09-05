using System.Globalization;

namespace EXAM_MAUI.Converters
{
    public class PageNumberConverter : IValueConverter
    {
        public object? Convert(object? values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values != null && values is int[])
            {
                int[]? vals = (int[])values;
                if (vals != null && vals[0] is int pageNumber && vals[1] is int totalCount)
                {
                    return $"{pageNumber}/{totalCount}";
                }
            }

            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetTypes, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

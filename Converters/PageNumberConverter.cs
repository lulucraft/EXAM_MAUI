using System.Globalization;

namespace EXAM_MAUI.Converters
{
    public class PageNumberConverter : IMultiValueConverter
    {
        public object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            //if (values != null && values is int[])
            //{
            //    int[]? vals = (int[])values;
                //if (vals != null && vals[0] is int pageNumber && vals[1] is int totalPages)
                if (values[0] is int pageNumber && values[1] is int totalPages)
                {
                    return $"{pageNumber}/{totalPages}";
                }
            //}

            return string.Empty;
        }

        public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

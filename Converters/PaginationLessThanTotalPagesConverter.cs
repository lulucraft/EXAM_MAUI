using System.Globalization;

namespace EXAM_MAUI.Converters
{
    public class PaginationLessThanTotalPagesConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                int pageNumber = (int)value;
                int totalPages = (int)parameter;
                return pageNumber < totalPages;
            }

            return false;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

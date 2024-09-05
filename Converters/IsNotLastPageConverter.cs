using System.Globalization;

namespace EXAM_MAUI.Converters
{
    public class IsNotLastPageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is int pageNumber && values[1] is int totalPages)
            {
                //int pageNumber = values[0];
                //int totalPages = values[1];
                return pageNumber < totalPages;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

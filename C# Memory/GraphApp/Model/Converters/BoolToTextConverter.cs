using System;
using System.Globalization;
using System.Windows.Data;

namespace GraphApp.Model.Converters
{
    public class BoolToTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3)
                return Binding.DoNothing;

            bool condition = values[0] as bool? ?? false;
            var text1 = values[1] as string;
            var text2 = values[2] as string;

            return condition ? text1 : text2;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new Exception();
    }
}
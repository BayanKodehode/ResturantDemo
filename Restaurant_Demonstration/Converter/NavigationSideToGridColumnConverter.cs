using System;
using System.Globalization;
using System.Windows.Data;
using Restaurant_Demonstration.ViewModel;

namespace Restaurant_Demonstration.Converter
{
    public class NavigationSideToGridColumnConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var navigationSide = (NavigationSide)value;
            return navigationSide == NavigationSide.Right
                ? 0 // value for grid.Column
                : 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

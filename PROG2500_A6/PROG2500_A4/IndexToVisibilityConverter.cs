using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PROG2500_A4
{
    public class IndexToVisibilityConverter : IValueConverter
    {
        // Converts an integer index to Visibility
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // value: The selected index (SelectedEyes, SelectedNose, those things)
            // parameter: The target index for this specific image (passed from XAML)
            if (value is int selectedIndex && parameter is string parameterString && int.TryParse(parameterString, out int targetIndex))
            {
                // If the selected index matches the target index, make the image visible
                return selectedIndex == targetIndex ? Visibility.Visible : Visibility.Collapsed;
            }
            // if something goes wrong default to Collapsed 
            return Visibility.Collapsed;
        }

        // Not needed but required by IValueConverter interface
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
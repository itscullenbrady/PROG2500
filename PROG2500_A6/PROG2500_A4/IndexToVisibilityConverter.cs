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
            // value: The selected index (e.g., SelectedEyes, SelectedNose, etc.)
            // parameter: The target index for this specific image (passed from XAML)
            if (value is int selectedIndex && parameter is string parameterString && int.TryParse(parameterString, out int targetIndex))
            {
                // If the selected index matches the target index, make the image visible
                return selectedIndex == targetIndex ? Visibility.Visible : Visibility.Collapsed;
            }
            // Default to Collapsed if something goes wrong
            return Visibility.Collapsed;
        }

        // Not needed for this scenario, but required by the IValueConverter interface
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
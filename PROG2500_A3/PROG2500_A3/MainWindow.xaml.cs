using System;
using System.Windows;
using System.Windows.Controls;

namespace PROG2500_A2
{
    public partial class MainWindow : Window
    {
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            // Randomize Eyes
            var eyesOptions = new[] { Eyes1, Eyes2, Eyes3 };
            SetRandomVisibility(eyesOptions);

            // Randomize Mouth
            var mouthOptions = new[] { Mouth1, Mouth2, Mouth3 };
            SetRandomVisibility(mouthOptions);

            // Randomize Hair
            var hairOptions = new[] { Hair1, Hair2, Hair3 };
            SetRandomVisibility(hairOptions);

            // Randomize Nose
            var noseOptions = new[] { Nose1, Nose2, Nose3 };
            SetRandomVisibility(noseOptions);
        }

        private void SetRandomVisibility(UIElement[] options)
        {
            // Collapse all options
            foreach (var option in options)
            {
                option.Visibility = Visibility.Collapsed;
            }

            // Pick a random option and make it visible
            int randomIndex = random.Next(options.Length);
            options[randomIndex].Visibility = Visibility.Visible;
        }

        private void Nose1_Checked(object sender, RoutedEventArgs e) => ShowOnly(Nose1, Nose2, Nose3);
        private void Nose1_Unchecked(object sender, RoutedEventArgs e) => Nose1.Visibility = Visibility.Collapsed;

        private void Nose2_Checked(object sender, RoutedEventArgs e) => ShowOnly(Nose2, Nose1, Nose3);
        private void Nose2_Unchecked(object sender, RoutedEventArgs e) => Nose2.Visibility = Visibility.Collapsed;

        private void Nose3_Checked(object sender, RoutedEventArgs e) => ShowOnly(Nose3, Nose1, Nose2);
        private void Nose3_Unchecked(object sender, RoutedEventArgs e) => Nose3.Visibility = Visibility.Collapsed;

        private void EyeColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EyeColor.SelectedIndex == 0) ShowOnly(Eyes1, Eyes2, Eyes3);
            else if (EyeColor.SelectedIndex == 1) ShowOnly(Eyes2, Eyes1, Eyes3);
            else if (EyeColor.SelectedIndex == 2) ShowOnly(Eyes3, Eyes1, Eyes2);
        }

        private void Mouth1_Checked(object sender, RoutedEventArgs e) => ShowOnly(Mouth1, Mouth2, Mouth3);
        private void Mouth1_Unchecked(object sender, RoutedEventArgs e) => Mouth1.Visibility = Visibility.Collapsed;

        private void Mouth2_Checked(object sender, RoutedEventArgs e) => ShowOnly(Mouth2, Mouth1, Mouth3);
        private void Mouth2_Unchecked(object sender, RoutedEventArgs e) => Mouth2.Visibility = Visibility.Collapsed;

        private void Mouth3_Checked(object sender, RoutedEventArgs e) => ShowOnly(Mouth3, Mouth1, Mouth2);
        private void Mouth3_Unchecked(object sender, RoutedEventArgs e) => Mouth3.Visibility = Visibility.Collapsed;

        private void HairOption_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = HairOptions.Value;

            if (value < 33) ShowOnly(Hair1, Hair2, Hair3);
            else if (value < 66) ShowOnly(Hair2, Hair1, Hair3);
            else ShowOnly(Hair3, Hair1, Hair2);
        }

        private void ShowOnly(UIElement toShow, params UIElement[] toHide)
        {
            toShow.Visibility = Visibility.Visible;
            foreach (var element in toHide)
            {
                element.Visibility = Visibility.Collapsed;
            }
        }
    }
}

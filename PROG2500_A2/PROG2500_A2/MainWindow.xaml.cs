using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG2500_A2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowHair1_Click(object sender, RoutedEventArgs e)
        {
            Hair1.Visibility = Visibility.Visible;
            Hair2.Visibility = Visibility.Collapsed;
        }
        private void ShowHair2_Click(object sender, RoutedEventArgs e)
        {
            Hair2.Visibility = Visibility.Visible;
            Hair1.Visibility = Visibility.Collapsed;
        }
        private void ShowNose1_Click(object sender, RoutedEventArgs e)
        {
            Nose1.Visibility = Visibility.Visible;
            Nose2.Visibility = Visibility.Collapsed;
        }
        private void ShowNose2_Click(object sender, RoutedEventArgs e)
        {
            Nose2.Visibility = Visibility.Visible;
            Nose1.Visibility = Visibility.Collapsed;
        }
        private void ShowEye1_Click(object sender, RoutedEventArgs e)
        {
            Eyes1.Visibility = Visibility.Visible;
            Eyes2.Visibility = Visibility.Collapsed;
        }
        private void ShowEye2_Click(object sender, RoutedEventArgs e)
        {
            Eyes2.Visibility = Visibility.Visible;
            Eyes1.Visibility = Visibility.Collapsed;
        }
        private void ShowMouth1_Click(object sender, RoutedEventArgs e)
        {
            Mouth1.Visibility = Visibility.Visible;
            Mouth2.Visibility = Visibility.Collapsed;
        }
        private void ShowMouth2_Click(object sender, RoutedEventArgs e)
        {
            Mouth2.Visibility = Visibility.Visible;
            Mouth1.Visibility = Visibility.Collapsed;
        }
        private void Random_Click(object sender, RoutedEventArgs e)
        {
            // Randomize Eyes
            var eyesOptions = new[] { Eyes1, Eyes2 };
            SetRandomVisibility(eyesOptions);

            // Randomize Mouth
            var mouthOptions = new[] { Mouth1, Mouth2 };
            SetRandomVisibility(mouthOptions);

            // Randomize Hair (example placeholders)
            var hairOptions = new[] { Hair1, Hair2 };
            SetRandomVisibility(hairOptions);

            // Randomize Nose (example placeholders)
            var noseOptions = new[] { Nose1, Nose2 };
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
    }
}
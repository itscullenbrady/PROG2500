using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PROG2500_A4
{
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private string comboBox1Selection;
        private string comboBox2Selection;

        // Initiating the counter / selection storage
        private int CurrentHair = 0;
        private int CurrentEyes = 0;
        private int CurrentMouth = 0;
        private int CurrentNose = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Key bindings **Shift + Control + F# as the F# are already bind
            this.InputBindings.Add(new KeyBinding(new RelayCommand(SetNextHair), new KeyGesture(Key.F1, ModifierKeys.Control | ModifierKeys.Shift)));
            this.InputBindings.Add(new KeyBinding(new RelayCommand(SetNextEyes), new KeyGesture(Key.F2, ModifierKeys.Control | ModifierKeys.Shift)));
            this.InputBindings.Add(new KeyBinding(new RelayCommand(SetNextMouth), new KeyGesture(Key.F3, ModifierKeys.Control | ModifierKeys.Shift)));
            this.InputBindings.Add(new KeyBinding(new RelayCommand(SetNextNose), new KeyGesture(Key.F4, ModifierKeys.Control | ModifierKeys.Shift)));
        }

        // Functions that the Buttons and menu clicks both share! ** oouuu handlers 
        private void NextHair_Click(object sender, RoutedEventArgs e) => SetNextHair();
        private void NextEyes_Click(object sender, RoutedEventArgs e) => SetNextEyes();
        private void NextMouth_Click(object sender, RoutedEventArgs e) => SetNextMouth();
        private void NextNose_Click(object sender, RoutedEventArgs e) => SetNextNose();

        // Methods for updating face elements
        private void SetNextHair()
        {
            CurrentHair = (CurrentHair + 1) % 3;
            UpdateVisibility(new[] { Hair1, Hair2, Hair3 }, CurrentHair);

            var viewModel = DataContext as MainViewModel;
            viewModel.SelectedHair = CurrentHair;
        }

        private void SetNextEyes()
        {
            CurrentEyes = (CurrentEyes + 1) % 3;
            UpdateVisibility(new[] { Eyes1, Eyes2, Eyes3 }, CurrentEyes);

            var viewModel = DataContext as MainViewModel;
            viewModel.SelectedEyes = CurrentEyes;
        }

        private void SetNextMouth()
        {
            CurrentMouth = (CurrentMouth + 1) % 3;
            UpdateVisibility(new[] { Mouth1, Mouth2, Mouth3 }, CurrentMouth);

            var viewModel = DataContext as MainViewModel;
            viewModel.SelectedMouth = CurrentMouth;
        }

        private void SetNextNose()
        {
            CurrentNose = (CurrentNose + 1) % 3;
            UpdateVisibility(new[] { Nose1, Nose2, Nose3 }, CurrentNose);

            var viewModel = DataContext as MainViewModel;
            viewModel.SelectedNose = CurrentNose;
        }

        // Randomize all face pics
        private void Random_Click(object sender, RoutedEventArgs e)
        {
            CurrentHair = random.Next(3);
            CurrentEyes = random.Next(3);
            CurrentMouth = random.Next(3);
            CurrentNose = random.Next(3);

            UpdateFace();
        }

        private void UpdateFace()
        {
            UpdateVisibility(new[] { Hair1, Hair2, Hair3 }, CurrentHair);
            UpdateVisibility(new[] { Eyes1, Eyes2, Eyes3 }, CurrentEyes);
            UpdateVisibility(new[] { Mouth1, Mouth2, Mouth3 }, CurrentMouth);
            UpdateVisibility(new[] { Nose1, Nose2, Nose3 }, CurrentNose);
        }

        // Function to show/hide elements based on index
        private void UpdateVisibility(UIElement[] options, int visibleIndex)
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].Visibility = (i == visibleIndex) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        // ComboBox Selection Changed Event
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                var viewModel = DataContext as MainViewModel;

                if (comboBox.SelectedItem != null)
                {
                    // Extract the Content of the selected ComboBoxItem
                    string selectedValue = (comboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

                    if (comboBox.Name == "Occupation")
                    {
                        viewModel.Occupation = selectedValue;
                    }
                    else if (comboBox.Name == "Hobbies")
                    {
                        viewModel.Hobbies = selectedValue;
                    }
                }
            }
        }

        // TextBox GotFocus Event (Clear placeholder text)
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == textBox.Tag?.ToString())
            {
                textBox.Text = string.Empty;
            }
        }

        // TextBox LostFocus Event (Restore placeholder text if empty)
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = textBox.Tag?.ToString();
            }
        }

        private void SaveSummary_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;

            // Create the summary text
            string summaryText = $"First Name: {viewModel.FirstName}\n" +
                                 $"Last Name: {viewModel.LastName}\n" +
                                 $"Address: {viewModel.Address}\n" +
                                 $"City: {viewModel.City}\n" +
                                 $"Province: {viewModel.Province}\n" +
                                 $"Postal Code: {viewModel.PostalCode}\n" +
                                 $"Occupation: {viewModel.Occupation}\n" +
                                 $"Hobbies: {viewModel.Hobbies}\n" +
                                 $"Dog Lover: {viewModel.IsDogLover}\n" +
                                 $"Cat Lover: {viewModel.IsCatLover}";

            // Use FirstName as the filename
            string fileName = $"{viewModel.FirstName}.txt";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            // Save the summary to a text file
            File.WriteAllText(filePath, summaryText);

            MessageBox.Show($"Summary saved to {filePath}", "Save Successful", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Clear local data by resetting the ViewModel properties
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                viewModel.FirstName = "First Name";
                viewModel.LastName = "Last Name";
                viewModel.Address = "Civic Address";
                viewModel.City = "City";
                viewModel.Province = "Province";
                viewModel.PostalCode = "Postal Code";
                viewModel.Occupation = string.Empty;
                viewModel.Hobbies = string.Empty;
                viewModel.IsDogLover = false;
                viewModel.IsCatLover = false;

                // Reset face customization options
                viewModel.SelectedEyes = 0;
                viewModel.SelectedNose = 0;
                viewModel.SelectedMouth = 0;
                viewModel.SelectedHair = 0;
            }

            // Navigate to Personal Information tab
            tabControl.SelectedIndex = 0;

            // a little confirmation message
            MessageBox.Show("All data has been cleared.", "Cancel", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    }

    // Command implementation for key bindings
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => canExecute == null || canExecute();

        public void Execute(object parameter) => execute();

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
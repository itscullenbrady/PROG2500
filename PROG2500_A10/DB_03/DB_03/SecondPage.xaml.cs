using System.Diagnostics;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;

namespace DB_03
{
    public partial class SecondPage : Page
    {
        public SecondPage()
        {
            InitializeComponent();

            // Key bindings **Shift + Control + F# as the F# are already bind
            this.InputBindings.Add(new KeyBinding(new RelayCommand(SetNextHair), new KeyGesture(Key.F1, ModifierKeys.Control | ModifierKeys.Shift)));
            this.InputBindings.Add(new KeyBinding(new RelayCommand(SetNextEyes), new KeyGesture(Key.F2, ModifierKeys.Control | ModifierKeys.Shift)));
            this.InputBindings.Add(new KeyBinding(new RelayCommand(SetNextMouth), new KeyGesture(Key.F3, ModifierKeys.Control | ModifierKeys.Shift)));
            this.InputBindings.Add(new KeyBinding(new RelayCommand(SetNextNose), new KeyGesture(Key.F4, ModifierKeys.Control | ModifierKeys.Shift)));
        }

        private readonly Random random = new Random();

        // Initiating the counter / selection storage
        private int CurrentHair = 0;
        private int CurrentEyes = 0;
        private int CurrentMouth = 0;
        private int CurrentNose = 0;

        private void ChmHelpFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature pending", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void HtmlHelpWebsite_Click(object sender, RoutedEventArgs e)
        {
            // help website
            string htmlHelpUrl = @"https://itscullenbrady.github.io/Character-Customization-Help/MainPage";
            Process.Start(new ProcessStartInfo(htmlHelpUrl) { UseShellExecute = true });
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
        }

        private void SetNextEyes()
        {
            CurrentEyes = (CurrentEyes + 1) % 3;
            UpdateVisibility(new[] { Eyes1, Eyes2, Eyes3 }, CurrentEyes);
        }

        private void SetNextMouth()
        {
            CurrentMouth = (CurrentMouth + 1) % 3;
            UpdateVisibility(new[] { Mouth1, Mouth2, Mouth3 }, CurrentMouth);
        }

        private void SetNextNose()
        {
            CurrentNose = (CurrentNose + 1) % 3;
            UpdateVisibility(new[] { Nose1, Nose2, Nose3 }, CurrentNose);
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

        private void SaveFace_Click(object sender, RoutedEventArgs e)
        {
            string lastName = tb_lastName.Text;

            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please enter a last name.");
                return;
            }

            string connstr = DB_03.Utility.GetConnectionString();
            using (SqlConnection con = new SqlConnection(connstr))
            {
                string cmdText = "UPDATE Person SET Hair = @Hair, Eyes = @Eyes, Mouth = @Mouth, Nose = @Nose WHERE lname = @LastName";
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@Hair", CurrentHair);
                cmd.Parameters.AddWithValue("@Eyes", CurrentEyes);
                cmd.Parameters.AddWithValue("@Mouth", CurrentMouth);
                cmd.Parameters.AddWithValue("@Nose", CurrentNose);
                cmd.Parameters.AddWithValue("@LastName", lastName);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Face saved successfully.");
                }
                else
                {
                    MessageBox.Show("No person found with the given last name.");
                }
            }
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



using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PROG2500_A7
{
    public partial class MainWindow : Window
    {
        private Dorothy dorothy;
        private object lockObject = new object(); // For synchronized version

        public MainWindow()
        {
            InitializeComponent();
            dorothy = new Dorothy();
            Text_Output.AppendText(" .. Startup ... ready to run either synched or non-synched data access\r");
        }

        // Clear the textbox
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Text_Output.Clear();
            ProgressBar.Value = 0;
        }

        // Reset Dorothy's data
        private void ResetDorothy()
        {
            dorothy.FavoriteCharacter = "None";
            dorothy.FavoriteColor = Color.None; // Default color
        }

        // Update the UI using Dispatcher
        private void UpdateUI(string characterName, Color color, int totalThreads)
        {
            Dispatcher.Invoke(() =>
            {
                Text_Output.AppendText($"{characterName} set favorite character to {dorothy.FavoriteCharacter} and color to {dorothy.FavoriteColor}\r");

                // Update progress (if you have a ProgressBar)
                if (ProgressBar.Value < totalThreads)
                {
                    ProgressBar.Value++;
                }

                // Display final result when all threads are done
                if (ProgressBar.Value == totalThreads)
                {
                    Text_Output.AppendText($"Final Result: {dorothy}\r");
                }
            });
        }

        //----------------------------------------------------------------------------------------------------------------
        // Task-based versions
        //----------------------------------------------------------------------------------------------------------------

        // Unsynched version using Task
        private async void RunUnsynchedButton_Click(object sender, RoutedEventArgs e)
        {
            ResetDorothy();
            Text_Output.AppendText("Running Unsynched Version (Task)...\r");
            ProgressBar.Value = 0;

            List<Task> tasks = new List<Task>();
            int threadCount = 100; // Number of threads per character
            int totalThreads = threadCount * 3; // Total number of threads

            for (int i = 0; i < threadCount; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    new CharacterThread(dorothy, "Tin Man", Color.Silver, null).Run();
                    UpdateUI("Tin Man", Color.Silver, totalThreads);
                }));

                tasks.Add(Task.Run(() =>
                {
                    new CharacterThread(dorothy, "Scarecrow", Color.Brown, null).Run();
                    UpdateUI("Scarecrow", Color.Brown, totalThreads);
                }));

                tasks.Add(Task.Run(() =>
                {
                    new CharacterThread(dorothy, "Cowardly Lion", Color.Yellow, null).Run();
                    UpdateUI("Cowardly Lion", Color.Yellow, totalThreads);
                }));
            }

            await Task.WhenAll(tasks); // Wait for all tasks to complete asynchronously
        }

        // Synched version using Task and lock
        private async void RunSynchedButton_Click(object sender, RoutedEventArgs e)
        {
            ResetDorothy();
            Text_Output.AppendText("Running Synched Version (Task)...\r");
            ProgressBar.Value = 0;

            List<Task> tasks = new List<Task>();
            int threadCount = 100; // Number of threads per character
            int totalThreads = threadCount * 3; // Total number of threads

            for (int i = 0; i < threadCount; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    lock (lockObject)
                    {
                        new CharacterThread(dorothy, "Tin Man", Color.Silver, lockObject).Run();
                        UpdateUI("Tin Man", Color.Silver, totalThreads);
                    }
                }));

                tasks.Add(Task.Run(() =>
                {
                    lock (lockObject)
                    {
                        new CharacterThread(dorothy, "Scarecrow", Color.Brown, lockObject).Run();
                        UpdateUI("Scarecrow", Color.Brown, totalThreads);
                    }
                }));

                tasks.Add(Task.Run(() =>
                {
                    lock (lockObject)
                    {
                        new CharacterThread(dorothy, "Cowardly Lion", Color.Yellow, lockObject).Run();
                        UpdateUI("Cowardly Lion", Color.Yellow, totalThreads);
                    }
                }));
            }

            await Task.WhenAll(tasks); // Wait for all tasks to complete asynchronously
        }

        //----------------------------------------------------------------------------------------------------------------
        // Thread-based versions
        //----------------------------------------------------------------------------------------------------------------

        // Unsynched version using Thread
        private void RunUnsynchedButton_Click_Thread(object sender, RoutedEventArgs e)
        {
            ResetDorothy();
            Text_Output.AppendText("Running Unsynched Version (Thread)...\r");
            ProgressBar.Value = 0;

            List<Thread> threads = new List<Thread>();
            int threadCount = 100; // Number of threads per character
            int totalThreads = threadCount * 3; // Total number of threads

            for (int i = 0; i < threadCount; i++)
            {
                threads.Add(new Thread(() =>                             // vvv added lockObject null because unsynched
                {
                    new CharacterThread(dorothy, "Tin Man", Color.Silver, null).Run();
                    UpdateUI("Tin Man", Color.Silver, totalThreads);
                }));

                threads.Add(new Thread(() =>
                {
                    new CharacterThread(dorothy, "Scarecrow", Color.Brown, null).Run();
                    UpdateUI("Scarecrow", Color.Brown, totalThreads);
                }));

                threads.Add(new Thread(() =>
                {
                    new CharacterThread(dorothy, "Cowardly Lion", Color.Yellow, null).Run();
                    UpdateUI("Cowardly Lion", Color.Yellow, totalThreads);
                }));
            }

            // Start all threads
            foreach (var thread in threads)
            {
                thread.Start();
            }

            // Use a BACKGROUND THREAD to wait for all threads to complete.. fhew i hated the non responsive UI
            Thread waitThread = new Thread(() =>
            {
                foreach (var thread in threads)
                {
                    thread.Join();
                }

                // Notify the UI that all threads are done
                Dispatcher.Invoke(() =>
                {
                    Text_Output.AppendText($"Final Result: {dorothy}\r");
                });
            });

            waitThread.IsBackground = true; // Ensure the thread doesn't keep the application alive
            waitThread.Start(); // Start the background thread
        }

        // Synched version using Thread and lock
        private void RunSynchedButton_Click_Thread(object sender, RoutedEventArgs e)
        {
            ResetDorothy();
            Text_Output.AppendText("Running Synched Version (Thread)...\r");
            ProgressBar.Value = 0;

            List<Thread> threads = new List<Thread>();
            int threadCount = 100; // Number of threads per character
            int totalThreads = threadCount * 3; // Total number of threads

            for (int i = 0; i < threadCount; i++)
            {
                threads.Add(new Thread(() =>
                {
                    lock (lockObject)                                        // vvvvvvvvv
                    {  // Lock the objects to prevent multiple threads from accessing it at the same time   
                        new CharacterThread(dorothy, "Tin Man", Color.Silver, lockObject).Run();
                        UpdateUI("Tin Man", Color.Silver, totalThreads);   
                    }
                }));

                threads.Add(new Thread(() =>
                {
                    lock (lockObject)
                    {
                        new CharacterThread(dorothy, "Scarecrow", Color.Brown, lockObject).Run();
                        UpdateUI("Scarecrow", Color.Brown, totalThreads);
                    }
                }));

                threads.Add(new Thread(() =>
                {
                    lock (lockObject)
                    {
                        new CharacterThread(dorothy, "Cowardly Lion", Color.Yellow, lockObject).Run();
                        UpdateUI("Cowardly Lion", Color.Yellow, totalThreads);
                    }
                }));
            }

            // Start all threads
            foreach (var thread in threads)
            {
                thread.Start();
            }

            // Use a background thread to wait for all threads to complete
            Thread waitThread = new Thread(() =>
            {
                foreach (var thread in threads)
                {
                    thread.Join();
                }

                // tell the UI that all threads are done
                Dispatcher.Invoke(() =>
                {
                    Text_Output.AppendText($"Final Result: {dorothy}\r");
                });
            });

            waitThread.IsBackground = true; // making sure thread doesn't keep the application alive
            waitThread.Start(); // Start background thread
        }
    }
}
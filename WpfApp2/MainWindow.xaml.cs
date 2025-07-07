using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms; // Добавь ссылку на System.Windows.Forms
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;


namespace StylishDownloader
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = "Выберите папку для сохранения статьи";
            dialog.ShowNewFolderButton = true;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text.Trim();
            string outputPath = PathTextBox.Text.Trim();

            string pythonExe = "python";
            string scriptPath = @"C:\Users\Михаил\Desktop\pa.py";

            string arguments = $"\"{scriptPath}\" \"{url}\" \"{outputPath}\"";

            var psi = new ProcessStartInfo
            {
                FileName = pythonExe,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine("[STDOUT]");
                Console.WriteLine(output);

                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("[STDERR]");
                    Console.WriteLine(error);
                }
            }

            // Например, в обработчике кнопки или где нужно показать сообщение:
            CustomMessageBox.Show("Готово!", this);


        }
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Позволяет перетаскивать окно
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
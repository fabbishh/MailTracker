using MailTracker.Desktop.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace MailTracker.Desktop
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class EmailInfoWindow : Window
    {
        private GetMail Email;

        public EmailInfoWindow(GetMail email)
        {
            InitializeComponent();
            this.Email = email;
            this.DataContext = this.Email;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAttachment = ((FrameworkElement)sender).DataContext as GetDocumentDto;

            if (selectedAttachment != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = Path.GetFileName(selectedAttachment.Path);

                string fileExtension = Path.GetExtension(selectedAttachment.Path);
                saveFileDialog.Filter = $"{fileExtension} files (*{fileExtension})|*{fileExtension}|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = fileExtension;

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.Copy(selectedAttachment.Path, saveFileDialog.FileName, true);

                    MessageBox.Show("File saved successfully.", "Save File", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}

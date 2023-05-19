using MailTracker.App.Models;
using MailTracker.Desktop.Models;
using MailTracker.Desktop.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MailTracker.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string BaseUrl = "https://localhost:7265/api/";
        private MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees();
            RefreshMails();
            this.DataContext = this.viewModel;
        }

        private async Task LoadEmployees()
        {
            recipientComboBox.ItemsSource = await GetEmployees();
            senderComboBox.ItemsSource = await GetEmployees();
        }

        private async Task<List<Employee>> GetEmployees()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = await client.GetAsync("employee");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Employee>>();
                }
                else
                {
                    MessageBox.Show("Error retrieving employees: " + response.ReasonPhrase);
                    return new List<Employee>();
                }
            }
        }

        private async Task RefreshMails()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = await client.GetAsync("emails");

                if (response.IsSuccessStatusCode)
                {
                    viewModel.Emails = await response.Content.ReadFromJsonAsync<ObservableCollection<GetMail>>();
                    mailsDataGrid.ItemsSource = viewModel.Emails;
                }
                else
                {
                    MessageBox.Show("Error retrieving mails: " + response.ReasonPhrase);
                }
            }
        }

        private async void AddMail_Click(object sender, RoutedEventArgs e)
        {
            var mail = new PostMail
            {
                Name = titleTextBox.Text,
                Date = DateTime.Now,
                RecipientId = (recipientComboBox.SelectedItem as Employee)?.Id ?? 0,
                SenderId = (senderComboBox.SelectedItem as Employee)?.Id ?? 0,
                Content = contentTextBox.Text,
                Documents = viewModel.Documents
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = await client.PostAsJsonAsync("emails", mail);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Mail added successfully.");
                    titleTextBox.Clear();
                    recipientComboBox.SelectedIndex = -1;
                    senderComboBox.SelectedIndex = -1;
                    contentTextBox.Clear();
                    viewModel.Documents.Clear();
                    await RefreshMails();
                }
                else
                {
                    MessageBox.Show("Error adding mail: " + response.ReasonPhrase);
                }
            }
        }

        private void AttachFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                viewModel.Documents.Add(new DocumentDto
                {
                    Name = Path.GetFileName(filePath),
                    FileBytes = File.ReadAllBytes(filePath)
                });
            }
        }

        private void MailsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (mailsDataGrid.SelectedItem == null) return;
            var selectedEmail = mailsDataGrid.SelectedItem as GetMail;
            var existingEmail = viewModel.Emails.FirstOrDefault(e => e.Id == selectedEmail.Id);
            var emailInfoWindow = new EmailInfoWindow(existingEmail);
            emailInfoWindow.Show();
            mailsDataGrid.SelectedItem = null;
        }

        private void RemoveDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedDocument = ((FrameworkElement)sender).DataContext as DocumentDto;

            if (selectedDocument != null)
            {
                viewModel.Documents.Remove(selectedDocument);
            }
        }

    }
}

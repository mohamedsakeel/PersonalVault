using PersonalVault.Data;
using PersonalVault.Models;
using PersonalVault.Services;
using System.Collections.ObjectModel;
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
using Windows.Security.Credentials.UI;

namespace PersonalVault
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VaultDbContext _context;
        private readonly EncryptionService _encryptionService;
        private readonly VaultService _vaultService;

        public ObservableCollection<Credential> Credentials { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            string secretKey = "D6Ehx2prE96ef9k2NlDlJtl4Rp6Zw/E=";
            var dbContext = new VaultDbContext(); // Assuming you have configured this correctly.

            _vaultService = new VaultService(dbContext, secretKey);
            LoadCredentials();

            SaveButton.IsEnabled = false;

            // Event handlers for field change
            ServiceTextBox.TextChanged += ValidateForm;
            UsernameTextBox.TextChanged += ValidateForm;
            PasswordTextBox.PasswordChanged += ValidateForm;
        }

        private void LoadCredentials()
        {
            Credentials = new ObservableCollection<Credential>(_vaultService.GetAllCredentials());
            CredentialsListView.ItemsSource = Credentials;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _vaultService.SaveCredential(ServiceTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Password, CommentTextBox.Text);
            LoadCredentials(); // Reload the credentials after saving a new one.
            ClearFields();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private async void GetButton_Click(object sender, RoutedEventArgs e)
        {
            var credential = _vaultService.GetCredential(ServiceTextBox.Text, UsernameTextBox.Text);
            if (credential.Id != 0)
            {
                ServiceTextBox.Text = credential.Service;
                UsernameTextBox.Text = credential.Username;
                PasswordTextBox.Password = _vaultService.DecryptPassword(credential.Password);
                CommentTextBox.Text = credential.Comment;
                ResultTextBlock.Text = "Credential loaded successfully.";

                // Show the decrypted password as plain text
                PasswordTextBox.Visibility = Visibility.Collapsed;
                PlainTextPasswordBox.Text = _vaultService.DecryptPassword(credential.Password);
                PlainTextPasswordBox.Visibility = Visibility.Visible;
            }
            else
            {
                ResultTextBlock.Text = "Credential not found.";
            }

        }

        private void ValidateForm(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = !string.IsNullOrWhiteSpace(ServiceTextBox.Text)
                                   && !string.IsNullOrWhiteSpace(UsernameTextBox.Text)
                                   && !string.IsNullOrWhiteSpace(PasswordTextBox.Password);
        }

        private void CredentialsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CredentialsListView.SelectedItem is Credential selectedCredential)
            {
                ServiceTextBox.Text = selectedCredential.Service;
                UsernameTextBox.Text = selectedCredential.Username;
                PasswordTextBox.Password = _vaultService.DecryptPassword(selectedCredential.Password);
                CommentTextBox.Text = selectedCredential.Comment;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CredentialsListView.SelectedItem is Credential selectedCredential)
            {
                _vaultService.DeleteCredential(selectedCredential.Id);
                LoadCredentials(); // Reload the credentials after deletion.
            }
        }

        private void ClearFields()
        {
            ServiceTextBox.Text = string.Empty;
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Password = string.Empty;
            CommentTextBox.Text = string.Empty;
            PlainTextPasswordBox.Text = string.Empty;
            PlainTextPasswordBox.Visibility = Visibility.Collapsed;
            PasswordTextBox.Visibility = Visibility.Visible;
        }
    }
}

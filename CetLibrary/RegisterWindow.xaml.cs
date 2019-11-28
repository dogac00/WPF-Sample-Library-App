using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CetLibrary.Data;
using CetLibrary.Service;

namespace CetLibrary
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string surname = surnameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Password;
            string passwordAgain = passwordAgainTextBox.Password;
            Role role = (Role) roleComboBox.SelectionBoxItem;

            if (password != passwordAgain)
            {
                MessageBox.Show("Parolalar eşleşmiyor.");

                return;
            }

            CetUserService service = ServiceProvider.GetUserService();

            CetUser user = new CetUser
            {
                Name = name,
                Surname = surname,
                UserName = username,
                Role = role,
                Password = CetUserService.HashPassword(password),
                CreatedDate = DateTime.Now
            };

            var errors = DataValidator.Validate(user).ToList();

            if (errors.Any())
            {
                StringBuilder errorText = new StringBuilder();

                foreach (DataValidator.ErrorInfo errorInfo in errors)
                {
                    errorText.Append(errorInfo.Property + " is not valid.\r\n");
                    errorText.Append(errorInfo.Message + "\r\n\r\n");
                }

                MessageBox.Show(errorText.ToString());

                return;
            }

            service.Register(user);

            MainWindow window = new MainWindow(user);

            window.Show();

            this.Close();

            MessageBox.Show("Register Successful");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.roleComboBox.ItemsSource = new List<Role> { Role.User, Role.Admin, Role.SuperAdmin };
            this.roleComboBox.SelectedItem = Role.User;
        }
    }
}

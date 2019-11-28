using System;
using System.Collections.Generic;
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
    /// Interaction logic for UpdatePasswordWindow.xaml
    /// </summary>
    public partial class UpdatePasswordWindow : Window
    {
        private CetUser _user;

        public UpdatePasswordWindow(CetUser user)
        {
            InitializeComponent();

            this._user = user;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = this.oldPasswordTextBox.Password;
            string newPassword = this.newPasswordTextBox.Password;
            string newPasswordAgain = this.newPasswordAgainTextBox.Password;

            if (newPassword != newPasswordAgain)
            {
                MessageBox.Show("Girdiğiniz yeni parolalar eşleşmiyor.");

                return;
            }

            CetUserService service = ServiceProvider.GetUserService();

            if (!service.IsPasswordTrue(_user, oldPassword))
            {
                MessageBox.Show("Eski parola hatalı.");

                return;
            }

            service.UpdatePassword(_user, newPassword);

            MessageBox.Show("Şifreniz başarıyla güncellendi.");

            this.Close();
        }
    }
}

using CetLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CetLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CetUser _loginUser;

        public MainWindow(CetUser cetUser)
        { 
            InitializeComponent();

            _loginUser = cetUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updatePasswordButton.IsEnabled = _loginUser.Role.CanChangePassword;

            string loginText = $"Merhaba {_loginUser.GetFullName()}, Rol : {_loginUser.Role}";

            txtLoginUser.Text = loginText;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show( "Uygulamadan Çıkmak İstediğinize Emin misiniz?", "Onay", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void UpdatePasswordButton_OnClick(object sender, RoutedEventArgs e)
        {
            UpdatePasswordWindow window = new UpdatePasswordWindow(_loginUser);

            window.ShowDialog();
        }
    }
}

using CetLibrary.Service;
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

namespace CetLibrary
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        { 
            CetUserService cetUserService = ServiceProvider.GetUserService();
            
            var loginUser = cetUserService.Login(txtUserName.Text, txtPassword.Password);
            
            if (loginUser == null) 
            {
                MessageBox.Show("Hatalı Giriş Yaptınız");
            }
            else
            {
                MainWindow mainWindow = new MainWindow(loginUser);
                mainWindow.Show();
                
                this.Close();
            }
        }
    }
}

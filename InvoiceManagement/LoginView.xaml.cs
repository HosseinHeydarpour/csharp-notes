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

namespace InvoiceManagement
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }


        public void OnLoginButtonClicked(object sender, RoutedEventArgs e)
        {
            string passwordEntered = PasswordBox.Password;

            // This value can be null
           string? envPass = Environment.GetEnvironmentVariable("InvoiceManagement");

            if(envPass != null)
            {
                if(passwordEntered == envPass)
                {
                    MessageBox.Show("Entered Correct Password!");
                } else
                {
                    MessageBox.Show("Incorrect Password!");
                }
            } else
            {
                MessageBox.Show("Environemnt Vasriable Not Found!");
            }

      
        }


        public void OnPasswwordEntered(object sender, EventArgs e)
        {
            LoginButton.IsEnabled = !string.IsNullOrEmpty(PasswordBox.Password);
        }
    }
}

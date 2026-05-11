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

namespace CurrencyConverter_static
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lblCurrency.Content = "HELLO WORLD";

        }


        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            lblCurrency.Content = "Convert Button Cicked";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)  
        {
            lblCurrency.Content = "";
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) 
        { 
            
        }


        //private void MyClickEvent(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Custom");
        //}


        private void txtCurrency_TextChanged(object sender, TextChangedEventArgs e) {
            
            
        }
      

    }


   

    
}
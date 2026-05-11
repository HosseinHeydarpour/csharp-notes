using System.Data;
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

            BindCurrecny();

        }


        private void BindCurrecny()
        {
            DataTable dtCurrency = new DataTable();
            dtCurrency.Columns.Add("Text", typeof(string));
            dtCurrency.Columns.Add("Value", typeof(int));

            // Add rows in the Datatable with text and value
            dtCurrency.Rows.Add("--انتخاب--", 0);
            dtCurrency.Rows.Add("INR", 1);
            dtCurrency.Rows.Add("USD", 75);
            dtCurrency.Rows.Add("EUR", 85);
            dtCurrency.Rows.Add("SAR", 20);
            dtCurrency.Rows.Add("POUND", 5);
            dtCurrency.Rows.Add("DEM", 43);

            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;


            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        } 


        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            // Create the variable as ConvertedValue with double datatype to store currency converted value
            double ConvertedValue;

            // Check if the amount of text box is Null or Blank
            if(txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                // If amount of the text box is null or blank show this
                MessageBox.Show("لطفا مقدار ارز را وارد کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);

                // Set focus on text box after clicking on messagebox ok
                txtCurrency.Focus();

                return;
            } 
            // else if currecny from is not selected or it has default select state -- Select --
            else if(cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                // Show the Message
                MessageBox.Show("لطفا یک واحد ارز را انتخاب نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);

                // Set focus on combo box after clicking on messagebox ok
                cmbFromCurrency.Focus();

                return;
            }
            // else if currecny to is not selected or it has default select state -- Select --
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                // Show the Message
                MessageBox.Show("لطفا یک واحد ارز را انتخاب نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);

                // Set focus on combo box after clicking on messagebox ok
                cmbToCurrency.Focus();

                return;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)  
        {
            lblCurrency.Content = "";
            // Reset the comboboxes
            cmbFromCurrency.SelectedIndex = 0;
            cmbToCurrency.SelectedIndex = 0;
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
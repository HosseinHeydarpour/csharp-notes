using System.Data;
using System.Text;
using System.Text.RegularExpressions;
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

            // Check if amount textbox is empty
            if (string.IsNullOrWhiteSpace(txtCurrency.Text))
            {
                MessageBox.Show(
                    "لطفاً مبلغ ارز را وارد کنید.",
                    "خطا",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtCurrency.Focus();
                return;
            }
            // If source currency is not selected
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show(
                    "لطفاً ارز مبدأ را انتخاب کنید.",
                    "خطا",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                cmbFromCurrency.Focus();
                return;
            }

            // If destination currency is not selected
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show(
                    "لطفاً ارز مقصد را انتخاب کنید.",
                    "خطا",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                cmbToCurrency.Focus();
                return;
            }


            // Check if From and To Combobox selected values are the same
            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                // Amount textbox value set in ConvertedValue.
                // double.Parse is used for converting datatype String to Duble
                // Textbox text have string and Convertvalue is double data type
                ConvertedValue = double.Parse(txtCurrency.Text);
                // Show the label converted currecny and converted currecny name and ToSting("N3") - N3 is used to place 000 after the dot(.)
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
            else
            {
                //Calculation for currency converter is From Currency value multiply(*) 
                //With the amount textbox value and then that total divided(/) with To Currency value
                ConvertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) /
                                    double.Parse(cmbToCurrency.SelectedValue.ToString());

                //Show the label converted currency and converted currency name.
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Reset the comboboxes
            ClearControls();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        //private void MyClickEvent(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Custom");
        //}


        private void txtCurrency_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        // Reset all controls
        private void ClearControls()
        {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.Items.Count > 0)
            {
                cmbFromCurrency.SelectedIndex = 0;
            }
            if (cmbToCurrency.Items.Count > 0)
            {
                cmbToCurrency.SelectedIndex = 0;
            }
            lblCurrency.Content = "";
            txtCurrency.Focus();

        }

    }
    
}
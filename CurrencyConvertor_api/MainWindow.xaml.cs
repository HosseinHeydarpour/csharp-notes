using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
using static CurrencyConvertor_api.MainWindow;
using Newtonsoft.Json;

namespace CurrencyConvertor_api
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        Root val = new Root();

        public class Root // Root class is a Main Class. API returns Rates in a rates it return All Currency name with value
        {
            public Rate rates { get; set; } // get all record in rates and set in Rate Class as Currency Name Wise
            public long timestamp;
            public string license;

        }

        public class Rate // MAKE SURE api RETURN value names and where you want to store those names are the same. Like un API GET respinse
        {
            public double INR { get; set; }

            public double JPY { get; set; }

            public double USD { get; set; }

            public double NZD { get; set; }

            public double EUR { get; set; }

            public double CAD { get; set; }

            public double ISK { get; set; }

            public double PHP { get; set; }

            public double DKK { get; set; }

            public double CZK { get; set; }
        }









        public MainWindow()
        {
            InitializeComponent();

           ClearControls();

           GetValue();

        }

        public async void GetValue()
        {
            val = await GetData<Root>("https://openexchangerates.org/api/latest.json?app_id=cf9f7edef29c4afeb13f1786f5e6c1c6");

            BindCurrecny();
        }




        public static async Task<Root> GetData<T>(string url)
        {
            var myRoot = new Root();
            try
            {
                using (var client = new HttpClient()) // HttpClient class provides a base class for sendeing/recieving the HTTP request
                {
                    client.Timeout = TimeSpan.FromMinutes(1); //The timespan to wait before the request times out.
                    HttpResponseMessage respone = await client.GetAsync(url); // HttpResponseMessage is a way of returning a message
                    if(respone.StatusCode == System.Net.HttpStatusCode.OK) // Check API response status code ok
                    {
                        var ResponseString = await respone.Content.ReadAsStringAsync(); // Serialize the HTTP content to a string
                        // for JsonConvert you need to install newtonsoft nuget package
                        var ResponseObject = JsonConvert.DeserializeObject<Root>(ResponseString); // JsonConvert.DeserializeObject

                       // MessageBox.Show("Rates: " + ResponseString, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        return ResponseObject; // return api response
                    }
                    return myRoot;
                }
            }
            catch 
            {

                return myRoot;
            }
        }


       


        private void BindCurrecny()
        {
            DataTable dtCurrency = new DataTable();
            dtCurrency.Columns.Add("Text", typeof(string));
            dtCurrency.Columns.Add("Value", typeof(int));

            // Add rows in the api call with text and value
            dtCurrency.Rows.Add("--انتخاب--", 0);
            dtCurrency.Rows.Add("INR", val.rates.INR);
            dtCurrency.Rows.Add("USD", val.rates.USD);
            dtCurrency.Rows.Add("NZD", val.rates.NZD);
            dtCurrency.Rows.Add("JPY", val.rates.JPY);
            dtCurrency.Rows.Add("EUR", val.rates.EUR);
            dtCurrency.Rows.Add("CAD", val.rates.CAD);
            dtCurrency.Rows.Add("ISK", val.rates.ISK);
            dtCurrency.Rows.Add("PHP", val.rates.PHP);
            dtCurrency.Rows.Add("DKK", val.rates.DKK);
            dtCurrency.Rows.Add("CZK", val.rates.CZK);

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
                ConvertedValue = (double.Parse(cmbToCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) /
                                    double.Parse(cmbFromCurrency.SelectedValue.ToString());

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

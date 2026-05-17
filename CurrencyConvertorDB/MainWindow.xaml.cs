using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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


namespace CurrencyConverter_static
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection(); // Cretae Object for sqlConnection
        SqlCommand command = new SqlCommand();  // Create Object for SqlCommand
        SqlDataAdapter da = new SqlDataAdapter(); // CREATE Object for SqlDataAdapter

        private int CurrencyId = 0; // Declare CurrencyId with int DataType and Assign Value 0
        private double FromAmount = 0; // Declare FromAmount with Double Data type and assign value 0
        private double ToAmount = 0; // Declare ToAmount with double DataType and Assign value 0

        public MainWindow()
        {
            InitializeComponent();

            BindCurrecny();

        }



        // CRUD -- Create -- Read -- Update -- Delete
        public void MyCon()
        {
            String Conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; //  DB connection string
            con = new SqlConnection(Conn);
            con.Open(); // Connection Open
        }


        private void BindCurrecny()
        {
            //DataTable dtCurrency = new DataTable();
            //dtCurrency.Columns.Add("Text", typeof(string));
            //dtCurrency.Columns.Add("Value", typeof(int));

            //// Add rows in the Datatable with text and value
            //dtCurrency.Rows.Add("--انتخاب--", 0);
            //dtCurrency.Rows.Add("INR", 1);
            //dtCurrency.Rows.Add("USD", 75);
            //dtCurrency.Rows.Add("EUR", 85);
            //dtCurrency.Rows.Add("SAR", 20);
            //dtCurrency.Rows.Add("POUND", 5);
            //dtCurrency.Rows.Add("DEM", 43);


            MyCon();

            // Create an object for DataTable
            DataTable dt = new DataTable();

            // Write query to get data from Currency_Master table
            command = new SqlCommand("SELECT Id, CurrencyName from Currency_Master", con);

            // CommandType define which type of command we use to write a query
            command.CommandType = CommandType.Text;


            da = new SqlDataAdapter(command);

            da.Fill(dt);

            DataRow newRow = dt.NewRow();

            // Assign a value to Id column
            newRow["Id"] = 0;
            // Assign value to CurrencyName column
            newRow["CurrencyName"] = "--انتخاب ارز--";

            // Insert a new row in dt with the data at a 0 position
            dt.Rows.InsertAt(newRow, 0);

            // dt is not null and rows count greater than 0
            if (dt != null && dt.Rows.Count > 0) 
            {
                // Assign the datatable data to from currecny combobox using ItemsSource property
                cmbFromCurrency.ItemsSource = dt.DefaultView;

                // Assign the datatable data to from currecny combobox using ItemsSource property
                cmbToCurrency.ItemsSource = dt.DefaultView;
            }
            con.Close();

           
            cmbFromCurrency.DisplayMemberPath = "CurrencyName";
            cmbFromCurrency.SelectedValuePath = "Id";
            cmbFromCurrency.SelectedIndex = 0;


           
            cmbToCurrency.DisplayMemberPath = "CurrencyName";
            cmbToCurrency.SelectedValuePath = "Id";
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtAmount.Text == null || txtAmount.Text.Trim() == "")
                {
                    MessageBox.Show("لطفا مقدار را وارد نمایید", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtAmount.Focus();
                    return;
                } 
                else if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
                {
                    MessageBox.Show("لطفا نام ارز را وارد نمایید", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtCurrency.Focus();
                    return;
                } else
                {

                    // Code for update button. Here Check currencyId greater than 0 if it is we can go for update
                    if (CurrencyId > 0)
                    {
                        if(MessageBox.Show("از به روزرسانی ارز مورد نظر اطمینان دارید؟","Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) // Show Confirmation Message
                        {
                            MyCon();
                            DataTable dt = new DataTable();
                            command = 
                                new SqlCommand("UPDATE Currency_Master SET Amount = @Amount, CurrencyName = @CurrencyName WHERE Id = @Id", con); // Uodate Query Record udpate using ID

                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@Id",CurrencyId);
                            command.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            command.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            command.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("تعییرات با موفقیت صورت گرفت","Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    } else
                    {

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgvCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgvCurrency_SelectedCellsChanged(object sender, EventArgs e)
        {
            // your code here
        }

    }

}

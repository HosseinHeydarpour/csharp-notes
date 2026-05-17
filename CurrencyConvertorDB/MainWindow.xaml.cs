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

            GetData();

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
                else if (txtCurrencyName.Text == null || txtCurrencyName.Text.Trim() == "")
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
                    } else // Save Button Code
                    {
                        if(MessageBox.Show("از ذخیره ارز مورد نظر اطمینان دارید؟", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            MyCon();
                            command = new SqlCommand("INSERT INTO Currency_Master(Amount, CurrencyName) VALUES(@Amount, @CurrencyName)", con); // INSERT Query for Save data in the Table
                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            command.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            command.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("ارز مورد نظر با موفقیت ذخیره شد", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    ClearRates();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearRates();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

     

        private void dgvCurrency_SelectedCellsChanged(object sender, EventArgs e)
        {
           
            try
            {
                DataGrid grd = sender as DataGrid; // Create object for DataGrid
                DataRowView row_selected = grd.CurrentItem as DataRowView; // Create Object for DataRowView

                

                if (row_selected != null)  // row selected is not null
                {
                    
                    if (dgvCurrency.Items.Count > 0) // dgvCurrency items count greater than 0 
                    {
                        if (grd.SelectedCells.Count > 0) 
                        { 
                            CurrencyId = Int32.Parse(row_selected["Id"].ToString()); // Get selected row Id Col value and set

                            if (grd.SelectedCells[0].Column.DisplayIndex == 2) // DisplayIndex is 0 then it is the edit cell
                            {
                                txtAmount.Text = row_selected["Amount"].ToString(); // get selected row amount col value
                                txtCurrencyName.Text = row_selected["CurrencyName"].ToString(); // get selected row currencyname
                                btnSave.Content = "به روز رسانی";
                            }
                            if (grd.SelectedCells[0].Column.DisplayIndex == 3) // Display index is equal to one then it is delete cell
                            {
                                if (MessageBox.Show("آیا از حذف رکورد مطمئن هستید؟", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    MyCon();
                                    DataTable dt = new DataTable();
                                    command = new SqlCommand("DELETE FROM Currency_Master WHERE Id = @Id", con);  // Execute delete query for delete record from table using Id
                                    command.CommandType = CommandType.Text;
                                    command.Parameters.AddWithValue("@Id", CurrencyId);  // CurrencyId set in @Id param and send it in del statement
                                    command.ExecuteNonQuery();
                                    con.Close();

                                    MessageBox.Show("رکورد با موفقیت حذف شد","Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                    ClearRates();
                                }
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

      

        private void ClearRates() // This method is used to clear all the input which the user entered in Currency rates tab
        {
            try
            {
                txtAmount.Text = string.Empty;
                txtCurrencyName.Text = string.Empty;
                btnSave.Content = "ذخیره";
                GetData();
                CurrencyId = 0;
                BindCurrecny();
                txtAmount.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        /// <summary>
        /// Retrieves all records from the Currency_Master table
        /// and binds the result to the DataGrid (dgvCurrency).
        /// </summary>
        /// <remarks>
        /// This method:
        /// 1. Opens a database connection
        /// 2. Executes a SELECT query
        /// 3. Loads data into a DataTable
        /// 4. Binds the data to the DataGrid
        /// 5. Closes the database connection
        /// </remarks>
        private void GetData()
        {
            // Open database connection
            MyCon();

            // Create a DataTable to store retrieved records
            DataTable dt = new DataTable();

            // Define SQL query to fetch all records from Currency_Master table
            command = new SqlCommand("SELECT * FROM Currency_Master", con)
            {
                CommandType = CommandType.Text
            };

            // Execute query and fill DataTable using SqlDataAdapter
            da = new SqlDataAdapter(command); // The data adapter serves as a bridge between a data set and a data source for retriving and saving
            da.Fill(dt);

            // Bind data to DataGridView if records exist
            if (dt != null && dt.Rows.Count > 0) // dt is not null and rows count greater than 0
            {
                dgvCurrency.ItemsSource = dt.DefaultView; // Assign DataTable data to dgvCurrency using ItemSource Prop
            }
            else
            {
                // Clear DataGrid if no records are found
                dgvCurrency.ItemsSource = null;
            }

            // Close database connection
            con.Close();
        }

        private void dgvCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtCurrencyName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}

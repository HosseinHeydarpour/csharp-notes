using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ZooManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {

        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["ZooManagerApp.Properties.Settings.ZooDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            ShowZoos();
        }


        private void ShowZoos()
        {
            try
            {

                string query = "SELECT * FROM ZOO";
                // The SqlDataAdaptar can be imagined like an interface to make Tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);

                    // Whch information of the table in the database should be shown in our listbox?
                    listZoos.DisplayMemberPath = "Location";

                    // Whch value should be delivered, when an Item from our listbox is selected?
                    listZoos.SelectedValuePath = "Id";

                    // The reference to the data the listbox should populate
                    listZoos.ItemsSource = zooTable.DefaultView;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }




        }

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                
                ShowAnimalsOfAZoo();
           
        }

        private void ShowAnimalsOfAZoo()
        {
            try
            {
                string query = $"SELECT a.Id, a.Name FROM ZooAnimal za INNER JOIN Animal a ON za.AnimalId = a.Id WHERE za.ZooId = @ZooId";
                
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // The SqlDataAdaptar can be imagined like an interface to make Tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);


                    DataTable AnimalTable = new DataTable();
                    sqlDataAdapter.Fill(AnimalTable);

                    // Whch information of the table in the database should be shown in our listbox?
                    zoosAnimals.DisplayMemberPath = "Name";

                    // Whch value should be delivered, when an Item from our listbox is selected?
                    zoosAnimals.SelectedValuePath = "Id";

                    // The reference to the data the listbox should populate
                    zoosAnimals.ItemsSource = AnimalTable.DefaultView;
                }
            }
            catch (Exception ex) { }
        }
    }
}

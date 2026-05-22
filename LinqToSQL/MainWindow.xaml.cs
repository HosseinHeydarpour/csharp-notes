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
using System.Configuration;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        LinqToDataClassesDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();


            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.LinqDBConnectionString"].ConnectionString;

            dataContext = new LinqToDataClassesDataContext(connectionString);


            // 1. Clear everything in the correct order (Children first)
            dataContext.Students.DeleteAllOnSubmit(dataContext.Students);
            dataContext.Universities.DeleteAllOnSubmit(dataContext.Universities);
            dataContext.SubmitChanges();

            InsertUniversities();
            InsertStudents();

        }


        public void InsertUniversities()
        {

            dataContext.ExecuteCommand("DELETE FROM University");


            // We add this class by dragging university in linq to data classes dbml
            University yale = new University();
            yale.Name = "Yale";
            dataContext.Universities.InsertOnSubmit(yale);

            University harvard = new University();
            harvard.Name = "Harvard";
            dataContext.Universities.InsertOnSubmit(harvard);


            // submit changes
            dataContext.SubmitChanges();

            //MainDataGrid.ItemsSource = dataContext.Universities;
        }


        public void InsertStudents()

        {

            try
            {
                // 1. Clear Students FIRST if you need to clear the database
                dataContext.Students.DeleteAllOnSubmit(dataContext.Students);
                dataContext.SubmitChanges();

                // 2. Ensure your Universities exist before searching for them
                var yale = dataContext.Universities.FirstOrDefault(un => un.Name == "Yale");
                var harvard = dataContext.Universities.FirstOrDefault(un => un.Name == "Harvard");

                if (yale == null || harvard == null)
                {
                    throw new Exception("Universities not found in database.");
                }

                // 3. Create the list
                List<Student> newStudents = new List<Student>
        {
            new Student { Name = "Tony", Gender = "Male", University = yale },
            new Student { Name = "Leon", Gender = "Male", University = harvard },
            new Student { Name = "Ralf", Gender = "Male", University = yale },
            new Student { Name = "Pam", Gender = "Female", University = harvard }
        };

                dataContext.Students.InsertAllOnSubmit(newStudents);
                dataContext.SubmitChanges();

                // 4. Update the UI
                MainDataGrid.ItemsSource = dataContext.Students;
            }
            catch (Exception ex)
            {
                // Use a MessageBox or Debugger to see why it's failing
                System.Windows.MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

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
using WpfDemo.Data;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Person Person = new Person
        {
            Name = "Hossein",
            Age = 28
        };


        public MainWindow()
        {
            InitializeComponent();

            // Sets the DataContext for the window, which acts as the default data source
            // for all data bindings in this view. UI elements can bind to properties
            // of the Person object (e.g., {Binding Name}) without explicitly referencing it.
            this.DataContext = Person;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World!");
        }
    }
}
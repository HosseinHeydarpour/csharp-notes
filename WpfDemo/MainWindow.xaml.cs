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

        public List<Person> People = new List<Person>()
        {
            new Person { Name = "Hossein", Age = 28 },
            new Person { Name = "Sara", Age = 25 },
            new Person { Name = "Ali",  Age = 32 },
            new Person { Name = "Maryam", Age = 29 },
            new Person { Name = "Reza", Age = 34 },
            new Person { Name = "Fatemeh", Age = 27 }
        };


        public MainWindow()
        {
            InitializeComponent();

            // This takes an IENUM like a List<>
            ListBoxNames.ItemsSource = People;
        }

        
    }
}
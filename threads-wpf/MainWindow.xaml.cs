using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace threads_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(MainWindow),
            new PropertyMetadata(OnHtmlChanged));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId}");
                HttpClient webClient = new HttpClient();
                string html = webClient.GetStringAsync("https://zoomit.ir").Result;


                // This will have error without using dispathcer because it belongs to the UI thread we have to use dispatcher
                MyButton.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} owns my button");
                    MyButton.Content = "Done";
                });

            });




            // This will freeze the main thread and the UI will freeze
            //HttpClient webClient = new HttpClient();
            //string html = webClient.GetStringAsync("https://zoomit.ir").Result;
            //MyButton.Content = "Done";
        }


        // This way is better
        private async void MyButton_Click2(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} before awaiting task");
            var myHtml="";
            await Task.Run(async() =>
            {
                Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId}");
                HttpClient webClient = new HttpClient();
                myHtml = webClient.GetStringAsync("https://google.com").Result;
            });
            Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} after awaiting task");
            MyButton.Content = "Done Downloading";
            myWebBrowser.SetValue(HtmlProperty, myHtml);
        }


        static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = d as WebBrowser;
            if(webBrowser != null)
            {
                webBrowser.NavigateToString(e.NewValue as string);
            }
        }
}}

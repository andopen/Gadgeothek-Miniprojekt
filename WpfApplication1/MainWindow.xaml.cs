using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public String serverUrl = ConfigurationSettings.AppSettings.Get("server");

        public MainWindow()
        {
            InitializeComponent();

            LibraryAdminService lib = new LibraryAdminService(serverUrl);

            List<Loan> loans = lib.GetAllLoans();

           // dgLoans.ItemsSource = loans;
           

            List<TestVO> list1 = new List<TestVO>();
            list1.Add(new TestVO() { KundenNr = 1, Name = "John Doe", Reservation = "iphone 7", Ausleihen = "iphone, blablub" });


        }
        public class TestVO
        {
            public int KundenNr { get; set; }

            public string Name { get; set; }

            public string Reservation { get; set; }

            public string Ausleihen { get; set; }

        }
    }
}

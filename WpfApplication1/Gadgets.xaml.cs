using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Gadgets.xaml
    /// </summary>
    public partial class Gadgets : UserControl
    {
        public Gadgets()
        {
            InitializeComponent();

            LibraryAdminService lib = new LibraryAdminService("http://mge7.dev.ifs.hsr.ch/");

            List<Loan> gadgets = lib.GetAllLoans();

            dgGadgets.ItemsSource = gadgets;

            Regex regex = new Regex("(?<WEAKDAY>Mon|Tue|Wed|Thu|Fri|Sat|Sun) (?<MONTH>[0-9]{1,2})/(?<DAY>[0-9]{1,2})/(?<YEAR>[0-9]*)");

        }

        public ObservableCollection<Gadget> GadgetItems { get; set; }

        private void AddGadget_Click(object sender, RoutedEventArgs e)
        {
            var gadgetWindow = new AddGadget();
            var dialog = gadgetWindow.ShowDialog();

            if (dialog == true)
            {
                Console.WriteLine("Neues Gadget erfasst");
            }
            else
            {
                Console.WriteLine("Alles ist abgebrochen");

            }
        }

       

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}

using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Gadgets.xaml
    /// </summary>
    public partial class Kunde : UserControl
    {


        public ObservableCollection<Loan> loans { get; set; }


        public Kunde()
        {
            InitializeComponent();
            var url = "http://mge7.dev.ifs.hsr.ch/";

            LibraryAdminService lib = new LibraryAdminService(url);

            loans = new ObservableCollection<Loan>(lib.GetAllLoans());

           
            // web socket connection to listen to changes:
            var client = new ch.hsr.wpf.gadgeothek.websocket.WebSocketClient(url);
            client.NotificationReceived += (o, e) =>
            {
                // demonstrate how these updates could be further used
                if (e.Notification.Target == typeof(Loan).Name.ToLower())
                {
                    loans = new ObservableCollection<Loan>(lib.GetAllLoans());
                }
            };

            // spawn a new background thread in which the websocket client listens to notifications from the server
            client.ListenAsync();


            DataContext = this;
            
        }
    }
}

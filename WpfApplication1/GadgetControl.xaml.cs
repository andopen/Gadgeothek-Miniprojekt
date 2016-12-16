using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für GadgetControl.xaml
    /// </summary>
    public partial class GadgetControl : UserControl
    {
        public ObservableCollection<Gadget> GadgetItem { get; set; }

        public String url = "http://mge7.dev.ifs.hsr.ch/";

        public GadgetControl()
        {
            InitializeComponent();
            GadgetItem = new ObservableCollection<Gadget>();
            setData();
            initWebSocket();
            DataContext = this;
        }

        public void setData()
        {
            GadgetItem.Clear();
            List<Gadget> gadgetList = new LibraryAdminService(url).GetAllGadgets();
            foreach (Gadget gadget in gadgetList)
            {
                GadgetItem.Add(gadget);
            }
        }

        public void initWebSocket()
        {
            // web socket connection to listen to changes:
            var client = new ch.hsr.wpf.gadgeothek.websocket.WebSocketClient(url);
            client.NotificationReceived += (o, e) =>
            {
                // demonstrate how these updates could be further used
                if (e.Notification.Target == typeof(Gadget).Name.ToLower())
                {
                    setData();
                }
            };
            // spawn a new background thread in which the websocket client listens to notifications from the server
            client.ListenAsync();
        }

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

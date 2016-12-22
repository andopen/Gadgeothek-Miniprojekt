using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Configuration;
using System;

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für LoanControl.xaml
    /// </summary>
    public partial class LoanControl : UserControl
    {
        public ObservableCollection<Loan> LoanItem { get; set; }

        public String serverUrl = ConfigurationSettings.AppSettings.Get("server");

        public LoanControl()
        {
          
            Console.WriteLine("serverURL:" + serverUrl);

            InitializeComponent();
            LoanItem = new ObservableCollection<Loan>();
            setData();
            initWebSocket();
            DataContext = this;
        }

        public void setData()
        {
            LoanItem.Clear();
            List<Loan> loanList = new LibraryAdminService(serverUrl).GetAllLoans();
            foreach(Loan loan in loanList)
            {
                if (loan.IsLent)
                {
                    LoanItem.Add(loan);
                }
            }            
        }

        public void initWebSocket()
        {
            // web socket connection to listen to changes:
            var client = new ch.hsr.wpf.gadgeothek.websocket.WebSocketClient(serverUrl);
            client.NotificationReceived += (o, e) =>
            {
                // demonstrate how these updates could be further used
                if (e.Notification.Target == typeof(Loan).Name.ToLower())
                {
                    setData();
                }
            };
            // spawn a new background thread in which the websocket client listens to notifications from the server
            client.ListenAsync();
        }
    }
}

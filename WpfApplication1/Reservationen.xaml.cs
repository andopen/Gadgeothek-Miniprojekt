﻿using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Reservationen.xaml
    /// </summary>
    public partial class Reservationen : UserControl
    {
        public Reservationen()
        {
            InitializeComponent();
            LibraryAdminService library = new LibraryAdminService("http://mge7.dev.ifs.hsr.ch/");
            List<Reservation> reserved = library.GetAllReservations();

            ReservationList.ItemsSource = reserved;
        }
    }
}

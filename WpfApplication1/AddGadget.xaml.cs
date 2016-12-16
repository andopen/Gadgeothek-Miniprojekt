using ch.hsr.wpf.gadgeothek.domain;
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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for AddGadget.xaml
    /// </summary>
    public partial class AddGadget : Window
    {
        public AddGadget()
        {
            InitializeComponent();

            
        }
        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            if (NamensEingabe.Equals(""))
            {
                MessageBox.Show("Bitte Namen eingeben");
            } else if (Hersteller.Equals(""))
            {
                MessageBox.Show("Bitte Hersteller eingeben");
            } else  if (Condition.Equals(""))
            {
                MessageBox.Show("Bitte Zusand eingeben");
            }
            else
            {
                Gadget newestGadget = new Gadget("");
                newestGadget.Name = NamensEingabe.ToString();
                newestGadget.Manufacturer = Hersteller.ToString();
                if (Condition.Equals("New"))
                {
                    // TODO Condition anpassen
                    newestGadget.Condition = 
                }
            }
            
        }
        private List<Key> AllowedKeys = new List<Key>()
        {
            Key.D0,
            Key.D1,
            Key.D2,
            Key.D3,
            Key.D4,
            Key.D5,
            Key.D6,
            Key.D7,
            Key.D8,
            Key.D9,
            Key.Back,
            Key.Decimal //TODO überprüfen ob Punkt bsp. 20.50
        };

        private void Preis_KeyDown(object sender, KeyEventArgs e)
        {
 
                if (!AllowedKeys.Contains(e.Key))
                {
                    e.Handled = true;
                    return;
                }

        }

    }
}

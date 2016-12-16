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
        public Gadget EditedGadget { get; set; }

        public AddGadget()
        {
            InitializeComponent();

            EditedGadget = new Gadget("neues Gadget");          

            DataContext = this;
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditedGadget.Name.Equals(""))
            {
                MessageBox.Show("Bitte Namen eingeben");
            }
            else if (EditedGadget.Manufacturer.Equals(""))
            {
                MessageBox.Show("Bitte Hersteller eingeben");
            }
            else
            {
                //Gadget newestGadget = new Gadget("");
                //newestGadget.Name = NamensEingabe.Text;
                //newestGadget.Manufacturer = Hersteller.Text;

                // Properties von EditedGadget werden via Data Binding automatisch zur Verfügung gestellt

                //// TODO Condition anpassen
                EditedGadget.Condition = (ch.hsr.wpf.gadgeothek.domain.Condition)Enum.Parse(typeof(ch.hsr.wpf.gadgeothek.domain.Condition), GadgetCondition.Text);

                DialogResult = true;
            }
        }

        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
           
            DialogResult = false;
            
        }
        private List<Key> AllowedKeys = new List<Key>()
        {
            Key.NumPad0,
            Key.NumPad1,
            Key.NumPad2,
            Key.NumPad3,
            Key.NumPad4,
            Key.NumPad5,
            Key.NumPad6,
            Key.NumPad7,
            Key.NumPad8,
            Key.NumPad9,
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

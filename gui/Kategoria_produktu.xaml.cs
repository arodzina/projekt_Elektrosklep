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

namespace gui
{
    /// <summary>
    /// Logika interakcji dla klasy Kategoria_produktu.xaml
    /// </summary>
    public partial class Kategoria_produktu : Window
    {
        public Kategoria_produktu()
        {
            InitializeComponent();
        }
        private void ClkLaptop(object sender, RoutedEventArgs e)
        {
            ListaProduktow laptopy = new("Laptopy");
            laptopy.Show();
            this.Hide();
        }
        private void ClkTablet(object sender, RoutedEventArgs e)
        {
            ListaProduktow tablety = new("Tablety");
            tablety.Show();
            this.Hide();
        }
        private void ClkSmart(object sender, RoutedEventArgs e)
        {
            ListaProduktow telefony = new("Telefony");
            telefony.Show();
            this.Hide();
        }

    }
}

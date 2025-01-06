using Elektrosklep;
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
    /// Logika interakcji dla klasy Koszyk_produktów.xaml
    /// </summary>
    public partial class Koszyk_produktów : Window
    {
        private Koszyk _koszyk;
        public Koszyk_produktów(Koszyk koszyk)
        {
            
            InitializeComponent();
            _koszyk = koszyk;
            DataContext = _koszyk;
            OdswiezListe();
        }
        private void OdswiezListe()
        {
            LstBKoszyk.ItemsSource = null;
            LstBKoszyk.ItemsSource = _koszyk.produkty;
        }
        private void ClkKupujdalej(object sender, RoutedEventArgs e)
        {
            this.Close();
            Kategoria_produktu kategoria_Produktu = new();
            kategoria_Produktu.Show();
        }
        private void ClkUsun(object sender, RoutedEventArgs e)
        {
            if (LstBKoszyk.SelectedItem is Elektrosklep.Produkt wybranyProdukt)
            {
                _koszyk.UsunProdukt(wybranyProdukt);
                OdswiezListe();
            }
        }
    }
}

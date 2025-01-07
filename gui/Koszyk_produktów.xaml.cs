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
            _koszyk.ZastosujRabat();
            TxtCenaPrzed.Text = $"{_koszyk.CalkowitaCenaPrzedRabatem():c}";
            TxtRabat.Text = $"{_koszyk.ObliczWartoscRabatu():c}";
            TxtCenaPo.Text = $"{_koszyk.ObliczCalkowitaCene():c}";
        }
        private void ClkKupujdalej(object sender, RoutedEventArgs e)
        {
            this.Close();
            Kategoria_produktu kategoria_Produktu = new(_koszyk, "user");
            kategoria_Produktu.Show();
        }

        private void ClkUsun(object sender, RoutedEventArgs e)
        {
            if (LstBKoszyk.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano żadnego produktu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            List<Produkt> lista = new List<Produkt>();
            foreach(Produkt item in LstBKoszyk.SelectedItems)
            {
                lista.Add(item);
            }
            foreach(Produkt p in lista)
            {
                _koszyk.UsunProdukt(p);
            }
        
            OdswiezListe();
        }
        private void btnZwiekszLiczbe_Click(object sender, RoutedEventArgs e)
        {
            Produkt p = LstBKoszyk.SelectedItem as Produkt;
            if(LstBKoszyk.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano żadnego produktu", "Błąd!",  MessageBoxButton.OK, MessageBoxImage.Warning);
                return;

            }
            Produkt p2 = (Produkt)p.Clone();
            _koszyk.DodajProdukt(p2);
            OdswiezListe();
        }


    }
    
}

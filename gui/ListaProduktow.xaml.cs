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
    /// Logika interakcji dla klasy ListaProduktow.xaml
    /// </summary>
    public partial class ListaProduktow : Window
    {
        public ListaProduktow(string kategoria)
        {
            InitializeComponent();
           
            // Ustawienie nagłówka z nazwą kategorii
            lblKategoria.Content = $"Produkty z kategorii: {kategoria}";

            // Załadowanie listy produktów na podstawie kategorii
            List<string> produkty = PobierzProdukty(kategoria);
            listBoxProdukty.ItemsSource = produkty;
        }

        // Metoda zwracająca listę produktów na podstawie kategorii
        private List<string> PobierzProdukty(string kategoria)
        {
            if (kategoria == "Laptopy")
                return new List<string> { "Laptop Dell XPS", "Laptop HP Spectre", "Laptop MacBook Air" };
            else if (kategoria == "Telefony")
                return new List<string> { "iPhone 14", "Samsung Galaxy S23", "Xiaomi Mi 13" };
            else if (kategoria == "Tablety")
                return new List<string> { "iPad Pro", "Samsung Galaxy Tab", "Microsoft Surface Pro" };
            else
                return new List<string>();
        }
        
        // Obsługa przycisku powrotu
        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            // Powrót do menu sklepu
            MenuSklepu menu = new MenuSklepu();
            menu.Show();
            this.Close();
        }
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            foreach(ListBoxItem item in listBoxProdukty.SelectedItems)
            {
                //koszyk.DodajProdukt(item); coś trzeba zrobić żeby się dodawało do koszyka
            }
            
        }
    }
}
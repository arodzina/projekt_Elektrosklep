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
    /// Logika interakcji dla klasy MenuSklepu.xaml
    /// </summary>
    public partial class MenuSklepu : Window
    {
        // Zmienna do przechowywania wybranej kategorii
        private string wybranaKategoria;

        public MenuSklepu()
        {
            InitializeComponent();
        }

        // Obsługa przycisku "Laptopy"
        private void btnLaptopy_Click(object sender, RoutedEventArgs e)
        {
            wybranaKategoria = "Laptopy";
            OtworzListeProduktow();
        }

        // Obsługa przycisku "Telefony"
        private void btnTelefony_Click(object sender, RoutedEventArgs e)
        {
            wybranaKategoria = "Telefony";
            OtworzListeProduktow();
        }

        // Obsługa przycisku "Tablety"
        private void btnTablety_Click(object sender, RoutedEventArgs e)
        {
            wybranaKategoria = "Tablety";
            OtworzListeProduktow();
        }

        // Metoda do otwarcia okna z listą produktów
        private void OtworzListeProduktow()
        {
            ListaProduktow lista = new ListaProduktow(wybranaKategoria);
            lista.Show();
            this.Hide();
        }
    }

}


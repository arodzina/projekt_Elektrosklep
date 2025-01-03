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
        private string kategoria;

        public ListaProduktow(string kategoria)
        {
            this.kategoria = kategoria;
            InitializeComponent();
        }

        private void ListaProduktow_Load(object sender, RoutedEventArgs e)
        {
            lblKategoria.Content = "Produkty w kategorii: " + kategoria;

            // Przykładowe produkty
            listBoxProdukty.Items.Clear();
            if (kategoria == "Laptopy")
            {
                listBoxProdukty.Items.Add("Laptop 1 - 3000 zł");
                listBoxProdukty.Items.Add("Laptop 2 - 2500 zł");
            }
            else if (kategoria == "Telefony")
            {
                listBoxProdukty.Items.Add("Telefon 1 - 1200 zł");
                listBoxProdukty.Items.Add("Telefon 2 - 1500 zł");
            }
            else if (kategoria == "Tablety")
            {
                listBoxProdukty.Items.Add("Tablet 1 - 800 zł");
                listBoxProdukty.Items.Add("Tablet 2 - 1000 zł");
            }
        }

        private void btnDodajDoKoszyka_Click(object sender, RoutedEventArgs e)
        {
            // Logika dodawania do koszyka
            MessageBox.Show("Dodano do koszyka!");
        }
    }
}
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
        public MenuSklepu()
        {
            InitializeComponent();
        }
        private void btnLaptopy_Click(object sender, RoutedEventArgs e)
        {
            ListaProduktow lista = new ListaProduktow("Laptopy");
            lista.Show();
            this.Hide();
        }

        private void btnTelefony_Click(object sender, RoutedEventArgs e)
        {
            ListaProduktow lista = new ListaProduktow("Telefony");
            lista.Show();
            this.Hide();
        }

        private void btnTablety_Click(object sender, RoutedEventArgs e)
        {
            ListaProduktow lista = new ListaProduktow("Tablety");
            lista.Show();
            this.Hide();
        }
    }
}


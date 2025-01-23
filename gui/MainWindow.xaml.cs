using Elektrosklep;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gui
{
    public partial class MainWindow : Window
    {
    
        public Magazyn magazyn = new Magazyn();
        public Koszyk Koszyk { get; private set; }
        
        public MainWindow()
        {
            InitializeComponent();
            Koszyk = new();
            Koszyk.produkty = new();
            magazyn = (Magazyn)Magazyn.OdczytXml("magazyn.xml");
        }
        private void btnZalogujClick(object sender, RoutedEventArgs e)
        {
            OknoLogowania logowanie = new OknoLogowania(Koszyk, "user");
            logowanie.Show();
            this.Hide();
        }
        private void btnGoscClick(object sender, RoutedEventArgs e)
        {
            Kategoria_produktu menu = new Kategoria_produktu(Koszyk, "user");
            menu.Show();
            this.Hide();
        }
        private void MenuItem_Zaloguj_Click(object sender, RoutedEventArgs e)
        {
            OknoLogowania logowanie = new OknoLogowania(Koszyk, "admin");
            logowanie.Show();
            this.Hide();
        }
        private void btnRabatClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Przy zakupie produktów z każdej z trzech kategorii przyznawany jest rabat w wysokości 10% na całe zamówienie!","RABAT", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void MenuItem_Wyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

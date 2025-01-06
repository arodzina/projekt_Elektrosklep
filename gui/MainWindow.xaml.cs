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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Magazyn magazyn = new Magazyn();
        public Koszyk koszyk = new();
        public MainWindow()
        {
            magazyn = (Magazyn)Magazyn.OdczytXml("magazyn.xml");
            
            InitializeComponent();
        }
        private void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            OknoLogowania logowanie = new OknoLogowania();
            logowanie.Show();
            this.Hide();
        }

        private void btnZarejestruj_Click(object sender, RoutedEventArgs e)
        {
            OknoRejestracji rejestracja = new OknoRejestracji();
            rejestracja.Show();
            this.Hide();
        }

        private void btnGosc_Click(object sender, RoutedEventArgs e)
        {
            Kategoria_produktu menu = new Kategoria_produktu();
            menu.Show();
            this.Hide();
        }
    }
}
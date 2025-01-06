using Elektrosklep;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace gui
{
    public partial class Specyfikacja : Window

    {
        private Koszyk _koszyk;
        private Produkt _produkt;

        public Specyfikacja(Produkt produkt, string nazwa, string cena, string opis, Dictionary<string, string> dodatkowePola, Koszyk koszyk)
        {
            
            InitializeComponent();
            _koszyk = koszyk;
            lblNazwa.Text = nazwa;
            lblCena.Text = $"{cena} PLN";
            lblOpis.Text = opis;
            _produkt = produkt;
            // Dodaj dynamicznie dodatkowe pola
            foreach (var pole in dodatkowePola)
            {
                stackDodatkowePola.Children.Add(new TextBlock
                {
                    Text = $"{pole.Key}:",
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 10, 0, 0)
                });

                stackDodatkowePola.Children.Add(new TextBlock
                {
                    Text = pole.Value,
                    Margin = new Thickness(0, 0, 0, 10)
                });
            }
        }
        private void btnDodajDoKoszyka_Click(object sender, RoutedEventArgs e)
        {
            
            string nazwaProduktu = lblNazwa.Text;
            _koszyk.DodajProdukt(_produkt);
            //MessageBox.Show($"Dodano '{nazwaProduktu}' do koszyka!", "Koszyk", MessageBoxButton.OK, MessageBoxImage.Information);
            Koszyk_produktów k = new(_koszyk);
            k.Show();
            this.Close();
        }
    }
}

using Elektrosklep;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace gui
{
    public partial class Specyfikacja : Window

    {
        
        public Specyfikacja(string nazwa, string cena, string opis, Dictionary<string, string> dodatkowePola)
        {
            InitializeComponent();
            
            lblNazwa.Text = nazwa;
            lblCena.Text = $"{cena} PLN";
            lblOpis.Text = opis;

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
            //koszyk.DodajProdukt(nazwaProduktu);
            MessageBox.Show($"Dodano '{nazwaProduktu}' do koszyka!", "Koszyk", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

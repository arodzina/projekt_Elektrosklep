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

using System.Windows;

namespace gui
{
    public partial class Produkt : Window
    {
        public Produkt(string nazwa, string cena, string opis, string procesor, string ram, string dysk, string kartaGraficzna)
        {
            InitializeComponent();
            lblNazwa.Text = nazwa;
            lblCena.Text = $"{cena} PLN";
            lblOpis.Text = opis;
            lblProcesor.Text = procesor;
            lblRAM.Text = $"{ram} GB";
            lblDysk.Text = $"{dysk} GB";
            lblKartaGraficzna.Text = kartaGraficzna;
        }
    }
}

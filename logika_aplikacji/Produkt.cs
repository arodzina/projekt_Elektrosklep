using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elektrosklep
{
    // Klasa bazowa
    public abstract class Produkt : IComparable<Produkt>, IEquatable<Produkt>, ICloneable
    {
        // Właściwości produktu
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public string Opis { get; set; }
        public int Id { get; set; }
        public double Rabat { get; set; }

        // Konstruktor
        public Produkt(int id, string nazwa, double cena, string opis)
        {
            Id = id;
            Nazwa = nazwa;
            Cena = cena;
            Opis = opis;
        }

        public double CenaPoRabacie()
        {
            return Cena * (1 - Rabat / 100); // Zwraca cenę po rabacie
        }

        // Metoda do zapisu produktu do pliku XML
        public void ZapiszDoPliku(string sciezka)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Produkt));
                using (StreamWriter writer = new StreamWriter(sciezka))
                {
                    serializer.Serialize(writer, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd zapisu do pliku: {ex.Message}");
            }
        }

        // Metoda porównująca produkty po cenie (IComparable)
        public int CompareTo(Produkt other)
        {
            if (other == null) return 1;
            return Cena.CompareTo(other.Cena);
        }

        // Metoda porównująca produkty (IEquatable)
        public bool Equals(Produkt other)
        {
            if (other == null) return false;
            return Id == other.Id;
        }

        // Metoda do klonowania produktu (ICloneable)
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        // ToString() do wyświetlania danych produktu
        public override string ToString()
        {
            return $"{Nazwa}, Cena: {Cena:c}, Opis: {Opis}";
        }

        // Abstrakcyjna metoda, która zostanie zaimplementowana w klasach dziedziczących
        public abstract void WyswietlSzczegoly();
    }
}


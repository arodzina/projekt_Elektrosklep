using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
        [XmlAttribute]
        [Key]
        public int Id { get;  set; }  // Zmieniamy dostęp do Id na tylko do odczytu
        public double Rabat { get; set; }

        // Statyczna zmienna do śledzenia ostatniego użytego Id
        private static int ostatnieId = 0;

        // Konstruktor
        public Produkt(string nazwa, double cena, string opis)
        {
            // Przypisanie Id na podstawie ostatniego użytego Id
            ostatnieId++;
            Id = ostatnieId;
            Nazwa = nazwa;
            Cena = cena;
            Opis = opis;
        }
        public Produkt() { }
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

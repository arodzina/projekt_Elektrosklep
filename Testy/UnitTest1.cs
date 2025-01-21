using Elektrosklep;

namespace Testy
{
    [TestClass]
    public class UnitTest1
    {
        //sprawdzenie czy nazwa nowego laptopa dodala sie prawidlowo
        [TestMethod]
        public void TestNazwaLaptopa()
        {

            //arrange
            string exppectedNAME = "Laptop testowy";
            //action
            Laptop laptop = new Laptop("Laptop testowy", 2000, "opis", "procesor", 32, 256, "karta graficzna");
            //assert
            Assert.AreEqual(exppectedNAME, laptop.Nazwa);
        }
        //sprawdzenie, czy stortowanie po cenie dziala poprawnie
        [TestMethod]
        public void TestCompareTo()
        {
            Tablet t1 = new Tablet("tablet test 1", 1000, "opis1", 23.6, "Android", true);
            Tablet t2 = new Tablet("tablet test 2", 1087, "opis2", 20.6, "Android", true);
            Assert.AreEqual(t1.CompareTo(t2), -1);

        }
        //sprawdzenie, czy metoda SprawdzDostepnosc wyrzuci odpowiedni wyjatek
        [TestMethod]
        [ExpectedException(typeof(ProduktNotFoundException))]
        public void wyjatek()
        {
            Magazyn m1 = new();
            m1.SprawdzDostepnosc(1);
           
        }
    }
}
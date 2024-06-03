using KsiazkaAdresowaAPI;
using Xunit;

namespace KsiazkaAdresowaAPITests
{
    public class KsiazkaAdresowaTests
    {
        [Fact]
        public void Add_ShouldAddAddress()
        {
            // Arrange
            var ksiazkaAdresowa = new KsiazkaAdresowa();
            var address = new Adres { Imie = "Jan", Nazwisko = "Kowalski", Ulica = "Main St", Miasto = "Warsaw", Wojewudztwo = "Mazowieckie", Kod_Pocztowy = "00-001" };

            // Act
            ksiazkaAdresowa.Add(address);

            // Assert
            var result = ksiazkaAdresowa.GetLatest();
            Assert.NotNull(result);
            Assert.Equal(address.Imie, result.Imie);
        }

        [Fact]
        public void GetByCity_ShouldReturnAddressesInCity()
        {
            // Arrange
            var ksiazkaAdresowa = new KsiazkaAdresowa();
            var address1 = new Adres { Imie = "Jan", Nazwisko = "Kowalski", Ulica = "Main St", Miasto = "Warsaw", Wojewudztwo = "Mazowieckie", Kod_Pocztowy = "00-001" };
            var address2 = new Adres { Imie = "Anna", Nazwisko = "Nowak", Ulica = "Second St", Miasto = "Warsaw", Wojewudztwo = "Mazowieckie", Kod_Pocztowy = "00-002" };
            ksiazkaAdresowa.Add(address1);
            ksiazkaAdresowa.Add(address2);

            // Act
            var result = ksiazkaAdresowa.GetByCity("Warsaw");

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetLatest_ShouldReturnLatestAddress()
        {
            // Arrange
            var ksiazkaAdresowa = new KsiazkaAdresowa();
            var address1 = new Adres { Imie = "Jan", Nazwisko = "Kowalski", Ulica = "Main St", Miasto = "Warsaw", Wojewudztwo = "Mazowieckie", Kod_Pocztowy = "00-001" };
            var address2 = new Adres { Imie = "Anna", Nazwisko = "Nowak", Ulica = "Second St", Miasto = "Warsaw", Wojewudztwo = "Mazowieckie", Kod_Pocztowy = "00-002" };
            ksiazkaAdresowa.Add(address1);
            ksiazkaAdresowa.Add(address2);

            // Act
            var result = ksiazkaAdresowa.GetLatest();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(address2.Imie, result.Imie);
        }
    }
}
namespace KsiazkaAdresowaAPI
{
    public class Adres
    {
        public int Id { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Ulica { get; set; }
        public string? Miasto { get; set; }
        public string? Wojewudztwo { get; set; }
        public string? Kod_Pocztowy { get; set; }
    }


public class KsiazkaAdresowa
    {
        private readonly List<Adres> _ksiazkaAdresowa;

        public KsiazkaAdresowa()
        {
            _ksiazkaAdresowa = new List<Adres>();
        }
        

        public IEnumerable<Adres> GetByCity(string city) =>
            _ksiazkaAdresowa.Where(ab => ab.Miasto.ToLower() == city.ToLower());


        public Adres? GetLatest() =>
            _ksiazkaAdresowa.Any() ? _ksiazkaAdresowa[^1] : null;


        public void Add(Adres addressBook)
        {   
            addressBook.Id = _ksiazkaAdresowa.Count > 0 ? _ksiazkaAdresowa.Max(ab => ab.Id) + 1 : 1;
            _ksiazkaAdresowa.Add(addressBook);
        }
    }

}
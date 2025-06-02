namespace RentalManagement.API.Models
{
    /// <summary>
    /// Reprezentuje mieszkanie dostępne do wynajęcia.
    /// Zawiera informacje o adresie, piętrze i innych cechach
    /// </summary>
    public class Apartment
    {
        public int Id { get; set; }

        /// <summary>
        /// Adres mieszkania.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        ///  Piętro, na którym znajduje się mieszkanie (0 = parter)
        /// </summary>
        public int Floor { get; set; } = 0;

        /// <summary>
        /// Liczba pokoi w mieszkaniu.
        /// </summary>
        public int RoomCount { get; set; }

        /// <summary>
        /// Cena wynajęcia mieszkania.
        /// </summary>
        public decimal RentAmount { get; set; }
    }
}

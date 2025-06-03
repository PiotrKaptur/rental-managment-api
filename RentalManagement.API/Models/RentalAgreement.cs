namespace RentalManagement.API.Models
{
    /// <summary>
    /// Reprezentuje umowy wynajęcia
    /// </summary>
    public class RentalAgreement
    {
        public int Id { get; set; }

        /// <summary>
        /// Data rozpoczęcia umowy (wartość domyślna ustawiona na datę bieżącą)
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Data zakonczenia umowy.
        /// Jeśli null - oznacza umowę bezterminową.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Miesięczna kwota wynajmu.
        /// </summary>
        public decimal MonthlyPayment { get; set; } = 0.0m;

        /// <summary>
        /// Kod waluty w której naliczana jest opłata. Domyślnie PLN. 
        /// </summary>
        public string Currency { get; set; } = "PLN";

        /// <summary>
        /// Id lokatora.
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        /// Lokator przypisany do umowy.
        /// </summary>
        public Tenant? Tenant { get; set; }

        /// <summary>
        /// Id mieszkania.
        /// </summary>
        public int ApartmentId { get; set; }

        /// <summary>
        /// Miezkanie przypisane do umowy.
        /// </summary>
        public Apartment? Apartment { get; set; }
    }
}

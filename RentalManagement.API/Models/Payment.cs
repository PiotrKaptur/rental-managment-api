namespace RentalManagement.API.Models
{
    /// <summary>
    /// Reprezentuje pojedyńczą płatność związaną z umową wynajmu.
    /// </summary>
    public class Payment
    {
        public int Id { get; set; }

        /// <summary>
        /// Data dokonania płatności.
        /// </summary>
        public DateTime PaymentDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Kwota płatności.
        /// </summary>
        public decimal Amount { get; set; } = 0.0m;

        /// <summary>
        /// Komentarz.
        /// </summary>
        public string? Comment { get; set; } = string.Empty;

        /// <summary>
        /// Id umowy wynajmu.
        /// </summary>
        public int RentalAgreementId { get; set; }

        /// <summary>
        /// Płatność przypisana do umowy wynajmu.
        /// </summary>
        public RentalAgreement? RentalAgreement { get; set; }
    }
}

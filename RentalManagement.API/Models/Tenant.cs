namespace RentalManagement.API.Models
{
    /// <summary>
    /// Reprezentuje lokatora (imie, nazwisko, kontakt itd...)
    /// </summary>
    public class Tenant
    {
        public int Id { get; set; }

        /// <summary>
        /// Imię lokatora.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Nazwisko lokatora.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Numer telefonu lokatora.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Adres e-mail lokatora.
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}

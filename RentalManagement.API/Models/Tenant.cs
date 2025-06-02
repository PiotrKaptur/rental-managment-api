namespace RentalManagement.API.Models
{
    /// <summary>
    /// Reprezentuje lokatora (imie, nazwisko, kontakt itd...)
    /// </summary>
    public class Tenant
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}

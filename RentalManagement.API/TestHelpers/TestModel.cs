using System;
using RentalManagement.API.Models;

namespace RentalManagement.API.TestHelpers
{
    public class TestModel
    {
        public static void Run()
        {
            Console.WriteLine("=== Test Modele ===");

            Tenant tenant = new Tenant
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                PhoneNumber = "123-456-789",
                Email = "Jan.kowalski@gmail.com"
            };
            Console.WriteLine($"Lokator: {tenant.FirstName} {tenant.LastName},Phone number: {tenant.PhoneNumber}, Email: {tenant.Email}");
        }
    }
}

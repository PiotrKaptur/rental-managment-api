using System;
using RentalManagement.API.Models;
using Xunit;

namespace RentalManagement.Tests
{
    public class TestModelTests
    {
        [Fact]
        public void SampleData_ShouldHaveExpectedValues()
        {
            Tenant tenant = new Tenant
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                PhoneNumber = "123-456-789",
                Email = "Jan.kowalski@gmail.com"
            };

            Apartment apartment = new Apartment
            {
                Address = "ul.Zielna 6, 00-123 Warszawa",
                Floor = 3,
                RoomCount = 3,
                RentAmount = 3250.00m
            };

            RentalAgreement agreement = new RentalAgreement
            {
                StartDate = new DateTime(2023, 09, 23),
                MonthlyPayment = 3250.00m,
                Currency = "PLN",
                Tenant = tenant,
                Apartment = apartment,
                EndDate = new DateTime(2027, 09, 23),
            };

            Payment payment = new Payment
            {
                PaymentDate = new DateTime(2023, 09, 27),
                Amount = 3250.00m,
                Comment = "Pierwsza płatność",
                RentalAgreement = agreement,
            };

            Assert.Equal("Jan", tenant.FirstName);
            Assert.Equal("Kowalski", tenant.LastName);
            Assert.Equal(apartment, agreement.Apartment);
            Assert.Equal(tenant, agreement.Tenant);
            Assert.Equal(agreement, payment.RentalAgreement);
            Assert.Equal(3250.00m, payment.Amount);
        }
    }
}

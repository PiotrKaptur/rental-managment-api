using System;
using RentalManagement.API.Models;

namespace RentalManagement.API.TestHelpers
{
    public class TestModel
    {
        public static void Run()
        {
            Console.WriteLine("=== Test Modele ===");

            // Tworzymy przykładowego lokatora
            Tenant tenant = new Tenant
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                PhoneNumber = "123-456-789",
                Email = "Jan.kowalski@gmail.com"
            };

            // Tworzymy przykładowe mieszkanie
            Apartment apartment = new Apartment
            {
                Address = "ul.Zielna 6, 00-123 Warszawa",
                Floor = 3,
                RoomCount = 3,
                RentAmount = 3250.00m
            };

            // Tworzymy umowę wynajmu z przypisanym lokatorem i mieszkaniem
            RentalAgreement agreement = new RentalAgreement
            {
                StartDate = new DateTime(2023, 09, 23),
                MonthlyPayment = 3250.00m,
                Currency = "PLN",
                Tenant = tenant,
                Apartment = apartment,
                EndDate = new DateTime(2027, 09, 23),
            };

            // Tworzymy pojedynczą płatność przypisaną do umowy
            Payment payment = new Payment
            {
                PaymentDate = new DateTime(2023, 09, 27),
                Amount = 3250.00m,
                Comment = "Pierwsza płatność",
                RentalAgreement = agreement,
            };

            // Wyświetlanie danych testowych
            Console.WriteLine(
                $"Lokator: {tenant.FirstName} {tenant.LastName}," +
                $"Phone number: {tenant.PhoneNumber}, " +
                $"Email: {tenant.Email}"
                );

            Console.WriteLine();

            Console.WriteLine(
                $"Mieszkanie: {apartment.Address}," +
                $" Piętro: {apartment.Floor}," +
                $" Liczba pokoi: {apartment.RoomCount}," +
                $" Czynsz: {apartment.RentAmount}"
                );

            Console.WriteLine();

            Console.WriteLine(
                $"Umowa wynajmu: od: {agreement.StartDate}," +
                $" do: {agreement.EndDate}," +
                $" kwota miesięczna: {agreement.MonthlyPayment}," +
                $" waluta: {agreement.Currency}," +
                $" lokator: {agreement.Tenant.FirstName} {agreement.Tenant.LastName}," +
                $" mieszkanie: {agreement.Apartment.Address}"
                );

            Console.WriteLine();

            Console.WriteLine(
                $"Płatności: {payment.PaymentDate}," +
                $" kwota: {payment.Amount}," +
                $" komentarz: {payment.Comment}"
                );

            Console.WriteLine();

        }
    }
}

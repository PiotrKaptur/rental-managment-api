# 🏢 RentalManagement.API

Projekt REST API do zarządzania wynajmem mieszkań. Pozwala na rejestrowanie lokali, najemców, umów oraz płatności czynszu.

## 📦 Technologie

- ASP.NET Core 8 (Web API)
- Entity Framework Core
- SQLite
- Swagger (Swashbuckle)
- LINQ, C#
- Visual Studio 2022

## 🚀 Funkcje

- Zarządzanie najemcami (`GET`, `POST`, `PUT`, `DELETE`)
- Zarządzanie mieszkaniami
- Tworzenie umów najmu
- Rejestrowanie płatności
- Wykrywanie zaległości czynszu
- Swagger UI do testowania API

## 🧩 Struktura projektu

RentalManagement.API

|Models/ → Klasy danych (Apartment, Tenant, RentalAgreement, Payment)

|Controllers/ → Endpointy API

|Data/ → DbContext z EF Core

|TestHelpers/ → Dane testowe i uruchomienie

|Program.cs → Konfiguracja aplikacji


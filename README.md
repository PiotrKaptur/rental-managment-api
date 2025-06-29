# RentalManagement.API

Projekt REST API do zarządzania wynajmem mieszkań. Pozwala na rejestrowanie lokali, najemców, umów oraz płatności czynszu.
Projekt jest w trakcie realizacji. 

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

|- Models/ → Klasy danych (Apartment, Tenant, RentalAgreement, Payment)

|- Controllers/ → Endpointy API

|- Data/ → DbContext z EF Core

|- TestHelpers/ → Dane testowe i uruchomienie

|- Program.cs → Konfiguracja aplikacji




## ⚙️ Jak uruchomić

1. Otwórz projekt w Visual Studio 2022
2. Upewnij się, że masz zainstalowany `SQLite` i `dotnet-ef`
3. W terminalu:
   ```bash
   dotnet ef database update
4. Uruchom aplikację (F5)
5. Przejdź do: https://localhost:5001/swagger




## 📑 Endpointy
### Najemcy
GET /api/tenant

GET /api/tenant/{id}

POST /api/tenant

PUT /api/tenant/{id}

DELETE /api/tenant/{id}

### Mieszkania
GET /api/apartment

POST /api/apartment

PUT /api/apartment/{id}

DELETE /api/apartment/{id}

### Umowy
GET /api/rentalagreement

POST /api/rentalagreement

PUT /api/rentalagreement/{id}

DELETE /api/rentalagreement/{id}

### Płatności
GET /api/payment

POST /api/payment

DELETE /api/payment/{id}

GET /api/payment/overdue






## 👤 Autor
Projekt realizowany jako ćwiczenie z C# / .NET.

Autor: Piotr Kaptur

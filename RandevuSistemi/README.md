# AppointmentSystem (Randevu Sistemi) — ASP.NET Core MVC + LocalDB

Basit ama uçtan uca tamamlanmış bir **randevu yönetim sistemi**.  
Amaç: ASP.NET Core MVC, Entity Framework Core ve LocalDB ile CRUD akışlarını öğrenmek ve uygulamak.

## Özellikler
### Müşteri Yönetimi (Customer)
- Müşteri listeleme
- Müşteri ekleme
- Müşteri düzenleme
- Müşteri silme (onay ekranı ile)

### Randevu Yönetimi (Appointment)
- Randevu listeleme
- Randevu ekleme
- Randevu düzenleme
- Randevu silme (onay ekranı ile)
- **Çakışma kontrolü**: Aynı saat aralığında ikinci randevu oluşturmayı engeller

### Dashboard (Home)
- Anasayfada hızlı erişim kartları
- Yaklaşan 5 randevuyu görüntüleme

## Kullanılan Teknolojiler
- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- LocalDB (SQL Server Express LocalDB)
- Bootstrap (UI)

## Kurulum / Çalıştırma
1. Projeyi klonla:
   ```bash
   git clone <repo-url>

###

Visual Studio ile aç (.sln dosyası)
NuGet paketlerini restore et (otomatik)
Migration çalıştır: dotnet ef database update
Çalıştır:dotnet run
 
### Veritabanı

LocalDB kullanır.
EF Core migration ile tablolar otomatik oluşturulur.
__EFMigrationsHistory tablosu EF Core’un migration geçmişini tuttuğu sistem tablosudur.

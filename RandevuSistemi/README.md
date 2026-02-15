# 📅 AppointmentSystem (Randevu Sistemi)

Basit ama uçtan uca tamamlanmış bir **Randevu Yönetim Sistemi**.

Amaç:  
ASP.NET Core MVC + Entity Framework Core + LocalDB kullanarak CRUD işlemlerini ve katmanlı mimariyi pratik etmek.

---

## 🚀 Özellikler

### 👤 Müşteri Yönetimi (Customer)
- Müşteri listeleme
- Müşteri ekleme
- Müşteri düzenleme
- Müşteri silme (onay ekranı ile)

### 📆 Randevu Yönetimi (Appointment)
- Randevu listeleme
- Randevu ekleme
- Randevu düzenleme
- Randevu silme (onay ekranı ile)
- Çakışma kontrolü (aynı saat aralığında ikinci randevu oluşturulamaz)

### 🏠 Dashboard (Home)
- Hızlı erişim kartları
- Yaklaşan 5 randevuyu görüntüleme

---

## 🛠 Kullanılan Teknolojiler

- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server Express LocalDB
- Bootstrap (UI)

---

## ⚙️ Gereksinimler

- Visual Studio 2022+
- .NET 8 SDK
- SQL Server Express LocalDB

---

## 📦 Kurulum

### 1. Projeyi klonla
```bash
git clone <repo-url>
2. Projeyi aç
.sln dosyasını Visual Studio ile aç

3. Paketleri yükle
NuGet paketleri otomatik restore edilir

4. Migration çalıştır
dotnet ef database update
5. Uygulamayı başlat
dotnet run
Tarayıcıda:
https://localhost:7139

🗄 Veritabanı
LocalDB kullanır

Tablolar EF Core Migration ile otomatik oluşturulur

__EFMigrationsHistory tablosu migration geçmişini tutan sistem tablosudur

🎯 Öğrenilen Konular
MVC mimarisi

CRUD operasyonları

Entity Framework Core

Migration kullanımı

Form validation

Relationship (Customer ↔ Appointment)

Business rule: Çakışma kontrolü

📌 Not
Bu proje eğitim ve pratik amaçlı geliştirilmiştir.
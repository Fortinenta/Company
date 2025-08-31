# CompanySolution

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-692079?style=for-the-badge&logo=dot-net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![TailwindCSS](https://img.shields.io/badge/Tailwind_CSS-06B6D4?style=for-the-badge&logo=tailwind-css&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![CsvHelper](https://img.shields.io/badge/CsvHelper-FF5722?style=for-the-badge&logo=nuget&logoColor=white)
![FontAwesome](https://img.shields.io/badge/Font_Awesome-528DD7?style=for-the-badge&logo=fontawesome&logoColor=white)
![Newtonsoft.Json](https://img.shields.io/badge/Newtonsoft.Json-528DD7?style=for-the-badge&logo=nuget&logoColor=white)

Proyek **CompanySolution** adalah aplikasi web full-stack yang dirancang untuk manajemen data perusahaan, termasuk informasi pegawai, cabang, dan jabatan. Aplikasi ini telah mengalami serangkaian peningkatan signifikan untuk menyediakan pengalaman pengguna yang lebih baik dan fungsionalitas manajemen data massal yang kuat.

## Daftar Isi

- [Gambaran Umum Proyek](#gambaran-umum-proyek)
- [Fitur Utama & Peningkatan Terbaru](#fitur-utama--peningkatan-terbaru)
- [Tumpukan Teknologi (Technology Stack)](#tumpukan-teknologi-technology-stack)
- [Struktur Proyek](#struktur-proyek)
- [Detail Komponen](#detail-komponen)
  - [Backend (CompanyAPI)](#backend-companyapi)
  - [Frontend (CompanyWeb)](#frontend-companyweb)
  - [Database (Scripts)](#database-scripts)
- [Tutorial Penggunaan Proyek](#tutorial-penggunaan-proyek)
  - [Langkah 1: Prasyarat (Prerequisites)](#langkah-1-prasyarat-prerequisites)
  - [Langkah 2: Setup Database](#langkah-2-setup-database)
  - [Langkah 3: Konfigurasi Backend (CompanyAPI)](#langkah-3-konfigurasi-backend-companyapi)
  - [Langkah 4: Konfigurasi Frontend (CompanyWeb)](#langkah-4-konfigurasi-frontend-companyweb)
  - [Langkah 5: Instalasi Dependensi Frontend](#langkah-5-instalasi-dependensi-frontend)
  - [Langkah 6: Menjalankan Proyek](#langkah-6-menjalankan-proyek)

---

## Gambaran Umum Proyek

**CompanySolution** adalah sistem informasi berbasis web yang dirancang untuk mengelola data fundamental perusahaan, seperti data pegawai, cabang, dan jabatan. Aplikasi ini terdiri dari tiga komponen utama:

1.  **Backend (CompanyAPI):** Sebuah RESTful API yang dibangun menggunakan ASP.NET Core untuk mengelola semua logika bisnis dan interaksi database. Kini dilengkapi dengan endpoint transaksional untuk operasi batch.
2.  **Frontend (CompanyWeb):** Sebuah aplikasi web MVC (Model-View-Controller) yang juga dibangun dengan ASP.NET Core sebagai antarmuka pengguna (UI) untuk berinteraksi dengan data melalui API. Tampilan telah diperbarui secara signifikan untuk pengalaman pengguna yang lebih modern dan responsif.
3.  **Database:** Skema dan data yang dikelola oleh SQL Server, dengan skrip inisialisasi yang telah disediakan.

## Fitur Utama & Peningkatan Terbaru

Berikut adalah fitur-fitur inti dan peningkatan signifikan yang telah diimplementasikan:

### 🚀 Peningkatan UI/UX Modern
*   **Desain Responsif:** Tampilan yang dioptimalkan untuk berbagai ukuran layar (mobile-first).
*   **Layout Bersih:** Tata letak halaman yang lebih modern dengan penggunaan kartu dan bayangan halus.
*   **Formulir & Tabel Interaktif:** Input formulir yang konsisten, tabel yang mudah dibaca dengan baris bergantian dan efek hover.
*   **Notifikasi:** Sistem notifikasi yang lebih jelas untuk umpan balik pengguna.
*   **Ikon:** Penggunaan ikon Font Awesome untuk visualisasi yang lebih baik.
*   **Pencarian Lanjutan:** Fitur pencarian multi-kriteria di halaman utama pegawai untuk memfilter data berdasarkan nama, status kontrak, cabang, dan jabatan.

### 📊 Manajemen Data Massal yang Kuat
*   **Upload & Update Batch Transaksional:**
    *   Proses "semua atau tidak sama sekali": Jika ada satu kesalahan dalam batch, seluruh operasi dibatalkan untuk menjaga integritas data.
    *   Notifikasi yang jelas tentang keberhasilan atau kegagalan proses batch.
*   **Template Download:** Unduh template CSV dengan contoh data untuk memudahkan input data baru.
*   **Export Data Massal:** Export data pegawai yang dipilih ke file CSV untuk analisis atau update offline.
*   **Hapus Data Massal:** Hapus beberapa data pegawai sekaligus dengan konfirmasi.
*   **Pelacakan Riwayat Upload:** Setiap file CSV yang diunggah akan dicatat dalam sistem untuk tujuan audit dan pelacakan.
*   **Halaman Batch Update Khusus:** Halaman terpisah untuk mengelola update data massal dengan kolom read-only untuk ID dan nama lengkap.
*   **Dropdown Otomatis:** Input untuk Status Kontrak, Cabang, dan Jabatan kini menggunakan dropdown untuk mengurangi kesalahan input.

### 📈 Pelaporan (Reporting)
*   **Dasbor Laporan:** Menyediakan ringkasan visual atau data agregat mengenai sumber daya perusahaan.
*   **Laporan Pegawai per Cabang:** Menampilkan distribusi jumlah pegawai di setiap cabang.
*   **Laporan Pegawai per Jabatan:** Menampilkan distribusi jumlah pegawai di setiap jabatan.
*   **Laporan Status Kontrak:** Memberikan rincian jumlah pegawai berdasarkan status (e.g., Permanen, Kontrak).

## Tumpukan Teknologi (Technology Stack)

*   **Backend:**
    *   Framework: ASP.NET Core 8
    *   Bahasa: C#
    *   ORM: Entity Framework Core
    *   API Documentation: Swashbuckle (Swagger)
*   **Frontend:**
    *   Framework: ASP.NET Core MVC
    *   Bahasa: C#, HTML, CSS, JavaScript
    *   CSS Framework: Tailwind CSS (v3)
    *   Library: jQuery, CsvHelper, Font Awesome, Newtonsoft.Json
*   **Database:**
    *   Sistem: Microsoft SQL Server
*   **Development Tools:**
    *   IDE: Visual Studio
    *   Build Tools: .NET CLI, Node.js (npm)

## Struktur Proyek

```
C:\Enigma\test-work\CompanySolution\
├─── CompanySolution.sln       // File solusi utama untuk Visual Studio
├─── CompanyAPI\               // Proyek Backend (RESTful API)
│    ├─── Controllers\         // Endpoints API (Pegawai, Cabang, Jabatan, Report)
│    ├─── Models\              // Model data Entity Framework Core (termasuk UploadedFile)
│    ├─── Services\            // Logika bisnis & transaksi batch
│    ├─── ViewModels\          // Data Transfer Objects (DTOs) & BatchResult
│    └─── Program.cs           // Konfigurasi dan entry point API
├─── CompanyWeb\               // Proyek Frontend (Web App MVC)
│    ├─── Controllers\         // Controller untuk me-render Views
│    ├─── Models\              // ViewModels untuk halaman web (termasuk FileUploadViewModel, BatchResultViewModel)
│    ├─── Services\            // Layanan untuk berkomunikasi dengan CompanyAPI
│    ├─── Views\                // Halaman CSHTML (UI)
│    │    ├─── Pegawai\         // Halaman Pegawai (Index, Create, Edit, Details, Upload, BatchUpdate)
│    │    └─── Shared\          // Layout, Partial Views (termasuk _Sidebar, _ScriptsPartial, _DeleteConfirmModal)
│    ├─── wwwroot\             // Aset statis (CSS, JS, gambar)
│    ├─── Mappings\            // ClassMap untuk CsvHelper
│    └─── Program.cs           // Konfigurasi dan entry point web app
├─── Database\                 // Skrip dan dokumentasi database
│    └─── Scripts\             // Skrip SQL untuk membuat tabel dan data
└─── PostmanDocumentation\     // Dokumentasi Postman (jika ada)
```

## Detail Komponen

### Backend (CompanyAPI)

**CompanyAPI** bertanggung jawab untuk menyediakan data dan mengelola operasi CRUD (Create, Read, Update, Delete) melalui serangkaian endpoint RESTful.

*   **Controllers & Endpoints:**
    *   `CabangController`: Mengelola data cabang.
    *   `JabatanController`: Mengelola data jabatan.
    *   `PegawaiController`: Mengelola data pegawai. Dilengkapi dengan endpoint `POST /api/pegawai/batch` untuk operasi transaksional, `POST /api/pegawai/upload` untuk mengunggah file, dan lainnya.
    *   `ReportController`: Menyediakan data agregat untuk laporan, seperti pegawai per cabang, per jabatan, dan berdasarkan status kontrak.
*   **Models:**
    *   `Pegawai.cs`, `Cabang.cs`, `Jabatan.cs`: Representasi tabel di database.
    *   `UploadedFile.cs`: Model untuk mencatat metadata setiap file yang diunggah.
    *   `CompanyDbContext.cs`: Konteks database untuk Entity Framework Core.
*   **Services:**
    *   Berisi logika bisnis yang dipisahkan dari controller, termasuk implementasi transaksi database untuk operasi batch.
*   **ViewModels:**
    *   `PegawaiDto.cs`, `CabangDto.cs`, `JabatanDto.cs`: Data Transfer Objects untuk komunikasi API.
    *   `BatchResult.cs`: Model untuk respons operasi batch.

### Frontend (CompanyWeb)

**CompanyWeb** adalah antarmuka yang digunakan oleh pengguna. Aplikasi ini tidak terhubung langsung ke database, melainkan mengonsumsi data dari **CompanyAPI**.

*   **Fitur:**
    *   Menampilkan, menambah, mengubah, dan menghapus data Pegawai, Cabang, dan Jabatan.
    *   **Manajemen Data Massal:**
        *   Halaman `Upload.cshtml`: Untuk upload data pegawai baru dari template CSV.
        *   Halaman `BatchUpdate.cshtml`: Untuk update data pegawai yang sudah ada dari file CSV hasil export.
        *   Fungsionalitas "Export Selected" dan "Delete Selected" di halaman daftar pegawai.
    *   Menampilkan laporan sederhana.
*   **Arsitektur:**
    *   Menggunakan pola **MVC** di mana `Controller` menerima input, `Model` (ViewModel) membawa data ke `View`, dan `View` menampilkannya sebagai HTML.
    *   `ApiService` (dan turunannya seperti `CabangApiService`) digunakan untuk melakukan panggilan HTTP (GET, POST, PUT, DELETE) ke `CompanyAPI`.
*   **UI/UX:**
    *   Menggunakan Tailwind CSS untuk styling modern dan responsif.
    *   Integrasi Font Awesome untuk ikon.
    *   Peningkatan pada layout, form, dan tabel untuk pengalaman pengguna yang lebih baik.

### Database (Scripts)

Skrip SQL disediakan untuk mempersiapkan database.

*   `01-CreateTables.sql`: Membuat semua tabel yang diperlukan (`Pegawai`, `Cabang`, `Jabatan`, `UploadedFiles`).
*   `02-SampleData.sql`: Mengisi tabel dengan data awal untuk keperluan development.
*   `03-StoredProcedures.sql`: Membuat stored procedure jika ada.
*   `04-Views.sql`: Membuat view database jika ada.

---

## Tutorial Penggunaan Proyek

Ikuti langkah-langkah ini untuk menjalankan proyek **CompanySolution** di lingkungan lokal Anda.

### Langkah 1: Prasyarat (Prerequisites)

Pastikan perangkat lunak berikut sudah terinstal:

1.  **Visual Studio 2022** (atau versi lebih baru) dengan workload **ASP.NET and web development**.
2.  **.NET 8 SDK** (atau yang sesuai dengan proyek).
3.  **SQL Server** (versi Express atau Developer sudah cukup).
4.  **SQL Server Management Studio (SSMS)**.
5.  **Node.js** (LTS version).

### Langkah 2: Setup Database

1.  Buka **SSMS** dan hubungkan ke instance SQL Server Anda.
2.  Di Object Explorer, klik kanan pada folder **Databases** dan pilih **New Database**.
3.  Beri nama database, misalnya `CompanyDB`, lalu klik **OK**.
4.  Buka file skrip SQL dari direktori `Database/Scripts/` satu per satu dengan urutan numerik:
    *   `01-CreateTables.sql`
    *   `02-SampleData.sql`
    *   `03-StoredProcedures.sql`
    *   `04-Views.sql`
5.  Jalankan (Execute) setiap skrip pada database `CompanyDB` yang baru saja Anda buat.

### Langkah 3: Konfigurasi Backend (CompanyAPI)

1.  Buka file `CompanyAPI/appsettings.Development.json`.
2.  Ubah `ConnectionStrings` agar sesuai dengan konfigurasi SQL Server Anda. Ganti `YOUR_SERVER_NAME` dengan nama server SQL Anda (misalnya, `localhost` atau `DESKTOP-ABC\SQLEXPRESS`).
3.  (Opsional) Konfigurasikan pengaturan untuk upload file.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CompanyDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
      },
      "FileUploadSettings": {
        "AllowedExtensions": [".csv"],
        "MaxSizeMb": 10
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

### Langkah 4: Konfigurasi Frontend (CompanyWeb)

1.  Buka file `CompanyWeb/appsettings.Development.json`.
2.  Pastikan ada konfigurasi `ApiBaseUrl`. Nilai URL ini harus menunjuk ke alamat di mana `CompanyAPI` akan berjalan. Anda bisa melihat port-nya di `CompanyAPI/Properties/launchSettings.json`. Contoh:

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ApiBaseUrl": "https://localhost:7123" // Ganti port jika berbeda
    }
    ```

### Langkah 5: Instalasi Dependensi Frontend

1.  Buka terminal atau Command Prompt.
2.  Masuk ke direktori `CompanyWeb`:
    ```bash
    cd CompanyWeb
    ```
3.  Jalankan perintah berikut untuk menginstal dependensi JavaScript (seperti Tailwind CSS):
    ```bash
    npm install
    ```

### Langkah 6: Menjalankan Proyek

1.  Buka file `CompanySolution.sln` dengan **Visual Studio**.
2.  Di **Solution Explorer**, klik kanan pada **Solution 'CompanySolution'** dan pilih **Properties**.
3.  Di bagian **Common Properties** -> **Startup Project**, pilih **Multiple startup projects**.
4.  Atur **Action** untuk `CompanyAPI` dan `CompanyWeb` menjadi **Start**.
5.  Pastikan `CompanyAPI` berada di atas `CompanyWeb` agar API berjalan lebih dulu.
6.  Klik **Apply** lalu **OK**.
7.  Tekan tombol **F5** atau klik tombol **Start** (dengan ikon panah hijau) di Visual Studio.

Dua aplikasi akan berjalan secara bersamaan:

*   **CompanyAPI** akan berjalan di satu tab browser (mungkin menampilkan UI Swagger).
*   **CompanyWeb** akan berjalan di tab lain, dan Anda sekarang dapat menavigasi aplikasi web untuk melihat, menambah, atau mengubah data.

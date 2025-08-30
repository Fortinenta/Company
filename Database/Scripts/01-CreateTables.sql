-- =============================================
-- Script to create tables for CompanySolution
-- =============================================

-- Drop tables if they exist to ensure a clean slate
DROP TABLE IF EXISTS Pegawai;
DROP TABLE IF EXISTS Cabang;
DROP TABLE IF EXISTS Jabatan;

-- =============================================
-- Table: Cabang
-- Description: Stores information about company branches.
-- =============================================
CREATE TABLE Cabang (
    CabangID INT PRIMARY KEY IDENTITY(1,1),
    NamaCabang NVARCHAR(100) NOT NULL,
    Alamat NVARCHAR(255),
    Kota NVARCHAR(100),
    KodePos NVARCHAR(10)
);

-- =============================================
-- Table: Jabatan
-- Description: Stores information about job positions.
-- =============================================
CREATE TABLE Jabatan (
    JabatanID INT PRIMARY KEY IDENTITY(1,1),
    NamaJabatan NVARCHAR(100) NOT NULL,
    Deskripsi NVARCHAR(500)
);

-- =============================================
-- Table: Pegawai
-- Description: Stores information about employees.
-- =============================================
CREATE TABLE Pegawai (
    PegawaiID INT PRIMARY KEY IDENTITY(1,1),
    NamaLengkap NVARCHAR(150) NOT NULL,
    TanggalLahir DATE,
    Alamat NVARCHAR(255),
    NomorTelepon NVARCHAR(20),
    Email NVARCHAR(100) UNIQUE,
    TanggalMasuk DATE NOT NULL,
    StatusKontrak NVARCHAR(50), -- e.g., 'Permanent', 'Contract', 'Intern'
    CabangID INT,
    JabatanID INT,
    CONSTRAINT FK_Pegawai_Cabang FOREIGN KEY (CabangID) REFERENCES Cabang(CabangID),
    CONSTRAINT FK_Pegawai_Jabatan FOREIGN KEY (JabatanID) REFERENCES Jabatan(JabatanID)
);

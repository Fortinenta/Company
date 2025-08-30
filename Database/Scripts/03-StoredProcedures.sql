-- =============================================
-- Script to create stored procedures for CompanySolution
-- =============================================

-- Stored Procedure: sp_GetAllPegawaiWithDetails
-- Description: Retrieves all employees with their branch and position details.
-- =============================================
CREATE PROCEDURE sp_GetAllPegawaiWithDetails
AS
BEGIN
    SELECT 
        p.PegawaiID,
        p.NamaLengkap,
        p.Email,
        p.NomorTelepon,
        p.TanggalMasuk,
        p.StatusKontrak,
        c.NamaCabang,
        j.NamaJabatan
    FROM Pegawai p
    LEFT JOIN Cabang c ON p.CabangID = c.CabangID
    LEFT JOIN Jabatan j ON p.JabatanID = j.JabatanID;
END
GO

-- =============================================
-- Stored Procedure: sp_SearchPegawai
-- Description: Searches for employees based on multiple parameters.
-- =============================================
CREATE PROCEDURE sp_SearchPegawai
    @NamaLengkap NVARCHAR(150) = NULL,
    @NamaCabang NVARCHAR(100) = NULL,
    @NamaJabatan NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        p.PegawaiID,
        p.NamaLengkap,
        p.Email,
        p.NomorTelepon,
        p.TanggalMasuk,
        p.StatusKontrak,
        c.NamaCabang,
        j.NamaJabatan
    FROM Pegawai p
    LEFT JOIN Cabang c ON p.CabangID = c.CabangID
    LEFT JOIN Jabatan j ON p.JabatanID = j.JabatanID
    WHERE 
        (@NamaLengkap IS NULL OR p.NamaLengkap LIKE '%' + @NamaLengkap + '%') AND
        (@NamaCabang IS NULL OR c.NamaCabang LIKE '%' + @NamaCabang + '%') AND
        (@NamaJabatan IS NULL OR j.NamaJabatan LIKE '%' + @NamaJabatan + '%');
END
GO

-- =============================================
-- Stored Procedure: sp_GetPegawaiByContract
-- Description: Filters employees by their contract status.
-- =============================================
CREATE PROCEDURE sp_GetPegawaiByContract
    @StatusKontrak NVARCHAR(50)
AS
BEGIN
    SELECT 
        p.PegawaiID,
        p.NamaLengkap,
        p.Email,
        p.NomorTelepon,
        p.TanggalMasuk,
        p.StatusKontrak,
        c.NamaCabang,
        j.NamaJabatan
    FROM Pegawai p
    LEFT JOIN Cabang c ON p.CabangID = c.CabangID
    LEFT JOIN Jabatan j ON p.JabatanID = j.JabatanID
    WHERE p.StatusKontrak = @StatusKontrak;
END
GO

-- =============================================
-- Stored Procedure: sp_ImportPegawai
-- Description: Bulk inserts employee data from a table type.
-- =============================================
-- First, create a table type for bulk import
CREATE TYPE PegawaiType AS TABLE (
    NamaLengkap NVARCHAR(150) NOT NULL,
    TanggalLahir DATE,
    Alamat NVARCHAR(255),
    NomorTelepon NVARCHAR(20),
    Email NVARCHAR(100) UNIQUE,
    TanggalMasuk DATE NOT NULL,
    StatusKontrak NVARCHAR(50),
    CabangID INT,
    JabatanID INT
);
GO

CREATE PROCEDURE sp_ImportPegawai
    @PegawaiData PegawaiType READONLY
AS
BEGIN
    INSERT INTO Pegawai (NamaLengkap, TanggalLahir, Alamat, NomorTelepon, Email, TanggalMasuk, StatusKontrak, CabangID, JabatanID)
    SELECT NamaLengkap, TanggalLahir, Alamat, NomorTelepon, Email, TanggalMasuk, StatusKontrak, CabangID, JabatanID
    FROM @PegawaiData;
END
GO

-- =============================================
-- Script to create stored procedures for CompanySolution
-- =============================================

-- Stored Procedure: sp_GetAllPegawaiWithDetails
-- Description: Retrieves all employees with their branch and position details.
-- =============================================
IF OBJECT_ID('sp_GetAllPegawaiWithDetails', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllPegawaiWithDetails;
GO
CREATE PROCEDURE sp_GetAllPegawaiWithDetails
AS
BEGIN
    SELECT 
        p.PegawaiID,
        p.NamaLengkap,
        p.Email,
        p.NomorTelepon,
        p.TanggalLahir,
        p.TanggalMasuk,
        p.TanggalHabisKontrak,
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
IF OBJECT_ID('sp_SearchPegawai', 'P') IS NOT NULL
    DROP PROCEDURE sp_SearchPegawai;
GO
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
        p.TanggalLahir,
        p.TanggalMasuk,
        p.TanggalHabisKontrak,
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
IF OBJECT_ID('sp_GetPegawaiByContract', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetPegawaiByContract;
GO
CREATE PROCEDURE sp_GetPegawaiByContract
    @StatusKontrak NVARCHAR(50)
AS
BEGIN
    SELECT 
        p.PegawaiID,
        p.NamaLengkap,
        p.Email,
        p.NomorTelepon,
        p.TanggalLahir,
        p.TanggalMasuk,
        p.TanggalHabisKontrak,
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
IF TYPE_ID('PegawaiType') IS NOT NULL
    DROP TYPE PegawaiType;
GO
CREATE TYPE PegawaiType AS TABLE (
    NamaLengkap NVARCHAR(150) NOT NULL,
    TanggalLahir DATE,
    Alamat NVARCHAR(255),
    NomorTelepon NVARCHAR(20),
    Email NVARCHAR(100) UNIQUE,
    TanggalMasuk DATE NOT NULL,
    TanggalHabisKontrak DATE,
    StatusKontrak NVARCHAR(50),
    CabangID INT,
    JabatanID INT
);
GO

IF OBJECT_ID('sp_ImportPegawai', 'P') IS NOT NULL
    DROP PROCEDURE sp_ImportPegawai;
GO
CREATE PROCEDURE sp_ImportPegawai
    @PegawaiData PegawaiType READONLY
AS
BEGIN
    INSERT INTO Pegawai (NamaLengkap, TanggalLahir, Alamat, NomorTelepon, Email, TanggalMasuk, TanggalHabisKontrak, StatusKontrak, CabangID, JabatanID)
    SELECT NamaLengkap, TanggalLahir, Alamat, NomorTelepon, Email, TanggalMasuk, TanggalHabisKontrak, StatusKontrak, CabangID, JabatanID
    FROM @PegawaiData;
END
GO

-- =============================================
-- Stored Procedure: sp_GetFilteredPegawai
-- Description: Retrieves employees based on dynamic filter criteria.
-- =============================================
IF OBJECT_ID('sp_GetFilteredPegawai', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetFilteredPegawai;
GO
CREATE PROCEDURE sp_GetFilteredPegawai
    @PegawaiID INT = NULL,
    @NamaLengkap NVARCHAR(150) = NULL,
    @CabangID INT = NULL,
    @NamaCabang NVARCHAR(100) = NULL,
    @JabatanID INT = NULL,
    @NamaJabatan NVARCHAR(100) = NULL,
    @TanggalMasukStart DATE = NULL,
    @TanggalMasukEnd DATE = NULL,
    @TanggalHabisKontrakStart DATE = NULL,
    @TanggalHabisKontrakEnd DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @sql NVARCHAR(MAX);
    DECLARE @params NVARCHAR(MAX);

    SET @sql = N'
        SELECT 
            p.PegawaiID,
            p.NamaLengkap,
            p.Email,
            p.NomorTelepon,
            p.TanggalLahir,
            p.TanggalMasuk,
            p.TanggalHabisKontrak,
            p.StatusKontrak,
            p.CabangID,
            c.NamaCabang,
            p.JabatanID,
            j.NamaJabatan
        FROM Pegawai p
        LEFT JOIN Cabang c ON p.CabangID = c.CabangID
        LEFT JOIN Jabatan j ON p.JabatanID = j.JabatanID
        WHERE 1=1';

    IF @PegawaiID IS NOT NULL
        SET @sql = @sql + N' AND p.PegawaiID = @PegawaiID';
    IF @NamaLengkap IS NOT NULL
        SET @sql = @sql + N' AND p.NamaLengkap LIKE '%' + @NamaLengkap + '%'';
    IF @CabangID IS NOT NULL
        SET @sql = @sql + N' AND p.CabangID = @CabangID';
    IF @NamaCabang IS NOT NULL
        SET @sql = @sql + N' AND c.NamaCabang LIKE '%' + @NamaCabang + '%'';
    IF @JabatanID IS NOT NULL
        SET @sql = @sql + N' AND p.JabatanID = @JabatanID';
    IF @NamaJabatan IS NOT NULL
        SET @sql = @sql + N' AND j.NamaJabatan LIKE '%' + @NamaJabatan + '%'';
    IF @TanggalMasukStart IS NOT NULL
        SET @sql = @sql + N' AND p.TanggalMasuk >= @TanggalMasukStart';
    IF @TanggalMasukEnd IS NOT NULL
        SET @sql = @sql + N' AND p.TanggalMasuk <= @TanggalMasukEnd';
    IF @TanggalHabisKontrakStart IS NOT NULL
        SET @sql = @sql + N' AND p.TanggalHabisKontrak >= @TanggalHabisKontrakStart';
    IF @TanggalHabisKontrakEnd IS NOT NULL
        SET @sql = @sql + N' AND p.TanggalHabisKontrak <= @TanggalHabisKontrakEnd';

    SET @params = N'@PegawaiID INT, @NamaLengkap NVARCHAR(150), @CabangID INT, @NamaCabang NVARCHAR(100), @JabatanID INT, @NamaJabatan NVARCHAR(100), @TanggalMasukStart DATE, @TanggalMasukEnd DATE, @TanggalHabisKontrakStart DATE, @TanggalHabisKontrakEnd DATE';

    EXEC sp_executesql @sql, @params,
        @PegawaiID = @PegawaiID,
        @NamaLengkap = @NamaLengkap,
        @CabangID = @CabangID,
        @NamaCabang = @NamaCabang,
        @JabatanID = @JabatanID,
        @NamaJabatan = @NamaJabatan,
        @TanggalMasukStart = @TanggalMasukStart,
        @TanggalMasukEnd = @TanggalMasukEnd,
        @TanggalHabisKontrakStart = @TanggalHabisKontrakStart,
        @TanggalHabisKontrakEnd = @TanggalHabisKontrakEnd;
END;
GO
-- =============================================
-- Script to create views for CompanySolution
-- =============================================

-- View: vw_PegawaiReport
-- Description: Provides a comprehensive view of employees for reporting and dashboard purposes.
--              It joins Pegawai, Cabang, and Jabatan tables to include details about
--              employee's branch, position, and tenure.
-- =============================================
CREATE VIEW vw_PegawaiReport AS
SELECT 
    p.PegawaiID,
    p.NamaLengkap,
    p.Email,
    p.NomorTelepon,
    p.TanggalMasuk,
    p.StatusKontrak,
    p.CabangID,
    p.JabatanID,
    c.NamaCabang,
    c.Kota AS KotaCabang,
    j.NamaJabatan,
    DATEDIFF(year, p.TanggalMasuk, GETDATE()) AS LamaBekerjaTahun,
    DATEDIFF(month, p.TanggalMasuk, GETDATE()) % 12 AS LamaBekerjaBulan
FROM 
    Pegawai p
LEFT JOIN 
    Cabang c ON p.CabangID = c.CabangID
LEFT JOIN 
    Jabatan j ON p.JabatanID = j.JabatanID;
GO

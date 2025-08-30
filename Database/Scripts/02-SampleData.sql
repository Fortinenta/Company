-- =============================================
-- Script to insert sample data for CompanySolution
-- =============================================

-- Sample Data for Cabang Table
INSERT INTO Cabang (NamaCabang, Alamat, Kota, KodePos) VALUES
('Kantor Pusat', 'Jl. Jend. Sudirman Kav. 52-53', 'Jakarta Selatan', '12190'),
('Cabang Bandung', 'Jl. Asia Afrika No. 1', 'Bandung', '40111'),
('Cabang Surabaya', 'Jl. Basuki Rahmat No. 129-131', 'Surabaya', '60271'),
('Cabang Medan', 'Jl. Imam Bonjol No. 17', 'Medan', '20112'),
('Cabang Makassar', 'Jl. Sultan Hasanuddin No. 5', 'Makassar', '90111'),
('Cabang Yogyakarta', 'Jl. Malioboro No. 60', 'Yogyakarta', '55213'),
('Cabang Semarang', 'Jl. Gajah Mada No. 1', 'Semarang', '50134'),
('Cabang Denpasar', 'Jl. Teuku Umar No. 220', 'Denpasar', '80114'),
('Cabang Palembang', 'Jl. Jend. Sudirman No. 123', 'Palembang', '30129'),
('Cabang Balikpapan', 'Jl. Jend. Sudirman No. 45', 'Balikpapan', '76114');

-- Sample Data for Jabatan Table
INSERT INTO Jabatan (NamaJabatan, Deskripsi) VALUES
('Manager', 'Manages a team or department.'),
('Software Engineer', 'Designs, develops, and maintains software.'),
('Quality Assurance', 'Ensures the quality of software through testing.'),
('Human Resources', 'Manages employee relations and recruitment.'),
('Accountant', 'Manages financial records and transactions.'),
('Project Manager', 'Oversees projects from initiation to completion.'),
('Business Analyst', 'Analyzes business needs and processes.'),
('UI/UX Designer', 'Designs user interfaces and user experiences.'),
('DevOps Engineer', 'Manages infrastructure and deployment pipelines.'),
('Data Scientist', 'Analyzes and interprets complex data.');

-- Sample Data for Pegawai Table
INSERT INTO Pegawai (NamaLengkap, TanggalLahir, Alamat, NomorTelepon, Email, TanggalMasuk, StatusKontrak, CabangID, JabatanID) VALUES
('Budi Santoso', '1985-05-10', 'Jl. Merdeka No. 10', '081234567890', 'budi.santoso@example.com', '2015-01-15', 'Permanent', 1, 1),
('Ani Yudhoyono', '1990-02-20', 'Jl. Pahlawan No. 5', '081234567891', 'ani.yudhoyono@example.com', '2018-03-10', 'Permanent', 1, 2),
('Cici Paramida', '1992-08-15', 'Jl. Kenanga No. 25', '081234567892', 'cici.paramida@example.com', '2019-07-20', 'Contract', 2, 3),
('Doni Kusuma', '1988-11-30', 'Jl. Mawar No. 15', '081234567893', 'doni.kusuma@example.com', '2017-06-01', 'Permanent', 3, 4),
('Eka Sari', '1995-01-25', 'Jl. Melati No. 30', '081234567894', 'eka.sari@example.com', '2020-02-18', 'Contract', 4, 5),
('Fajar Nugraha', '1987-07-07', 'Jl. Anggrek No. 12', '081234567895', 'fajar.nugraha@example.com', '2016-09-11', 'Permanent', 5, 6),
('Gita Gutawa', '1993-04-18', 'Jl. Cendana No. 8', '081234567896', 'gita.gutawa@example.com', '2021-01-05', 'Intern', 6, 7),
('Hadi Pranoto', '1989-12-12', 'Jl. Flamboyan No. 3', '081234567897', 'hadi.pranoto@example.com', '2018-08-08', 'Permanent', 7, 8),
('Indah Permata', '1996-06-06', 'Jl. Dahlia No. 21', '081234567898', 'indah.permata@example.com', '2022-03-15', 'Contract', 8, 9),
('Joko Widodo', '1984-03-03', 'Jl. Istana No. 1', '081234567899', 'joko.widodo@example.com', '2014-10-20', 'Permanent', 9, 10),
('Kiki Amalia', '1991-09-09', 'Jl. Bunga No. 9', '081234567880', 'kiki.amalia@example.com', '2019-11-11', 'Permanent', 10, 1);

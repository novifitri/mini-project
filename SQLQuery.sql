--CREATE database
CREATE Database SistemAbsensi;

--CREATE table Divisi
CREATE TABLE Divisi (
	Id INT PRIMARY KEY Identity(1,1) NOT NULL,
	Nama VARCHAR(50) NOT NULL
);

--CREATE table Karyawan
CREATE TABLE Karyawan (
	Id INT PRIMARY KEY Identity(1,1) NOT NULL,
	Nama VARCHAR(50) NOT NULL,
	NIK INT NOT NULL,
	Jenis_Kelamin VARCHAR(30) NOT NULL CHECK (Jenis_Kelamin IN('Laki - laki', 'Perempuan')),
	Tanggal_Lahir DATE NOT NULL,
	Alamat VARCHAR(255) NOT NULL,
	Nomor_Telp VARCHAR(12) NOT NULL,
	Divisi_Id INT Foreign Key References Divisi(Id)
);


--CREATE table Profile
CREATE TABLE Profile (
	Id INT Primary Key Identity(1,1) NOT NULL,
	Username VARCHAR(50) NOT NULL,
	Email VARCHAR(20) UNIQUE NOT NULL,
	Password VARCHAR(8) NOT NULL,
	Karyawan_Id INT Foreign Key References Karyawan(id)
);

--CREATE table Absensi
CREATE TABLE Absensi (
	Id INT Primary Key Identity(1,1) NOT NULL,
	Karyawan_Id INT Foreign Key References Karyawan(id),
	Tanggal_Hadir Date NOT NULL,
);

--DROP table Absensi
DROP TABLE Absensi;

--DROP Table Profile
DROP TABLE Profile;

--DROP Table Karyawan
DROP TABLE Karyawan;

--DROP Table Divisi
DROP TABLE Divisi;


--Insert ke Divisi
INSERT INTO Divisi VALUES ('Human Resource');
INSERT INTO Divisi VALUES ('Engineering'), ('Marketing');

--Insert ke Karyawan
INSERT INTO Karyawan 
					(Nama, 
					NIK, 
					Jenis_Kelamin, 
					Tanggal_Lahir, 
					Alamat, 
					Nomor_Telp, 
					Divisi_Id
					)
VALUES				('Andri', 
					1234567890, 
					'Laki - laki', 
					convert(date,'18-06-1999',105), 
					'Jakarta Barat', 		
					'08123456789',
					1);
INSERT INTO Karyawan 
					(Nama, 
					NIK, 
					Jenis_Kelamin, 
					Tanggal_Lahir, 
					Alamat, 
					Nomor_Telp, 
					Divisi_Id
					)
VALUES				('Bambang', 
					343, 
					'Laki - laki', 
					convert(date,'14-05-1996',105), 
					'Jakarta Selatan', 		
					'085456235',
					1),
					('Chika', 
					132434, 
					'Perempuan', 
					convert(date,'18-09-2000',105), 
					'Jakarta Barat', 		
					'081231231',
					1);

--INSERT ke Profile
INSERT INTO Profile (
					Username,
					Email,
					Password,
					Karyawan_Id
					)
VALUES				(
					'Andri', 
					'andri@gmail.com', 
					'andri123', 
					1
					);
INSERT INTO Profile
VALUES				('Bambang', 
					'bambang@gmail.com', 
					'bambang', 
					2),
					('Chika', 
					'chika@gmail.com', 
					'chik123', 
					3);

--Insert ke Absensi
INSERT INTO Absensi (Karyawan_Id,Tanggal_Hadir)
VALUES (1, '2022-09-19'), (2, '2022-09-1'), (2, '2022-09-2');

INSERT INTO Absensi VALUES (1, '2022-09-02');

--SELECT ALL Divisi
SELECT * FROM Divisi;

--SELECT ALL Karyawan
SELECT * FROM Karyawan;

--SELECT ALL Profile
SELECT * FROM Profile;
--SELECT Profile
SELECT p.username, p.email, d.nama Divisi
FROM Profile p JOIN Karyawan k
ON p.karyawan_id = k.id
JOIN divisi d
ON d.id = k.Divisi_id;

--SELECT ALL Absensi
SELECT * FROM Absensi;

--Update Divisi
UPDATE Divisi SET Nama = 'Finance' WHERE Id = 4;

--CREATE Trigger After Update Divisi
CREATE TRIGGER TG_ShowDivisi
	ON Divisi
	AFTER UPDATE
AS
BEGIN
	SELECT * FROM Divisi;
END

--CREATE Trigger After Update Karyawan
CREATE TRIGGER TG_ShowKaryawan
	ON Karyawan
	AFTER UPDATE
AS
BEGIN
	SELECT * FROM Karyawan;
END

--UPDATE Karyawan
UPDATE Karyawan SET Divisi_Id = 2 WHERE Id = 2;
UPDATE Karyawan SET Divisi_Id = 3 WHERE Id = 3;

--CREATE Trigger After Update Profile
CREATE TRIGGER TG_ShowProfile
	ON Profile
	AFTER UPDATE
AS
BEGIN
	SELECT * FROM Profile;
END

--UPDATE Profile
UPDATE Profile SET Password = 12345678 WHERE Id = 3;

--CREATE Trigger After Update Absensi
CREATE TRIGGER TG_ShowAbsensi
	ON Absensi
	AFTER UPDATE
AS
BEGIN
	SELECT * FROM Absensi;
END

--UPDATE Absensi
UPDATE Absensi SET Tanggal_Hadir = '2022-09-01' WHERE Id = 3;

--DELETE Divisi
Delete Divisi WHERE Id = 4;

--Delete Karyawan 
DELETE Karyawan WHERE Id = 4;

--Delete Profile
DELETE Profile WHERE Id = 4;

--Delete Absensi
DELETE Absensi WHERE Id = 6;


--Untuk mendapatkan jumlah hadir karyawan id tertentu dalam rentang 1 bulan
CREATE FUNCTION FN_GetJumlahHadir_Absensi
(
	@id INT,
	@minTanggal DATE
)
RETURNS INT
AS
BEGIN
	DECLARE @jumlah int;

	SELECT @jumlah = COUNT(DISTINCT Tanggal_Hadir)
	FROM Absensi
	WHERE Karyawan_Id = @id 
	AND Tanggal_Hadir >= @minTanggal
	AND Tanggal_Hadir <= dateadd(day, -1, dateadd(month, 1, dateadd(day, 1 - day(@minTanggal), @minTanggal))) 
	RETURN @jumlah;
END  

--Cari jumlah hadir karyawan id 1
SELECT Nama, dbo.FN_GetJumlahHadir_Absensi(1, TRY_CAST('2022-09-01' as DATE)) As 'Jumlah Hadir'
FROM Karyawan
WHERE Id = 1;

--Lihat Detail Karyawan 
Select k.Nama, k.Jenis_Kelamin, d.Nama Divisi, p.Email
From Karyawan k
JOIN Profile p
ON k.Id = p.Karyawan_Id
JOIN Divisi d
ON k.Divisi_Id =d.Id;


--Lihat semua daftar Absensi
Select a.Id, k.Nama, a.Tanggal_Hadir
From Karyawan k JOIN Absensi a
ON k.Id = a.Karyawan_Id
ORDER BY a.Tanggal_Hadir;


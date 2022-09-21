using System;
using MiniProject.Model;

namespace MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // CRUD Divisi
            DivisiModel dm = new DivisiModel();
            Divisi divisi = new Divisi(){
                Nama = "Admin"
            };
            dm.Insert(divisi);
            dm.GetById(3);
            dm.Update(divisi, 4);
            dm.Delete(4);
            dm.GetAll();
            
            //CRUD Karyawan
            KaryawanModel km = new KaryawanModel();
            Karyawan karyawan = new Karyawan(){
                Nama = "Agung Prakoso",
                NIK = "123",
                Jenis_Kelamin = "Laki - laki",
                Tanggal_Lahir = "1990-01-01",
                Alamat = "Semarang",
                Nomor_Telp = "081231231",
                Divisi_Id = 1,
            };
            km.GetById(6);
            km.Insert(karyawan);
            km.Update(karyawan, 15);
            km.Delete(14);
            km.GetAll();

            //CRUD Profile
            ProfileModel pm = new ProfileModel();
            Profile profile = new Profile(){
                Username = "Agung aja",
                Email = "agung@gmail.com",
                Password = "tes12345",
                Karyawan_Id = 15
            };
            pm.GetById(8);
            pm.Insert(profile);
            pm.Update(profile, 9);
            pm.Delete(9);
            pm.GetAll();

            // CRUD Absensi
            AbsensiModel am = new AbsensiModel();
            Absensi absensi = new Absensi(){
                Karyawan_Id = 3,
                Tanggal_Hadir = "2022-09-01"
            };
            am.GetById(1);
            am.Update(absensi, 4);
            am.Delete(3);
            am.GetAll();
        }
    }
}

using System;

namespace MiniProject
{
    class Karyawan
    {
        public string Nama {get; set;}
        public string NIK {get; set;}
        public string Jenis_Kelamin {get; set;}
        public string Tanggal_Lahir {get; set;}
        public string Alamat {get; set;}
        public string Nomor_Telp {get; set;}
        public int Divisi_Id {get; set;}

        public void printInfo()
        {         
            Console.WriteLine($"Nama \t\t:{this.Nama}"); 
            Console.WriteLine($"NIK \t\t:{this.NIK}");   
            Console.WriteLine($"Jenis Kelamin \t:{this.Jenis_Kelamin}");
            Console.WriteLine($"Tanggal Lahir \t:{this.Tanggal_Lahir}");
            Console.WriteLine($"Alamat \t\t:{this.Alamat}"); 
            Console.WriteLine($"Nomor Hp \t:{this.Nomor_Telp}");
            Console.WriteLine($"Divisi Id \t:{this.Divisi_Id}");
        }
    }
}

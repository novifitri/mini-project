using System;

namespace MiniProject
{
    class Absensi
    {
        public int Karyawan_Id {get; set;}
        public string Tanggal_Hadir {get; set;}

        public void printInfo()
        {         
            Console.WriteLine($"Karyawan Id \t\t:{this.Karyawan_Id}"); 
            Console.WriteLine($"Tanggal Hadir \t\t:{this.Tanggal_Hadir}"); 
        }
  
    }
}

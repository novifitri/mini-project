using System;

namespace MiniProject
{
    class Profile
    {
        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public int Karyawan_Id {get; set;}

        public void printInfo()
        {         
            Console.WriteLine($"Username \t\t:{this.Username}"); 
            Console.WriteLine($"Email \t\t:{this.Email}");   
            Console.WriteLine($"Password \t:{this.Password}");
            Console.WriteLine($"Employee Id \t:{this.Karyawan_Id}");
        }

        public bool ValidasiPassword()
        {
            if(this.Password.Length == 8){
                return true;
            }
            return false;
        }
    }
}

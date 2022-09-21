using System;
using System.Data.SqlClient;

namespace MiniProject.Model
{
    class KaryawanModel : Model<Karyawan>
    {
        public override void GetAll()
        {
            SqlConnection cnn = new SqlConnection(connectionString);  
            string query = "SELECT * FROM karyawan";
            SqlCommand command = new SqlCommand(query, cnn);
            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        Console.WriteLine("Id\tNama\tNIK\tJenis Kelamin\tTanggal Lahir\tAlamat\tNomor Hp\tDivisi Id");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0] + "\t" + reader[1] 
                            + "\t" + reader[2] 
                            + "\t" + reader[3]
                            + "\t" + Convert.ToDateTime(reader[4]).ToShortDateString()
                            + "\t" + reader[5]
                            + "\t" + reader[6]
                            + "\t" + reader[7]
                            );      
                        }   
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
                    cnn.Close();
            }
            catch (Exception e)
            {     
                Console.WriteLine(e.InnerException);
            }       
        }
        
        public override void GetById(int id)
        {
            SqlConnection cnn = new SqlConnection(connectionString);  
            string query = "SELECT * FROM karyawan WHERE Id ="+id;
            SqlCommand command = new SqlCommand(query, cnn);
            try
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           Console.WriteLine($"Id \t\t:{reader[0]}");   
                           Console.WriteLine($"Nama \t\t:{reader[1]}"); 
                           Console.WriteLine($"NIK \t\t:{reader[2]}");   
                           Console.WriteLine($"Jenis Kelamin \t:{reader[3]}");
                           Console.WriteLine($"Tanggal Lahir \t:{reader[4]}");
                           Console.WriteLine($"Alamat \t\t:{reader[5]}"); 
                           Console.WriteLine($"Nomor Hp \t:{reader[6]}");
                           Console.WriteLine($"Divisi Id \t:{reader[7]}");
                        }   
                    }   
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
                    cnn.Close();
            }
            catch (Exception e)
            {     
                Console.WriteLine(e.InnerException);
            }  
        }

        public override void Insert(Karyawan karyawan)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Nama";
                sqlParameter1.Value = karyawan.Nama;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@NIK";
                sqlParameter2.Value = karyawan.NIK; 

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@Jenis_Kelamin";
                sqlParameter3.Value = karyawan.Jenis_Kelamin; 

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@Tanggal_Lahir";
                sqlParameter4.Value = karyawan.Tanggal_Lahir; 
               
                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@Alamat";
                sqlParameter5.Value = karyawan.Alamat; 
            
                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@Nomor_Telp";
                sqlParameter6.Value = karyawan.Nomor_Telp; 
               
                SqlParameter sqlParameter7 = new SqlParameter();
                sqlParameter7.ParameterName = "@Divisi_Id";
                sqlParameter7.Value = karyawan.Divisi_Id; 

                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);
                sqlCommand.Parameters.Add(sqlParameter7);

                try
                {
                    sqlCommand.CommandText = 
                    "INSERT INTO Karyawan " +
                    "(Nama, NIK, Jenis_Kelamin, Tanggal_Lahir, Alamat, Nomor_Telp, Divisi_Id) " +
                    "VALUES (@Nama, @NIK, @Jenis_Kelamin, @Tanggal_Lahir, @Alamat, @Nomor_Telp, @Divisi_Id) ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                          Console.WriteLine(exRollback.Message);;
                    }
                }
            }
        }

        public override void Update(Karyawan karyawan, int id)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Id";
                sqlParameter.Value = id;

                SqlParameter sqlParameter1 = new SqlParameter();
                sqlParameter1.ParameterName = "@Nama";
                sqlParameter1.Value = karyawan.Nama;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@NIK";
                sqlParameter2.Value = karyawan.NIK; 

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@Jenis_Kelamin";
                sqlParameter3.Value = karyawan.Jenis_Kelamin; 

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@Tanggal_Lahir";
                sqlParameter4.Value = karyawan.Tanggal_Lahir; 
               
                SqlParameter sqlParameter5 = new SqlParameter();
                sqlParameter5.ParameterName = "@Alamat";
                sqlParameter5.Value = karyawan.Alamat; 
            
                SqlParameter sqlParameter6 = new SqlParameter();
                sqlParameter6.ParameterName = "@Nomor_Telp";
                sqlParameter6.Value = karyawan.Nomor_Telp; 
               
                SqlParameter sqlParameter7 = new SqlParameter();
                sqlParameter7.ParameterName = "@Divisi_Id";
                sqlParameter7.Value = karyawan.Divisi_Id; 

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter1);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);
                sqlCommand.Parameters.Add(sqlParameter4);
                sqlCommand.Parameters.Add(sqlParameter5);
                sqlCommand.Parameters.Add(sqlParameter6);
                sqlCommand.Parameters.Add(sqlParameter7);

                try
                {
                    sqlCommand.CommandText = 
                    "Update Karyawan " +
                    "SET Nama=@Nama, NIK=@NIK, Jenis_Kelamin=@Jenis_Kelamin, Tanggal_Lahir=@Tanggal_Lahir, " +
                    "Alamat=@Alamat, Nomor_Telp=@Nomor_Telp, Divisi_Id=@Divisi_Id " +
                    "WHERE Id = @Id ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                          Console.WriteLine(exRollback.Message);;
                    }
                }
            }
        }

        public override void Delete(int id)
        {
             using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Id";
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);
                try
                {
                    sqlCommand.CommandText = "Delete Karyawan Where ID = @id";         
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                          Console.WriteLine(exRollback.Message);;
                    }
                }
            }
        }
    }
}

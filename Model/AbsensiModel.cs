using System;
using System.Data.SqlClient;

namespace MiniProject.Model
{
    class AbsensiModel : Model<Absensi>
    {
      public override void GetAll()
      {
         SqlConnection cnn = new SqlConnection(connectionString);  
          string query = "SELECT a.Id, k.Nama, a.Tanggal_Hadir "+
                         "FROM Absensi a JOIN Karyawan k "+
                         "ON a.Karyawan_Id= k.Id ";
          SqlCommand command = new SqlCommand(query, cnn);
          try
          {
               cnn.Open();
               using (SqlDataReader reader = command.ExecuteReader())
               {
               if(reader.HasRows)
               {
                    Console.WriteLine("Id\tKaryawan\tTanggal Hadir");
                    while (reader.Read())
                    {
                         Console.WriteLine(
                         reader[0] 
                         + "\t" + reader[1]  
                         + "\t\t" + Convert.ToDateTime(reader[2]).ToShortDateString()
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
         string query = "SELECT a.Id, k.Nama, a.Tanggal_Hadir "+
                        "FROM Absensi a JOIN Karyawan k "+
                        "ON a.Karyawan_Id= k.Id " +
                        "WHERE a.id = "+id;
         SqlCommand command = new SqlCommand(query, cnn);
         try
         {
            cnn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
            if(reader.HasRows)
            {
                  Console.WriteLine("Id\tKaryawan\tTanggal Hadir");
                  while (reader.Read())
                  {
                        Console.WriteLine(
                        reader[0] 
                        + "\t" + reader[1]  
                        + "\t\t" + Convert.ToDateTime(reader[2]).ToShortDateString() 
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
      public override void Insert(Absensi a)
      {
         using(SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Transaction = sqlTransaction;

            SqlParameter sqlParameter1 = new SqlParameter();
            sqlParameter1.ParameterName = "@Karyawan_Id";
            sqlParameter1.Value = a.Karyawan_Id; 

            SqlParameter sqlParameter2 = new SqlParameter();
            sqlParameter2.ParameterName = "@Tanggal_Hadir";
            sqlParameter2.Value = a.Tanggal_Hadir;

            sqlCommand.Parameters.Add(sqlParameter1);
            sqlCommand.Parameters.Add(sqlParameter2);

            try
            {
                sqlCommand.CommandText = 
                "INSERT INTO Absensi " +
                "(Karyawan_Id, Tanggal_Hadir) " +
                "VALUES (@Karyawan_Id, @Tanggal_Hadir) ";
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
      public override void Update(Absensi a, int id)
      {
         using(SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Transaction = sqlTransaction;

            SqlParameter sqlParameter1 = new SqlParameter();
            sqlParameter1.ParameterName = "@Karyawan_Id";
            sqlParameter1.Value = a.Karyawan_Id; 

            SqlParameter sqlParameter2 = new SqlParameter();
            sqlParameter2.ParameterName = "@Tanggal_Hadir";
            sqlParameter2.Value = a.Tanggal_Hadir;

            sqlCommand.Parameters.Add(sqlParameter1);
            sqlCommand.Parameters.Add(sqlParameter2);

            try
            {
                sqlCommand.CommandText = 
                "UPDATE Absensi " +
                "SET Karyawan_Id=@Karyawan_Id, Tanggal_Hadir=@Tanggal_Hadir " +
                "WHERE id = "+ id;
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

            try
            {
               sqlCommand.CommandText = "DELETE Absensi WHERE id = "+ id;
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

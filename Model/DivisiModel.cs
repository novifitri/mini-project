using System;
using System.Data.SqlClient;

namespace MiniProject.Model
{
    class DivisiModel : Model<Divisi>
    {
    public override void GetAll()
    {
      SqlConnection cnn = new SqlConnection(connectionString);  
      string query = "SELECT * FROM Divisi";
      SqlCommand command = new SqlCommand(query, cnn);
      try
      {
         cnn.Open();
         using (SqlDataReader reader = command.ExecuteReader())
         {
         if(reader.HasRows)
         {
               Console.WriteLine("Id\tNama Divisi");
               while (reader.Read())
               {
                     Console.WriteLine(reader[0] + "\t" + reader[1]);      
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
      string query = "SELECT * FROM Divisi WHERE Id = " +id;
      SqlCommand command = new SqlCommand(query, cnn);
      try
      {
         cnn.Open();
         using (SqlDataReader reader = command.ExecuteReader())
         {
         if(reader.HasRows)
         {
               Console.WriteLine("Id\tNama Divisi");
               while (reader.Read())
               {
                  Console.WriteLine(reader[0] + "\t" + reader[1]);      
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
    public override void Insert(Divisi d)
    {
      using(SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Transaction = sqlTransaction;

            SqlParameter sqlParameter1 = new SqlParameter();
            sqlParameter1.ParameterName = "@Nama";
            sqlParameter1.Value = d.Nama;

            sqlCommand.Parameters.Add(sqlParameter1);

            try
            {
                sqlCommand.CommandText = 
                "INSERT INTO Divisi " +
                "VALUES (@Nama) ";
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
    public override void Update(Divisi d, int id)
    {
       using(SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Transaction = sqlTransaction;

            SqlParameter sqlParameter1 = new SqlParameter();
            sqlParameter1.ParameterName = "@Nama";
            sqlParameter1.Value = d.Nama;

            sqlCommand.Parameters.Add(sqlParameter1);

            try
            {
                sqlCommand.CommandText = 
                "UPDATE Divisi " +
                "SET Nama= @Nama " +
                "WHERE Id = " +id;
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
                sqlCommand.CommandText = "DELETE Divisi WHERE Id = " +id;
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
     public void Tes()
     {
        Console.WriteLine(connectionString);
     }   
    }
}

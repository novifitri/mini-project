using System;
using System.Data.SqlClient;

namespace MiniProject.Model
{
    class ProfileModel : Model<Profile>
    {
    public override void GetAll()
    {
     SqlConnection cnn = new SqlConnection(connectionString);  
          string query = "SELECT * FROM Profile";
          SqlCommand command = new SqlCommand(query, cnn);
          try
          {
               cnn.Open();
               using (SqlDataReader reader = command.ExecuteReader())
               {
               if(reader.HasRows)
               {
                    Console.WriteLine("Id\tUsername\tEmail\tPassword\tDivisi ID");
                    while (reader.Read())
                    {
                         Console.WriteLine(
                         reader[0] 
                         + "\t" + reader[1]  
                         + "\t" + reader[2] 
                         + "\t" + reader[3]  
                         + "\t" + reader[4]
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
          string query = "SELECT p.Username, p.Email, d.Nama "+
          "FROM Profile p JOIN Karyawan k "+
          "ON p.Karyawan_Id = k.Id " + 
          "JOIN Divisi d "+
          "ON d.Id = k.Divisi_Id " +
          "WHERE p.Id = " + id;
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
                         Console.WriteLine("Username : " +  reader[0] );
                         Console.WriteLine("Email : " + reader[1]  );
                         Console.WriteLine("Divisi : " + reader[2]  );
                       
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
    public override void Insert(Profile p)
    {
     if(p.ValidasiPassword()){
        using(SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Transaction = sqlTransaction;

            SqlParameter sqlParameter1 = new SqlParameter();
            sqlParameter1.ParameterName = "@Username";
            sqlParameter1.Value = p.Username;

            SqlParameter sqlParameter2 = new SqlParameter();
            sqlParameter2.ParameterName = "@Email";
            sqlParameter2.Value = p.Email; 

            SqlParameter sqlParameter3 = new SqlParameter();
            sqlParameter3.ParameterName = "@Password";
            sqlParameter3.Value = p.Password; 

            SqlParameter sqlParameter4 = new SqlParameter();
            sqlParameter4.ParameterName = "@Karyawan_Id";
            sqlParameter4.Value = p.Karyawan_Id; 

            sqlCommand.Parameters.Add(sqlParameter1);
            sqlCommand.Parameters.Add(sqlParameter2);
            sqlCommand.Parameters.Add(sqlParameter3);
            sqlCommand.Parameters.Add(sqlParameter4);

            try
            {
                sqlCommand.CommandText = 
                "INSERT INTO Profile " +
                "(Username, Email, Password, Karyawan_Id) " +
                "VALUES (@Username, @Email, @Password, @Karyawan_Id) ";
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
     else
     {
        Console.WriteLine("Password harus 8 karakter");
     }
    }
    public override void Update(Profile p, int id)
    {
      if(p.ValidasiPassword()){
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
            sqlParameter1.ParameterName = "@Username";
            sqlParameter1.Value = p.Username;

            SqlParameter sqlParameter2 = new SqlParameter();
            sqlParameter2.ParameterName = "@Email";
            sqlParameter2.Value = p.Email; 

            SqlParameter sqlParameter3 = new SqlParameter();
            sqlParameter3.ParameterName = "@Password";
            sqlParameter3.Value = p.Password; 

            SqlParameter sqlParameter4 = new SqlParameter();
            sqlParameter4.ParameterName = "@Karyawan_Id";
            sqlParameter4.Value = p.Karyawan_Id; 

            sqlCommand.Parameters.Add(sqlParameter);
            sqlCommand.Parameters.Add(sqlParameter1);
            sqlCommand.Parameters.Add(sqlParameter2);
            sqlCommand.Parameters.Add(sqlParameter3);
            sqlCommand.Parameters.Add(sqlParameter4);

            try
            {
                sqlCommand.CommandText = 
                "UPDATE Profile " +
                "SET Username=@Username, Email=@Email, Password=@Password, Karyawan_id=@Karyawan_Id " +
                "WHERE Id = @id ";
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
     else
     {
        Console.WriteLine("Password harus 8 karakter");
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
                sqlCommand.CommandText = "Delete Profile Where ID = @id";         
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

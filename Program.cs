using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using ApiConsumption;

namespace MBE_PRUEBA_22
{
    internal class Program
    {
        static void Main(string[] args)
        {             
           try
            {
                using var connection = new MySqlConnection("Server=35.175.112.147;Port=3306;Uid=testuser;Password=Test.344;Database=test");
                connection.Open();

                using var command = new MySqlCommand("SELECT * FROM schedule;", connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                  
                    // A) LECTURA DE LA TABLA 
                    do
                    {
                        if (reader.GetString(1) == "API")
                        {
                            HttpApi.GetApi(reader.GetString(2));

                        }
                    //    if (reader.GetString(1) == "LINUX")
                    //    {
                    //    Console.WriteLine("if LIN");
                    //}

                    } while (reader.Read());
                Console.ReadLine();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
               

          
        }

    }
}



using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


var connString = "Server=35.175.112.147;Port=3306;Uid=testuser;Password=Test.344;Database=test";
using (var conn = new MySqlConnection(connString))
{
    await conn.OpenAsync();

    using (var cmd = new MySqlCommand("SELECT * FROM schedule", conn))
    using (var reader = await cmd.ExecuteReaderAsync())
        while (await reader.ReadAsync())
            // A) LECTURA DE LA TABLA 
            do
            {
                Console.WriteLine(reader.GetString(2));

                if (reader.GetString(1) == "API")
                {
                    Console.WriteLine("API");
                }
                if (reader.GetString(1) == "LINUX")
                {
                    Process.Start("C://acrobat.exe");
                }

            } while (reader.Read());
    Console.ReadLine();
}


namespace MBE_PRUEBA_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

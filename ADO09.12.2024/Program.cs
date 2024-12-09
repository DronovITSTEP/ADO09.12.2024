using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO09._12._2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            try
            {
                // первый способ - через конструктор
                conn =
                    new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;" +
                    "Initial Catalog=StudentData;");

                // второй способ - через свойство
                SqlConnection conn2 = new SqlConnection();
                conn2.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                    "Initial Catalog=StudentData;";

                conn.Open();
/*                string insert = @"insert into Students (FirstName, LastName) 
            values ('Ivan', 'Ivanov'),
                    ('Petr', 'Petrov')";
                insert = Console.ReadLine();
                SqlCommand command = new SqlCommand(insert, conn);
                command.ExecuteNonQuery();*/
                /*
                ExecuteReader() - для запросов select
                ExecuteNonQuery() - insert, update, delete
                ExecuteScalar() - результат агрегированной функции в select
                 */

                SqlCommand command = new SqlCommand();
                command.CommandText = "select * from Students";
                command.Connection = conn;
         
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Console.WriteLine(reader[1] + " " + reader[2]);
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (conn != null)
                    conn.Close();
                
            }

            string connectionString = ConfigurationManager
                .ConnectionStrings["connString"].ConnectionString;
        }
    }
}

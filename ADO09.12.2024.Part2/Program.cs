using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO09._12._2024.Part2
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
                conn.Open();

                string name, surname;
                name = Console.ReadLine();
                surname = Console.ReadLine();

                string insert = "insert into Students (FirstName, LastName) " +
            "values ( @name, @surname)";

                SqlCommand command = conn.CreateCommand();
                command.CommandText = insert;

                // первый вариант (подробный)
                /*SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@name";
                parameter.SqlDbType = System.Data.SqlDbType.NVarChar;
                parameter.Value = name;

                command.Parameters.Add(parameter);*/

                // второй вариант (короткий)
                command.Parameters.Add("@surname", System.Data.SqlDbType.NVarChar)
                    .Value = surname;

                // третий вариант (еще короче)
                command.Parameters.AddWithValue("@name", name);

                command.ExecuteNonQuery();

            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }

        }
    }
}

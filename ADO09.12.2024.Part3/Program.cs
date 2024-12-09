using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO09._12._2024.Part3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = null;
            try
            {
                conn =
                    new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;" +
                    "Initial Catalog=StudentData;");
                conn.Open();

                SqlCommand command = 
                    new SqlCommand("getFullNameStudent", conn);
                command.CommandType = System.Data
                                        .CommandType.StoredProcedure;

                command.Parameters.Add("@id", System.Data.SqlDbType.Int)
                    .Value = 2;

                SqlParameter outputFullName = new SqlParameter("@fullname", 
                    System.Data.SqlDbType.NVarChar);
                outputFullName.Direction = System.Data.ParameterDirection.Output;

                command.Parameters.Add(outputFullName);

                command.ExecuteNonQuery();

                Console
                    .WriteLine(command.Parameters["@fullname"]
                                .Value.ToString());
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }
        }
    }
}

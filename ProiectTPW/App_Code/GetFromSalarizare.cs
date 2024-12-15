using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GetFromSalarizare
/// </summary>
public class GetFromSalarizare
{
    private static string connectionString = "Data Source=andreimihai;User Id=STUDENT;Password=STUDENT;"; // Actualizează cu datele tale
    public GetFromSalarizare()
    {
    }

    public static void GetSalarizare(out string cas, out string cass, out string impozit)
    {
        cas = "";
        cass = "";
        impozit = "";

        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "SELECT cas, cass, impozit FROM Salarizare";

                using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cas = reader["cas"].ToString();
                                cass = reader["cass"].ToString();
                                impozit = reader["impozit"].ToString();
                            }
                        }
                    }
            }
                catch (Exception ex)
                {

                }
            }
    }
}

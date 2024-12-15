using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employees
/// </summary>
public class Employees
{
    private static string connectionString = "Data Source=andreimihai;User Id=STUDENT;Password=STUDENT;"; // Actualizează cu datele tale
    public class Employee
    {
        public int NrCrt { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Functie { get; set; }
        public int SalarBaza { get; set; }
        public int Spor { get; set; }
        public int PremiiBrute { get; set; }
        public int Retineri { get; set; }
        public int Total_Brut { get; set; }
        public int Brut_Impozabil { get; set; }
        public int CAS { get; set; }
        public int CASS { get; set; }
        public int Impozit { get; set; }
        public int Virat_Card { get; set; }
        public string Poza { get; set; }
        
    }

    public static List<Employee> GetAngajati()
    {
        List<Employee> employees = new List<Employee>();

        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, RETINERI, TOTAL_BRUT, BRUT_IMPOZABIL, CAS, CASS, IMPOZIT, VIRAT_CARD, POZA FROM Angajati";

            using (OracleCommand command = new OracleCommand(query, connection))
            {
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            NrCrt = Convert.ToInt32(reader["NR_CRT"]),
                            Nume = reader["NUME"].ToString(),
                            Prenume = reader["PRENUME"].ToString(),
                            Functie = reader["FUNCTIE"].ToString(),
                            SalarBaza = Convert.ToInt32(reader["SALAR_BAZA"]),
                            Spor = Convert.ToInt32(reader["SPOR"]),
                            PremiiBrute = Convert.ToInt32(reader["PREMII_BRUTE"]),
                            Retineri = Convert.ToInt32(reader["RETINERI"]),
                            Total_Brut = Convert.ToInt32(reader["TOTAL_BRUT"]),
                            Brut_Impozabil = Convert.ToInt32(reader["BRUT_IMPOZABIL"]),
                            CAS = Convert.ToInt32(reader["CAS"]),
                            CASS = Convert.ToInt32(reader["CASS"]),
                            Impozit = Convert.ToInt32(reader["IMPOZIT"]),
                            Virat_Card = Convert.ToInt32(reader["VIRAT_CARD"]),
                        };
               
                        if (reader["POZA"] != DBNull.Value)
                        {
                            byte[] imageData = (byte[])reader["POZA"];
                            string base64String = Convert.ToBase64String(imageData);
                            employee.Poza = "data:image/jpeg;base64," + base64String; 
                        }
                        else
                        {
                            employee.Poza = null;
                        }

                        employees.Add(employee);
                    }
                }
            }
            connection.Dispose();
        }
       
        return employees;
    }

}
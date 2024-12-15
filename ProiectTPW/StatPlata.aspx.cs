using CrystalDecisions.CrystalReports.Engine;
using Oracle.ManagedDataAccess.Client;
using System;
using CrystalDecisions.Shared;
using System.Data;


public partial class StatPlata : System.Web.UI.Page
{
    private string connectionString = "Data Source=andreimihai;PERSIST SECURITY INFO = True;User Id=STUDENT;Password=STUDENT;";
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void GenerateReport()
    {

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            string query = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, RETINERI, TOTAL_BRUT, BRUT_IMPOZABIL, CAS, CASS, IMPOZIT, VIRAT_CARD FROM Angajati";

            using (OracleCommand cmd = new OracleCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        ReportDocument crp = new ReportDocument();
                        crp.Load(Server.MapPath("~/StatPlataReport.rpt"));
                        crp.DataSourceConnections[0].SetConnection("andreimihai", "STUDENT", "STUDENT", "STUDENT");
                        crp.SetDataSource(ds.Tables["Angajati"]);
                        CrystalReportViewer1.ReportSource = crp;

                        DiskFileDestinationOptions file = new DiskFileDestinationOptions();
                        crp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        file.DiskFileName = Server.MapPath("~/Stat_Plata_Report.pdf");
                        crp.ExportOptions.DestinationOptions = file;
                        crp.Export();
                    }
                }
                catch (Exception ex)
                {
                   
                }
            }
        }

    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        GenerateReport();
    }

}



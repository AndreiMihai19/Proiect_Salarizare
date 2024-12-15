using CrystalDecisions.CrystalReports.Engine;
using Oracle.ManagedDataAccess.Client;
using System;
using CrystalDecisions.Shared;
using System.Data;

public partial class Fluturasi : System.Web.UI.Page
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
                        crp.Load(Server.MapPath("~/FluturasiReport.rpt"));
                        crp.DataSourceConnections[0].SetConnection("andreimihai", "STUDENT", "STUDENT", "STUDENT");
                        crp.SetDataSource(ds.Tables["Angajati"]);
                        CrystalReportViewer1.ReportSource = crp;

                        DiskFileDestinationOptions file = new DiskFileDestinationOptions();
                        crp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        file.DiskFileName = Server.MapPath("~/Fluturasi_Report.pdf");
                        crp.ExportOptions.DestinationOptions = file;
                        crp.Export();
                        conn.Close();
                        statusMessage.Text = "Fluturasul a fost generat cu succes!";
                        statusMessage.ForeColor = System.Drawing.Color.Green;
                        statusMessage.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    statusMessage.Text = "A aparut o problema!";
                    statusMessage.ForeColor = System.Drawing.Color.Red;
                    statusMessage.Visible = true;
                }
            }
        }
    }
    private void GenerateReportForOne(string fullName)
    {
        try
        {
            string[] _fullName = fullName.Split(' ');
            if (_fullName.Length != 2)
            {
                statusMessage.Text = "Numele complet trebuie sa conțina doar nume si prenume.";
                statusMessage.ForeColor = System.Drawing.Color.Red;
                statusMessage.Visible = true;
                return;
            }

            string lastName = _fullName[0];
            string firstName = _fullName[1];

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                string query = @"SELECT NR_CRT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, 
                             PREMII_BRUTE, RETINERI, TOTAL_BRUT, BRUT_IMPOZABIL, 
                             CAS, CASS, IMPOZIT, VIRAT_CARD 
                             FROM Angajati 
                             WHERE NUME = :nume AND PRENUME = :prenume";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("nume", lastName));
                    cmd.Parameters.Add(new OracleParameter("prenume", firstName));

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        conn.Open();
                        adapter.Fill(ds, "Angajati");

                        if (ds.Tables["Angajati"].Rows.Count == 0)
                        {
                            statusMessage.Text = "Angajatul " + fullName + " nu a fost gasit!";
                            statusMessage.ForeColor = System.Drawing.Color.Red;
                            statusMessage.Visible = true;
                            return;
                        }

                        ReportDocument crp = new ReportDocument();
                        crp.Load(Server.MapPath("~/FluturasiReport.rpt"));
                        crp.DataSourceConnections[0].SetConnection("andreimihai", "STUDENT", "STUDENT", "STUDENT");
                        crp.SetDataSource(ds.Tables["Angajati"]);
                        CrystalReportViewer1.ReportSource = crp;

                        DiskFileDestinationOptions file = new DiskFileDestinationOptions();
                        crp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        file.DiskFileName = Server.MapPath("~/Fluturas_" + fullName.Replace(" ", "_") + "_Report.pdf");
                        crp.ExportOptions.DestinationOptions = file;
                        crp.Export();
                        conn.Close();
                        statusMessage.Text = "Fluturasul a fost generat cu succes!";
                        statusMessage.ForeColor = System.Drawing.Color.Green;
                        statusMessage.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            statusMessage.Text = "A aparut o eroare: " + ex.Message;
            statusMessage.ForeColor = System.Drawing.Color.Red;
            statusMessage.Visible = true;
        }
       
    }

    protected void btnGenerateForAll_Click(object sender, EventArgs e)
    {
        GenerateReport();
    }

    protected void btnGenerateForOne_Click(object sender, EventArgs e)
    {
        GenerateReportForOne(txtNumePrenume.Text);
    }
}
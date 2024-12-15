using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

public partial class Adaugare : System.Web.UI.Page
{
    private string _cas = "";
    private string _cass = "";
    private string _impozit = "";
    private string connectionString = "Data Source=andreimihai;User Id=STUDENT;Password=STUDENT;"; // Actualizează cu datele tale

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnAdauga_Click(object sender, EventArgs e)
    {
        GetFromSalarizare.GetSalarizare(out _cas, out _cass, out _impozit);
        SalaryCalculation salaryCalc = new SalaryCalculation();

        string nume = txtNume.Text;
        string prenume = txtPrenume.Text;
        string functie = txtFunctie.Text;
        decimal salarBaza = decimal.Parse(txtSalarBaza.Text);
        decimal spor = decimal.Parse(txtSpor.Text);
        decimal premiiBrute = decimal.Parse(txtPremiiBrute.Text);
        decimal retineri = decimal.Parse(txtRetineri.Text);
        decimal totalBrut = salaryCalc.CalculateTotalBrut(salarBaza, spor, premiiBrute);
        decimal cas = salaryCalc.CalculateCAS(totalBrut, decimal.Parse(_cas.ToString()));
        decimal cass = salaryCalc.CalculateCASS(totalBrut, decimal.Parse(_cass.ToString()));
        decimal brutImpozabil = salaryCalc.CalculateBrutImpozabil(totalBrut, cas, cass);
        decimal impozit = salaryCalc.CalculateImpozit(brutImpozabil, decimal.Parse(_impozit.ToString()));
        decimal viratCard = salaryCalc.CalculateViratCard(brutImpozabil, impozit, retineri);
        byte[] poza = null;

        if (this.filePoza.PostedFile != null && this.filePoza.PostedFile.ContentLength > 0)
        {
            var file = this.filePoza.PostedFile;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                poza = binaryReader.ReadBytes(file.ContentLength);
            }
        }

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            conn.Open();
            using (OracleCommand command = new OracleCommand())
            {
                command.Connection = conn;
                command.CommandText = "INSERT INTO Angajati (nume, prenume, functie, salar_baza, spor, premii_brute, salarizare_id, total_brut, brut_impozabil, cas, cass, impozit, retineri,virat_card, poza) " +
                                      "VALUES (:nume, :prenume, :functie, :salar_baza, :spor, :premii_brute, :salarizare_id, :total_brut, :brut_impozabil, :cas, :cass, :impozit, :retineri, :virat_card, :poza)";

                command.Parameters.Add(new OracleParameter("nume", nume));
                command.Parameters.Add(new OracleParameter("prenume", prenume));
                command.Parameters.Add(new OracleParameter("functie", functie));
                command.Parameters.Add(new OracleParameter("salar_baza", salarBaza));
                command.Parameters.Add(new OracleParameter("spor", spor));
                command.Parameters.Add(new OracleParameter("premii_brute", premiiBrute));
                command.Parameters.Add(new OracleParameter("salarizare_id", 1));
                command.Parameters.Add(new OracleParameter("total_brut", totalBrut));
                command.Parameters.Add(new OracleParameter("brut_impozabil", brutImpozabil));
                command.Parameters.Add(new OracleParameter("cas", cas));
                command.Parameters.Add(new OracleParameter("cass", cass));
                command.Parameters.Add(new OracleParameter("impozit", impozit));
                command.Parameters.Add(new OracleParameter("retineri", retineri));
                command.Parameters.Add(new OracleParameter("virat_card", viratCard));
                command.Parameters.Add(new OracleParameter("poza", (object)poza ?? DBNull.Value)); 

                command.ExecuteNonQuery();
            }
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Page.Validate("Reset");
        txtNume.Text = " ";
        txtPrenume.Text = " ";
        txtFunctie.Text = " ";
        txtSalarBaza.Text = " ";
        txtSpor.Text = "0";
        txtRetineri.Text = "0";
        filePoza.Attributes.Clear();
    }
}

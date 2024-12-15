using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActualizareDate : System.Web.UI.Page
{
    private string connectionString = "Data Source=andreimihai;User Id=STUDENT;Password=STUDENT;"; 
    private string _cas = "";
    private string _cass = "";
    private string _impozit = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Show_Table_Angajati();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchEmployee();
    }

    private void SearchEmployee()
    {
        List<Employees.Employee> employees = new List<Employees.Employee>();
        employees = Employees.GetAngajati();

        string searchNumePrenume = txtName.Text.Trim().ToLower();

        List<Employees.Employee> results = new List<Employees.Employee>();

        if (searchNumePrenume.Contains(' '))
        {
            string[] searchNP = searchNumePrenume.Split(' ');

            results = employees
            .Where(emp => (emp.Nume.ToLower().Contains(searchNP[0]) && emp.Prenume.ToLower().Contains(searchNP[1])))
            .ToList();
        }

        if (results.Any())
        {
            gvAngajat.DataSource = results;
            gvAngajat.DataBind();
            gvAngajat.Visible = true;
            errorMessage.Text = "";
        }
        else
        {
            errorMessage.Text = "Nu s-a găsit niciun angajat.";
            errorMessage.Visible = true;
            gvAngajat.Visible = false;
        }
    }

    protected void gvActualizare_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAngajat.EditIndex = e.NewEditIndex;
        SearchEmployee();
    }

    protected void gvActualizare_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.RowIndex);
        decimal nrCrt = 0;

        GridViewRow row = gvAngajat.Rows[e.RowIndex];
        string nume = ((TextBox)row.FindControl("txtNume")).Text;
        string prenume = ((TextBox)row.FindControl("txtPrenume")).Text;
        string functie = ((TextBox)row.FindControl("txtFunctie")).Text;
        decimal salarBaza = Convert.ToInt32(((TextBox)row.FindControl("txtSalarBaza")).Text);
        decimal spor = Convert.ToInt32(((TextBox)row.FindControl("txtSpor")).Text);
        decimal premiiBrute = Convert.ToInt32(((TextBox)row.FindControl("txtPremiiBrute")).Text);
        decimal retineri = Convert.ToInt32(((TextBox)row.FindControl("txtRetineri")).Text);

        if (int.TryParse(rowIndex.ToString(), out rowIndex))
        {
            nrCrt = Convert.ToInt32(gvAngajat.DataKeys[rowIndex].Value);
        }
        else
        {
            nrCrt = 0;
        }

        UpdateEmployeeData(nume, prenume, functie, salarBaza, spor, premiiBrute, retineri, nrCrt);

        gvAngajat.EditIndex = -1; 
        SearchEmployee();
        Show_Table_Angajati();
    }

    protected void gvActualizare_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAngajat.EditIndex = -1;
    }

    private void UpdateEmployeeData(string nume, string prenume, string functie, decimal salarBaza, decimal spor, decimal premiiBrute, decimal retineri, decimal nrCrt)
    {
        SalaryCalculation salaryCalc = new SalaryCalculation();
        List<Employees.Employee> employees = Employees.GetAngajati();
        Employees.Employee employee = new Employees.Employee();

        employee = employees.FirstOrDefault(emp => (emp.NrCrt==nrCrt));

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            conn.Open();
            try
            {
                GetFromSalarizare.GetSalarizare(out _cas, out _cass, out _impozit);
                string sql = "UPDATE Angajati SET nume = :nume, prenume = :prenume, functie = :functie, salar_baza = :salariuBaza, spor = :spor, premii_brute = :premiiBrute, total_brut =:total_brut, brut_impozabil =:brut_impozabil, CAS =:CAS, CASS =:CASS, Impozit =:Impozit, Retineri =:Retineri, Virat_Card =:Virat_Card WHERE NR_CRT = :nrCrt";
                decimal total_brut = salaryCalc.CalculateTotalBrut(salarBaza, spor, premiiBrute);
                decimal CAS = salaryCalc.CalculateCAS(total_brut, decimal.Parse(_cas.ToString()));
                decimal CASS = salaryCalc.CalculateCASS(total_brut, decimal.Parse(_cass.ToString()));
                decimal brut_impozabil = salaryCalc.CalculateBrutImpozabil(total_brut, CAS, CASS);
                decimal Impozit = salaryCalc.CalculateImpozit(brut_impozabil, decimal.Parse(_impozit.ToString()));
                decimal Virat_Card = salaryCalc.CalculateViratCard(brut_impozabil, Impozit, retineri);

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("nume", nume));
                        cmd.Parameters.Add(new OracleParameter("prenume", prenume));
                        cmd.Parameters.Add(new OracleParameter("functie", functie));
                        cmd.Parameters.Add(new OracleParameter("salariuBaza", salarBaza));
                        cmd.Parameters.Add(new OracleParameter("spor", spor));
                        cmd.Parameters.Add(new OracleParameter("premiiBrute", premiiBrute));
                        cmd.Parameters.Add(new OracleParameter("total_brut", total_brut));
                        cmd.Parameters.Add(new OracleParameter("brut_impozabil", brut_impozabil));
                        cmd.Parameters.Add(new OracleParameter("CAS", CAS));
                        cmd.Parameters.Add(new OracleParameter("CASS", CASS));
                        cmd.Parameters.Add(new OracleParameter("Impozit", Impozit));
                        cmd.Parameters.Add(new OracleParameter("Retineri", retineri));
                        cmd.Parameters.Add(new OracleParameter("Virat_Card", Virat_Card));
                        cmd.Parameters.Add(new OracleParameter("nrCrt", nrCrt));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                        }
                        else
                        {
                        }
                    }
                conn.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void gvActualizareAngajati_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAngajati.EditIndex = e.NewEditIndex;
        Show_Table_Angajati();
    }

    protected void gvActualizareAngajati_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.RowIndex);
        decimal nrCrt = 0;

        GridViewRow row = gvAngajati.Rows[e.RowIndex];
        string nume = ((TextBox)row.FindControl("txtNumeAng")).Text;
        string prenume = ((TextBox)row.FindControl("txtPrenumeAng")).Text;
        string functie = ((TextBox)row.FindControl("txtFunctieAng")).Text;
        decimal salarBaza = Convert.ToInt32(((TextBox)row.FindControl("txtSalarBazaAng")).Text);
        decimal spor = Convert.ToInt32(((TextBox)row.FindControl("txtSporAng")).Text);
        decimal premiiBrute = Convert.ToInt32(((TextBox)row.FindControl("txtPremiiBruteAng")).Text);
        decimal retineri = Convert.ToInt32(((TextBox)row.FindControl("txtRetineriAng")).Text);

        if (int.TryParse(rowIndex.ToString(), out rowIndex))
        {
            nrCrt = Convert.ToInt32(gvAngajati.DataKeys[rowIndex].Value);
        }
        else
        {
            nrCrt = 0;
        }

        UpdateEmployeeData(nume, prenume, functie, salarBaza, spor, premiiBrute, retineri, nrCrt);

        gvAngajati.EditIndex = -1;
        Show_Table_Angajati();
    }

    protected void gvActualizareAngajati_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAngajati.EditIndex = -1;
    }

    private void Show_Table_Angajati()
    {

        List<Employees.Employee> employees = new List<Employees.Employee>();
        employees = Employees.GetAngajati();

        string searchNumePrenume = txtName.Text.Trim().ToLower();

        if (employees.Any())
        {
            gvAngajati.DataSource = employees;
            gvAngajati.DataBind();
            gvAngajati.Visible = true;
            errorMessage.Text = "";
        }
        else
        {
            errorMessage.Text = "Nu s-a găsit niciun angajat.";
            errorMessage.Visible = true;
            gvAngajati.Visible = false;
        }
    }

}





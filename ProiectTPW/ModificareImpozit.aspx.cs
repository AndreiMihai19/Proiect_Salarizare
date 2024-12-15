using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificareImpozit : System.Web.UI.Page
{
    private readonly string connectionString = "Data Source=andreimihai;User Id=STUDENT;Password=STUDENT;";
    private string _cas = "";
    private string _cass = "";
    private string _impozit = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Show_Table_Salarizare();
        }
    }

    private void Show_Table_Salarizare()
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            string query = "SELECT cas, cass, impozit FROM Salarizare";
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        gvSalarizare.DataSource = dt;
                        gvSalarizare.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('A apărut o eroare: " + ex.Message + "');</script>");
                }
            }
        }
    }
    protected void gvSalarizare_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSalarizare.EditIndex = e.NewEditIndex;
        Show_Table_Salarizare();
    }

    protected void gvSalarizare_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvSalarizare.Rows[e.RowIndex];
        decimal cas = Convert.ToInt32(((TextBox)row.FindControl("txtCAS")).Text);
        decimal cass = Convert.ToInt32(((TextBox)row.FindControl("txtCASS")).Text);
        decimal impozit = Convert.ToInt32(((TextBox)row.FindControl("txtIMPOZIT")).Text);

        UpdateSalarizare(cas, cass, impozit);
        UpdateEmployeeData(cas, cass, impozit);

        gvSalarizare.EditIndex = -1; 
        Show_Table_Salarizare();
    }

    protected void gvSalarizare_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSalarizare.EditIndex = -1;
        Show_Table_Salarizare();
    }

    private void UpdateSalarizare(decimal cas, decimal cass, decimal impozit)
    {
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string query = "UPDATE Salarizare SET cas = :cas, cass = :cass, impozit = :impozit WHERE id = :id";
                OracleCommand cmd = new OracleCommand(query, connection);
                cmd.Parameters.Add(new OracleParameter(":cas", cas));
                cmd.Parameters.Add(new OracleParameter(":cass", cass));
                cmd.Parameters.Add(new OracleParameter(":impozit", impozit));
                cmd.Parameters.Add(new OracleParameter(":id", 1));

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
           
        }
    }

    private void UpdateEmployeeData(decimal cas, decimal cass, decimal impozit)
    {
        SalaryCalculation salaryCalc = new SalaryCalculation();
        var employees = Employees.GetAngajati();

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            conn.Open();
            try
            {
                foreach (var employee in employees)
                {
                    GetFromSalarizare.GetSalarizare(out _cas, out _cass, out _impozit);
                    string sql = "UPDATE Angajati SET total_brut =:total_brut, brut_impozabil =:brut_impozabil, CAS =:CAS, CASS =:CASS, Impozit =:Impozit, Virat_Card =:Virat_Card WHERE NR_CRT = :nrCrt";
                    decimal total_brut = salaryCalc.CalculateTotalBrut(employee.SalarBaza, employee.Spor, employee.PremiiBrute);
                    decimal CAS = salaryCalc.CalculateCAS(total_brut, decimal.Parse(_cas.ToString()));
                    decimal CASS = salaryCalc.CalculateCASS(total_brut, decimal.Parse(_cass.ToString()));
                    decimal brut_impozabil = salaryCalc.CalculateBrutImpozabil(total_brut, CAS, CASS);
                    decimal Impozit = salaryCalc.CalculateImpozit(brut_impozabil, decimal.Parse(_impozit.ToString()));
                    decimal Virat_Card = salaryCalc.CalculateViratCard(brut_impozabil, Impozit, employee.Retineri);

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("total_brut", total_brut));
                        cmd.Parameters.Add(new OracleParameter("brut_impozabil", brut_impozabil));
                        cmd.Parameters.Add(new OracleParameter("CAS", CAS));
                        cmd.Parameters.Add(new OracleParameter("CASS", CASS));
                        cmd.Parameters.Add(new OracleParameter("Impozit", Impozit));
                        cmd.Parameters.Add(new OracleParameter("Virat_Card", Virat_Card));
                        cmd.Parameters.Add(new OracleParameter("nrCrt", employee.NrCrt));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                        }
                        else
                        {

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
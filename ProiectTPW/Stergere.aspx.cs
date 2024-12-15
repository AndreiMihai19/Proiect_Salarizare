using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Stergere : System.Web.UI.Page
{
    private string connectionString = "Data Source=andreimihai;User Id=STUDENT;Password=STUDENT;"; 
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchEmployee();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "RequestDelete")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int nrCrt = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);

            HiddenNrCrtToDelete.Value = nrCrt.ToString();

            ConfirmationPanel.Visible = true;
            OverlayPanel.Visible = true;
        }

        if (e.CommandName == "DeleteEmployee")
        {
          
            int rowIndex;
            if (int.TryParse(e.CommandArgument.ToString(), out rowIndex))
            {
                int nrCrt = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);

                DeleteEmployeeById(nrCrt);

                errorMessage.Text = "Angajatul cu NrCrt " + nrCrt + " a fost sters cu succes.";
                errorMessage.Visible = true;
            }
            else
            {
                errorMessage.Text = "Eroare: Indexul nu a putut fi citit.";
                errorMessage.Visible = true;
            }
        }
    }


    protected void ConfirmDelete_Click(object sender, EventArgs e)
    {
        int nrCrt;
        if (int.TryParse(HiddenNrCrtToDelete.Value, out nrCrt))
        {
            DeleteEmployeeById(nrCrt);

            ConfirmationPanel.Visible = false;
            OverlayPanel.Visible = false;

            errorMessage.Text = "Angajatul a fost șters cu succes.";
            errorMessage.Visible = true;
        }
        SearchEmployee();
    }

    protected void CancelDelete_Click(object sender, EventArgs e)
    {
        ConfirmationPanel.Visible = false;
        OverlayPanel.Visible = false;
    }

    private bool DeleteEmployeeById(int nrCrt)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "DELETE FROM Angajati WHERE NR_CRT = :nrCrt";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("nrCrt", nrCrt));
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0; 
                }
                
            }
            catch (Exception ex)
            {
                errorMessage.Text = "A apărut o eroare la ștergerea înregistrării: " + ex.Message;
                errorMessage.CssClass = "error-message";
                return false;
            }
            
        }
    }

    private void SearchEmployee()
    {
        List<Employees.Employee> employees = new List<Employees.Employee>();
        employees = Employees.GetAngajati();

        string searchNumePrenume = txtName.Text.Trim().ToLower();

        List<Employees.Employee> results;

        if (searchNumePrenume.Contains(' '))
        {
            string[] searchNP = searchNumePrenume.Split(' ');

            results = employees
            .Where(emp => (emp.Nume.ToLower().Contains(searchNP[0]) && emp.Prenume.ToLower().Contains(searchNP[1])) || (emp.Nume.ToLower().Contains(searchNP[1]) && emp.Prenume.ToLower().Contains(searchNP[0])))
            .ToList();
        }
        else
        {
            results = employees
            .Where(emp => emp.Nume.ToLower().Contains(searchNumePrenume) || emp.Prenume.ToLower().Contains(searchNumePrenume))
            .ToList();
        }

        if (results.Any())
        {
            GridView1.DataSource = results;
            GridView1.DataBind();
            GridView1.Visible = true;
            errorMessage.Text = "";
        }
        else
        {
            errorMessage.Text = "Nu s-a găsit niciun angajat.";
            errorMessage.Visible = true;
            GridView1.Visible = false;
        }
    }
}
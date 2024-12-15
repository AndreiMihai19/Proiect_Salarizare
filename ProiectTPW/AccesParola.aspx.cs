using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccesParola : System.Web.UI.Page
{
    private string connectionString = "Data Source=andreimihai;User Id=STUDENT;Password=STUDENT";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnShowModal_Click(object sender, EventArgs e)
    {
        passwordPanel.Visible = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }

    protected void btnSubmitPassword_Click(object sender, EventArgs e)
    {
        string adminPassword = GetPassword();
        if (PasswordEncryptor.Encrypt(txtPassword.Text) == adminPassword)
        {
            passwordPanel.Visible = false;
            Response.Redirect("ModificareImpozit.aspx");
        }
        else
        {
            lblError.Visible = true;
            passwordPanel.Visible = true;
        }
    }

    public string GetPassword()
    {
        string password = string.Empty;

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            conn.Open();
            try
            {
                string sql = "SELECT parola FROM Salarizare WHERE id = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("id", 1)); 

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        password = result.ToString(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o eroare: " + ex.Message);
            }
        }

        return password;
    }


}
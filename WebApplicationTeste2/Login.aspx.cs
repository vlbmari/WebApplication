using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplicationTeste2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-560L90G;Database=Teste2;User ID = sa; Password=123;Trusted_Connection=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string mail = txtMail.Text;
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
                {
                    lblMessage.Text = "Todos os campos devem ser preenchidos.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Verificar usuário no banco de dados
                string query = "SELECT COUNT(*) FROM tbl_cadastro WHERE Mail = @Mail AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Mail", mail);
                    command.Parameters.AddWithValue("@Password", password); 

                    int count = (int)command.ExecuteScalar();
                    if (count == 0)
                    {
                        lblMessage.Text = "Email ou senha incorretos.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblMessage.Text = "Login realizado com sucesso!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this, GetType(), "redirect", "setTimeout(function() { window.location = 'VisualizarUsuarios.aspx'; }, 1000);", true);

                    }
                }
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplicationTeste2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-560L90G;Database=Teste2;User ID = sa; Password=07092002;Trusted_Connection=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string name = txtName.Text;
                string lastname = txtLastname.Text;
                string mail = txtMailC.Text;
                string password = txtPasswordC.Text;
                string confirmPass = txtConfirmPassword.Text;

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(mail) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPass))
                {
                    lblMessageC.Text = "Todos os campos devem ser preenchidos.";
                    lblMessageC.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (confirmPass != password)
                {
                    lblMessageC.Text = "As senhas não coincidem.";
                    lblMessageC.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Inserir usuário no banco de dados
                string query = "INSERT INTO tbl_cadastro(name, lastname, mail, password) VALUES (@name, @lastname, @mail, @password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Lastname", lastname);
                command.Parameters.AddWithValue("@Mail", mail);
                command.Parameters.AddWithValue("@Password", password); 
                
                    command.ExecuteNonQuery();
                }

                lblMessageC.Text = "Cadastro realizado com sucesso!";
                lblMessageC.ForeColor = System.Drawing.Color.Green;

                
                ScriptManager.RegisterStartupScript(this, GetType(), "redirect", "setTimeout(function() { window.location = 'Login.aspx'; }, 1000);", true);

            }
        }
    }
}

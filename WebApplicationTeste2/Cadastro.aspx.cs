using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTeste2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCidades();
            }
            string valorCidade = ddlCidades.SelectedValue;
        }

        private void CarregarCidades()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string consulta = "SELECT pk_cidade, nome FROM tbl_cidade";
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    conexao.Open();
                    DataTable dtCidades = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(dtCidades);

                    ddlCidades.DataSource = dtCidades;
                    ddlCidades.DataTextField = "nome";  
                    ddlCidades.DataValueField = "pk_cidade";  
                    ddlCidades.DataBind();
                }
            }

            
            ddlCidades.Items.Insert(0, new ListItem("Selecione uma cidade", "0"));
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string name = txtName.Text;
                string lastname = txtLastname.Text;
                string mail = txtMailC.Text;
                string password = txtPasswordC.Text;
                string confirmPass = txtConfirmPassword.Text;
                int cidadeId = Convert.ToInt32(ddlCidades.SelectedValue);
                // int UFid = Convert.ToInt32(Request.Form["ddlUF"]);


                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(mail) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPass) || cidadeId == 0)
                {
                    lblMessageC.Text = "Todos os campos, inclusive a cidade, devem ser preenchidos.";
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
                string query = "INSERT INTO tbl_cadastro(name, lastname, mail, password, fk_cidade) VALUES (@name, @lastname, @mail, @password, @fk_cidade)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@lastname", lastname);
                    command.Parameters.AddWithValue("@mail", mail);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@fk_cidade", cidadeId); 

                    command.ExecuteNonQuery();
                }

                lblMessageC.Text = "Cadastro realizado com sucesso!";
                lblMessageC.ForeColor = System.Drawing.Color.Green;

                
                ScriptManager.RegisterStartupScript(this, GetType(), "redirect", "setTimeout(function() { window.location = 'Login.aspx'; }, 1000);", true);
            }
        }

        
    }
}

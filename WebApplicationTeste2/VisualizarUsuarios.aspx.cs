using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTeste2
{
    public partial class VisualizarUsuarios : System.Web.UI.Page
    {
        private string connectionString = "Server=DESKTOP-560L90G;Database=Teste2;User ID = sa; Password=07092002;Trusted_Connection=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarUsuarios();
            }
        }

        private void CarregarUsuarios()
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string consulta = "SELECT * FROM tbl_cadastro";
                using (SqlCommand comando = new SqlCommand(consulta, conexao))
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabelaUsuarios = new DataTable();
                    adaptador.Fill(tabelaUsuarios);
                    GridViewUsuarios.DataSource = tabelaUsuarios;
                    GridViewUsuarios.DataBind();
                }
            }
        }

        protected void GridViewUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewUsuarios.EditIndex = e.NewEditIndex;
            CarregarUsuarios();
        }

        protected void GridViewUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewUsuarios.EditIndex = -1;
            CarregarUsuarios();
        }

        protected void GridViewUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewUsuarios.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridViewUsuarios.DataKeys[e.RowIndex].Value);
            string nome = ((TextBox)(row.Cells[1].Controls[0])).Text;
            string sobrenome = ((TextBox)(row.Cells[2].Controls[0])).Text;
            string email = ((TextBox)(row.Cells[3].Controls[0])).Text;
            string senha = ((TextBox)(row.Cells[4].Controls[0])).Text;

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                
                string query = "UPDATE tbl_cadastro SET name=@Name, lastname=@Lastname, mail=@Mail, password=@Password WHERE id=@Id";
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.Parameters.AddWithValue("@Name", nome);
                    comando.Parameters.AddWithValue("@Lastname", sobrenome);
                    comando.Parameters.AddWithValue("@Mail", email);
                    comando.Parameters.AddWithValue("@Password", senha);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
            }

            GridViewUsuarios.EditIndex = -1;
            CarregarUsuarios();
        }

        protected void GridViewUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewUsuarios.DataKeys[e.RowIndex].Value);

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                //Deletar dados na tabela do banco de dados
                string query = "DELETE FROM tbl_cadastro WHERE id=@Id";
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", id);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
            }

            CarregarUsuarios();
        }
    }
}

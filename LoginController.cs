using System.Data.SqlClient;
using ControleDeTarefas.Models;
using ControleDeTarefas.Database;

namespace ControleDeTarefas.Controllers
{
    public class LoginController
    {
        private readonly Conexao conexao = new Conexao();

        public Usuario Autenticar(string email, string senha)
        {
            Usuario usuario = null;

            string query = "SELECT * FROM Usuarios WHERE email = @Email AND senha = @Senha";

            using (SqlCommand cmd = new SqlCommand(query, conexao.Abrir()))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senha);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Id = (int)reader["id"],
                        Nome = reader["nome"].ToString(),
                        Email = reader["email"].ToString(),
                        Senha = reader["senha"].ToString()
                    };
                }

                conexao.Fechar();
            }

            return usuario;
        }
    }
}

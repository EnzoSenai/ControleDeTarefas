using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ControleDeTarefas.Models;
using ControleDeTarefas.Database;

namespace ControleDeTarefas.Controllers
{
    public class TarefaController
    {
        private readonly Conexao conexao = new Conexao();

        public List<Tarefa> ListarPorUsuario(int idUsuario)
        {
            List<Tarefa> tarefas = new List<Tarefa>();

            string query = "SELECT * FROM Tarefas WHERE id_usuario = @IdUsuario ORDER BY data, horario";

            using (SqlCommand cmd = new SqlCommand(query, conexao.Abrir()))
            {
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Tarefa tarefa = new Tarefa
                    {
                        Id = (int)reader["id"],
                        IdUsuario = (int)reader["id_usuario"],
                        Data = (DateTime)reader["data"],
                        Horario = (TimeSpan)reader["horario"],
                        Descricao = reader["descricao"].ToString()
                    };

                    tarefas.Add(tarefa);
                }

                conexao.Fechar();
            }

            return tarefas;
        }

        public void Adicionar(Tarefa tarefa)
        {
            string query = "INSERT INTO Tarefas (id_usuario, data, horario, descricao) VALUES (@IdUsuario, @Data, @Horario, @Descricao)";

            using (SqlCommand cmd = new SqlCommand(query, conexao.Abrir()))
            {
                cmd.Parameters.AddWithValue("@IdUsuario", tarefa.IdUsuario);
                cmd.Parameters.AddWithValue("@Data", tarefa.Data);
                cmd.Parameters.AddWithValue("@Horario", tarefa.Horario);
                cmd.Parameters.AddWithValue("@Descricao", tarefa.Descricao);
                cmd.ExecuteNonQuery();

                conexao.Fechar();
            }
        }

        public void Atualizar(Tarefa tarefa)
        {
            string query = "UPDATE Tarefas SET data = @Data, horario = @Horario, descricao = @Descricao WHERE id = @Id";

            using (SqlCommand cmd = new SqlCommand(query, conexao.Abrir()))
            {
                cmd.Parameters.AddWithValue("@Data", tarefa.Data);
                cmd.Parameters.AddWithValue("@Horario", tarefa.Horario);
                cmd.Parameters.AddWithValue("@Descricao", tarefa.Descricao);
                cmd.Parameters.AddWithValue("@Id", tarefa.Id);
                cmd.ExecuteNonQuery();

                conexao.Fechar();
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM Tarefas WHERE id = @Id";

            using (SqlCommand cmd = new SqlCommand(query, conexao.Abrir()))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                conexao.Fechar();
            }
        }
    }
}
✅ /Database/Conexao.cs
csharp
Copiar
Editar
using System.Data.SqlClient;

namespace ControleDeTarefas.Database
{
    public class Conexao
    {
        private readonly SqlConnection conexao = new SqlConnection(
            "Server=localhost;Database=ControleDeTarefas;Trusted_Connection=True;");

        public SqlConnection Abrir()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();
            return conexao;
        }

        public void Fechar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}

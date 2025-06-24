using System.Data.SqlClient;

public class Conexao
{
    private SqlConnection conexao = new SqlConnection(
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

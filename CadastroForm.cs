using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ControleDeTarefas.Database;

namespace ControleDeTarefas.Forms
{
    public partial class CadastroForm : Form
    {
        public CadastroForm()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            string query = "INSERT INTO Usuarios (nome, email, senha) VALUES (@Nome, @Email, @Senha)";

            using (SqlCommand cmd = new SqlCommand(query, conexao.Abrir()))
            {
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Senha", txtSenha.Text);
                cmd.ExecuteNonQuery();
                conexao.Fechar();
            }

            MessageBox.Show("Usuário cadastrado com sucesso!");
            this.Close();
        }
    }
}

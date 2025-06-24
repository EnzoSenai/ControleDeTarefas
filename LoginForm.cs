using System;
using System.Windows.Forms;
using ControleDeTarefas.Controllers;

namespace ControleDeTarefas.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var controller = new LoginController();
            var usuario = controller.Autenticar(txtEmail.Text, txtSenha.Text);

            if (usuario != null)
            {
                this.Hide();
                MainForm main = new MainForm(usuario);
                main.Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.");
            }
        }
    }
}

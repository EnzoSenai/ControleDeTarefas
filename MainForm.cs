using System;
using System.Windows.Forms;
using ControleDeTarefas.Controllers;
using ControleDeTarefas.Models;

namespace ControleDeTarefas.Forms
{
    public partial class MainForm : Form
    {
        private Usuario usuarioLogado;
        private TarefaController tarefaController = new TarefaController();

        public MainForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
            CarregarTarefas();
        }

        private void CarregarTarefas()
        {
            var tarefas = tarefaController.ListarPorUsuario(usuarioLogado.Id);
            dgvTarefas.DataSource = tarefas;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Tarefa tarefa = new Tarefa
            {
                IdUsuario = usuarioLogado.Id,
                Data = dtpData.Value.Date,
                Horario = dtpHora.Value.TimeOfDay,
                Descricao = txtDescricao.Text
            };

            tarefaController.Adicionar(tarefa);
            CarregarTarefas();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvTarefas.CurrentRow != null)
            {
                int id = (int)dgvTarefas.CurrentRow.Cells["Id"].Value;
                tarefaController.Excluir(id);
                CarregarTarefas();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvTarefas.CurrentRow != null)
            {
                Tarefa tarefa = new Tarefa
                {
                    Id = (int)dgvTarefas.CurrentRow.Cells["Id"].Value,
                    Data = dtpData.Value.Date,
                    Horario = dtpHora.Value.TimeOfDay,
                    Descricao = txtDescricao.Text
                };

                tarefaController.Atualizar(tarefa);
                CarregarTarefas();
            }
        }
    }
}

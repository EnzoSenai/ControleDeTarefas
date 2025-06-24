using System;

namespace ControleDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Horario { get; set; }
        public string Descricao { get; set; }

        public Tarefa() { }

        public Tarefa(int id, int idUsuario, DateTime data, TimeSpan horario, string descricao)
        {
            Id = id;
            IdUsuario = idUsuario;
            Data = data;
            Horario = horario;
            Descricao = descricao;
        }
    }
}

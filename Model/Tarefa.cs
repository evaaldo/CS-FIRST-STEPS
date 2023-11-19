using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTarefas.Model
{
    public class Tarefa
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public bool Concluida { get; set; }
    }
}
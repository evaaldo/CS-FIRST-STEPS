using GerenciamentoTarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefas.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
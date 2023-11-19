using GerenciamentoTarefas.Context;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefas.Controller
{
    [Route("Tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContext? _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }

        private bool TarefaExists(Guid id)
        {
            return(_context.Tarefas?.Any(tarefa => tarefa.ID == id)).GetValueOrDefault();
        }
    }
}
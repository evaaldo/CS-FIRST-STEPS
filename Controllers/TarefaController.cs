using GerenciamentoTarefas.Context;
using GerenciamentoTarefas.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefa()
        {
            if(_context.Tarefas == null)
            {
                return NotFound();
            }

            return await _context.Tarefas.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(Guid id)
        {
            if(_context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas.FindAsync(id);

            if(tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        private bool TarefaExists(Guid id)
        {
            return(_context.Tarefas?.Any(tarefa => tarefa.ID == id)).GetValueOrDefault();
        }
    }
}
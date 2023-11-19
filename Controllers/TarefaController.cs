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

        private bool TarefaExists(Guid id)
        {
            return(_context.Tarefas?.Any(tarefa => tarefa.ID == id)).GetValueOrDefault();
        }
    }
}
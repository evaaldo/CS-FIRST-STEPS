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

        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
        {
            if(_context.Tarefas == null)
            {
                return Problem("Construtor vazio!");
            }

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefa", new { id = tarefa.ID }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(Guid id, Tarefa tarefa)
        {
            if(tarefa.ID != id)
            {
                return BadRequest();
            }

            _context.Tarefas.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(Guid id)
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

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaExists(Guid id)
        {
            return(_context.Tarefas?.Any(tarefa => tarefa.ID == id)).GetValueOrDefault();
        }
    }
}
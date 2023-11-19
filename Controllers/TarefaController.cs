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
    }
}
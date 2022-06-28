using EscolaWebApi.Data;
using EscolaWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly EscolaContext _context;

        public TurmasController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetTurmas()
        {
            IQueryable<Turma> query = _context.Turmas;
            return Ok(query.ToArray());
        }


        [HttpGet("GetTurmaById")]
        public async Task<ActionResult> GetTurmasById(int turmaId)
        {
            IQueryable<Turma> query = _context.Turmas
            .Where(turma => turma.Id == turmaId);

            return Ok(query.ToArray());
        }

        [HttpPost]
        public async Task<ActionResult<List<Turma>>> Post(Turma turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();

            return await GetTurmas();
        }

        
    }
}

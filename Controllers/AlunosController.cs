using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EscolaWebApi.Models;
using EscolaWebApi.Data;

namespace EscolaWebApi.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly EscolaContext _context;
        public AlunosController(EscolaContext escolaContext)
        {
            _context = escolaContext;
        }

        [HttpGet("GetAlunos")]
        public async Task<ActionResult> GetAlunos()
        {
            IQueryable<Aluno> query = _context.Alunos;
            return Ok(query.ToArray());
        }
    }
}

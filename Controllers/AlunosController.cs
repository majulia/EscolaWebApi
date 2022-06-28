using EscolaWebApi.Data;
using EscolaWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("GetAlunoById")]

        public async Task<ActionResult> GetAlunosById(int alunoId)
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.AsNoTracking().OrderBy(a => a.Id)
            .Where(aluno => aluno.Id == alunoId);

            return Ok(query.ToArray());
        }

        [HttpPost]
        public async Task<ActionResult<List<Aluno>>> Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);

            if (aluno.TurmaId != 0)
                await _context.SaveChangesAsync();

            return await GetAlunos();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            return BadRequest("Aluno não encontrado");
            
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await GetAlunos();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return await GetAlunos();
        }

    }
}

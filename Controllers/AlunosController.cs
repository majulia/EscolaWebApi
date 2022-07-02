using EscolaWebApi.Data;
using EscolaWebApi.Data.Interfaces;
using EscolaWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepository _repo;
        public AlunosController(IAlunoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAlunos")]
        public IActionResult Get()
        {
            var result = _repo.BuscaAluno();
            return Ok(result);
        }

        [HttpGet("GetAlunosById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repo.BuscaAluno(id);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.AddAluno(aluno);
            return Ok(aluno);
        }

        [HttpPut]
        public IActionResult Put(Aluno aluno)
        {
            var result = _repo.UpdateAluno(aluno);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.DeleteAluno(id);
            return Ok(result);
        }

    }
}

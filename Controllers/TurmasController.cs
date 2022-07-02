using EscolaWebApi.Data;
using EscolaWebApi.Data.Interfaces;
using EscolaWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaRepository _repo;

        public TurmasController(ITurmaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetTurmas")]
        public IActionResult Get()
        {
            var result = _repo.BuscaTurma();
            return Ok(result);
        }

        [HttpGet("GetTurmasById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repo.BuscaTurma(id);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Post(Turma turma)
        {
            _repo.AddTurma(turma);
            return Ok(turma);
        }

        [HttpPut]
        public IActionResult Put(Turma turma)
        {
            var result = _repo.UpdateTurma(turma);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.DeleteTurma(id);
            return Ok(result);
        }




    }
}

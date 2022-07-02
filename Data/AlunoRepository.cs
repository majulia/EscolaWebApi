using EscolaWebApi.Data.Interfaces;
using EscolaWebApi.Models;

namespace EscolaWebApi.Data
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly EscolaContext _context;
        public AlunoRepository(EscolaContext context)
        {
            _context = context;
        }

        public void AddAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
             _context.SaveChangesAsync();

        }

        public Aluno BuscaAluno(int id)
        {
            IQueryable<Aluno> query = _context.Alunos
                .Where(a => a.Id == id && a.Ativo);
            return query.FirstOrDefault();
        }

        public IEnumerable<Aluno> BuscaAluno()
        {
            IQueryable<Aluno> query = _context.Alunos
                .Where(a => a.Ativo);
            return query.ToList();
        }

        public bool DeleteAluno(int id)
        {
            var aluno = BuscaAluno(id);
            if (aluno == null)
                return false;

            _context.Alunos.Remove(aluno);
            var linhas = _context.SaveChangesAsync();

            return linhas.Result > 0 ? true : false;
        }

        public bool UpdateAluno(Aluno aluno)
        {
            var alunoDb = BuscaAluno(aluno.Id);
            if (alunoDb == null)
                return false;

            alunoDb.Nome = aluno.Nome;
            alunoDb.Sexo = aluno.Sexo;
            alunoDb.DataNascimento = aluno.DataNascimento;
            alunoDb.TotalFaltas = aluno.TotalFaltas;
            alunoDb.TurmaId = aluno.TurmaId;

            var linhas = _context.SaveChangesAsync();

            return linhas.Result > 0 ? true : false;
        }
    }
}

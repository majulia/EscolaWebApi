using EscolaWebApi.Data.Interfaces;
using EscolaWebApi.Models;

namespace EscolaWebApi.Data
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly EscolaContext _context;
        public TurmaRepository(EscolaContext context)
        {
            _context = context;
        }

        public void AddTurma(Turma turma)
        {
            _context.Turmas.Add(turma);
            _context.SaveChangesAsync();
        }

        public Turma BuscaTurma(int id)
        {
            IQueryable<Turma> query = _context.Turmas
                .Where(t => t.Id == id && t.Ativo);
            return query.FirstOrDefault();
        }

        public IEnumerable<Turma> BuscaTurma()
        {
            IQueryable<Turma> query = _context.Turmas
                .Where(t => t.Ativo);
            return query.ToList();
        }

        public bool DeleteTurma(int id)
        {
            Aluno aluno = _context.Alunos
                .Where(a => a.TurmaId == id)
                .FirstOrDefault();
            if (aluno != null)
                return false;

            var turma = BuscaTurma(id);
            if (turma == null)
                return false;

            _context.Turmas.Remove(turma);

            var linhas = _context.SaveChangesAsync();

            return linhas.Result > 0 ? true : false;
        }

        public bool UpdateTurma(Turma turma)
        {
            var turmaDb = BuscaTurma(turma.Id);
            if (turmaDb == null)
                return false;


            turmaDb.Nome = turma.Nome;
            turmaDb.Ativo = turma.Ativo;

            var linhas = _context.SaveChangesAsync();

            return linhas.Result > 0 ? true : false;
        }
    }
}

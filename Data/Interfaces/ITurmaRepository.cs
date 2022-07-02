using EscolaWebApi.Models;

namespace EscolaWebApi.Data.Interfaces
{
    public interface ITurmaRepository
    {
        Turma BuscaTurma(int id);
        IEnumerable<Turma> BuscaTurma();
        void AddTurma(Turma turma);
        bool UpdateTurma(Turma turma);
        bool DeleteTurma(int id);
    }
}

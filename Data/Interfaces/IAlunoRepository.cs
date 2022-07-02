using EscolaWebApi.Models;

namespace EscolaWebApi.Data.Interfaces
{
    public interface IAlunoRepository
    {
        Aluno BuscaAluno(int id);
        IEnumerable<Aluno> BuscaAluno();
        void AddAluno(Aluno aluno);
        bool UpdateAluno(Aluno aluno);
        bool DeleteAluno(int id);

    }
}

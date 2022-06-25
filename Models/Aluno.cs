using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaWebApi.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Column("dataNascimento")]
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public int TotalFaltas { get; set; }
        public int TurmaId { get; set; }
    }
}

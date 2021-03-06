using EscolaWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaWebApi.Data
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("aluno");
            modelBuilder.Entity<Turma>().ToTable("turma");
        }
    }
}

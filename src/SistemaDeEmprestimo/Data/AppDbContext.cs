using Microsoft.EntityFrameworkCore;
using SistemaDeEmprestimo.Models;


namespace SistemaDeEmprestimo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //define as casas decimais pro valor
            modelBuilder.Entity<Emprestimo>()
            .Property(e => e.Valor)
            .HasPrecision(18,2);

            //impede de apagar o user inteiro quando fizer um DELETE
            modelBuilder.Entity<Emprestimo>()
            .HasOne(e => e.UserCredor)
            .WithMany(u => u.EmprestimoComoCredor)
            .HasForeignKey(e => e.UserCredorId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Emprestimo>()
            .HasOne(e => e.UserDevedor)
            .WithMany(u => u.EmprestimoComoDevedor)
            .HasForeignKey(e => e.UserDevedorId)
            .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Emprestimo> Emprestimos {get; set;}
        public DbSet<User> Users {get; set;}
    }
}
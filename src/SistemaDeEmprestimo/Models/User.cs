using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


//User.cs
namespace SistemaDeEmprestimo.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } 

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CriadoEm{ get; set; }

        public DateTime? AtualizadoEm{ get; set; }
    
        public ICollection<Emprestimo> EmprestimoComoCredor { get; set; }
    
        public ICollection<Emprestimo> EmprestimoComoDevedor { get; set; }
    
    }
}
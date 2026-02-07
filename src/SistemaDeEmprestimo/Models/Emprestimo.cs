using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Empretimo.cs
namespace SistemaDeEmprestimo.Models
{
    public class Emprestimo
    {
        public Guid Id { get; set; }

        public decimal Valor { get; set; }
 
        public EnumStatusEmprestimo Status { get; set; }

        public DateTime CriadoEm { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime? PagoEm { get; set; }


        //relacionamento externo
        public Guid UserCredorId { get; set; }
        public User UserCredor { get; set; }
        public Guid UserDevedorId { get; set; }
        public User UserDevedor { get; set; }
 
    }
}
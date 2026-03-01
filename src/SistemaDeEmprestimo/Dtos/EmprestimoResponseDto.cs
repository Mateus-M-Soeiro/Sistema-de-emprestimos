using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeEmprestimo.Models;

namespace SistemaDeEmprestimo.Dtos
{
    public class EmprestimoResponseDto
    {
        public Guid Id { get; set; }

        public decimal ValorOriginal { get; set; }
        public decimal ValorPago { get; set; }

        // public decimal ValorRestante { get; set; }
        public decimal ValorRestante => ValorOriginal - ValorPago;

        public EnumStatusEmprestimo Status { get; set; }

        public DateTime DataLimite { get; set; }

        public Guid UserCredorId { get; set; }
        public Guid UserDevedorId { get; set; }
    }
}
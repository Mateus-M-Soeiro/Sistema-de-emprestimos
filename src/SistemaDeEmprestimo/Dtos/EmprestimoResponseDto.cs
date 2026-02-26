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

        public decimal Valor { get; set; }

        public EnumStatusEmprestimo Status { get; set; }

        public DateTime DataLimite { get; set; }

        public Guid UserCredorId { get; set; }
        public Guid UserDevedorId { get; set; }
    }
}
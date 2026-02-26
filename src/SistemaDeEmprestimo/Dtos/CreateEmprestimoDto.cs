using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeEmprestimo.Dtos
{
    public class CreateEmprestimoDto
    {
        

        public decimal Valor { get; set; }
        public Guid UserCredorId { get; set; }
        public Guid UserDevedorId { get; set; }

        public DateTime DataLimite { get; set; }



    }
}
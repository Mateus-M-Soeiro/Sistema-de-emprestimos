
//RespostaUserDto.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeEmprestimo.Dtos
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
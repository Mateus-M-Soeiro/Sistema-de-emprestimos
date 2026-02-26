
//CriarUserDto.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeEmprestimo.Dtos
{
    public class CreateUserDto
    {
        
        [Required]
        [MinLength(2)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        public string Password { get; set; }

    }
}
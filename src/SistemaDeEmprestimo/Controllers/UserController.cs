//CreateUser.cs CONTROLLER

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SistemaDeEmprestimo.Data;
using SistemaDeEmprestimo.Dtos;
using SistemaDeEmprestimo.Models;

namespace SistemaDeEmprestimo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // private readonly ILogger<CreateUser> _logger;

        // public CreateUser(ILogger<CreateUser> logger)
        // {
        //     _logger = logger;
        // }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            
            _context = context;

        }

        
        [HttpPost]
        public async Task<IActionResult> CriarUsuario(CreateUserDto dto)
        {

            var user = new User
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CriadoEm = DateTime.UtcNow,
                AtualizadoEm = DateTime.UtcNow
            };

            _context.Add(user);
            //_context.SaveChanges();
            await _context.SaveChangesAsync();
            var Response = new UserResponseDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email
            };

            return CreatedAtAction(nameof(ObterPorId),new {id =  user.Id}, Response);
            // return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid Id){
        
            var user = _context.Users.Find(Id);

            if(user == null) return NotFound();
            var Response = new UserResponseDto
            {
              Id = user.Id,Nome = user.Nome,Email = user.Email  
            };

            
        return Ok(Response);
        }


        [HttpGet]
        public IActionResult ObterUsuarios()
        {
            var usuarios = _context.Users;

            var Response = usuarios.Select(user => new UserResponseDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email
            });
            return Ok(Response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(Guid id)
        {
            var user = _context.Users.Find(id);
            if(user == null) return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
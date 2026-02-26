using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaDeEmprestimo.Data;
using SistemaDeEmprestimo.Dtos;
using SistemaDeEmprestimo.Models;

namespace SistemaDeEmprestimo.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly AppDbContext _context;
        public EmprestimoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<EmprestimoResponseDto> RegistrarAsync(CreateEmprestimoDto dto)
        {
            if(dto.UserCredorId == dto.UserDevedorId) 
                // return BadRequest("Credor e Devedor devem ser diferentes");// mudei de forbbiden para badrequest
                throw new Exception("Credor e Devedor devem ser diferentes");

            if(dto.Valor <= 0) 
                // return BadRequest("Valor precisa ser maior que zero");
                throw new Exception("Valor precisa ser maior que zero");

            var UserDevedor = await _context.Users.FindAsync(dto.UserDevedorId);
            var UserCredor = await _context.Users.FindAsync(dto.UserCredorId);

            if(UserDevedor == null) 
                // return NotFound("Devedor não encontrado");
                throw new Exception("Devedor não encontrado");

            if(UserCredor == null) 
                // return NotFound("Credor não encontrado");
                throw new Exception("Credor não encontrado");
            if(dto.DataLimite <= DateTime.UtcNow) 
                // return BadRequest("Data limite deve ser futura");
                throw new Exception("Data limite deve ser futura");

            var novoEmprestimo = new Emprestimo
            {
             
              Valor = dto.Valor,
              Status = EnumStatusEmprestimo.Ativo,
              DataLimite = dto.DataLimite,
              CriadoEm = DateTime.UtcNow,

              UserCredorId = dto.UserCredorId,
              UserDevedorId = dto.UserDevedorId,

            };        

            _context.Emprestimos.Add(novoEmprestimo);
            await _context.SaveChangesAsync();    

            return new EmprestimoResponseDto
            {
                Id = novoEmprestimo.Id,
                Valor = novoEmprestimo.Valor,
                Status = novoEmprestimo.Status,
                DataLimite = novoEmprestimo.DataLimite,
                UserCredorId = novoEmprestimo.UserCredorId,
                UserDevedorId = novoEmprestimo.UserDevedorId

            };        
            
        }

        public async Task<bool> PagarAsync(Guid id)
        {
            var Emprestimo = await _context.Emprestimos.FindAsync(id);

            if(Emprestimo == null)
                // return NotFound();
                return false;
                
            if(Emprestimo.Status == EnumStatusEmprestimo.Pago) 
                // return BadRequest("Emprestimo já foi pago");
                return false;

            Emprestimo.Status = EnumStatusEmprestimo.Pago;
            Emprestimo.PagoEm = DateTime.UtcNow;
            // await _context.AddAsync(Emprestimo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<EmprestimoResponseDto> ObterPorIdAsync(Guid id)
        {
            var Emprestimo = await _context.Emprestimos.FindAsync(id);
            return new EmprestimoResponseDto
            {
                Id = Emprestimo.Id,
                Valor = Emprestimo.Valor,
                Status = Emprestimo.Status,
                DataLimite = Emprestimo.DataLimite,
                UserCredorId = Emprestimo.UserCredorId,
                UserDevedorId = Emprestimo.UserDevedorId
            };
        }

        public async Task<IEnumerable<EmprestimoResponseDto>> ObterTodosAsync()
        {
            // var Emprestimos = _context.Emprestimos;
            return await _context.Emprestimos
            .Select(Emprestimo => new EmprestimoResponseDto{
            Id = Emprestimo.Id,
            Valor = Emprestimo.Valor,
            Status = Emprestimo.Status,
            DataLimite = Emprestimo.DataLimite,
            UserCredorId = Emprestimo.UserCredorId,
            UserDevedorId = Emprestimo.UserDevedorId

            }).ToListAsync();

        }

    }
}
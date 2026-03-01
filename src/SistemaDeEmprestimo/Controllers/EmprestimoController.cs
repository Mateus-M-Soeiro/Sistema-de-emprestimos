using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaDeEmprestimo.Data;
using SistemaDeEmprestimo.Dtos;
using SistemaDeEmprestimo.Models;
using SistemaDeEmprestimo.Services;

namespace SistemaDeEmprestimo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmprestimoController : ControllerBase
    {
        
        private readonly IEmprestimoService _service;
        // private readonly AppDbContext _context;
        
        public EmprestimoController(IEmprestimoService service)
        {
            
            _service = service;

        }


        // public EmprestimoController(AppDbContext context)
        // {
        //     _context = context;

        // }

        [HttpPost]

        public async Task<IActionResult> RegistrarEmprestimo(CreateEmprestimoDto dto)
        {

            try
            {
                var response = await _service.RegistrarAsync(dto);
                return CreatedAtAction(nameof(ObterPorId),new {id = response.Id},response);
            }
            catch(Exception err) 
            {
                return BadRequest(err.Message);
                
            }
            // return CreatedAtAction(nameof(ObterPorId),new {id = novoEmprestimo.Id},Response);
        }

        [HttpPut("{id}/pagar")]

        public async Task<IActionResult> PagarEmprestimo(Guid id)
        {
            
            var response = await _service.PagarAsync(id);

            if(response != true)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}/registrar-pagamento")]
        public async Task<IActionResult> RegistrarPagamento(Guid id, RegistrarPagamentoDto dto)
        {
            var resultado = await _service.RegistrarPagamento(id, dto.Valor);

            return resultado switch
            {
                EnumResultadoPagamento.NaoEncontrado => NotFound(),
                EnumResultadoPagamento.JaPago => BadRequest("Empréstimo já pago."),
                EnumResultadoPagamento.ValorInvalido => BadRequest("Valor inválido."),
                EnumResultadoPagamento.ValorMaiorQueRestante => BadRequest("Valor maior que o restante da dívida."),
                _ => NoContent()
            };
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {   
            var response = await _service.ObterPorIdAsync(id);
            return Ok(response);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterEmprestimos()
        {


            // var Emprestimos = _context.Emprestimos;
            // var Response = Emprestimos.Select(Emprestimo=> new EmprestimoResponseDto{
            // Id = Emprestimo.Id,
            // Valor = Emprestimo.Valor,
            // Status = Emprestimo.Status,
            // DataLimite = Emprestimo.DataLimite,
            // UserCredorId = Emprestimo.UserCredorId,
            // UserDevedorId = Emprestimo.UserDevedorId

            // });


            try
            {
                var response = await _service.ObterTodosAsync();
                return Ok(response);
            }catch(Exception err)
            {
                return BadRequest(err.Message);

            }

            // return Ok(Response);
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeEmprestimo.Dtos;
using SistemaDeEmprestimo.Models;

namespace SistemaDeEmprestimo.Services
{
    public interface IEmprestimoService
    {
        Task<EmprestimoResponseDto> RegistrarAsync(CreateEmprestimoDto dto);
        Task<bool> PagarAsync(Guid id);
        Task<EnumResultadoPagamento> RegistrarPagamento(Guid id,decimal valor);
        Task<EmprestimoResponseDto> ObterPorIdAsync(Guid id);
        Task<IEnumerable<EmprestimoResponseDto>> ObterTodosAsync();
    }
}
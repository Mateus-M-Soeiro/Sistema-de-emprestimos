using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeEmprestimo.Dtos;

namespace SistemaDeEmprestimo.Services
{
    public interface IEmprestimoService
    {
        Task<EmprestimoResponseDto> RegistrarAsync(CreateEmprestimoDto dto);
        Task<bool> PagarAsync(Guid id);
        Task<EmprestimoResponseDto> ObterPorIdAsync(Guid id);
        Task<IEnumerable<EmprestimoResponseDto>> ObterTodosAsync();
    }
}
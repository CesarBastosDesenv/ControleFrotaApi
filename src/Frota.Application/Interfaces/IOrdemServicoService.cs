using System;
using Frota.Application.Dto;

namespace Frota.Application.Interfaces;

public interface IOrdemServicoService
{
    Task<ResultViewModel> AddAsync(OrdemServicoCadastro ordemServico);

    Task<ResultViewModel> UpdateAsync(OrdemServicoCadastro ordemServico);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<ResultViewModel> BuscaOrdemServicoId(Guid Id);
}

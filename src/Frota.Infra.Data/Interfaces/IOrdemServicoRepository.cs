using System;
using Frota.Domain.Models;
using Frota.Domain.Pagination;


namespace Frota.Infra.Data.Interfaces;

public interface IOrdemServicoRepository
{
    Task<PagedList<OrdemServico>> BuscaOrdemServico(int pageNumber, int pageSize);
    Task<OrdemServico> BuscaOrdemServicoId(Guid Id);
    void AdicionarOrdemServico(OrdemServico ordemServico);
    void AtualizarOrdemServico(OrdemServico ordemServico);
    void DeletarOrdemServico(OrdemServico ordemServico);

    Task<bool> SaveChangesAsync();
}

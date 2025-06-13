using System;
using Frota.Domain.Models;
using Frota.Domain.Pagination;
using Frota.Infra.Data.Contex;
using Frota.Infra.Data.Helpers;
using Frota.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Frota.Infra.Data.Repositories;

public class OrdemServicoRepository : IOrdemServicoRepository
{
    private readonly ApiContext _context;

         public OrdemServicoRepository(ApiContext context)
        {
            _context = context;
        }

    public void AdicionarOrdemServico(OrdemServico ordemServico)
    {
        _context.Add(ordemServico);
    }

    public void AtualizarOrdemServico(OrdemServico ordemServico)
    {
        _context.Update(ordemServico);
    }

    public async Task<PagedList<OrdemServico>> BuscaOrdemServico(int pageNumber, int pageSize)
    {
        var query = _context.OrdemServicos.AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<OrdemServico> BuscaOrdemServicoId(Guid Id)
    {
        return await _context.OrdemServicos.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public void DeletarOrdemServico(OrdemServico ordemServico)
    {
        _context.Remove(ordemServico);
    }

    public async Task<PagedList<OrdemServico>> ListaOrdemServicoId(int pageNumber, int pageSize, Guid VeiculoId)
    {
        var query = _context.OrdemServicos.AsQueryable();
        query = query.Where(x => x.VeiculoId == VeiculoId);
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}

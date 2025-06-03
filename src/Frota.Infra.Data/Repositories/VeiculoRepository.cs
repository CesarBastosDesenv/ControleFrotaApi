using System;
using Frota.Domain.Models;
using Frota.Domain.Pagination;
using Frota.Infra.Data.Contex;
using Frota.Infra.Data.Helpers;
using Frota.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Frota.Infra.Data.Repositories;

public class VeiculoRepository : IVeiculoRepository
{
     private readonly ApiContext _context;

         public VeiculoRepository(ApiContext context)
        {
            _context = context;
        }

    public void AdicionarVeiculo(Veiculo veiculo)
    {
        _context.Add(veiculo);
    }

    public void AtualizarVeiculo(Veiculo veiculo)
    {
        _context.Update(veiculo);
    }

    public async Task<PagedList<Veiculo>> BuscaVeiculo(int pageNumber, int pageSize)
    {
        var query = _context.Veiculos.AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Veiculo> BuscaVeiculoId(Guid Id)
    {
        return await _context.Veiculos.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public void DeletarVeiculo(Veiculo veiculo)
    {
        _context.Remove(veiculo);
    }

    public async Task<bool> SaveChangesAsync()
    {
       return await _context.SaveChangesAsync() > 0;
    }
}

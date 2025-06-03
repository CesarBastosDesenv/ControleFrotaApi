using System;
using Frota.Domain.Models;
using Frota.Domain.Pagination;

namespace Frota.Infra.Data.Interfaces;

public interface IVeiculoRepository
{
    Task<PagedList<Veiculo>> BuscaVeiculo(int pageNumber, int pageSize);
    Task<Veiculo> BuscaVeiculoId(Guid Id);
    void AdicionarVeiculo(Veiculo veiculo);
    void AtualizarVeiculo(Veiculo veiculo);
    void DeletarVeiculo(Veiculo veiculo);

    Task<bool> SaveChangesAsync();
}

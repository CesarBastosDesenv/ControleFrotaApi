using System;
using Frota.Domain.Models;
using Frota.Domain.Pagination;

namespace Frota.Infra.Data.Interfaces;

public interface IVeiculoRepository
{
    Task<PagedList<Veiculo>> BuscaVeiculo(int pageNumber, int pageSize);
    void AdicionarVeiculo(Veiculo veiculo);
    void AtualizarVeiculo(Veiculo veiculo);
    void DeletarVeiculo(Veiculo veiculo);

    Task<bool> SaveChangesAsync();
}

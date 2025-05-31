using System;
using Frota.Application.Dto;

namespace Frota.Application.Interfaces;

public interface IVeiculoService
{
    Task<ResultViewModel> AddAsync(VeiculoCadastro agenda);

    Task<ResultViewModel> UpdateAsync(VeiculoCadastro agenda);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);
}

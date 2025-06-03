using System;
using Azure.Core;
using Frota.Application.Dto;
using Frota.Application.Interfaces;
using Frota.Domain.Models;
using Frota.Infra.Data.Interfaces;

namespace Frota.Application.Services;

public class VeiculoService : IVeiculoService
{
    private IVeiculoRepository _veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(VeiculoCadastro args)
    {
        var veiculo = new Veiculo()
        {
            VeiculoNome = args.VeiculoNome,
            Status = args.Status
        };
        _veiculoRepository.AdicionarVeiculo(veiculo);
        var result = new ResultViewModel(await _veiculoRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result;  
    }

    public async Task<ResultViewModel> BuscaVeiculoId(Guid Id)
    {
        return new ResultViewModel(await _veiculoRepository.BuscaVeiculoId(Id));
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
         var retorno = await _veiculoRepository.BuscaVeiculo(pageNumber, pageSize);
        var retornoModel = retorno.Select(x => new VeiculoView(){
            Id = x.Id,
            VeiculoNome = x.VeiculoNome,
            Status = x.Status 
            });
        return new PagedList() {Data = retornoModel, TotalCount = retorno.TotalCount};
    }

    public Task<ResultViewModel> UpdateAsync(VeiculoCadastro agenda)
    {
        throw new NotImplementedException();
    }
}

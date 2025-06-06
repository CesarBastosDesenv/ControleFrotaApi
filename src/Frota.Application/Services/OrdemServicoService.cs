using System;
using Frota.Application.Dto;
using Frota.Application.Interfaces;
using Frota.Domain.Models;
using Frota.Infra.Data.Interfaces;

namespace Frota.Application.Services;

public class OrdemServicoService : IOrdemServicoService
{
    private IOrdemServicoRepository _ordemServicoRepository;

    public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository)
    {
        _ordemServicoRepository = ordemServicoRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(OrdemServicoCadastro args)
    {
        var ordemServico = new OrdemServico()
        {
            DtServico = args.DtServico,
            TipoManutencao = args.TipoManutencao,
            DefeitoApresentado = args.DefeitoApresentado,
            Executor = args.Executor,
            ValorMaoObra = args.ValorMaoObra,
            VeiculoId = args.VeiculoId,
            Status = args.Status
        };
        _ordemServicoRepository.AdicionarOrdemServico(ordemServico);
        var result = new ResultViewModel(await _ordemServicoRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result;  
    }

    public async Task<ResultViewModel> BuscaOrdemServicoId(Guid Id)
    {
        return new ResultViewModel(await _ordemServicoRepository.BuscaOrdemServicoId(Id));
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
          var retorno = await _ordemServicoRepository.BuscaOrdemServico(pageNumber, pageSize);
         var retornoModel = retorno.Select(x => new OrdemServicoView(){
            Id = x.Id,
            DtServico = x.DtServico,
            TipoManutencao = x.TipoManutencao,
            DefeitoApresentado = x.DefeitoApresentado,
            Executor = x.Executor,
            ValorMaoObra = x.ValorMaoObra,
            VeiculoId = x.VeiculoId,
            Status = x.Status
            });
        return new PagedList() {Data = retornoModel, TotalCount = retorno.TotalCount};
    }

    public Task<ResultViewModel> UpdateAsync(OrdemServicoCadastro ordemServico)
    {
        throw new NotImplementedException();
    }
}

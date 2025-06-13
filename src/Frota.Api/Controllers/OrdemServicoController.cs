using System;
using Frota.Api.Extensions;
using Frota.Api.Models;
using Frota.Application.Dto;
using Frota.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Frota.Api.Controllers.OrdemServicoController;

[Route("api/[controller]")]
[ApiController]
public class OrdemServicoController : ControllerBase
{
    private ILogger<OrdemServicoController> _logger;
    private IOrdemServicoService _ordemServicoService;

    public OrdemServicoController(ILogger<OrdemServicoController> logger, IOrdemServicoService ordemServicoService)
    {
        _logger = logger;
        _ordemServicoService = ordemServicoService;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery]PaginationParams paginationParams)
    {
        try
        {
            var result = await _ordemServicoService.GetAllAsync(paginationParams.PageNumber,paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages));
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    } 
    [HttpGet("{Id}")]
    public async Task<ActionResult> Get(Guid Id)
    {
       try
        {
            var result = await _ordemServicoService.BuscaOrdemServicoId(Id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        } 
    }

     [HttpGet("{Id}/list")]
    public async Task<ActionResult> GetListId([FromQuery]PaginationParams paginationParams, Guid Id)
    {
        try
        {
            var result = await _ordemServicoService.GetListId(paginationParams.PageNumber, paginationParams.PageSize, Id);
            Response.AddPaginationHeader(new PaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages));
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    }


    [HttpPost]
    public async Task<ActionResult> Add(OrdemServicoCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _ordemServicoService.AddAsync(args);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    }
}

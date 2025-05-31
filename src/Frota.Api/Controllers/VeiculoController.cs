using System;
using Frota.Application.Interfaces;
using Frota.Api.Models;
using Frota.Application.Dto;
using Frota.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Frota.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeiculoController : ControllerBase
{
    private ILogger<VeiculoController> _logger;
    private IVeiculoService _veiculoService;

    public VeiculoController(ILogger<VeiculoController> logger, IVeiculoService veiculoService)
    {
        _logger = logger;
        _veiculoService = veiculoService;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery]PaginationParams paginationParams)
    {
        try
        {
            var result = await _veiculoService.GetAllAsync(paginationParams.PageNumber,paginationParams.PageSize);
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
    public async Task<ActionResult> Add(VeiculoCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _veiculoService.AddAsync(args);
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

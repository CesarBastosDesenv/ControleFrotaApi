using System;

namespace Frota.Application.Dto;

public class OrdemServicoView
{
    public Guid Id { get; set; }
    public Guid VeiculoId { get; set; }
    public DateTime DtServico { get; set; }
    public required string TipoManutencao { get; set; }
    public required string DefeitoApresentado { get; set; }
    public required string Executor { get; set; }
    public decimal ValorMaoObra { get; set; }
    public bool Status { get; set; }
  //  public String Veiculo { get; set; }
}

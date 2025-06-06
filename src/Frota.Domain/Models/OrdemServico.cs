using System;
using System.Security.Cryptography.X509Certificates;

namespace Frota.Domain.Models;

public class OrdemServico
{
    public Guid Id { get; set; }
    public Veiculo? Veiculo { get; set; } 

    public DateTime DtServico { get; set; }
    public required string TipoManutencao { get; set; }
    public required string DefeitoApresentado { get; set; }
    public required string Executor { get; set; }
    public decimal ValorMaoObra { get; set; }
    public bool Status { get; set; }
    public Guid VeiculoId { get; set; }
}

using System;

namespace Frota.Domain.Models;

public class Veiculo
{
    public Guid Id { get; set; }
    public required string VeiculoNome { get; set; }
    public bool Status { get; set; } = true;
}

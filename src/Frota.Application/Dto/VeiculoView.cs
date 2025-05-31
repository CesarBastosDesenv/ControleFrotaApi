using System;

namespace Frota.Application.Dto;

public class VeiculoView
{
    public Guid Id { get; set; }
    public required string VeiculoNome { get; set; }
    public bool Status { get; set; } = true;
}

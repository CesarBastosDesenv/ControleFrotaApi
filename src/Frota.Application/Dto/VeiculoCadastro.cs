using System;
using System.ComponentModel.DataAnnotations;

namespace Frota.Application.Dto;

public class VeiculoCadastro
{   
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50,ErrorMessage = "{0}: Maximo de 20 caracteres")] 
    public required string VeiculoNome { get; set; }
    public bool Status { get; set; } = true;
}

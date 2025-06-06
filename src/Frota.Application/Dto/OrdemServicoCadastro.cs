using System;
using System.ComponentModel.DataAnnotations;

namespace Frota.Application.Dto;

public class OrdemServicoCadastro
{
     
    public Guid VeiculoId { get; set; }
   
    public DateTime DtServico { get; set; }

    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")] 
    public required string TipoManutencao { get; set; }

    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(250, ErrorMessage = "{0}: Maximo de 250 caracteres")] 
    public required string DefeitoApresentado { get; set; }

    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")] 
    public required string Executor { get; set; }

    public decimal ValorMaoObra { get; set; }
    public bool Status { get; set; }
   

}

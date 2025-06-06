using System;
using Frota.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Frota.Infra.Data.Contex;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {

    }

    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<OrdemServico> OrdemServicos { get; set; }

}

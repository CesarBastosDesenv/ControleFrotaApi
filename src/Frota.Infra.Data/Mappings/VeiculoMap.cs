using System;
using Frota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frota.Infra.Data.Mappings;

public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("Veiculos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.VeiculoNome)
        .IsRequired()
        .HasColumnType("varchar(50)"); 

        builder.Property(x => x.Status)
        .HasDefaultValue(true);
    }
}

using System;
using Frota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frota.Infra.Data.Mappings;

public class OrdemServicoMap : IEntityTypeConfiguration<OrdemServico>
{
    public void Configure(EntityTypeBuilder<OrdemServico> builder)
    {
        builder.ToTable("OrdensServico");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DtServico)
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(x => x.TipoManutencao)
        .IsRequired()
        .HasColumnType("varchar(20)");

        builder.Property(x => x.DefeitoApresentado)
        .IsRequired()
        .HasColumnType("varchar(255)");

        builder.Property(x => x.Executor)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(x => x.ValorMaoObra)
        .IsRequired()
        .HasColumnType("numeric(38,2)");

        builder.Property(x => x.Status)
        .HasDefaultValue(true);

        builder.HasOne(x => x.Veiculo)
        .WithMany(x => x.OrdemServicos)
        .HasForeignKey(x => x.VeiculoId);
    }
}

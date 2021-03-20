using HomeManagerApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeManagerApi.Data.Configurations
{
    public class CompraConfiguration : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compras");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IncluidoDataHora).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.UltimaAlteracaoDataHora).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(p => p.Nome).HasConversion<string>();
            builder.Property(p => p.Concluido).HasConversion<bool>();
            builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");
            
            builder.HasMany(p => p.Itens)
                .WithOne(p => p.Compra)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

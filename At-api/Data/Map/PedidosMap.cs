using At_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace At_api.Data.Map
{
    public class PedidosMap : IEntityTypeConfiguration<PedidosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EnderecoEntrega).IsRequired().HasMaxLength(255);
            builder.Property(x => x.usuarioId);
            builder.HasOne(x => x.Usuario);
        }
    }
}

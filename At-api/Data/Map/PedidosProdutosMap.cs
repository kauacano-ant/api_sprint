using At_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace At_api.Data.Map
{
    public class PedidosProdutosMap : IEntityTypeConfiguration<pedidosProdutosModel>
    {
        public void Configure(EntityTypeBuilder<pedidosProdutosModel> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProdutoId);
            builder.Property(x => x.CategoriaId);

            builder.HasOne(x => x.Produtos);
            builder.HasOne(x => x.Categorias);
        }
    }
}

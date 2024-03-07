using At_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace At_api.Data.Map
{
    public class ProdutosMap : IEntityTypeConfiguration<ProdutosModel>
    {
        public void Configure(EntityTypeBuilder<ProdutosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Preco).IsRequired();
        }
    }
}

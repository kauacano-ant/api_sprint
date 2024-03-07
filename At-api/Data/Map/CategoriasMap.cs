using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using At_api.Models;


namespace At_api.Data.Map
{
    public class CategoriasMap : IEntityTypeConfiguration<CategoriasModel>
    {
        
            public void Configure(EntityTypeBuilder<CategoriasModel> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Status).IsRequired().HasMaxLength(255);

            }
       

    }
}

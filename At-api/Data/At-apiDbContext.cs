using At_api.Data.Map;
using At_api.Models;
using Microsoft.EntityFrameworkCore;

namespace At_api.Data
{
    public class At_apiDbContext : DbContext
    {
        public At_apiDbContext(DbContextOptions<At_apiDbContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<pedidosProdutosModel> PedidosProdutos { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<CategoriasModel> Categorias { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PedidosMap());
            modelBuilder.ApplyConfiguration(new PedidosProdutosMap());
            modelBuilder.ApplyConfiguration(new ProdutosMap());
            modelBuilder.ApplyConfiguration(new CategoriasMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}

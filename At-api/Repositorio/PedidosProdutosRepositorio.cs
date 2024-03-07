using At_api.Data;
using At_api.Models;
using At_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace At_api.Repositorio
{
    public class PedidosProdutosRepositorio : IPedidoProdutosRepositorio
    {
        private readonly At_apiDbContext _dbcontext;

        public PedidosProdutosRepositorio(At_apiDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<pedidosProdutosModel> BuscarPorId(int id)
        {
            return await _dbcontext.PedidosProdutos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<pedidosProdutosModel>> BuscarTodasPedidoProdutos()
        {
            return await _dbcontext.PedidosProdutos.ToListAsync();
        }
        public async Task<pedidosProdutosModel> Adicionar(pedidosProdutosModel pedidosprodutos)
        {
            await _dbcontext.PedidosProdutos.AddAsync(pedidosprodutos);
            await _dbcontext.SaveChangesAsync();

            return pedidosprodutos;
        }

        public async Task<bool> Apagar(int id)
        {
            pedidosProdutosModel pedidosprodutos = await BuscarPorId(id);
            if (pedidosprodutos == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.PedidosProdutos.Remove(pedidosprodutos);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<pedidosProdutosModel> Atualizar(pedidosProdutosModel pedidosprodutos, int id)
        {
            pedidosProdutosModel pedidosprodutosPorId = await BuscarPorId(id);
            if (pedidosprodutosPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            pedidosprodutosPorId.Quantidade = pedidosprodutos.Quantidade;

            _dbcontext.PedidosProdutos.Update(pedidosprodutosPorId);
            await _dbcontext.SaveChangesAsync();
            return pedidosprodutosPorId;
        }
    }
}

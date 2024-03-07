using At_api.Data;
using At_api.Models;
using At_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace At_api.Repositorio
{
    public class PedidosRepositorio : IPedidosRepositorio
    {
        private readonly At_apiDbContext _dbcontext;

        public PedidosRepositorio(At_apiDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<PedidosModel> BuscarPorId(int id)
        {
            return await _dbcontext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidosModel>> BuscarTodasPedidos()
        {
            return await _dbcontext.Pedidos.ToListAsync();
        }
        public async Task<PedidosModel> Adicionar(PedidosModel pedidos)
        {
            await _dbcontext.Pedidos.AddAsync(pedidos);
            await _dbcontext.SaveChangesAsync();

            return pedidos;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidosModel pedidos = await BuscarPorId(id);
            if (pedidos == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Pedidos.Remove(pedidos);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidosModel> Atualizar(PedidosModel pedidos, int id)
        {
            PedidosModel PedidosPorId = await BuscarPorId(id);
            if (PedidosPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            PedidosPorId.EnderecoEntrega = pedidos.EnderecoEntrega;
            

            _dbcontext.Pedidos.Update(PedidosPorId);
            await _dbcontext.SaveChangesAsync();
            return PedidosPorId;
        }
    }
}

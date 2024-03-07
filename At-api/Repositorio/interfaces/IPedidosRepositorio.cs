using At_api.Models;

namespace At_api.Repositorio.interfaces
{
    public interface IPedidosRepositorio
    {
        Task<List<PedidosModel>> BuscarTodasPedidos();

        Task<PedidosModel> BuscarPorId(int id);

        Task<PedidosModel> Adicionar(PedidosModel pedidos);

        Task<PedidosModel> Atualizar(PedidosModel pedidos, int id);

        Task<bool> Apagar(int id);
    }
}

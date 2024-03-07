using At_api.Models;

namespace At_api.Repositorio.interfaces
{
    public interface IPedidoProdutosRepositorio
    {
        Task<List<pedidosProdutosModel>> BuscarTodasPedidoProdutos();

        Task<pedidosProdutosModel> BuscarPorId(int id);

        Task<pedidosProdutosModel> Adicionar(pedidosProdutosModel pedidosProdutos);

        Task<pedidosProdutosModel> Atualizar(pedidosProdutosModel pedidosProdutos, int id);

        Task<bool> Apagar(int id);
    }
}

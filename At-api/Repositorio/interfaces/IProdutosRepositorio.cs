using At_api.Models;

namespace At_api.Repositorio.interfaces
{
    public interface IProdutosRepositorio
    {
        Task<List<ProdutosModel>> BuscarTodosProdutos();

        Task<ProdutosModel> BuscarPorId(int id);

        Task<ProdutosModel> Adicionar(ProdutosModel produtos);

        Task<ProdutosModel> Atualizar(ProdutosModel produtos, int id);

        Task<bool> Apagar(int id);
    }
}

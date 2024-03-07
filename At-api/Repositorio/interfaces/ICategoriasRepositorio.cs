using At_api.Models;

namespace At_api.Repositorio.interfaces
{
    public interface ICategoriasRepositorio
    {
        Task<List<CategoriasModel>> BuscarTodasCategorias();

        Task<CategoriasModel> BuscarPorId(int id);

        Task<CategoriasModel> Adicionar(CategoriasModel categorias);

        Task<CategoriasModel> Atualizar(CategoriasModel categorias, int id);

        Task<bool> Apagar(int id);
    }
}

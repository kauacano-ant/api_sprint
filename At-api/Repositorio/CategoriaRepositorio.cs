using At_api.Data;
using At_api.Models;
using At_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace At_api.Repositorio
{
    public class CategoriaRepositorio : ICategoriasRepositorio
    {
        private readonly At_apiDbContext _dbcontext;

        public CategoriaRepositorio(At_apiDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<CategoriasModel> BuscarPorId(int id)
        {
            return await _dbcontext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoriasModel>> BuscarTodasCategorias()
        {
            return await _dbcontext.Categorias.ToListAsync();
        }
        public async Task<CategoriasModel> Adicionar(CategoriasModel categorias)
        {
            await _dbcontext.Categorias.AddAsync(categorias);
            await _dbcontext.SaveChangesAsync();

            return categorias;
        }

        public async Task<bool> Apagar(int id)
        {
            CategoriasModel categorias = await BuscarPorId(id);
            if (categorias == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Categorias.Remove(categorias);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoriasModel> Atualizar(CategoriasModel categorias, int id)
        {
            CategoriasModel categoriasPorId = await BuscarPorId(id);
            if (categoriasPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            categoriasPorId.Name = categorias.Name;
            categoriasPorId.Status = categorias.Status;

            _dbcontext.Categorias.Update(categoriasPorId);
            await _dbcontext.SaveChangesAsync();
            return categoriasPorId;
        }
    }
}

using At_api.Data;
using At_api.Models;
using At_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace At_api.Repositorio
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        private readonly At_apiDbContext _dbcontext;

        public ProdutosRepositorio(At_apiDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<ProdutosModel> BuscarPorId(int id)
        {
            return await _dbcontext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutosModel>> BuscarTodosProdutos()
        {
            return await _dbcontext.Produtos.ToListAsync();
        }
        public async Task<ProdutosModel> Adicionar(ProdutosModel produtos)
        {
            await _dbcontext.Produtos.AddAsync(produtos);
            await _dbcontext.SaveChangesAsync();

            return produtos;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutosModel produtos = await BuscarPorId(id);
            if (produtos == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Produtos.Remove(produtos);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<ProdutosModel> Atualizar(ProdutosModel produtos, int id)
        {
            ProdutosModel produtosPorId = await BuscarPorId(id);
            if (produtosPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            produtosPorId.Name = produtos.Name;
            produtosPorId.Descricao = produtos.Descricao;
            produtosPorId.Preco = produtos.Preco;

            _dbcontext.Produtos.Update(produtosPorId);
            await _dbcontext.SaveChangesAsync();
            return produtosPorId;
        }


    }
}


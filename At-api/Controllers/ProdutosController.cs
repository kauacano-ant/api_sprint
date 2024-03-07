using At_api.Models;
using At_api.Repositorio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace At_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepositorio _ProdutosRepositorio;
        public ProdutosController(IProdutosRepositorio produtosRepositorio)
        {
            _ProdutosRepositorio = produtosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutosModel>>> BuscarTodosUsuarios()
        {
            List<ProdutosModel> produtos = await _ProdutosRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel>> BuscarPorId(int id)
        {
            ProdutosModel produtos = await _ProdutosRepositorio.BuscarPorId(id);
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutosModel>> Adicionar([FromBody] ProdutosModel produtosModel)
        {
            ProdutosModel produtos = await _ProdutosRepositorio.Adicionar(produtosModel);
            return Ok(produtos);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ProdutosModel>> Atualizar(int id, [FromBody] ProdutosModel produtosModel)
        {
            produtosModel.Id = id;
            ProdutosModel produtos = await _ProdutosRepositorio.Atualizar(produtosModel, id);
            return Ok(produtos);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ProdutosModel>> Apagar(int id)
        {
            bool apagado = await _ProdutosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

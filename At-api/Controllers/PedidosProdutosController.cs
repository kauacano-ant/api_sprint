using At_api.Models;
using At_api.Repositorio;
using At_api.Repositorio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace At_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PedidosProdutosController : ControllerBase
    {
        private readonly IPedidoProdutosRepositorio _PedidoProdutosRepositorio;
        public PedidosProdutosController(IPedidoProdutosRepositorio pedidoprodutosRepositorio)
        {
            _PedidoProdutosRepositorio = pedidoprodutosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<pedidosProdutosModel>>> BuscarTodosUsuarios()
        {
            List<pedidosProdutosModel> pedidoprodutos = await _PedidoProdutosRepositorio.BuscarTodasPedidoProdutos();
            return Ok(pedidoprodutos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<pedidosProdutosModel>> BuscarPorId(int id)
        {
            pedidosProdutosModel pedidoprodutos = await _PedidoProdutosRepositorio.BuscarPorId(id);
            return Ok(pedidoprodutos);
        }

        [HttpPost]
        public async Task<ActionResult<pedidosProdutosModel>> Adicionar([FromBody] pedidosProdutosModel pedidoprodutosModel)
        {
            pedidosProdutosModel pedidoprodutos = await _PedidoProdutosRepositorio.Adicionar(pedidoprodutosModel);
            return Ok(pedidoprodutos);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<pedidosProdutosModel>> Atualizar(int id, [FromBody] pedidosProdutosModel pedidoprodutosModel)
        {
            pedidoprodutosModel.Id = id;
            pedidosProdutosModel pedidoprodutos = await _PedidoProdutosRepositorio.Atualizar(pedidoprodutosModel, id);
            return Ok(pedidoprodutos);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<pedidosProdutosModel>> Apagar(int id)
        {
            bool apagado = await _PedidoProdutosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

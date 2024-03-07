using At_api.Models;
using At_api.Repositorio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace At_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosRepositorio _PedidoRepositorio;
        public PedidosController(IPedidosRepositorio pedidoRepositorio)
        {
            _PedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosModel>>> BuscarTodasPedidos()
        {
            List<PedidosModel> pedido = await _PedidoRepositorio.BuscarTodasPedidos();
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosModel>> BuscarPorId(int id)
        {
            PedidosModel pedido = await _PedidoRepositorio.BuscarPorId(id);
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<PedidosModel>> Adicionar([FromBody] PedidosModel pedidoModel)
        {
            PedidosModel pedido = await _PedidoRepositorio.Adicionar(pedidoModel);
            return Ok(pedido);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<PedidosModel>> Atualizar(int id, [FromBody] PedidosModel pedidoModel)
        {
            pedidoModel.Id = id;
            PedidosModel pedido = await _PedidoRepositorio.Atualizar(pedidoModel, id);
            return Ok(pedido);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<PedidosModel>> Apagar(int id)
        {
            bool apagado = await _PedidoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

using At_api.Models;
using At_api.Repositorio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace At_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriasRepositorio _CategoriaRepositorio;
        public CategoriaController(ICategoriasRepositorio categoriaRepositorio)
        {
            _CategoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriasModel>>> BuscarTodasCategorias()
        {
            List<CategoriasModel> categoria = await _CategoriaRepositorio.BuscarTodasCategorias();
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriasModel>> BuscarPorId(int id)
        {
            CategoriasModel categoria = await _CategoriaRepositorio.BuscarPorId(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriasModel>> Adicionar([FromBody] CategoriasModel categoriaModel)
        {
            CategoriasModel categoria = await _CategoriaRepositorio.Adicionar(categoriaModel);
            return Ok(categoria);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<CategoriasModel>> Atualizar(int id, [FromBody] CategoriasModel categoriaModel)
        {
            categoriaModel.Id = id;
            CategoriasModel categoria = await _CategoriaRepositorio.Atualizar(categoriaModel, id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<CategoriasModel>> Apagar(int id)
        {
            bool apagado = await _CategoriaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

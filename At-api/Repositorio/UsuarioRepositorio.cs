using At_api.Data;
using At_api.Models;
using At_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace At_api.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly At_apiDbContext _dbcontext;

        public UsuarioRepositorio(At_apiDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbcontext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbcontext.Usuarios.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuario = await BuscarPorId(id);

            if (usuario == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Usuarios.Remove(usuario);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.DataNasc = usuario.DataNasc;

            _dbcontext.Usuarios.Update(usuarioPorId);
            await _dbcontext.SaveChangesAsync();
            return usuarioPorId;
        }
    }
}


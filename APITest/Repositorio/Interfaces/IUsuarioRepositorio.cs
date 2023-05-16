using APITest.Models;

namespace APITest.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarUsuarioId(int Id);

        Task<UsuarioModel> AdicionaUsuarioId(UsuarioModel usuario);

        Task<UsuarioModel> AtualizaUsuario(UsuarioModel usuario, int Id);

        Task<bool> ApagaUsuario(int Id);
    }
}

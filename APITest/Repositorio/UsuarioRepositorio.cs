using APITest.Data;
using APITest.Models;
using APITest.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APITest.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefaDBcontext _dbcontex;
        public UsuarioRepositorio(SistemaTarefaDBcontext sistemaTarefaDBcontext)
        {
            _dbcontex= sistemaTarefaDBcontext;  
        }

        // buscas//
        public async Task<UsuarioModel> BuscarUsuarioId(int Id)
        {
            return await _dbcontex.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbcontex.Usuarios.ToListAsync();
        }

        

        // adicionar//
        public async Task<UsuarioModel> AdicionaUsuarioId(UsuarioModel usuario)
        {
         await _dbcontex.Usuarios.AddAsync(usuario); 
          await  _dbcontex.SaveChangesAsync();    

            return usuario; 
        }

        

        //atualizar//
        public async Task<UsuarioModel> AtualizaUsuario(UsuarioModel usuario, int Id)
        {
           UsuarioModel usuarioPorId = await BuscarUsuarioId(Id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para ID :{Id} NAO FOI ENCONTRADO NO BANCO DE DADOS");
                
            }
            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email= usuario.Email; 
            
            _dbcontex.Usuarios.Update(usuarioPorId);    
            await _dbcontex.SaveChangesAsync();   

            return usuarioPorId;
        }

        //APAGAR USUARIO//

        public async Task<bool> ApagaUsuario(int Id)
        {
            UsuarioModel usuarioPorId = await BuscarUsuarioId(Id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para ID :{Id} NAO FOI ENCONTRADO NO BANCO DE DADOS");
            }

          _dbcontex.Usuarios.Remove(usuarioPorId);
          await  _dbcontex.SaveChangesAsync();

            return true;    

        }

    }
}

using APITest.Models;
using APITest.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task <ActionResult<List<UsuarioModel>>> BuscaTodosUsuarios() 
        {
                List<UsuarioModel> usuario = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuario);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioModel>> BuscarUsuarioId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarUsuarioId(id);
            return Ok(usuario); 
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel) 
        {
            UsuarioModel usuario = await  _usuarioRepositorio.AdicionaUsuarioId(usuarioModel);

            return Ok(usuario);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> AtualizaUsuario([FromBody] UsuarioModel usuarioModel,int id)
        {
            usuarioModel.Id=id;
            UsuarioModel usuario = await _usuarioRepositorio.AtualizaUsuario(usuarioModel,id);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> ApagaUsuario(int id)
        {
            
            bool apagado = await _usuarioRepositorio.ApagaUsuario(id);

            return Ok(apagado);
        }


    }
}

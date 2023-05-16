using gerenciadorTarefa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gerenciadorTarefa.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]   
        public ActionResult<List<UsuarioModel>> BuscarTodosUsuarios() 
        {
            return Ok();
           
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestauranteSiteAdmin.Application.Interfaces;
using RestauranteSiteAdmin.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RestauranteSiteAdmin.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioApp;

        public UsuarioController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioViewModel>> Get()
        {
            try
            {
                return await _usuarioApp.ListarUsuarios();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [Route("autenticar/{email}")]
        [HttpPost]
        public async Task<UsuarioViewModel> Autenticar(string email, [FromBody]string senha)
        {
            try
            {
                return await _usuarioApp.AutenticarUsuario(email, senha);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpPost]
        public async Task<bool> Post([FromBody]UsuarioViewModel usuario)
        {
            return await _usuarioApp.CadastrarNovoUsuario(usuario);
        }
    }
}

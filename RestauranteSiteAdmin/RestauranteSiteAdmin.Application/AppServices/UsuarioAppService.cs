using RestauranteSiteAdmin.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestauranteSiteAdmin.Application.ViewModels;
using RestauranteSiteAdmin.Domain.Interfaces;
using RestauranteSiteAdmin.Application.Adapters;

namespace RestauranteSiteAdmin.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<UsuarioViewModel> AutenticarUsuario(string email, string senha)
            => UsuarioAdapter.ToViewModel(await _usuarioService.AutenticarUsuario(email, senha));

        public async Task<bool> CadastrarNovoUsuario(UsuarioViewModel usuario)
            => await _usuarioService.CadastrarNovoUsuario(UsuarioAdapter.ToDomain(usuario));

        public async Task<bool> EditarUsuario(UsuarioViewModel usuario)
            => await _usuarioService.EditarUsuario(UsuarioAdapter.ToDomain(usuario));

        public async Task<IEnumerable<UsuarioViewModel>> ListarUsuarios()
            => UsuarioAdapter.ToViewModelLst(await _usuarioService.ListarUsuarios());

        public void Dispose()
        {
            _usuarioService.Dispose();
            GC.Collect();
        }
    }
}

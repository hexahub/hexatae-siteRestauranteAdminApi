using RestauranteSiteAdmin.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteSiteAdmin.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<IEnumerable<UsuarioViewModel>> ListarUsuarios();
        Task<bool> CadastrarNovoUsuario(UsuarioViewModel usuario);
        Task<UsuarioViewModel> AutenticarUsuario(string email, string senha);
        Task<bool> EditarUsuario(UsuarioViewModel usuario);
    }
}

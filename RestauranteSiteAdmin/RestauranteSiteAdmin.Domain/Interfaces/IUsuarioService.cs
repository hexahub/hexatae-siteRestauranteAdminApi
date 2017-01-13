using RestauranteSiteAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteSiteAdmin.Domain.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task<IEnumerable<Usuario>> ListarUsuarios();
        Task<bool> CadastrarNovoUsuario(Usuario usuario);
        Task<Usuario> AutenticarUsuario(string email, string senha);
        Task<bool> EditarUsuario(Usuario usuario);
    }
}

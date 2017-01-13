using RestauranteSiteAdmin.Application.ViewModels;
using RestauranteSiteAdmin.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteSiteAdmin.Application.Adapters
{
    public class UsuarioAdapter
    {
        public static Usuario ToDomain(UsuarioViewModel usuarioViewModel)
            => new Usuario(usuarioViewModel.UsuarioId, usuarioViewModel.Nome, usuarioViewModel.Email, usuarioViewModel.Senha);

        public static UsuarioViewModel ToViewModel(Usuario usuario)
            => new UsuarioViewModel { UsuarioId = usuario.UsuarioId.ToString(), Nome = usuario.Nome, Email = usuario.Email };

        public static IEnumerable<Usuario> ToDomainLst(IEnumerable<UsuarioViewModel> usuarioViewModelLst)
        {
            var domainLst = new List<Usuario>();

            usuarioViewModelLst.ToList().ForEach(u => domainLst.Add(new Usuario(u.UsuarioId, u.Nome, u.Email, u.Senha)));

            return domainLst;
        }

        public static IEnumerable<UsuarioViewModel> ToViewModelLst(IEnumerable<Usuario> usuarioLst)
        {
            var viewModelLst = new List<UsuarioViewModel>();

            usuarioLst.ToList().ForEach(u => viewModelLst.Add(new UsuarioViewModel { UsuarioId = u.UsuarioId.ToString(), Nome = u.Nome, Email = u.Email }));

            return viewModelLst;
        }
    }
}

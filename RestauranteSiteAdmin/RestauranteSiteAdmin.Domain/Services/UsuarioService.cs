using RestauranteSiteAdmin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestauranteSiteAdmin.Domain.Entities;

namespace RestauranteSiteAdmin.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        IRepository<Usuario> _usuarioRepository;
        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> AutenticarUsuario(string email, string senha)
            => (await _usuarioRepository.Find(u => u.Email == email && u.Senha == CriptoService.Criptografar(senha))).First();

        public async Task<bool> CadastrarNovoUsuario(Usuario usuario)
            => await _usuarioRepository.Insert(usuario);

        public async Task<bool> EditarUsuario(Usuario usuario)
            => await _usuarioRepository.Update(usuario.UsuarioId.ToString(), usuario);

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
            => await _usuarioRepository.GetAll();

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            GC.Collect();
        }
    }
}

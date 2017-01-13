using System.ComponentModel.DataAnnotations;

namespace RestauranteSiteAdmin.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

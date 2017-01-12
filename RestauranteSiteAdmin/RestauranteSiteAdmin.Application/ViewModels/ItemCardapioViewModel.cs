using System.ComponentModel.DataAnnotations;

namespace RestauranteSiteAdmin.Application.ViewModels
{
    public class ItemCardapioViewModel
    {
        [Key]
        public string ItemCardapioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Refeicao { get; set; }
    }
}

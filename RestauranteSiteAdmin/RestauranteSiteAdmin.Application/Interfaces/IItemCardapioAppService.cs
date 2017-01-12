using RestauranteSiteAdmin.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteSiteAdmin.Application.Interfaces
{
    public interface IItemCardapioAppService : IDisposable
    {
        Task<bool> CadastrarNovoItemCardapio(ItemCardapioViewModel itemCardapio);

        Task<bool> EditarItemCardapio(ItemCardapioViewModel itemCardapio);

        Task<bool> ExcluirItemCardapio(string id);

        Task<IEnumerable<ItemCardapioViewModel>> ListarItensCardapio();

        Task<IEnumerable<ItemCardapioViewModel>> ObterItensCardapioPorDescricao(string descricao);

        Task<IEnumerable<ItemCardapioViewModel>> ObterItensCardapioPorRefeicao(int refeicao);

        Task<IEnumerable<ItemCardapioViewModel>> ObterItensCardapioPorTitulo(string titulo);
    }
}

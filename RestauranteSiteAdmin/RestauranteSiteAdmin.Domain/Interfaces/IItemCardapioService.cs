using RestauranteSiteAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteSiteAdmin.Domain.Interfaces
{
    public interface IItemCardapioService : IDisposable
    {
        Task<IEnumerable<ItemCardapio>> ObterItensCardapioPorTitulo(string titulo);
        Task<IEnumerable<ItemCardapio>> ObterItensCardapioPorDescricao(string descricao);
        Task<IEnumerable<ItemCardapio>> ObterItensCardapioPorRefeicao(int refeicao);
        Task<bool> ExcluirItemCardapio(string id);
        Task<IEnumerable<ItemCardapio>> ListarItensCardapio();
        Task<bool> CadastrarNovoItemCardapio(ItemCardapio itemCardapio);
        Task<bool> EditarItemCardapio(ItemCardapio itemCardapio);
    }
}

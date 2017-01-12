using RestauranteSiteAdmin.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestauranteSiteAdmin.Application.ViewModels;
using RestauranteSiteAdmin.Domain.Interfaces;
using RestauranteSiteAdmin.Application.Adapters;

namespace RestauranteSiteAdmin.Application.AppServices
{
    public class ItemCardapioAppService : IItemCardapioAppService
    {

        private readonly IItemCardapioService _itemCardapioService;

        public ItemCardapioAppService(IItemCardapioService itemCardapioService)
        {
            _itemCardapioService = itemCardapioService;
        }

        public async Task<bool> CadastrarNovoItemCardapio(ItemCardapioViewModel itemCardapioViewModel)
            => await _itemCardapioService.CadastrarNovoItemCardapio(ItemCardapioAdapter.ToDomain(itemCardapioViewModel));

        public async Task<bool> EditarItemCardapio(ItemCardapioViewModel itemCardapioViewModel)
            => await _itemCardapioService.EditarItemCardapio(ItemCardapioAdapter.ToDomain(itemCardapioViewModel));

        public Task<bool> ExcluirItemCardapio(string id)
            => _itemCardapioService.ExcluirItemCardapio(id);

        public async Task<IEnumerable<ItemCardapioViewModel>> ListarItensCardapio()
            => ItemCardapioAdapter.ToViewModelLst(await _itemCardapioService.ListarItensCardapio());
            

        public async Task<IEnumerable<ItemCardapioViewModel>> ObterItensCardapioPorDescricao(string descricao)
            => ItemCardapioAdapter.ToViewModelLst(await _itemCardapioService.ObterItensCardapioPorDescricao(descricao));

        public async Task<IEnumerable<ItemCardapioViewModel>> ObterItensCardapioPorRefeicao(int refeicao)
            => ItemCardapioAdapter.ToViewModelLst(await _itemCardapioService.ObterItensCardapioPorRefeicao(refeicao));

        public async Task<IEnumerable<ItemCardapioViewModel>> ObterItensCardapioPorTitulo(string titulo)
            => ItemCardapioAdapter.ToViewModelLst(await _itemCardapioService.ObterItensCardapioPorTitulo(titulo));

        public void Dispose()
        {
            _itemCardapioService.Dispose();
            GC.Collect();
        }
    }
}

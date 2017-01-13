using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestauranteSiteAdmin.Domain.Interfaces;
using RestauranteSiteAdmin.Domain.Entities;

namespace RestauranteSiteAdmin.Domain.Services
{
    public class ItemCardapioService : IItemCardapioService
    {
        IRepository<ItemCardapio> _itemCardapioRepository;
        public ItemCardapioService(IRepository<ItemCardapio> itemCardapioRepository)
        {
            _itemCardapioRepository = itemCardapioRepository;
        }

        public async Task<bool> CadastrarNovoItemCardapio(ItemCardapio itemCardapio)
            => await _itemCardapioRepository.Insert(itemCardapio);

        public async Task<bool> EditarItemCardapio(ItemCardapio itemCardapio)
            => await _itemCardapioRepository.Update(itemCardapio.ItemCardapioId.ToString(), itemCardapio);

        public async Task<bool> ExcluirItemCardapio(string id)
            => await _itemCardapioRepository.Delete(id);

        public async Task<IEnumerable<ItemCardapio>> ListarItensCardapio()
            => await _itemCardapioRepository.GetAll();

        public async Task<IEnumerable<ItemCardapio>> ObterItensCardapioPorDescricao(string descricao)
            => await _itemCardapioRepository.Find(i => i.Descricao.Contains(descricao));

        public async Task<IEnumerable<ItemCardapio>> ObterItensCardapioPorRefeicao(int refeicao)
            => await _itemCardapioRepository.Find(i => (int)i.Refeicao == refeicao);

        public async Task<IEnumerable<ItemCardapio>> ObterItensCardapioPorTitulo(string titulo)
            => await _itemCardapioRepository.Find(i => i.Titulo.Contains(titulo));

        public void Dispose()
        {
            _itemCardapioRepository.Dispose();
            GC.Collect();
        }
    }
}

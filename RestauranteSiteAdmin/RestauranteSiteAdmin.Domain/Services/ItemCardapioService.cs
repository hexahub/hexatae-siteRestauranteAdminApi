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

        public Task<bool> CadastrarNovoItemCardapio(ItemCardapio itemCardapio)
            => _itemCardapioRepository.Insert(itemCardapio);

        public Task<bool> EditarItemCardapio(ItemCardapio itemCardapio)
            => _itemCardapioRepository.Update(itemCardapio.ItemCardapioId.ToString(), itemCardapio);

        public Task<bool> ExcluirItemCardapio(string id)
            => _itemCardapioRepository.Delete(id);

        public Task<IEnumerable<ItemCardapio>> ListarItensCardapio()
            => _itemCardapioRepository.GetAll();

        public Task<IEnumerable<ItemCardapio>> ObterItensCardapioPorDescricao(string descricao)
            => _itemCardapioRepository.Find(i => i.Descricao.Contains(descricao));

        public Task<IEnumerable<ItemCardapio>> ObterItensCardapioPorRefeicao(int refeicao)
            => _itemCardapioRepository.Find(i => (int)i.Refeicao == refeicao);

        public Task<IEnumerable<ItemCardapio>> ObterItensCardapioPorTitulo(string titulo)
            => _itemCardapioRepository.Find(i => i.Titulo.Contains(titulo));

        public void Dispose()
        {
            _itemCardapioRepository.Dispose();
            GC.Collect();
        }
    }
}

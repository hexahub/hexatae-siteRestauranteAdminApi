using RestauranteSiteAdmin.Application.ViewModels;
using RestauranteSiteAdmin.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteSiteAdmin.Application.Adapters
{
    public static class ItemCardapioAdapter
    {
        public static ItemCardapio ToDomain(ItemCardapioViewModel itemCardapioViewModel)
            => new ItemCardapio(itemCardapioViewModel.ItemCardapioId, itemCardapioViewModel.Titulo, itemCardapioViewModel.Descricao, (Domain.Enum.ETipoRefeicao)itemCardapioViewModel.Refeicao);

        public static ItemCardapioViewModel ToViewModel(ItemCardapio itemCardapio)
            => new ItemCardapioViewModel {Descricao = itemCardapio.Descricao, Titulo = itemCardapio.Titulo, ItemCardapioId = itemCardapio.ItemCardapioId.ToString(), Refeicao = (int)itemCardapio.Refeicao };

        public static IEnumerable<ItemCardapio> ToDomainLst(IEnumerable<ItemCardapioViewModel> itemCardapioViewModelLst)
        {
            var domainLst = new List<ItemCardapio>();

            itemCardapioViewModelLst.ToList().ForEach(i => domainLst.Add(new ItemCardapio(i.ItemCardapioId, i.Titulo, i.Descricao, (Domain.Enum.ETipoRefeicao)i.Refeicao)));

            return domainLst;
        }

        public static IEnumerable<ItemCardapioViewModel> ToViewModelLst(IEnumerable<ItemCardapio> itemCardapioLst)
        {
            var viewModelLst = new List<ItemCardapioViewModel>();

            itemCardapioLst.ToList().ForEach(i => viewModelLst.Add(new ItemCardapioViewModel { Descricao = i.Descricao, Titulo = i.Titulo, ItemCardapioId = i.ItemCardapioId.ToString(), Refeicao = (int)i.Refeicao }));

            return viewModelLst;            
        }
            
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestauranteSiteAdmin.Application.Interfaces;
using RestauranteSiteAdmin.Application.ViewModels;

namespace RestauranteSiteAdmin.API.Controllers
{
    [Route("api/[controller]")]
    public class ItemCardapioController
    {
        private readonly IItemCardapioAppService _itemCardapioApp;

        public ItemCardapioController(IItemCardapioAppService itemCardapioApp)
        {
            _itemCardapioApp = itemCardapioApp;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemCardapioViewModel>> Get()
        {
            try
            {
                return await _itemCardapioApp.ListarItensCardapio();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        [Route("refeicao/{refeicao}")]
        [HttpGet]
        public async Task<IEnumerable<ItemCardapioViewModel>> GetByRefeicao(int refeicao)
        {
            return await _itemCardapioApp.ObterItensCardapioPorRefeicao(refeicao);
        }

        [HttpPost]
        public async Task<bool> Post([FromBody]ItemCardapioViewModel item)
        {
            return await _itemCardapioApp.CadastrarNovoItemCardapio(item);
        }
    }
}

using MongoDB.Bson;
using RestauranteSiteAdmin.Domain.Enum;
using System;

namespace RestauranteSiteAdmin.Domain.Entities
{
    public class ItemCardapio
    {
        public ObjectId ItemCardapioId { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public ETipoRefeicao Refeicao { get; private set; }

        public ItemCardapio(string itemCardapioId, string titulo, string descricao, ETipoRefeicao refeicao)
        {
            ItemCardapioId = ObjectId.Parse(itemCardapioId);
            DefinirTitulo(titulo);
            DefinirDescricao(descricao);
            Refeicao = refeicao;
        }

        private void DefinirTitulo(Untrusted<string> titulo)
            => Titulo = titulo.Validate(
                a => a.Length >= 2 && a.Length <= 30,
                a => a,
                a => { throw new ArgumentException("Título deve ter entre 2 e 30 caracteres"); });
        

        private void DefinirDescricao(Untrusted<string> descricao)
            => Descricao = descricao.Validate(
                a => a.Length >= 5 && a.Length <= 60,
                a => a,
                a => { throw new ArgumentException("Título deve ter entre 5 e 60 caracteres"); });
    }
}

using MongoDB.Bson;
using RestauranteSiteAdmin.Domain.Enum;
using System;
using System.Xml.Serialization;

namespace RestauranteSiteAdmin.Domain.Entities
{
    public class ItemCardapio
    {
        [XmlIgnore]
        public ObjectId _id { get; set; }
        public ObjectId ItemCardapioId { get { return _id; } set { _id = value; } }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public ETipoRefeicao Refeicao { get; private set; }

        public ItemCardapio(string itemCardapioId, string titulo, string descricao, ETipoRefeicao refeicao)
        {
            ItemCardapioId = itemCardapioId == null ? ObjectId.GenerateNewId() : ObjectId.Parse(itemCardapioId);
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
                a => a.Length >= 5 && a.Length <= 100,
                a => a,
                a => { throw new ArgumentException("Título deve ter entre 5 e 100 caracteres"); });
    }
}

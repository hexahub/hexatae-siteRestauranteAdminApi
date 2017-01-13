using MongoDB.Bson;
using RestauranteSiteAdmin.Domain.Services;
using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace RestauranteSiteAdmin.Domain.Entities
{
    public class Usuario
    {
        [XmlIgnore]
        public ObjectId _id { get; set; }
        public ObjectId UsuarioId { get { return _id; } set { _id = value; } }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string usuarioId, string nome, string email, string senha)
        {
            UsuarioId = usuarioId == null ? ObjectId.GenerateNewId() : ObjectId.Parse(usuarioId);
            DefinirNome(nome);
            DefinirEmail(email);
            DefinirSenha(senha);
        }

        private void DefinirNome(Untrusted<string> nome)
            => Nome = nome.Validate(
                a => a.Length >= 5 && a.Length <= 30,
                a => a,
                a => { throw new ArgumentException("Nome deve ter entre 5 e 30 caracteres"); });


        private void DefinirEmail(Untrusted<string> email)
            => Email = email.Validate(
                d => new Regex(@"^[a-zA-Z0-9.!£#$%&'^_`{}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$").Match(d).Success,
                d => d,
                d => { throw new ArgumentException("Email inválido"); });

        private void DefinirSenha(Untrusted<string> senha)
            => Senha = senha.Validate(
                a => a.Length >= 7,
                a => CriptoService.Criptografar(a),
                a => { throw new ArgumentException("Senha deve ter no mínimo 7 caracteres"); });
    }
}

using MongoDB.Driver;
using System.Security.Authentication;

namespace RestauranteSiteAdmin.Data
{
    public class DataAccess
    {
        protected MongoClient _client;
        protected IMongoDatabase _db;

        public DataAccess()
        {
            string connectionString = @"mongodb://site-restaurante-admin-bd:Gi7TORI4fedyrOq3rjTaODicUtmWf3t794S57Ojp3X22w5Ty5hjFg3mKfYqh6AA93lTvgOGiDepzo1fkIHVJ2g==@site-restaurante-admin-bd.documents.azure.com:10250/?ssl=true";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            _client = new MongoClient(settings);

            _db = _client.GetDatabase("site-restaurante-admin-bd");
        }
    }
}

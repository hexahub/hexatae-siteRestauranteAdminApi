using RestauranteSiteAdmin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MongoDB.Driver;
using System.Reflection;
using MongoDB.Bson;

namespace RestauranteSiteAdmin.Data.Repositories
{
    public class Repository<T> : DataAccess, IRepository<T> where T : class
    {

        IMongoCollection<T> _collection;
        string _table;

        public Repository()
        {
            _table = typeof(T).Name;
            _collection = _db.GetCollection<T>(_table);
        }

        public async Task<IEnumerable<T>> Find(Func<T, bool> predicate)
            => _collection.Find(_ => true).ToList().Where(predicate);

        public async Task<IEnumerable<T>> GetAll()
            => await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetById(string id)
        {
            var propertyOfId = typeof(T).GetProperties().First(p => p.Name == _table + "Id").Name;
            var filter = Builders<T>.Filter.Eq(propertyOfId, ObjectId.Parse(id));
            return await _collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(T t)
        {
            try
            {
                await _collection.InsertOneAsync(t);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Update(string id, T t)
        {
            try
            {
                var propertyOfId = typeof(T).GetProperties().First(p => p.Name == _table + "Id").Name;
                var filter = Builders<T>.Filter.Eq(propertyOfId, ObjectId.Parse(id));
                await _collection.UpdateOneAsync(filter, Builders<T>.Update.Set("$", t));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var propertyOfId = typeof(T).GetProperties().First(p => p.Name == _table + "Id").Name;
                var filter = Builders<T>.Filter.Eq(propertyOfId, ObjectId.Parse(id));
                await _collection.DeleteOneAsync(filter);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Dispose() => GC.Collect();
    }
}

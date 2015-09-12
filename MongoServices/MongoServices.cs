using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoServices
{
    public class MongoServices : IMongoServices
    {
        private readonly MongoDatabase _db;

        public MongoServices(string mongoConnection, string dataBase)
        {
            _db = new MongoClient(mongoConnection).GetServer().GetDatabase(dataBase);
        }
        public T Get<T>(T obj, string id)
        {
            try
            {
                return _db.GetCollection(Tablename(obj)).FindOneByIdAs<T>(id);
            }
            catch (Exception ex)
            {
                Trace.TraceInformation(ex.Message);
                throw;
            }
        }

        public T GetByUId<T>(T obj, string id)
        {
            try
            {
                return _db.GetCollection(Tablename(obj)).FindOneByIdAs<T>(ObjectId.Parse(id));
            }
            catch (Exception ex)
            {
                Trace.TraceInformation(ex.Message);
                throw;
            }
        }

        public void Save<T>(T obj)
        {
            try
            {
                _db.GetCollection(Tablename(obj)).Save(obj);
            }
            catch (Exception ex)
            {
                Trace.TraceInformation(ex.Message);
                throw;
            }
        }

        public void Insert<T>(T obj)
        {
            try
            {
                _db.GetCollection(Tablename(obj)).Insert(obj);
            }
            catch (Exception ex)
            {
                Trace.TraceInformation(ex.Message);
                throw;
            }
        }

        private static string Tablename<T>(T obj)
        {
            return typeof(T).Name.ToLower();
        }
    }
}

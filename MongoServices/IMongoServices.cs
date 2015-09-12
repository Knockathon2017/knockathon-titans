using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoServices
{
    public interface IMongoServices
    {
        void Insert<T>(T obj);
        void Save<T>(T obj);
        T Get<T>(T obj, string id);
        T GetByUId<T>(T obj, string id);
    }
}

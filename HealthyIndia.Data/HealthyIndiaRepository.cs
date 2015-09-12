using MongoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Driver;

namespace HealthyIndia.Data
{
    public class HealthyIndiaRepository
    {
        private IMongoServices _mongo;
        

        #region Constructor

        public HealthyIndiaRepository()
        {
            _mongo = new MongoServices.MongoServices(ConfigurationManager.ConnectionStrings["mongodb"].ConnectionString, ConfigurationManager.AppSettings["database"]);
        }

        #endregion

        public User Get(string id)
        {
            if (id == null)
                throw new NullReferenceException("query cannot be null.");
            var userData = _mongo.GetByUId<User>(new User(), id);
            return userData;
        }


        public User Save(User User)
        {
            if (User == null)
                throw new NullReferenceException("sourceNeed cannot be null.");

            _mongo.Save<User>(User);

            return User;
        }

    }
}

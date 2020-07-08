using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Livemodo_db.Models;

namespace Livemodo_db.Services
{
    public class RegisteredUserService
    {
        private readonly IMongoCollection<RegisteredUser> _users;

        public RegisteredUserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            //get users collection from db
            _users = database.GetCollection<RegisteredUser>(settings.RegisteredUsersCollectionName);

        }
        public List<RegisteredUser> GetAllRegisteredUsers()
        {
            return _users.Find(user => true).ToList();
        }
        public RegisteredUser GetRegisteredUserById(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }
        public RegisteredUser PostUser(RegisteredUser user)
        {
            _users.InsertOne(user);
            return user;
        }
        public void UpdateExistingUser(string id, RegisteredUser userInDB)
        {
            _users.ReplaceOne(user => user.Id == id, userInDB);
        }

        public void DeleteExistingUser(User userInDB)
        {
            _users.DeleteOne(user => user.Id == userInDB.Id);

        }
        public void DeleteExistingUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);

        }
    }
}

using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Livemodo_db.Models;
namespace Livemodo_db.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            //get users collection from db
            _users = database.GetCollection<User>(settings.UsersCollectionName);

        }
        public List<User> GetAllUsers()
        {
            return _users.Find(user => true).ToList();
        }
        public User GetUserById(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }
        public User RegisterUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }
        public void UpdateUser(string id, User userInDB)
        {
            _users.ReplaceOne(user => user.Id == id, userInDB);          
        }

        public void DeleteUser(User userInDB)
        {
            _users.DeleteOne(user => user.Id == userInDB.Id);
           
        }
        public void DeleteUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);

        }
    }
}

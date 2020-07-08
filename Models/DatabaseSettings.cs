namespace Livemodo_db.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ReviewsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string RegisteredUsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string ReviewsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        public string RegisteredUsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}


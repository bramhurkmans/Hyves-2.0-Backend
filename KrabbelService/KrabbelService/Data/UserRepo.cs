using KrabbelService.Models;
using MongoDB.Driver;

namespace KrabbelService.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly IMongoCollection<User> _context;

        public UserRepo(MongoContext context)
        {
            _context = context.Database.GetCollection<User>(MongoCollectionNames.Users);
        }

        public void CreateUser(User user)
        {
            if(user == null) {
                throw new ArgumentNullException(nameof(user));
            }

            _context.InsertOne(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.AsQueryable().ToList();
        }

        public User GetUserById(string id)
        {
            var filter = Builders<User>.Filter.Where(k => k.Id == id);

            return _context.Find(filter).FirstOrDefault();
        }

        public User GetUserByExternalId(int id)
        {
            var filter = Builders<User>.Filter.Where(k => k.ExternalId == id);

            return _context.Find(filter).FirstOrDefault();
        }

        public bool ExternalUserExists(int externalUserId)
        {
            var filter = Builders<User>.Filter.Where(k => k.ExternalId == externalUserId);

            return _context.Find(filter).FirstOrDefault() != null;
        }

        public bool SaveChanges()
        {
            return true;
        }

        public User GetUserByKeycloakIdentifier(string keyCloakIdentifier)
        {
            var filter = Builders<User>.Filter.Where(k => k.KeyCloakIdentifier == keyCloakIdentifier);

            return _context.Find(filter).FirstOrDefault();
        }
    }
}
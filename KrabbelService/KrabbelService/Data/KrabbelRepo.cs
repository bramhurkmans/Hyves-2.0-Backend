using System;
using System.Collections.Generic;
using System.Linq;
using KrabbelService.Models;
using KrabbelService.Data;
using MongoDB.Driver;

namespace KrabbelService.Data
{
    public class KrabbelRepo : IKrabbelRepo
    {
        private readonly IMongoCollection<Krabbel> _context;

        public KrabbelRepo(MongoContext context)
        {
            _context = context.Database.GetCollection<Krabbel>(MongoCollectionNames.Krabbels);
        }

        public void CreateKrabbel(Krabbel krabbel)
        {
            if(krabbel == null) {
                throw new ArgumentNullException(nameof(krabbel));
            }

            _context.InsertOne(krabbel);
        }

        public IEnumerable<Krabbel> GetAllKrabbels()
        {
            return _context.AsQueryable().ToList();
        }

        public Krabbel GetKrabbelById(int id)
        {
            var filter = Builders<Krabbel>.Filter.Where(k => k.Id == id.ToString());

            return _context.Find(filter).FirstOrDefault();
        }

        public void RemoveKrabbel(int id)
        {
            var filter = Builders<Krabbel>.Filter.Where(k => k.Id == id.ToString());

            _context.DeleteOne(filter);
        }

        public bool SaveChanges()
        {
            return true;
        }
    }
}
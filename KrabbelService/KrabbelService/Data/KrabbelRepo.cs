using System;
using System.Collections.Generic;
using System.Linq;
using KrabbelService.Models;
using KrabbelService.Data;

namespace KrabbelService.Data
{
    public class KrabbelRepo : IKrabbelRepo
    {
        private readonly AppDbContext _context;

        public KrabbelRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateKrabbel(Krabbel krabbel)
        {
            if(krabbel == null) {
                throw new ArgumentNullException(nameof(krabbel));
            }

            _context.Add(krabbel);
        }

        public IEnumerable<Krabbel> GetAllKrabbels()
        {
            return _context.Krabbels.ToList();
        }

        public Krabbel GetKrabbelById(int id)
        {
            return _context.Krabbels.FirstOrDefault(p => p.Id == id);
        }

        public void RemoveKrabbel(int id)
        {
            var krabbel = _context.Krabbels.FirstOrDefault(p => p.Id == id);

            _context.Krabbels.Remove(krabbel);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
using System.Collections.Generic;
using KrabbelService.Models;

namespace KrabbelService.Data
{
    public interface IKrabbelRepo
    {
        public bool SaveChanges();

        IEnumerable<Krabbel> GetAllKrabbels();

        Krabbel GetKrabbelById(int id);

        void CreateKrabbel(Krabbel krabbel);

        void RemoveKrabbel(int id);
    }
}
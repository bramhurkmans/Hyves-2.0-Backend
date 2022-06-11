using System.Collections.Generic;
using KrabbelService.Models;

namespace KrabbelService.Data
{
    public interface IKrabbelRepo
    {
        public bool SaveChanges();

        IEnumerable<Profile> GetAllProfiles();

        Profile GetProfileById(int id);

        void CreateProfile(Profile profile);
    }
}
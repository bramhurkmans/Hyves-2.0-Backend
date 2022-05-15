using System.Collections.Generic;
using ProfileService.Models;

namespace ProfileService.Data
{
    public interface IProfileRepo
    {
        public bool SaveChanges();

        IEnumerable<Profile> GetAllProfiles();

        Profile GetProfileById(int id);

        void CreateProfile(Profile profile);
    }
}
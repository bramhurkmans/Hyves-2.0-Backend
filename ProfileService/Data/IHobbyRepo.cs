using System.Collections.Generic;
using ProfileService.Models;

namespace ProfileService.Data
{
    public interface IHobbyRepo
    {
        public bool SaveChanges();

        IEnumerable<Hobby> GetAllHobbies();

        IEnumerable<Hobby> getHobbiesByProfileId(int profileId);

        Hobby GetHobbyById(int id);

        void CreateHobby(Hobby hobby);

        void RemoveHobby(int hobbyId);
    }
}
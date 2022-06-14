using KrabbelService.Data;
using KrabbelService.Models;
using System.Security.Claims;

namespace KrabbelService.Logic
{
    public class KrabbelLogic : IKrabbelLogic
    {
        private readonly IUserRepo _userRepo;
        private readonly IKrabbelRepo _krabbelRepo;

        public KrabbelLogic(IUserRepo userRepo, IKrabbelRepo krabbelRepo)
        {
            _userRepo = userRepo;
            _krabbelRepo = krabbelRepo;
        }

        public bool Createkrabbel(ClaimsPrincipal claimsPrincipal, int receiverId, string text)
        {
            var sender = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            var receiver = _userRepo.GetUserById(receiverId);

            if(sender == null || receiver == null) return false;

            var krabbel  = new Krabbel()
            {
                Text = text,
                Sender = sender,
                Receiver = receiver,

            };

            _krabbelRepo.CreateKrabbel(krabbel);

            return _krabbelRepo.SaveChanges();
        }

        public bool RemoveKrabbel(ClaimsPrincipal claimsPrincipal, int krabbelId)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            var krabbel = _krabbelRepo.GetKrabbelById(krabbelId);

            if(krabbel.Receiver.Id == user.Id || krabbel.Sender.Id == user.Id)
            {
                _krabbelRepo.RemoveKrabbel(krabbelId);
                return _krabbelRepo.SaveChanges();
            }

            return false;
        }

        public ICollection<Krabbel> GetKrabbels(int userId)
        {
            var user = _userRepo.GetUserById(userId);

            if (user == null) return new List<Krabbel>();

            return user.Krabbels;
        }
    }
}

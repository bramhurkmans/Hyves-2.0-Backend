﻿using KrabbelService.Models;
using System.Security.Claims;

namespace KrabbelService.Logic
{
    public interface IKrabbelLogic
    {
        public ICollection<Krabbel> GetKrabbels(int userId);

        public bool Createkrabbel(ClaimsPrincipal claimsPrincipal, int receiverId, string text);

        public bool RemoveKrabbel(ClaimsPrincipal claimsPrincipal, int krabbelId);
    }
}
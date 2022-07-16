using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Models;

namespace disease_tracker_api.Data
{
   public class AuthRespository : IAuthRepository
   {
      public Task<ServiceResponse<string>> Login(string username, string password)
      {
         throw new NotImplementedException();
      }

      public Task<ServiceResponse<int>> Register(User user, string password)
      {
         throw new NotImplementedException();
      }

      public Task<bool> UserExists(string username)
      {
         throw new NotImplementedException();
      }
   }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using disease_tracker_api.Models;
using Microsoft.EntityFrameworkCore;

namespace disease_tracker_api.Data
{
   public class AuthRespository : IAuthRepository
   {
    
      private readonly DataContext _context;
      private readonly IConfiguration _configuration;

      public AuthRespository(DataContext context, IConfiguration configuration)
      {
         _context = context;
         _configuration = configuration;
      }

      public async Task<ServiceResponse<string>> Login(string email, string password)
      {
         ServiceResponse<string> response = new ServiceResponse<string>();
         User user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
         if (user ==null) {
         response.Success = false;
         response.Messsage = "Invalid credentials";
         } else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) 
         {
         response.Success = false;
         response.Messsage = "Invalid credentials";
         } else 
         {
            response.Data = user.Id.ToString();
         // response.Data = CreateToken(user);
         }

         return response;
      }

      public async Task<ServiceResponse<int>> Register(User user, string password)
      {
        ServiceResponse<int> response = new ServiceResponse<int>();

        if(await UserExists(user.Email)) {
          response.Success = false;
          response.Messsage = "Email already exists";
          return response;
        }

         CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

         user.PasswordHash = passwordHash;
         user.PasswordSalt = passwordSalt;

         await _context.Users.AddAsync(user);
         await _context.SaveChangesAsync();
         
         response.Data = user.Id;
         return response;
      }

      public async Task<bool> UserExists(string email)
      {
         if(await _context.Users.AnyAsync(x=> x.Email.ToLower() == email.ToLower())) {
         return true;
         }
         return false;
      }

      private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
      {
         using(var hmac = new System.Security.Cryptography.HMACSHA512())
         {
               passwordSalt = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
         }
      }

      private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) 
      {
         using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
         {
         var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
         for(int i=0; i < computedHash.Length; i++)
         {
            if(computedHash[i] != passwordHash[i]) {
               return false;
            }
         }
         return true;
         }
      }
   }
}
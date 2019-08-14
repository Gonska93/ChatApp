using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Contracts.Responses;
using ChatApp.Data;
using ChatApp.Models;
using ChatApp.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ApplicationDbContext _context;

        public IdentityService( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserRegistrationResponse> RegisterAsync(string username, string password1, string password2)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Name.Equals(username));

            if (existingUser != null)
            {
                return new UserRegistrationResponse
                {
                    Ok = false,
                    Description = "User with this name has been already registered"
                };
            }
            else if (!password1.Equals(password2))
            {
                return new UserRegistrationResponse
                {
                    Ok = false,
                    Description = "Passwords do not match"
                };
            }

            var newUser = new User
            {
                Name = username,
                Password = SecurePasswordHasher.Hash(password1)
            };

            var createdUser = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            
            return new UserRegistrationResponse
            {
                Ok = true,
                Description = "User has been successfully registered"
            }; ;
        }
    }
}

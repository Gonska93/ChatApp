using ChatApp.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Services
{
    public interface IIdentityService
    {
        Task<UserRegistrationResponse> RegisterAsync(string username, string password1, string password2);
    }
}

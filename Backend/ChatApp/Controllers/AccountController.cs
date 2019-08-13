using ChatApp.Contracts.Requests;
using ChatApp.Contracts.Responses;
using ChatApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage));
                return BadRequest(new UserRegistrationResponse
                {
                    Ok = false,
                    Description = message
                });
            }

            var authResponse = await _identityService.RegisterAsync(request.Username, request.Password1, request.Password2);

            if (!authResponse.Ok)
            {
                return BadRequest(authResponse);
            }

            return Ok(authResponse);
        }
    }
}

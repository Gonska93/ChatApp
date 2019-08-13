using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Contracts.Responses
{
    public class UserRegistrationResponse
    {
        public bool Ok { get; set; }
        public string Description { get; set; }
    }
}

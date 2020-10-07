using Microsoft.AspNetCore.Identity;
using System;

namespace Zoe.IdentityAccess.Api.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string PreferredName { get; set; }
    }
}

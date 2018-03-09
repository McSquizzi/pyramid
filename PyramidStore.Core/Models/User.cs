using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PyramidStore.Core.Models
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public override string Email { get; set; }
        public string Password { get; set; }
    }
}

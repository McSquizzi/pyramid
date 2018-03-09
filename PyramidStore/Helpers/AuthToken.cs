using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidStore.Helpers
{
    public class AuthToken
    {
        public const string ISSUER = "PyramidStore";
        public const string AUDIENCE = "AuthController";
        const string KEY = "0123456789ABCDEF";
        public const int LIFETIME = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}

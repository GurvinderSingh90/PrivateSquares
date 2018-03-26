using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Services
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string Secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}

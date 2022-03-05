using LuftBornTask.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace LuftBornTask.API.jwt
{
    public class JwtFactory
    {
        public string GenerateToken(byte[] key, ApplicationUser user, IList<string> userRoles,long employeeId)
        {
            IdentityOptions _options = new IdentityOptions();
            var userClamis = new ClaimsIdentity(new Claim[]
            {
                    new Claim("UserId",user.Id),
                    new Claim("empId",employeeId.ToString())
            });
            userClamis.AddClaims(userRoles.Select(role => new Claim("UserRoles", role)));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = userClamis,
                Expires = DateTime.UtcNow.AddHours(9),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}

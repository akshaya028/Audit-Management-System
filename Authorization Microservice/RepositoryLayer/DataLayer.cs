using Authorization_Microservice.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorization_Microservice.RepositoryLayer
{
    public class DataLayer : IAuthManager
    {
        private string key;

        public DataLayer()
        {

        }

        public DataLayer(string key)
        {
            this.key = key;
        }

        public string Validate(PortalLoginDetails loginDetails)
        {
            using (AuditManagementSystemContext context = new AuditManagementSystemContext())
            {
                Logindetail detail = context.Logindetails.Where(u => u.UserName == loginDetails.username && u.Passwrd == loginDetails.password).FirstOrDefault();
                if (detail != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes(key);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] { 
                            new Claim(ClaimTypes.Name,detail.UserName)
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature),
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

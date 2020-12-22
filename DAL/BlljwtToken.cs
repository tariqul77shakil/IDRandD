using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace WebAppTest1.DAL
{
    public class BlljwtToken
    {
        public JsonWebToken BuildJWTToken(IConfiguration _config)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = _config["JwtToken:Issuer"];
            var audience = _config["JwtToken:Audience"];
            var jwtEntryTime = DateTime.Now;
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_config["JwtToken:TokenExpiry"]));

            var userCliams = new Claim[]{
            new Claim("Email", _config["AuthLogin:Email"])
             };

            var token = new JwtSecurityToken(issuer,
              audience,
              expires: jwtValidity,
              signingCredentials: creds,
              claims: userCliams);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var refresh_token = GetRefreshToken();

            JsonWebToken tokendata = new JsonWebToken
            {
                AccessToken = tokenString,
                RefreshToken = refresh_token,
                EntryTime = jwtEntryTime,
                ExpireTime = jwtValidity,
                Expires = _config["JwtToken:TokenExpiry"]
            };


            return tokendata;
        }

        public string GetRefreshToken()
        {
            var key = new Byte[32];
            using (var refreshTokenGenerator = RandomNumberGenerator.Create())
            {
                refreshTokenGenerator.GetBytes(key);
                return Convert.ToBase64String(key);
            }
        }

        public JsonWebToken BuildJWTRefreshToken(string email, IConfiguration _config)
        {

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"]));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtEntryTime = DateTime.Now;
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_config["JwtToken:TokenExpiry"]));

            var userCliams = new Claim[]{
            new Claim("Email", _config["AuthLogin:Email"])
             };

            var newJwtToken = new JwtSecurityToken(
                    issuer: _config["JwtToken:Issuer"],
                    audience: _config["JwtToken:Audience"],
                    expires: jwtValidity,
                    signingCredentials: credentials,
                    claims: userCliams
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(newJwtToken);

            var refresh_token = GetRefreshToken();

            JsonWebToken tokendata = new JsonWebToken
            {
                AccessToken = tokenString,
                RefreshToken = refresh_token,
                EntryTime = jwtEntryTime,
                ExpireTime = jwtValidity,
                Expires = _config["JwtToken:TokenExpiry"]
            };


            return tokendata;
        }
    }
}

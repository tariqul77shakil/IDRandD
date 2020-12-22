using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text;
using WebAppTest1.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Security.Cryptography;

namespace WebAppTest1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly IConfiguration _config;     

        public SecurityController(ILogger<SecurityController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }       
        
        BllAuthen objBllAuthen = new BllAuthen();
        BlljwtToken objBlljwtTokenn = new BlljwtToken();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginModel login)
        {
            if (login == null) return Unauthorized();
            var jsonWebToken = new JsonWebToken();

            bool validUser = objBllAuthen.Authenticate(login, _config);
            if (validUser)
            {
                jsonWebToken = objBlljwtTokenn.BuildJWTToken(_config);
            }
            else
            {
                return await Task.FromResult(Unauthorized());
            }

            if (jsonWebToken == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(jsonWebToken));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] JwtRefreshToken refreshToken)
        {
            var jsonWebToken = new JsonWebToken();

            var tokenHandler = new JwtSecurityTokenHandler();
            var claimsPrincipal = tokenHandler.ValidateToken(refreshToken.AccessToken,
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _config["JwtToken:Issuer"],
                ValidateAudience = true,
                ValidAudience = _config["JwtToken:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"])),
                ValidateLifetime = true
            }, out SecurityToken validatedToken);


            var jwtToken = validatedToken as JwtSecurityToken;

            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                return null;
            }
            var email = claimsPrincipal.Claims.Where(_ => _.Type == ClaimTypes.Email).Select(_ => _.Value).FirstOrDefault();

            bool validUser = objBllAuthen.AuthenticateRefresh(refreshToken, _config);
            if (validUser)
            {
                jsonWebToken = objBlljwtTokenn.BuildJWTRefreshToken(email, _config);
            }
            else
            {
                return await Task.FromResult(Unauthorized());
            }

            if (jsonWebToken == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(jsonWebToken));
        }
    }
}

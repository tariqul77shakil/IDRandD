using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppTest1.DAL
{
    public class BllAuthen
    {
        
        public bool Authenticate(LoginModel login, IConfiguration _config)
        {
            bool validUser = false;
            string strval = _config["AuthLogin:Password"];

            if (login.Username == _config["AuthLogin:UserName"] && login.Password == _config["AuthLogin:Password"])
            {
                validUser = true;
            }
            return validUser;
        }

        public bool AuthenticateRefresh(JwtRefreshToken refreshToken, IConfiguration _config)
        {
            bool validUser = false;
            if (refreshToken.Username == _config["AuthLogin:UserName"] && refreshToken.RefreshToken == _config["AuthLogin:Password"])
            {
                validUser = true;
            }
            else  /// need checnage
            {
                validUser = true;
            }

            return validUser;
        }
    }
}

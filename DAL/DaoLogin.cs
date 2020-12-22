using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAppTest1.DAL
{
   public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Orgcode { get; set; }
    }

    public class JwtRefreshToken
    {
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class JsonWebToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Expires { get; set; }
        public DateTime EntryTime { get;  set; }
        public DateTime ExpireTime { get;  set; }
    }

}

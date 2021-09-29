using System;

namespace Api.Domain.Models
{
    public class UserModel : BaseModel
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _refreshToken;
        public string RefreshToken
        {
            get { return _refreshToken; }
            set { _refreshToken = value; }
        }

        private DateTime _refreshTokenExpireTime;
        public DateTime RefreshTokenExpireTime
        {
            get { return _refreshTokenExpireTime; }
            set { _refreshTokenExpireTime = value; }
        }
    }
}

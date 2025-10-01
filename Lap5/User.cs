using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap5
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ManagementUser
    {
        private List<User> _user = new List<User>();
        private readonly object _lock = new object();

        public bool Register(string UserName, string Password)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException("User name or password cannot be empty");

            UserName = UserName.Trim();
            Password = Password.Trim();

            if (_user.Exists(u => u.UserName == UserName))
                return false;

            _user.Add(new User { UserName = UserName, Password = Password });
            return true;
        }

        public bool Login (string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            username = username.Trim();
            password = password.Trim();

            lock (_lock)
            {
                return _user.Exists(u => u.UserName == username && u.Password == password);
            }
        }
    }
}

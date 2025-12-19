using Journal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Services
{
    internal class UserService
    {
        private readonly JournalDatabase _database;

        public UserService(JournalDatabase database)
        {
            _database = database;
        }

        public bool UserExists()
        {
            return _database.Database.Table<User>().Any();
        }

        public void Register(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password
            };

            _database.Database.Insert(user);
        }

        public bool Login(string username, string password)
        {
            var user = _database.Database
                .Table<User>()
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
                return false;

            return user.Password == password;
        }
    }
}

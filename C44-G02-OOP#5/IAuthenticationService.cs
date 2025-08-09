using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G02_OOP_5
{
    internal interface IAuthenticationService
    {
        bool AuthenticateUser(string username, string password);
        bool AuthorizeUser(string username, string role);
    }

    public class BasicAuthenticationService : IAuthenticationService
    {
        // Demo store: username -> (password, roles)
        private readonly Dictionary<string, (string Password, HashSet<string> Roles)> _users =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["alice"] = ("pass123", new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "User", "Admin" }),
                ["bob"] = ("secret", new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "User" })
            };

        public bool AuthenticateUser(string username, string password)
        {
            if (!_users.TryGetValue(username, out var info)) return false;
            // In real life: never store plain passwords; use salted hashing.
            return info.Password == password;
        }

        public bool AuthorizeUser(string username, string role)
        {
            if (!_users.TryGetValue(username, out var info)) return false;
            return info.Roles.Contains(role);
        }
    }
}

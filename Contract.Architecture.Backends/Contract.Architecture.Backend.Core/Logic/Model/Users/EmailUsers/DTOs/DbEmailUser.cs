using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUsers;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Model.Users.EmailUsers
{
    internal class DbEmailUser : IDbEmailUser
    {
        public string Email { get; set; }

        public Guid Id { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
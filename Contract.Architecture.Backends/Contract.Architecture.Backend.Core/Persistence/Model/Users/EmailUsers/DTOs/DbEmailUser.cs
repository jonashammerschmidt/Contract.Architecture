using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUsers;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Model.Users.EmailUsers
{
    internal class DbEmailUser : IDbEmailUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public static DbEmailUser FromEfEmailUser(EfEmailUser emailUser)
        {
            if (emailUser == null)
            {
                return null;
            }

            return new DbEmailUser()
            {
                Id = emailUser.Id,
                Email = emailUser.Email,
                PasswordHash = emailUser.PasswordHash,
                PasswordSalt = emailUser.PasswordSalt
            };
        }

        public static EfEmailUser ToEfEmailUser(IDbEmailUser emailUser)
        {
            return new EfEmailUser()
            {
                Id = emailUser.Id,
                Email = emailUser.Email,
                PasswordHash = emailUser.PasswordHash,
                PasswordSalt = emailUser.PasswordSalt
            };
        }

        public static void UpdateEfEmailUser(EfEmailUser efEmailUser, IDbEmailUser emailUser)
        {
            efEmailUser.Id = emailUser.Id;
            efEmailUser.Email = emailUser.Email;
            efEmailUser.PasswordHash = emailUser.PasswordHash;
            efEmailUser.PasswordSalt = emailUser.PasswordSalt;
        }
    }
}
using System;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.UserManagement.EmailUsers
{
    public interface IDbEmailUser
    {
        Guid Id { get; set; }

        string Email { get; set; }

        string PasswordHash { get; set; }

        string PasswordSalt { get; set; }
    }
}
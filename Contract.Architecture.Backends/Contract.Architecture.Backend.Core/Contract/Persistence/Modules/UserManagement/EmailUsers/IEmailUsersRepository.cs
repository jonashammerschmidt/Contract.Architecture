using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.UserManagement.EmailUsers
{
    public interface IEmailUsersRepository
    {
        void CreateEmailUser(IDbEmailUser emailUser);

        void DeleteEmailUser(Guid emailUserId);

        IDbEmailUser GetEmailUser(Guid emailUserId);

        IDbEmailUser GetEmailUser(string mail);

        IEnumerable<IDbEmailUser> GetEmailUsers();

        void UpdateEmailUser(IDbEmailUser emailUser);
    }
}
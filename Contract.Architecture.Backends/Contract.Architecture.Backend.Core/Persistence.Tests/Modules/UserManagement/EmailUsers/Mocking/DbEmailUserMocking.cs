using Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUsers;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.UserManagement.EmailUsers
{
    internal static class DbEmailUserMocking
    {
        internal static DbEmailUser CreateWithMandant()
        {
            return CreateWithMandant(Guid.NewGuid());
        }

        internal static DbEmailUser CreateWithMandant(Guid id)
        {
            return new DbEmailUser()
            {
                Id = id,
                Email = "test@example.org",
                PasswordHash = "lLj3sQPf1isP6T1CZWZ9RMN3W9okAdTk4OjooKHO+9BT5tJ55euCLde8ifSl6ru6SuaypWRiE1nkiZPNHDbu4A==",
                PasswordSalt = "50000.voYJdI+L2w/atDbVrWlMRUw8MkmXeBO9c35Ms2wQZfYQkw==",
            };
        }
    }
}
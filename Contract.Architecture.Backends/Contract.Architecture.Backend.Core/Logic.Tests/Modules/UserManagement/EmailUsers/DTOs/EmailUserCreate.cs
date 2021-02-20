using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUsers;

namespace Contract.Architecture.Backend.Core.API.Modules.Users.EmailUsers
{
    public class EmailUserCreate : IEmailUserCreate
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
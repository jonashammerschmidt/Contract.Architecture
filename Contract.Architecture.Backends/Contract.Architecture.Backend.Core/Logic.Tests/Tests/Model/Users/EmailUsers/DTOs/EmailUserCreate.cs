using Contract.Architecture.Backend.Core.Contract.Logic.Model.Users.EmailUsers;

namespace Contract.Architecture.Backend.Core.API.Model.Users.EmailUsers
{
    public class EmailUserCreate : IEmailUserCreate
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
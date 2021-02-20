using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;

namespace Contract.Architecture.Backend.Core.Logic.Tools.Password
{
    internal class PasswordHash : IPasswordHash
    {
        public string PasswordHash { get; set; }

        public string Salt { get; set; }
    }
}
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;

namespace Contract.Architecture.Backend.Core.Logic.Services.Password
{
    internal class BsiPasswordHash : IBSIPasswordHash
    {
        public string PasswordHash { get; set; }

        public string Salt { get; set; }
    }
}
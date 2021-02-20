using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;

namespace Contract.Architecture.Backend.Core.Logic.Tools.Password
{
    internal class PasswordHasher : IPasswordHasher
    {
        public bool ComparePasswords(string passwordToHash, string passwordHash, string passwordSalt)
        {
            PBKDF2Service cryptoService = new PBKDF2Service();

            string passwordHash2 = cryptoService.Compute(passwordToHash, passwordSalt);

            bool isPasswordValid = cryptoService.Compare(passwordHash, passwordHash2);

            return isPasswordValid;
        }

        public IPasswordHash HashPassword(string password)
        {
            PasswordHash passwordHash = new PasswordHash();

            PBKDF2Service cryptoService = new PBKDF2Service();
            passwordHash.Salt = cryptoService.GenerateSalt();
            passwordHash.PasswordHash = cryptoService.Compute(password);

            return passwordHash;
        }

        public IPasswordHash HashPassword(string password, string salt)
        {
            PasswordHash passwordHash = new PasswordHash();

            PBKDF2Service cryptoService = new PBKDF2Service();
            passwordHash.Salt = salt;
            passwordHash.PasswordHash = cryptoService.Compute(password, salt);

            return passwordHash;
        }
    }
}
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;

namespace Contract.Architecture.Backend.Core.Logic.Services.Password
{
    internal class BsiPasswordService : IBsiPasswordService
    {
        public bool ComparePasswords(string passwordToHash, string passwordHash, string passwordSalt)
        {
            PBKDF2Service cryptoService = new PBKDF2Service();

            string passwordHash2 = cryptoService.Compute(passwordToHash, passwordSalt);

            bool isPasswordValid = cryptoService.Compare(passwordHash, passwordHash2);

            return isPasswordValid;
        }

        public IBSIPasswordHash HashPassword(string password)
        {
            BsiPasswordHash passwordHash = new BsiPasswordHash();

            PBKDF2Service cryptoService = new PBKDF2Service();
            passwordHash.Salt = cryptoService.GenerateSalt();
            passwordHash.PasswordHash = cryptoService.Compute(password);

            return passwordHash;
        }

        public IBSIPasswordHash HashPassword(string password, string salt)
        {
            BsiPasswordHash passwordHash = new BsiPasswordHash();

            PBKDF2Service cryptoService = new PBKDF2Service();
            passwordHash.Salt = salt;
            passwordHash.PasswordHash = cryptoService.Compute(password, salt);

            return passwordHash;
        }
    }
}
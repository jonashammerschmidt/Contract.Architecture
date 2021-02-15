namespace Contract.Architecture.Backend.Core.Contract.Logic.Services.Password
{
    public interface IBsiPasswordService
    {
        bool ComparePasswords(string passwordToHash, string passwordHash, string passwordSalt);

        IBSIPasswordHash HashPassword(string password);

        IBSIPasswordHash HashPassword(string password, string salt);
    }
}
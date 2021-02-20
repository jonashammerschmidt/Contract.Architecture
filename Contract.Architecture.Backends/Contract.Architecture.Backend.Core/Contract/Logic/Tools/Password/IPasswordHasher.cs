namespace Contract.Architecture.Backend.Core.Contract.Logic.Tools.Password
{
    public interface IPasswordHasher
    {
        bool ComparePasswords(string passwordToHash, string passwordHash, string passwordSalt);

        IPasswordHash HashPassword(string password);

        IPasswordHash HashPassword(string password, string salt);
    }
}
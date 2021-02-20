namespace Contract.Architecture.Backend.Core.Contract.Logic.Services.Password
{
    public interface IPasswordHash
    {
        string PasswordHash { get; set; }

        string Salt { get; set; }
    }
}
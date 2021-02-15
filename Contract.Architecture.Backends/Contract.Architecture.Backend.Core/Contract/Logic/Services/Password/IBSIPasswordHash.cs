namespace Contract.Architecture.Backend.Core.Contract.Logic.Services.Password
{
    public interface IBSIPasswordHash
    {
        string PasswordHash { get; set; }

        string Salt { get; set; }
    }
}
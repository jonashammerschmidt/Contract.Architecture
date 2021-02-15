namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUsers
{
    public interface IEmailUserCreate
    {
        string Email { get; set; }

        string Password { get; set; }
    }
}
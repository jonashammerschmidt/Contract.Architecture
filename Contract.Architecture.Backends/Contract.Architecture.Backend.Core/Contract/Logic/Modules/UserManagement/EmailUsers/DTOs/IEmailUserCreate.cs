namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.UserManagement.EmailUsers
{
    public interface IEmailUserCreate
    {
        string Email { get; set; }

        string Password { get; set; }
    }
}
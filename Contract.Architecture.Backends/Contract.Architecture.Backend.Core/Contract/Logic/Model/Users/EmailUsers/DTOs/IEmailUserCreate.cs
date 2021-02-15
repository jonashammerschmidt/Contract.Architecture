namespace Contract.Architecture.Backend.Core.Contract.Logic.Model.Users.EmailUsers
{
    public interface IEmailUserCreate
    {
        string Email { get; set; }

        string Password { get; set; }
    }
}
namespace Contract.Architecture.Backend.Core.Contract.Logic.Services.Email
{
    public interface IEmailService
    {
        void Send(IEmail email);
    }
}
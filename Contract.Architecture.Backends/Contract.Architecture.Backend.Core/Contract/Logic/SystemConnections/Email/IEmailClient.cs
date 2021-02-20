namespace Contract.Architecture.Backend.Core.Contract.Logic.Services.Email
{
    public interface IEmailClient
    {
        void Send(IEmail email);
    }
}
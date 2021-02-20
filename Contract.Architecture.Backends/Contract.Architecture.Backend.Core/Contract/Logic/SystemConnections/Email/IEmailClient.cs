namespace Contract.Architecture.Backend.Core.Contract.Logic.SystemConnections.Email
{
    public interface IEmailClient
    {
        void Send(IEmail email);
    }
}
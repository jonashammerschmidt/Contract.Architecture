namespace Contract.Architecture.Backend.Core.Contract.Logic.SystemConnections.Email
{
    public interface IEmail
    {
        string To { get; set; }

        string Subject { get; set; }

        string Message { get; set; }
    }
}
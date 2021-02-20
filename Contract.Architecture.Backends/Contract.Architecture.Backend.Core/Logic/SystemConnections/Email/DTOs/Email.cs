using Contract.Architecture.Backend.Core.Contract.Logic.Services.Email;

namespace Contract.Architecture.Backend.Core.Logic.SystemConnections.Email
{
    internal class Email : IEmail
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
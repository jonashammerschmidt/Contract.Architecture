namespace Contract.Architecture.Backend.Core.Logic.SystemConnections.Email
{
    internal class EmailClientOptions : OptionsFromConfiguration
    {
        public override string Position => "Services:Smtp";

        public string SmtpSender { get; set; }

        public string SmtpHost { get; set; }

        public int? SmtpPort { get; set; }

        public bool EnableSsl { get; set; }
    }
}
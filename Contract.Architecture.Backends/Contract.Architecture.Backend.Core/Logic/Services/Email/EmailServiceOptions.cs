namespace Contract.Architecture.Backend.Core.Logic.Services.Email
{
    internal class EmailServiceOptions : OptionsFromConfiguration
    {
        public override string Position => "Services:Smtp";

        public string SmtpSender { get; set; }

        public string SmtpHost { get; set; }

        public int? SmtpPort { get; set; }

        public bool EnableSsl { get; set; }
    }
}
namespace Contract.Architecture.Backend.Core.Logic.Modules.Sessions.Sessions
{
    internal class SessionExpirationOptions : OptionsFromConfiguration
    {
        public override string Position => "ContractArchitecture:Sessions:Expiration";

        public bool RunOnInitialization { get; set; }

        public int ExpirationTimeInMinutes { get; set; }
    }
}
namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUserPasswordReset
{
    public interface IBrowserInfo
    {
        string Browser { get; set; }

        string OperatingSystem { get; set; }
    }
}
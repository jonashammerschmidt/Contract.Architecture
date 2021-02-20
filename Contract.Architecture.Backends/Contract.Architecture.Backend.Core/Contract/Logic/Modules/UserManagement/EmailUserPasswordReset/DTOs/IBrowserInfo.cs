namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.UserManagement.EmailUserPasswordReset
{
    public interface IBrowserInfo
    {
        string Browser { get; set; }

        string OperatingSystem { get; set; }
    }
}
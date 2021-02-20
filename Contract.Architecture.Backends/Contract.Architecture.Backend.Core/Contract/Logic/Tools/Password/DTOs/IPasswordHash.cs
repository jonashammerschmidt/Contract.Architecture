namespace Contract.Architecture.Backend.Core.Contract.Logic.Tools.Password
{
    public interface IPasswordHash
    {
        string Hash { get; set; }

        string Salt { get; set; }
    }
}
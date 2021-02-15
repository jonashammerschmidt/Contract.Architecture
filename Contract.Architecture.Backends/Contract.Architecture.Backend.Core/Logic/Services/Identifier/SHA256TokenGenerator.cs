using Contract.Architecture.Backend.Core.Contract.Logic.Services.Identifier;
using System.Security.Cryptography;
using System.Text;

namespace Contract.Architecture.Backend.Core.Logic.Services.Identifier
{
    internal class SHA256TokenGenerator : ISHA256TokenGenerator
    {
        private readonly IGuidGenerator guidGenerator;

        public SHA256TokenGenerator(IGuidGenerator guidGenerator)
        {
            this.guidGenerator = guidGenerator;
        }

        public string Generate()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(this.guidGenerator.NewGuid().ToByteArray());

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
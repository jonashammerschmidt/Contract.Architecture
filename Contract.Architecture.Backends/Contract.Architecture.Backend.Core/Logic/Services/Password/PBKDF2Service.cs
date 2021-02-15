using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Contract.Architecture.Backend.Core.Logic.Services.Password
{
    internal class PBKDF2Service
    {
        public PBKDF2Service()
        {
            // Set default salt size and hashiterations
            // See https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Password_Storage_Cheat_Sheet.md
            this.HashIterations = 50000;
            this.SaltSize = 34;
        }

        public string HashedText { get; private set; }

        public int HashIterations { get; set; }

        public string PlainText { get; set; }

        public string Salt { get; set; }

        public int SaltSize { get; set; }

        public bool Compare(string passwordHash1, string passwordHash2)
        {
            if (passwordHash1 == null || passwordHash2 == null)
            {
                return false;
            }

            int min_length = Math.Min(passwordHash1.Length, passwordHash2.Length);
            int result = 0;

            for (int i = 0; i < min_length; i++)
            {
                result |= passwordHash1[i] ^ passwordHash2[i];
            }

            return result == 0;
        }

        public string Compute()
        {
            if (string.IsNullOrEmpty(this.PlainText))
            {
                throw new InvalidOperationException("PlainText cannot be empty");
            }

            // if there is no salt, generate one
            if (string.IsNullOrEmpty(this.Salt))
            {
                this.GenerateSalt();
            }

            this.HashedText = this.CalculateHash(this.HashIterations);

            return this.HashedText;
        }

        public string Compute(string textToHash)
        {
            this.PlainText = textToHash;

            this.Compute();
            return this.HashedText;
        }

        public string Compute(string textToHash, string salt)
        {
            this.PlainText = textToHash;
            this.Salt = salt;

            this.ExpandSalt();
            this.Compute();
            return this.HashedText;
        }

        public string GenerateSalt()
        {
            if (this.SaltSize < 1)
            {
                throw new InvalidOperationException(string.Format("Cannot generate a salt of size {0}, use a value greater than 1, recommended: 16", this.SaltSize));
            }

            var rand = RandomNumberGenerator.Create();

            var ret = new byte[this.SaltSize];

            rand.GetBytes(ret);

            // assign the generated salt in the format of {iterations}.{salt}
            this.Salt = string.Format("{0}.{1}", this.HashIterations, Convert.ToBase64String(ret));

            return this.Salt;
        }

        public int GetElapsedTimeForIteration(int iteration)
        {
            var sw = new Stopwatch();
            sw.Start();
            this.CalculateHash(iteration);
            return (int)sw.ElapsedMilliseconds;
        }

        private string CalculateHash(int iteration)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(this.Salt);

            var pbkdf2 = new Rfc2898DeriveBytes(this.PlainText, saltBytes, iteration);
            var key = pbkdf2.GetBytes(64);
            return Convert.ToBase64String(key);
        }

        private void ExpandSalt()
        {
            try
            {
                var i = this.Salt.IndexOf('.');

                this.HashIterations = int.Parse(this.Salt.Substring(0, i), System.Globalization.NumberStyles.Number);
            }
            catch (Exception)
            {
                throw new FormatException("The salt was not in an expected format of {int}.{string}");
            }
        }
    }
}
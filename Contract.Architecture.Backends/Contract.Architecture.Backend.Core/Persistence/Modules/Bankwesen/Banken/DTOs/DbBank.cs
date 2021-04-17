using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Bankwesen.Banken
{
    internal class DbBank : IDbBank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        internal static void UpdateEfBank(EfBank efBank, IDbBank dbBank)
        {
            efBank.Name = dbBank.Name;
            efBank.Boolean = dbBank.Boolean;
            efBank.DateTime = dbBank.DateTime;
            efBank.Double = dbBank.Double;
            efBank.Guid = dbBank.Guid;
            efBank.Integer = dbBank.Integer;
        }

        internal static IDbBank FromEfBank(EfBank efBank)
        {
            if (efBank == null)
            {
                return null;
            }

            return new DbBank()
            {
                Id = efBank.Id,
                Name = efBank.Name,
                Boolean = efBank.Boolean,
                DateTime = efBank.DateTime,
                Double = efBank.Double,
                Guid = efBank.Guid,
                Integer = efBank.Integer,
            };
        }

        internal static EfBank ToEfBank(IDbBank dbBank)
        {
            return new EfBank()
            {
                Id = dbBank.Id,
                Name = dbBank.Name,
                Boolean = dbBank.Boolean,
                DateTime = dbBank.DateTime,
                Double = dbBank.Double,
                Guid = dbBank.Guid,
                Integer = dbBank.Integer,
            };
        }
    }
}
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Bankwesen.Banken
{
    internal class Bank : IBank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        internal static void UpdateDbBank(IDbBank dbBank, IBankUpdate bankUpdate)
        {
            dbBank.Name = bankUpdate.Name;
            dbBank.Boolean = bankUpdate.Boolean;
            dbBank.DateTime = bankUpdate.DateTime;
            dbBank.Double = bankUpdate.Double;
            dbBank.Guid = bankUpdate.Guid;
            dbBank.Integer = bankUpdate.Integer;
        }

        internal static IBank FromDbBank(IDbBank dbBank)
        {
            return new Bank()
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

        internal static IDbBank CreateDbBank(Guid bankId, IBankCreate bankCreate)
        {
            return new DbBank()
            {
                Id = bankId,
                Name = bankCreate.Name,
                Boolean = bankCreate.Boolean,
                DateTime = bankCreate.DateTime,
                Double = bankCreate.Double,
                Guid = bankCreate.Guid,
                Integer = bankCreate.Integer,
            };
        }
    }
}
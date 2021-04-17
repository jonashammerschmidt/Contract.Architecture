using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Logic.Modules.Kundenstamm.Kunden;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Bankwesen.Banken
{
    internal class BankDetail : IBankDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        public IEnumerable<IKunde> Kunden { get; set; }

        internal static BankDetail FromDbBankDetail(IDbBankDetail dbBankDetail)
        {
            return new BankDetail()
            {
                Id = dbBankDetail.Id,
                Name = dbBankDetail.Name,
                Boolean = dbBankDetail.Boolean,
                DateTime = dbBankDetail.DateTime,
                Double = dbBankDetail.Double,
                Guid = dbBankDetail.Guid,
                Integer = dbBankDetail.Integer,
                Kunden = dbBankDetail.Kunden.Select(dbKunde => Kunde.FromDbKunde(dbKunde)),
            };
        }
    }
}
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class GegoennteBankDetail : IGegoennteBankDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        public IEnumerable<IGegoennterKunde> BesteKunden { get; set; }

        internal static GegoennteBankDetail FromDbGegoennteBankDetail(IDbGegoennteBankDetail dbGegoennteBankDetail)
        {
            return new GegoennteBankDetail()
            {
                Id = dbGegoennteBankDetail.Id,
                Name = dbGegoennteBankDetail.Name,
                GegoennterName = dbGegoennteBankDetail.GegoennterName,
                GegoennterBoolean = dbGegoennteBankDetail.GegoennterBoolean,
                GegoenntesDateTime = dbGegoennteBankDetail.GegoenntesDateTime,
                GegoennterDouble = dbGegoennteBankDetail.GegoennterDouble,
                GegoennteGuid = dbGegoennteBankDetail.GegoennteGuid,
                GegoennterInteger = dbGegoennteBankDetail.GegoennterInteger,
                BesteKunden = dbGegoennteBankDetail.BesteKunden.Select(dbGegoennterKunde => GegoennterKunde.FromDbGegoennterKunde(dbGegoennterKunde)),
            };
        }
    }
}
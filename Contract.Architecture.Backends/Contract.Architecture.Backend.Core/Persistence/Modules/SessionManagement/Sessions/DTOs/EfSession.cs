using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Sessions.Sessions
{
    [Table("Sessions")]
    public partial class EfSession
    {
        public string Token { get; set; }

        public string Name { get; set; }

        public Guid? EmailUserId { get; set; }

        public DateTime ExpiresOn { get; set; }
    }
}
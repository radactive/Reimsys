using System;
using System.Collections.Generic;

namespace Reimsys
{
    public partial class Transaction
    {
        public long TransactionId { get; set; }
        public int ReimburseTypeLevel2 { get; set; }
        public int UserId { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public byte[] Evidence { get; set; }

        public virtual ReimburseTypeLevel2 ReimburseTypeLevel2Navigation { get; set; }
        public virtual TransactionStatus StatusNavigation { get; set; }
        public virtual Users User { get; set; }
    }
}

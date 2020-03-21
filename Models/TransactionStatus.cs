using System;
using System.Collections.Generic;

namespace Reimsys
{
    public partial class TransactionStatus
    {
        public TransactionStatus()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int Status { get; set; }
        public string StatusName { get; set; }
        public string StatusCode { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

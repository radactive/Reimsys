using System;
using System.Collections.Generic;

namespace Reimsys
{
    public partial class ReimburseTypeLevel2
    {
        public ReimburseTypeLevel2()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int ReimburseTypeLevel2Id { get; set; }
        public int ReimburseTypeLevel1Id { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public virtual ReimburseTypeLevel1 ReimburseTypeLevel1 { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

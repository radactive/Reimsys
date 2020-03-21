using System;
using System.Collections.Generic;

namespace Reimsys
{
    public partial class ReimburseTypeLevel1
    {
        public ReimburseTypeLevel1()
        {
            ReimburseTypeLevel2 = new HashSet<ReimburseTypeLevel2>();
        }

        public int ReimburseTypeLevel1Id { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ReimburseTypeLevel2> ReimburseTypeLevel2 { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Reimsys
{
    public partial class Users
    {
        public Users()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public string PersonalNumber { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

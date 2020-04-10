using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reimsys
{
    public partial class Users
    {
        public Users()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int UserId { get; set; }

        [Display(Name="User Name")]
        public string Username { get; set; }
        public string Password { get; set; }
        [Display(Name = "Role")]
        public int? RoleId { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public string Name { get; set; }
        [Display(Name = "Personal Number")]
        public string PersonalNumber { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

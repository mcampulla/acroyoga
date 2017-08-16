using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acroyoga.it.Models
{
    [Table("RolesDto")]
    public class Role
    {
        [Key]
        [Display(Name = "ID")]
        public Guid RoleID { get; set; }

        [Column("RoleName")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [NotMapped]
        [Display(Name = "IsChecked")]
        public bool IsChecked { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }

    public class RoleComparer : IEqualityComparer<Role>
    {
        public bool Equals(Role a, Role b)
        {
            if (ReferenceEquals(a, b)) return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.RoleID == b.RoleID;
        }

        public int GetHashCode(Role role)
        {
            if (ReferenceEquals(role, null)) return 0;
            var hashroleId = role.RoleID.GetHashCode();
            return hashroleId;
        }
    }
}

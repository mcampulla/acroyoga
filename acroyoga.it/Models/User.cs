using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acroyoga.it.Models
{
    [Table("UsersDto")]
    public class User
    {
        [Key]
        [Display(Name = "ID")]
        public Guid UserID { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        //[Display(Name = "Application")]
        //public Application Application { get; set; }
        
        public virtual ICollection<Role> Roles { get; set; }

        [Display(Name = "DisplayName")]
        public string DisplayName { get { return string.Format("{0} {1} ({2})", LastName, FirstName, UserName); } }

    }

    [Table("ApplicationsDto")]
    public class Application
    {
        [Key]
        [Display(Name = "ID")]
        public Guid ApplicationID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    
    }
}

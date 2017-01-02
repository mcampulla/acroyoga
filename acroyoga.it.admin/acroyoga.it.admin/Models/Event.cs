using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace acroyoga.it.admin.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public String Body { get; set; }

        [Required]
        public string ImageLeft { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
       
    }
}
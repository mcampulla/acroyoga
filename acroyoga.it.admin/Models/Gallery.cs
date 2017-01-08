using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace acroyoga.it.admin.Models
{
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }

        [Required]
        public String Title { get; set; }
    }
}
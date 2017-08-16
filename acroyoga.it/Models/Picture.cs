using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace acroyoga.it.Models
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Description { get; set; }

        public String Image { get; set; }

        public String Video { get; set; }

        public int? GalleryId  { get; set; }

        public virtual Gallery Gallery { get; set; }

        public DateTime CreateDate { get; set; }       
    }
}
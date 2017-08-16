using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace acroyoga.it.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        [MaxLength]
        public String Body { get; set; }

        [DataType("Image")]
        public string ImageLeft { get; set; }

        [DataType("Image")]
        public string ImageRight { get; set; }

        [DataType("Video")]
        public string Video { get; set; }

        [DataType("Date")]
        public DateTime? DataInizio { get; set; }

        [DataType("Date")]
        public DateTime? DataFine { get; set; }

        public bool IsActive { get; set; }

        [DataType("Date")]
        public DateTime CreateDate { get; set; }      
    }
}
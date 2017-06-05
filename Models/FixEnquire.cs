using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSTVWebApp.Models
{
    public class FixEnquire
    {
        [Key]
        public int FixId { get; set; }
        [Required(ErrorMessage = "Provide Customer number")]
        [StringLength(8)]
        public string CustomerNumber { get; set; }
        [Required]
        public string ErrorCode { get; set; }
    }
}
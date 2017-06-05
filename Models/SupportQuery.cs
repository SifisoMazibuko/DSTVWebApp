using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSTVWebApp.Models
{
    public class SupportQuery
    {
        [Key]
        public int SupportID { get; set; }
        [Required(ErrorMessage ="Please Enter Name")] 
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Surname")]
        public string Surname { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string CustomerNumber { get; set; }
        public string Comments { get; set; }
        [Required(ErrorMessage = "Please Select Nature Of Query")]
        public string NatureOfQuery { get; set; }
    }
}
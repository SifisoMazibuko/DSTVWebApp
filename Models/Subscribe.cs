using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSTVWebApp.Models
{
    public class Subscribe
    {
        [Key]
        public int SubscribeID { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
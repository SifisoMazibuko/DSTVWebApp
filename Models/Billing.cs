using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSTVWebApp.Models
{
    public class Billing
    {
        public Billing()
        {
            Customers = new HashSet<Customer>();
        }
        public int BillingID { get; set; }
        public int CustomerNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public double Amount { get; set; }
        public virtual ICollection<Customer> Customers {get; set;}
    }
}
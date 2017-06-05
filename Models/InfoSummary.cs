using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSTVWebApp.Models
{
    public class InfoSummary
    {
        public int CustomerID { get; set; }
        public string CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }       
        public string Country { get; set; }
        public double Amount { get; set; }
    }
}
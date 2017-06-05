using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSTVWebApp.Models
{
    public class GuideModel
    {
        public int Channel { get; set; }
        public string ShowName { get; set; }
        public DateTime StartDate { get; set; }
    }
}
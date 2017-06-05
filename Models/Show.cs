namespace DSTVWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Show
    {
        public int ShowID { get; set; }

        public byte[] ShowImage { get; set; }

        [Required]
        public string ShowName { get; set; }

        [Required]
        public string ShowDescription { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public string Genre { get; set; }

        public TimeSpan Duration { get; set; }

        [Required]
        public string ChannelName { get; set; }

        public int Channel { get; set; }

        public string AgeRestriction { get; set; }

        public int? Admin_adminID { get; set; }

        public int? Customer_CustomerID { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

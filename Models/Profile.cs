namespace DSTVWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profile
    {
        public int ProfileID { get; set; }

        public byte[] ProfileImage { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

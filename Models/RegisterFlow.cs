namespace DSTVWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegisterFlow
    {
        public int RegisterFlowID { get; set; }

        [Required]
        [StringLength(100)]
        public string IdNumberOrPassport { get; set; }
    }
}

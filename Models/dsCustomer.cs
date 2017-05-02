namespace DSTVWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dsCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dsCustomer()
        {
            Customers = new HashSet<Customer>();
        }

        public int DsCustomerID { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerNumber { get; set; }

        [Required]
        public string accountHolderSurname { get; set; }

        [Required]
        public string accountHolderCountry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

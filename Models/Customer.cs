namespace DSTVWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Profiles = new HashSet<Profile>();
            Shows = new HashSet<Show>();
        }

        public int CustomerID { get; set; }

        public string CustomerNumber { get; set; }

        public string SmartCardNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public double Balance { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public int? dsCustomer_DsCustomerID { get; set; }

        public int? Payment_paymentID { get; set; }

        public virtual dsCustomer dsCustomer { get; set; }

        public virtual Payment Payment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profile> Profiles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Show> Shows { get; set; }
    }
}

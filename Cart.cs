namespace 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ClientID { get; set; }

        public int ProductID { get; set; }

        public int Amount { get; set; }

        public DateTime? DatePurchased { get; set; }

        public bool IsInCart { get; set; }

        public virtual Product Product { get; set; }

        public virtual Product Product1 { get; set; }
    }
}

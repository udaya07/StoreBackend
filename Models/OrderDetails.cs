using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBackEnd.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDefn UserDefn { get; set; }
        public int UserId { get; set; }

        public string DeliverTo { get; set; }
        public string ContactNo { get; set; }


        public string DeliveryAddress { get; set; }

        public string Pincode { get; set; }

        public virtual ICollection<AddToCart> AddToCart { get; set; }

 /*    public virtual ICollection <Orders> Orders { get; set; }*/
    } 
}

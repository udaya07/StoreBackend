using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CartId")]
        public virtual AddToCart AddToCart { get; set; }
        public int CartId { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
      
      /*  [ForeignKey("OrderDetailsId")]
        public virtual OrderDetails OrderDetails { get; set; }
        public int OrderDetailsId { get; set; }*/

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        public int StatusId { get; set; }
   
    }
}

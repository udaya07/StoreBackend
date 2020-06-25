using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Models
{
    public class WishList

    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDefn UserDefn { get; set; }
        public int UserId { get; set; }
       

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }


        [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public string ProductName { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }

        public string Picture { get; set; }
        public string Price { get; set; }
        public string AddQuantity { get; set; }
        public string InStock { get; set; }
        public bool IsDeleted { get; set; }


        public virtual ICollection<AddToCart> AddToCart { get; set; }

        public virtual ICollection<WishList> WishList { get; set; }


    }
}

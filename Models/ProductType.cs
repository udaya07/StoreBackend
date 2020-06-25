using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }

        public string ProdType { get; set; }

      
        public virtual ICollection<Product> Product { get; set; }
    }
}

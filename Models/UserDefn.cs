using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Models
{
    public class UserDefn
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string EmailId { get; set; }
        public string MobileNumber { get; set; }

        public string RoleName { get; set; }

       
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

      

        public virtual ICollection<WishList> WishList { get; set; }




    }
}

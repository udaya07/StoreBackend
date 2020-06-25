using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackEnd.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection <Orders> Orders {get; set;}

    }
}

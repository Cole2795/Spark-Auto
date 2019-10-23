using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spark2Auto.Models
{
    public class ServiceShoppingCart
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int ServiceTypeId { get; set; }

        [ForeignKey("CardId")]
        public virtual Car Car { get; set; }
        [ForeignKey("ServiceTypeId")]
        public virtual ServiceType ServiceType { get; set; }
    }
}

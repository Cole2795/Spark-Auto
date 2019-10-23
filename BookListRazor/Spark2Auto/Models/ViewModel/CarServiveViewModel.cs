using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spark2Auto.Models.ViewModel
{
    public class CarServiveViewModel
    {
        public Car Car { get; set; }
        public ServiceHeader ServiceHeader { get; set; }
        public ServiceDetails ServiceDetails { get; set; }

        public List<ServiceType> ServiceTypesList { get; set; }
        public List<ServiceShoppingCart> ServiceShoppingCartList { get; set; }
    }
}

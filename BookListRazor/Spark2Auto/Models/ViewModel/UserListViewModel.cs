using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spark2Auto.Models.ViewModel
{
    public class UserListViewModel
    {
        public List<ApplicationUser> ApplicationUserList { get; set; }
        public PageInfo PagingInfo { get; set; }
    }
}

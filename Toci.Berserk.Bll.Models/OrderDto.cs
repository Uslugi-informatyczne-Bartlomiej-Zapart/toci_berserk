using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Berserk.Bll.Models
{
    public class OrderDto
    {
        public string deliveryCompanyName { get; set; }
        public DateTime dateScope { get; set; }
        public int deliveryCompanyId { get; set; }
    }
}

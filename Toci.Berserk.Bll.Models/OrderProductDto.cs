using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Berserk.Bll.Models
{
    public class OrderProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CurrentQuantity { get; set; }

        public int ExpectedOrderQuantity { get; set; }

        public string DeliveryCompany { get; set; }

        public double Price { get; set; }
    }
}

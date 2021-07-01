using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Ml.Interfaces;

namespace Toci.Berserk.Bll.Ml
{
    public class OrderModel : IOrderModel
    {
        public int Quantity { get; set; }
        public int IdProduct { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Berserk.Bll.Ml.Interfaces
{
    public interface IOrderModel
    {
        int Quantity { get; set; }
        int IdProduct { get; set; }
        DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Models
{
    public class OrderProductDto : Productcompanyorder
    {
        public OrderProductDto() { }

        public OrderProductDto(Productcompanyorder dbBase)
        {
            Productid = dbBase.Productid;
            Price = dbBase.Price;
            Productname = dbBase.Productname;
            Currentquantity = dbBase.Currentquantity;
            Deliverycompany = dbBase.Deliverycompany;
        }

        public int ExpectedOrderQuantity { get; set; }

    }
}

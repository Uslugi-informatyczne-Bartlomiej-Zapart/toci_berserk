using System;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Models
{
    public class ProductDto
    {
        public Product Product { get; set; }
        public int Code { get; set; }
        public string DeliveryCompany { get; set; }
    }
}

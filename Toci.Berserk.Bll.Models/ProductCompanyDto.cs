using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Models
{
    class ProductCompanyDto
    {
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public Product Product { get; set; }
        public Deliverycompany DeliveryCompany { get; set; }
    }
}

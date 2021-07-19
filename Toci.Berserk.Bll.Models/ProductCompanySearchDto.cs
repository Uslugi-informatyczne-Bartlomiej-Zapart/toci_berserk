using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Models
{
    public class ProductCompanySearchDto : Productcompanysearch
    {
        public int ExpectedOrderQuantity { get; set; }

        public int? CurrentQuantity { get; set; }

        public List<DeliveryDto> CompaniesPerProduct { get; set; }
    }
}

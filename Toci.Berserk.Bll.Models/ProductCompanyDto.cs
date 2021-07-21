using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Models
{
    /// <summary>
    /// This class represents all informations necessary to make an order based on current company name
    /// It is referenced with OrderController
    /// </summary>
    public class ProductCompanyDto
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductCode { get; set; }
        public float? ProductPriceBasedOnCurrentCompany { get; set; }
        public int? Quantity { get; set; }
        public int? PredictedQuantityToOrder { get; set; }
        /// <summary>
        /// List of all companies which delivered the product in the past plus delivery price and delivery id
        /// </summary>
        public Dictionary<string?, Tuple<int?, float?>> ProductDeliveryCompaniesWithPrices { get; set; }
    }
}

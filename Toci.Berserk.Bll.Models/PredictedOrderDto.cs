namespace Toci.Berserk.Bll.Models
{
    public class PredictedOrderDto
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public int IdMetric { get; set; }
    }
}
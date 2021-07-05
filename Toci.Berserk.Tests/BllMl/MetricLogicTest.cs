using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll;
using Toci.Berserk.Bll.Ml;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Tests.BllMl
{
    [TestClass]
    public class MetricLogicTest
    {
        [TestMethod]
        public void AddMetrics()
        {
            MetricsLogic metricsLogic = new MetricsLogic();
            int newOne = metricsLogic.SetMetrics(new MetricsDto()
            {
                Metric = new Metric()
                {
                    Algorithm = 1,
                    Metric1 = 7
                }
            });
        }

        [TestMethod]
        public void AddPredicted()
        {
            LogicBase<Order> orderLogic = new LogicBase<Order>();
            int orderId = orderLogic.Insert(new Order()).Id;

            PredictedOrderLogic predictedOrderLogic = new PredictedOrderLogic();
            predictedOrderLogic.CreateOrder(new PredictedOrderDto()
            {
                IdOrder = orderId,
                IdMetric = 1,
                IdProduct = 1,
                Quantity = 3
            });
        }
    }
}
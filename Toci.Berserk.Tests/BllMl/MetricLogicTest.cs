using Microsoft.VisualStudio.TestTools.UnitTesting;
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

    }
}
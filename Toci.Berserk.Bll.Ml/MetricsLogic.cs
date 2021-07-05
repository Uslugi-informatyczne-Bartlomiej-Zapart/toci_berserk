using System.Linq;
using Microsoft.EntityFrameworkCore;
using Toci.Berserk.Bll.Ml.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml
{
    public class MetricsLogic : LogicBase<Metric>, IMetricsLogic
    {
        protected LogicBase<Metrichistory> MetricHistoryLogic = new LogicBase<Metrichistory>();

        public int SetMetrics(MetricsDto metric)
        {
            Metric metrics = Select(x => x.Algorithm == metric.Metric.Algorithm).AsNoTracking().FirstOrDefault();

            if (metrics != null)
            {
                if (metrics.Metric1.Value != metric.Metric.Metric1.Value)
                {
                    MetricHistoryLogic.Insert(new Metrichistory()
                    {
                        Metric = metrics.Metric1,
                        Idmetrics = metrics.Id
                    });

                    metric.Metric.Id = metrics.Id;

                    Update(metric.Metric);
                }

                return metric.Metric.Id;
            }

            return Insert(metric.Metric).Id;
        }
    }
}
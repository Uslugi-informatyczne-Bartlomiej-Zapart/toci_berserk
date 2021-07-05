using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml.Interfaces
{
    public interface IMetricsLogic : ILogicBase<Metric>
    {
        public int SetMetrics(MetricsDto product);
    }
}
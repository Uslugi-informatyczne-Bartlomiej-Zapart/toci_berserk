using System;
using System.Collections.Generic;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml.Interfaces
{
    public interface IArithmeticAverageProductOrderLogic
    {
        Dictionary<int, decimal> CalculateAverages(Dictionary<int, List<Chemistrypop>> history);
    }
}
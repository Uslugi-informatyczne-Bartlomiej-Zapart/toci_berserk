using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Toci.Berserk.Bll.Ml.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml
{
    public class ArithmeticAverageProductOrderLogic : IArithmeticAverageProductOrderLogic
    {
        public void CalculateAverages(Dictionary<int, List<Chemistrypop>> history)
        {
            foreach (KeyValuePair<int, List<Chemistrypop>> element in history)
            {
                IEnumerable<Tuple<int?, decimal>> products = element.Value.GroupBy(model => model.Idproducts)
                    .Select(m => new Tuple<int?, decimal>(m.Key, m.Average(x => (decimal)x.Quantity)));

            }

        }
    }
}
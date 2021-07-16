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
        public List<List<Tuple<int?, decimal>>> CalculateAverages(Dictionary<int, List<Chemistrypop>> history)
        {
            List<List<Tuple<int?, decimal>>> result = new List<List<Tuple<int?, decimal>>>();

            foreach (KeyValuePair<int, List<Chemistrypop>> element in history)
            {
                result.Add(element.Value.GroupBy(model => model.Idproducts)
                    .Select(m => new Tuple<int?, decimal>(m.Key, m.Average(x => (decimal)x.Quantity))).ToList());
            }

            return result;
        }
    }
}
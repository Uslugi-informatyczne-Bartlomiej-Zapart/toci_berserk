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
        public virtual Dictionary<int, decimal> CalculateAverages(Dictionary<int, List<Chemistrypop>> history)
        {
            List<List<Tuple<int?, decimal>>> result = new List<List<Tuple<int?, decimal>>>();

            foreach (KeyValuePair<int, List<Chemistrypop>> element in history)
            {
                result.Add(element.Value.GroupBy(model => model.Idproducts)
                    .Select(m => new Tuple<int?, decimal>(m.Key, m.Average(x => (decimal)x.Quantity))).ToList());
            }

            return GetOneAvgForProduct(result);
        }

        public virtual decimal CalculateAverages(List<Chemistrypop> history)
        {
            return history.Average(x => (decimal)x.Quantity);   
        }

        protected virtual Dictionary<int, decimal> GetOneAvgForProduct(List<List<Tuple<int?, decimal>>> averages)
        {
            Dictionary<int, List<decimal>> temp = new Dictionary<int, List<decimal>>();

            foreach (List<Tuple<int?, decimal>> avg in averages)
            {
                foreach (Tuple<int?, decimal> item in avg)
                {
                    if (temp.ContainsKey(item.Item1.Value))
                    {
                        temp[item.Item1.Value].Add(item.Item2);
                    }
                    else
                    {
                        temp.Add(item.Item1.Value, new List<decimal>() { item.Item2 });
                    }
                }
            }

            Dictionary<int, decimal> result = new Dictionary<int, decimal>();

            foreach (KeyValuePair<int, List<decimal>> item in temp)
            {
                result.Add(item.Key, item.Value.Average());
            }

            return result;
        }
    }
}
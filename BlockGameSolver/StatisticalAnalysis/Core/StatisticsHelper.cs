using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockGameSolver.StatisticalAnalysis.Core
{
    internal static class StatisticsHelper
    {
        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            List<double> values = new List<double>();

            foreach (TSource tSource in source)
            {
                double value = selector(tSource);
                values.Add(value);
            }
            double mean = values.Average();

            List<double> deviations = new List<double>();
            foreach (double d in values)
            {
                double deviation = Math.Pow(mean - d, 2);
                deviations.Add(deviation);
            }
            mean = deviations.Average();
            return Math.Sqrt(mean);
        }
    }
}
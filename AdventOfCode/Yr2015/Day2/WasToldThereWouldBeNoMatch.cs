using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Yr2015.Day2
{
    public static class WasToldThereWouldBeNoMatch
    {
        public static int CalculateTotalWrappingPaper(string input)
        {
            string[] stringLines = input.Split("\r\n");

            int total = 0;

            foreach (string line in stringLines)
            {
                total += CalculateIndividualWrappingPaper(line.Split("x").Select(int.Parse).ToArray());
            }

            return total;
        }

        private static int CalculateIndividualWrappingPaper(int[] dimensionValues)
        {
            Array.Sort(dimensionValues);

            return (3 * (dimensionValues[0] * dimensionValues[1])) 
                + (2 * (dimensionValues[0] * dimensionValues[2]))
                + (2 * (dimensionValues[1] * dimensionValues[2]));
        }

        public static int  CalculateTotalRibbonLength(string input)
        {
            string[] stringLines = input.Split("\r\n");

            int total = 0;

            foreach (string line in stringLines)
            {
                total += CalculateIndividualRibbonLength(line.Split("x").Select(int.Parse).ToArray());
            }

            return total;
        }

        private static int CalculateIndividualRibbonLength(int[] dimensionValues)
        {
            Array.Sort (dimensionValues);

            return (2 * (dimensionValues[0] + dimensionValues[1])) + (dimensionValues[0] * dimensionValues[1] * dimensionValues[2]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Yr2024.Day2
{
    public static class RedNosedReports
    {
        public static int CalcSafeReportsCount(string input)
        {
            int[][] valuesGrid = GetIntGridFromString(input);

            int numSafeReports = 0;

            for (int i = 0; i < valuesGrid.Length; i++)
            {
                if (CheckReportIsSafeNoSkips(valuesGrid[i]))
                {
                    numSafeReports++;
                }
            }

            return numSafeReports;
        }

        public static int CalcSafeReportsCountWithSkip(string input)
        {
            int[][] valuesGrid = GetIntGridFromString(input);
            int numSafeReports = 0;

            for (int i = 0; i < valuesGrid.Length; i++)
            {

                if (CheckReportIsSafeNoSkips(valuesGrid[i])) {
                    numSafeReports++;
                }
                else
                {
                    for (int j = 0; j < valuesGrid[i].Length; j++)
                    {

                        if (CheckReportIsSafeNoSkips(valuesGrid[i].Where((x, index) => index != j).ToArray()))
                        {
                            numSafeReports++;
                            break;
                        }
                    }
                }
            }

            return numSafeReports;
        }

        private static int[][] GetIntGridFromString(string input)
        {
            return input
                .Split("\r\n")
                .Select(line => line
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray())
                .ToArray();
        }

        private static bool CheckReportIsSafeNoSkips(int[] report)
        {
            bool isIncreasing = report[0] < report[1];
             
            for (int j = 1; j < report.Length; j++)
            {
                int differenceFromLast = report[j] - report[j - 1];
                int absoluteDifference = Math.Abs(differenceFromLast);
                bool differenceIsInRange = absoluteDifference >= 1 && absoluteDifference <= 3;

                //If it's not continuing to increase or decrease or the difference isn't in range
                if (((isIncreasing && differenceFromLast < 0) || (!isIncreasing && differenceFromLast > 0)) || !differenceIsInRange)
                {
                    return false;
                }

            }
            return true;
        }
    }
}

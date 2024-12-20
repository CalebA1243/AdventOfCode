using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Yr2024.Day5
{
    public static class PrintQueue
    {
        public static int ValidMiddleValueSum(String input)
        {
            string[] separatedInput = input.Split("\r\n\r\n");

            int[][] leftRightNums = separatedInput[0]
                                        .Split("\r\n")
                                        .Select(x => x
                                            .Split("|")
                                            .Select(int.Parse)
                                            .ToArray())
                                        .ToArray();

            var numToPreceedingNums = CreateRuleDictionary(leftRightNums);

            int[][] updates = separatedInput[1]
                                        .Split("\r\n")
                                        .Select(x => x
                                            .Split(",")
                                            .Select(int.Parse)
                                            .ToArray())
                                        .ToArray();

            int middleValueSum = 0;

            foreach (var update in updates )
            {
                int middleValue = CheckUpdate(update, numToPreceedingNums);

                if (middleValue != -1)
                {
                    middleValueSum += middleValue;
                }
            }

            return middleValueSum;
        }

        private static int CheckUpdate(int[] update, Dictionary<int, List<int>> numToPreceedingNums)
        {

            for (int i = 0; i < update.Length; i++)
            {
                List<int> preceedingNums;

                if (numToPreceedingNums.TryGetValue(update[i], out preceedingNums))
                {
                    for (int j = i + 1; j < update.Length; j++)
                    {
                        if (preceedingNums.Contains(update[j]))
                        {
                            return -1;
                        }
                    }
                }
            }

            return update[update.Length / 2];
        }

        private static Dictionary<int, List<int>> CreateRuleDictionary(int[][] leftRightNums)
        {
            var numToPreceedingNums = new Dictionary<int, List<int>>();

            foreach (var nums in leftRightNums)
            {
                List<int> preceedingInts;

                if (numToPreceedingNums.TryGetValue(nums[1], out preceedingInts))
                {
                    preceedingInts.Add(nums[0]);
                }
                else
                {
                    numToPreceedingNums.Add(nums[1], new List<int> { nums[0] });
                }
            }

            return numToPreceedingNums;
        }

        public static int SortAndAddMiddleSum(string input)
        {
            string[] separatedInput = input.Split("\r\n\r\n");

            int[][] leftRightNums = separatedInput[0]
                                        .Split("\r\n")
                                        .Select(x => x
                                            .Split("|")
                                            .Select(int.Parse)
                                            .ToArray())
                                        .ToArray();

            var numToPreceedingNums = CreateRuleDictionary(leftRightNums);

            int[][] updates = separatedInput[1]
                                        .Split("\r\n")
                                        .Select(x => x
                                            .Split(",")
                                            .Select(int.Parse)
                                            .ToArray())
                                        .ToArray();

            int middleValueSum = 0;

            foreach (var update in updates)
            {
                int updateMiddleValue = SortUpdate(update, numToPreceedingNums);

                if (updateMiddleValue != -1)
                {
                    middleValueSum += SortUpdate(update, numToPreceedingNums);
                }
            }

            return middleValueSum;
        }

        private static int SortUpdate(int[] update, Dictionary<int, List<int>> numToPreceedingNums)
        {
            List<int> updateList = new List<int>(update);

            updateList.Sort((x, y) =>
            {
                if (numToPreceedingNums.ContainsKey(x))
                {
                    if (numToPreceedingNums[x].Contains(y))
                    {
                        return 1;
                    }

                    if (numToPreceedingNums[y].Contains(x))
                    {
                        return -1;
                    }
                }

                return 0;
            });

            if (updateList.SequenceEqual(update))
            {
                return -1;
            }
            else
            {
                return update[update.Length / 2];
            }
        }

    }
}

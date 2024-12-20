using System.ComponentModel;

namespace AdventOfCode.Yr2024.Day1
{
    public static class HistorianHysteria
    {
        public static int CalculateListsDifference(string input)
        {
            var (leftList, rightList) = ParseLists(input);

            Array.Sort(leftList);
            Array.Sort(rightList);

            int totalDifference = 0;

            for (int i = 0; i < leftList.Length; i++)
            {
                totalDifference += Math.Abs(leftList[i] - rightList[i]);
            }

            return totalDifference;
        }

        public static int CalculateSimilarityScore(string input)
        {
            var (leftList, rightList) = ParseLists(input);

            var similarityScore = 0;

            var numToRightListOccurances = new Dictionary<int, int>();
            
            foreach (var num in leftList)
            {

                if (!numToRightListOccurances.TryGetValue(num, out int rightListOccurances))
                {
                    rightListOccurances = rightList.Count(x => x == num);
                    numToRightListOccurances[num] = rightListOccurances;
                }

                similarityScore += (rightListOccurances * num);
            }

            return similarityScore;
        }

        private static ( int[] leftList, int[] rightList) ParseLists(string input)
        {
            string[][] doubleSplitString = input
                .Split("\r\n")
                .Select(x => x
                .Split("   ")).ToArray();

            var listsLength = doubleSplitString.Length;

            var leftList = new int[listsLength];
            var rightList = new int[listsLength];

            for (int i = 0; i < listsLength; i++)
            {
                leftList[i] = int.Parse(doubleSplitString[i][0]);
                rightList[i] = int.Parse(doubleSplitString[i][1]);
            }

            return (leftList, rightList);
        }
    }
}

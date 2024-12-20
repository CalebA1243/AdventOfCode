using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Yr2024.Day3
{
    public static class MullItOver
    {
        public static int GetMultTotal(string input)
        {
            int total = 0;

            var matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)");

            foreach (Match match in matches)
            {
                total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
            }

            return total;
        }

        public static long GetMultTotalDoDont(string input)
        {
            var doSeparatedInput = input.Split("do()");

            long total = 0;

            foreach (string afterDo in doSeparatedInput)
            {

                var dontIndex = afterDo.IndexOf("don't()");
                var matches = Regex.Matches(afterDo, @"mul\((\d+),(\d+)\)");

                foreach (Match match in matches)
                {
                    if (dontIndex < 0 || match.Index < dontIndex)
                    {
                        total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                    }
                }
            }

            return total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Yr2015.Day1
{
    static class NotQuiteLisp
    {

        /*
         * ( - Go up one floor
         * ) - Go down one floor
         */


        public static int FindFloorNumber(string instructions)
        {
            int numOpenParenthases = instructions.Count(c => c == '(');
            int numCloseParenthases = instructions.Length - numOpenParenthases;

            return numOpenParenthases - numCloseParenthases;
        }

        public static int FindFirstCharacterInBasement(string instructions)
        {
            char[] instructionsChars = instructions.ToCharArray();
            int currFloor = 0;

            for (int i = 0; i < instructions.Length; i++)
            {
                if (instructionsChars[i] == '(')
                {
                    currFloor++;
                } else
                {
                    currFloor--;
                }

                if (currFloor < 0)
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}

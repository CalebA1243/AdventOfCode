using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdventOfCode.Yr2024.Day4
{
    public static class CeresSearch
    {

        private const string WORD_TO_SEARCH = "XMAS";
        private const int WORD_LENGTH =  4;

        private enum Direction { UP, DOWN, LEFT, RIGHT, UPLEFT, UPRIGHT, DOWNLEFT, DOWNRIGHT }

        public static int XmasCount(string input)
        {
            char[][] charGrid = input
                                    .Split("\r\n")
                                    .Select(x => x.ToCharArray())
                                    .ToArray();

            int totalXmas = 0;

            for (int i = 0; i < charGrid.Length; i++)
            {
                for (int j = 0; j < charGrid[i].Length; j++)
                {
                    if (charGrid[i][j] == 'X')
                    {
                        var directions = GetPossibleDirections(charGrid, i, j);

                        foreach (var direction in directions)
                        {
                            if (CheckDirection(charGrid, direction, i, j))
                                totalXmas++;
                        }
                    }
                }
            }

            return totalXmas;
        }

        private static Direction[] GetPossibleDirections(char[][] charGrid, int row, int col)
        {
            var directions = new List<Direction>();
            int rows = charGrid.Length;
            int columns = charGrid[0].Length;
            
            if ((row + 1) - WORD_LENGTH >= 0)
            {
                directions.Add(Direction.UP);
                
                if ((col + 1) - WORD_LENGTH >= 0)
                {
                    directions.Add(Direction.UPLEFT);
                }

                if (columns - col >= WORD_LENGTH)
                {
                    directions.Add(Direction.UPRIGHT);
                }
            }

            if (rows - row >= WORD_LENGTH)
            {
                directions.Add(Direction.DOWN);

                if ((col + 1) - WORD_LENGTH >= 0)
                {
                    directions.Add(Direction.DOWNLEFT);
                }

                if (columns - col >= WORD_LENGTH)
                {
                    directions.Add(Direction.DOWNRIGHT);
                }
            }

            if ((col + 1) - WORD_LENGTH >= 0)
            {
                directions.Add(Direction.LEFT);
            }

            if (columns - col >= WORD_LENGTH)
            {
                directions.Add(Direction.RIGHT);
            }

            return directions.ToArray(); 
        }

        private static bool CheckDirection(char[][] charGrid, Direction direction, int row, int col)
        {
            int rowIncrement = 0;
            int colIncrement = 0;

            
            switch (direction)
            {
                case Direction.UP:
                    rowIncrement = -1;
                    break;
                case Direction.DOWN:
                    rowIncrement = 1;
                    break;
                case Direction.LEFT:
                    colIncrement = -1;
                    break;
                case Direction.RIGHT:
                    colIncrement = 1;
                    break;
                case Direction.UPLEFT:
                    rowIncrement = -1;
                    colIncrement = -1;
                    break;
                case Direction.UPRIGHT:
                    rowIncrement = -1;
                    colIncrement = 1;
                    break;
                case Direction.DOWNLEFT:
                    rowIncrement = 1;
                    colIncrement = -1;
                    break;
                case Direction.DOWNRIGHT:
                    rowIncrement = 1;
                    colIncrement = 1;
                    break;
            }

            int currRow = row;
            int currCol = col;
            char[] wordChars = WORD_TO_SEARCH.ToCharArray();

            for (int i = 1; i < WORD_LENGTH; i++)
            {
                currRow += rowIncrement;
                currCol += colIncrement;

                if (wordChars[i] != charGrid[currRow][currCol])
                {
                    return false;
                }
            }

            return true;
        }

        public static int CrossedMASCount(string input)
        {
            char[][] charGrid = input
                                    .Split("\r\n")
                                    .Select(x => x.ToCharArray())
                                    .ToArray();

            int totalCrossedMAS = 0;

            for (int i = 0; i < charGrid.Length; i++)
            {
                for (int j = 0; j < charGrid[i].Length; j++)
                {
                    if (charGrid[i][j] == 'A')
                    {
                        if (CheckForCrossedMAS(charGrid, i, j))
                            totalCrossedMAS++;
                    }
                }
            }

            return totalCrossedMAS;
        }

        private static bool CheckForCrossedMAS(char[][] charGrid, int row, int col)
        {
            if (row - 1 < 0 || row + 1 >= charGrid.Length || col - 1 < 0 || col + 1 >= charGrid[0].Length)
            {
                return false;
            }

            string diagonal1 = charGrid[row - 1][col - 1].ToString() + 'A' + charGrid[row + 1][col + 1];
            string diagonal2 = charGrid[row - 1][col + 1].ToString() + 'A' + charGrid[row + 1][col - 1];

            return (diagonal1 == "MAS" || diagonal1 == "SAM")
                   && (diagonal2 == "MAS" || diagonal2 == "SAM");
        }
    }
}

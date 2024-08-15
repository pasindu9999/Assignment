using System;
using System.Collections.Generic;

namespace Task3
{
    public class Minefield
    {
        public int[,] Field;
        private int fieldRows;
        private int fieldCols;

        public Minefield(int[,] field)
        {
            Field = field;
            fieldRows = field.GetLength(0);
            fieldCols = field.GetLength(1);
        }

        private readonly List<Tuple<int, int>> neighbourWindow = new List<Tuple<int, int>>()
        {
            new Tuple<int, int>(-1,-1),
            new Tuple<int, int>(0,-1),
            new Tuple<int, int>(1,-1),
            new Tuple<int, int>(1,0),
            new Tuple<int, int>(1,1),
            new Tuple<int, int>(0,1),
            new Tuple<int, int>(-1,1),
            new Tuple<int, int>(-1,0),
            new Tuple<int, int>(-1,0),
        };

        // Difficulty 01
        public List<Tuple<int, int>> FindSafePathForSniffer()
        {
            Queue<Tuple<int, int>> opened = new Queue<Tuple<int, int>>();
            bool[,] visitedFields = new bool[fieldRows, fieldCols];
            Tuple<int, int>[,] parentMap = new Tuple<int, int>[fieldRows, fieldCols];

            for (int i = 0; i < fieldCols; i++)
            {
                if (Field[0, i] == 0)
                {
                    Tuple<int, int> startField = new Tuple<int, int>(0, i);
                    opened.Enqueue(startField);
                    visitedFields[0, i] = true;
                }
            }

            while (opened.Count > 0)
            {
                var currentField = opened.Dequeue();
                int currentRow = currentField.Item1;
                int currentCol = currentField.Item2;

                if (currentRow == fieldRows - 1)
                {
                    return ReconstructPath(currentField, parentMap);
                }

                foreach (var direction in neighbourWindow)
                {
                    int neighbourRow = currentRow + direction.Item1;
                    int neighbourCol = currentCol + direction.Item2;

                    if (IsValid(neighbourRow, neighbourCol) && !visitedFields[neighbourRow, neighbourCol] && Field[neighbourRow, neighbourCol] == 0)
                    {
                        visitedFields[neighbourRow, neighbourCol] = true;
                        parentMap[neighbourRow, neighbourCol] = currentField;
                        opened.Enqueue(new Tuple<int, int>(neighbourRow, neighbourCol));
                    }
                }
            }

            return new List<Tuple<int, int>>();
        }

        // Difficulty 2
        public List<Tuple<int, int>> FindSafePathForSnifferAndAlly()
        {
            Queue<Tuple<int, int>> opened = new Queue<Tuple<int, int>>();
            bool[,] visitedFields = new bool[fieldRows, fieldCols];
            Tuple<int, int>[,] parentMap = new Tuple<int, int>[fieldRows, fieldCols];

            for (int i = 0; i < fieldCols; i++)
            {
                if (Field[0, i] == 0)
                {
                    Tuple<int, int> startField = new Tuple<int, int>(0, i);
                    opened.Enqueue(startField);
                    visitedFields[0, i] = true;
                }
            }

            while (opened.Count > 0)
            {
                var currentField = opened.Dequeue();
                int currentRow = currentField.Item1;
                int currentCol = currentField.Item2;

                if (currentRow == fieldRows - 1)
                {
                    return ReconstructPath(currentField, parentMap);
                }

                foreach (var direction in neighbourWindow)
                {
                    int neighbourRow = currentRow + direction.Item1;
                    int neighbourCol = currentCol + direction.Item2;

                    if (IsValid(neighbourRow, neighbourCol) && !visitedFields[neighbourRow, neighbourCol] && Field[neighbourRow, neighbourCol] == 0)
                    {
                        visitedFields[neighbourRow, neighbourCol] = true;
                        parentMap[neighbourRow, neighbourCol] = currentField;

                        if (parentMap[currentRow, currentCol] == null || parentMap[currentRow, currentCol] != new Tuple<int, int>(neighbourRow, neighbourCol))
                        {
                            opened.Enqueue(new Tuple<int, int>(neighbourRow, neighbourCol));
                        }
                    }
                }
            }

            return new List<Tuple<int, int>>();
        }

        // Helper method to check if a cell is within bounds
        private bool IsValid(int row, int col)
        {
            return row >= 0 && row < fieldRows && col >= 0 && col < fieldCols;
        }

        // Helper method to reconstruct the path from the parent map
        private List<Tuple<int, int>> ReconstructPath(Tuple<int, int> endField, Tuple<int, int>[,] parentMap)
        {
            List<Tuple<int, int>> path = new List<Tuple<int, int>>();
            while (endField != null)
            {
                path.Add(endField);
                endField = parentMap[endField.Item1, endField.Item2];
            }
            path.Reverse();
            return path;
        }

        public void PrintSafePathsForSnifferAndAlly(List<Tuple<int, int>> pathSniffer)
        {
            int index = 1;
            Console.WriteLine("Steps in each iteration");
            foreach (var pathField in pathSniffer)
            {
                if (index == 1)
                {
                    Console.WriteLine($"Iteration {index}\t\t({pathField.Item1}, {pathField.Item2})\t\t\tAt the Starting mark");
                }
                else
                {
                    Console.WriteLine($"Iteration {index}\t\t({pathField.Item1}, {pathField.Item2})\t\t\t({pathSniffer[index - 2].Item1}, {pathSniffer[index - 2].Item2})");
                }
                index++;
            }
            Console.WriteLine($"Iteration {index}\t\tAt the destination\t({pathSniffer[index - 2].Item1}, {pathSniffer[index - 2].Item2})");
            Console.WriteLine();
        }
    }
}

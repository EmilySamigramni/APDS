using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int rows, columns;
    static int[] rowDirections = { 1, -1, 0, 0 };
    static int[] columnDirections = { 0, 0, 1, -1 };
    static int targetRow, targetColumn;
    static int[,] gameBoard = new int[250, 250];
    static HashSet<(int, int)> visitedCells = new HashSet<(int, int)>();
    static List<int> currentPath = new List<int>();
    static List<List<int>> solutions = new List<List<int>>();
    static int minimumMoves = int.MaxValue;

    static void BreadthFirstSearch(int row, int column)
    {
        visitedCells.Add((row, column));
        if (row == targetRow && column == targetColumn)
        {
            if (currentPath.Count < minimumMoves)
            {
                minimumMoves = currentPath.Count;
                solutions.Clear();
                solutions.Add(currentPath.ToList());
            }
            else if (currentPath.Count == minimumMoves)
            {
                solutions.Add(currentPath.ToList());
            }
            return;
        }
        for (int i = 0; i < 4; i++)
        {
            if (row + 2 * rowDirections[i] < 0 || row + 2 * rowDirections[i] >= rows || column + 2 * columnDirections[i] < 0 || column + 2 * columnDirections[i] >= columns)
                continue;
            if (gameBoard[row + rowDirections[i], column + columnDirections[i]] != gameBoard[row + 2 * rowDirections[i], column + 2 * columnDirections[i]])
                continue;
            if (gameBoard[row + rowDirections[i], column + columnDirections[i]] == -1) continue;
            if (visitedCells.Contains((row + 2 * rowDirections[i], column + 2 * columnDirections[i]))) continue;

            Swap(ref gameBoard[row, column], ref gameBoard[row + 2 * rowDirections[i], column + 2 * columnDirections[i]]);
            currentPath.Add(gameBoard[row, column]);
            BreadthFirstSearch(row + 2 * rowDirections[i], column + 2 * columnDirections[i]);
            currentPath.RemoveAt(currentPath.Count - 1);
            Swap(ref gameBoard[row, column], ref gameBoard[row + 2 * rowDirections[i], column + 2 * columnDirections[i]]);
        }
    }

    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        rows = int.Parse(dimensions[0]);
        columns = int.Parse(dimensions[1]);
        int startRow = 0, startColumn = 0;
        for (int row = 0; row < rows; row++)
        {
            string[] rowValues = Console.ReadLine().Split(' ');
            for (int column = 0; column < columns; column++)
            {
                gameBoard[row, column] = int.Parse(rowValues[column]);
                if (gameBoard[row, column] == -1)
                {
                    startRow = row;
                    startColumn = column;
                }
            }
        }
        string[] targetCoordinates = Console.ReadLine().Split(' ');
        targetRow = int.Parse(targetCoordinates[0]);
        targetColumn = int.Parse(targetCoordinates[1]);
        targetRow--;
        targetColumn--;
        BreadthFirstSearch(startRow, startColumn);
        solutions.Sort();
        if (solutions.Count == 0)
        {
            Console.WriteLine("impossible");
            return;
        }

        Console.WriteLine(string.Join(" ", solutions[0]));
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        int n = int.Parse(firstLine[0]);
        int m = int.Parse(firstLine[1]);

        List<Point> toys = new List<Point>();
        List<Point> trees = new List<Point>();

        for (int i = 0; i < n; i++)
        {
            string[] toyCoords = Console.ReadLine().Split();
            int x = int.Parse(toyCoords[0]);
            int y = int.Parse(toyCoords[1]);
            toys.Add(new Point(x, y));
        }

        for (int i = 0; i < m; i++)
        {
            string[] treeCoords = Console.ReadLine().Split();
            int x = int.Parse(treeCoords[0]);
            int y = int.Parse(treeCoords[1]);
            trees.Add(new Point(x, y));
        }

        double minLength = CalculateMinimumLeashLength(toys, trees);

        Console.WriteLine($"{minLength:F2}");
    }

    static double CalculateMinimumLeashLength(List<Point> toys, List<Point> trees)
    {
        double minLength = 0.0;

        toys.Sort((p1, p2) => (p2.X * p2.X + p2.Y * p2.Y).CompareTo(p1.X * p1.X + p1.Y * p1.Y));

        Func<Point, Point, double> squaredDistance = (p1, p2) => Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2);

        foreach (Point toy in toys)
        {
            double maxDistance = Math.Sqrt(squaredDistance(toy, new Point(0, 0)));

            foreach (Point tree in trees)
            {
                double distanceToTree = Math.Sqrt(squaredDistance(toy, tree));

                if (distanceToTree < maxDistance)
                {
                    maxDistance = distanceToTree;
                }
            }

            minLength = Math.Max(minLength, maxDistance);
        }

        return minLength;
    }

    class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

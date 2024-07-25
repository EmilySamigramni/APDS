using System;
using System.Collections.Generic;

public class TheSubwayProgram
{
    public static void Main(string[] args)
    {
        int A = int.Parse(Console.ReadLine());

        for (int a = 0; a < A; a++)
        {
            var insert = Console.ReadLine().Split();
            int n = int.Parse(insert[0]);
            int d = int.Parse(insert[1]);

            var points = new List<(double x, double y)>();
            bool correctPoints = true;

            for (int c = 0; c < n; c++)
            {
                insert = Console.ReadLine().Split();
                double x = double.Parse(insert[0]);
                double y = double.Parse(insert[1]);

                if (x < -100 || x > 100 || y < -100 || y > 100)
                {
                    correctPoints = false;
                }

                points.Add((x, y));
            }

            if (!correctPoints)
            {
                Console.WriteLine($"Data Set {a + 1}: Invalid coordinates");
                continue;
            }

            int answer = MinimumSubwayLinesCalculation(n, d, points);
            Console.WriteLine(answer);
        }
    }

    private static int MinimumSubwayLinesCalculation(int n, double d, List<(double x, double y)> points)
    {
        List<(double begin, double end)> angleRanges = new List<(double start, double end)>();

        foreach (var (x, y) in points)
        {
            foreach (var range in CalculateAngleRanges(x, y, d))
            {
                angleRanges.Add(range);
            }
        }

        angleRanges.Sort((a, b) => a.begin.CompareTo(b.begin));

        int minLines = 0;
        double currentEnd = -Math.PI;

        foreach (var (start, end) in angleRanges)
        {
            if (start > currentEnd)
            {
                minLines++;
                currentEnd = end;
            }
            else
            {
                currentEnd = Math.Max(currentEnd, end);
            }
        }

        return minLines;
    }

    private static List<(double start, double end)> CalculateAngleRanges(double x, double y, double d)
    {
        List<(double start, double end)> ranges = new List<(double start, double end)>();
        double dis = Math.Sqrt(x * x + y * y);

        if (dis <= d)
        {
            ranges.Add((-Math.PI, Math.PI));
        }
        else
        {
            double theta = Math.Atan2(y, x);
            double alpha = Math.Asin(d / dis);

            double ang1 = theta - alpha;
            double ang2 = theta + alpha;

            if (ang1 < -Math.PI)
                ang1 += 2 * Math.PI;
            if (ang2 > Math.PI)
                ang2 -= 2 * Math.PI;

            ranges.Add((ang1, ang2));
        }

        return ranges;
    }
}

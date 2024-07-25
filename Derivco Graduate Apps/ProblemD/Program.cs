using System;
using System.Collections.Generic;
using System.Linq;

class Solver
{
    class Building
    {
        public int Principal { get; set; }
        public int Demands { get; set; }
        public int Capability { get; set; }
    }

    static List<Building> structures;
    static List<int>[] descendants;
    static bool[] completed;

    static void Main(string[] args)
    {
        int numBuildings = int.Parse(Console.ReadLine());
        structures = new List<Building>(numBuildings + 1);
        descendants = new List<int>[numBuildings + 1];
        completed = new bool[numBuildings + 1];

        for (int i = 0; i <= numBuildings; i++)
        {
            structures.Add(new Building());
            descendants[i] = new List<int>();
        }

        for (int i = 1; i <= numBuildings; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            int principal = int.Parse(inputs[0]);
            int demands = int.Parse(inputs[1]);
            int capability = int.Parse(inputs[2]);

            structures[i] = new Building { Principal = principal, Demands = demands, Capability = capability };
            descendants[principal].Add(i);
        }

        TraverseRecursive(0);

        int count = 0;
        for (int i = 1; i <= numBuildings; i++)
        {
            if (completed[i])
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }

    static int TraverseRecursive(int node)
    {
        int totalCompleted = structures[node].Demands;

        foreach (int child in descendants[node])
        {
            totalCompleted += TraverseRecursive(child);
        }

        if (node != 0)
        {
            int head = structures[node].Principal;
            if (totalCompleted <= structures[node].Capability)
            {
                completed[node] = true;
                return totalCompleted;
            }
            else
            {
                return 0;
            }
        }

        return totalCompleted;
    }
}

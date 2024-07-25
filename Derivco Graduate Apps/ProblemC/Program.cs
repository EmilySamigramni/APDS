using System;

using System.Collections.Generic;

using System.Linq;



namespace ProblemC

{

    class Program

    {

        static void Main(string[] args)

        {

            List<Testing> tc = ParseInput();

            foreach (var testCase in tc)

            {

                int maxSat = CalcMaxSat(testCase);

                Console.WriteLine(maxSat);

            }

        }



        static List<Testing> ParseInput()

        {

            List<Testing> tests = new List<Testing>();

            string line;

            while ((line = Console.ReadLine()) != "00")

            {

                var line1 = line.Split();

                int n = int.Parse(line1[0]);

                int m = int.Parse(line1[1]);



                if ((n < 4) || (n > 140)) break;

                if ((m < 1) || (m > 70)) break;




                int[] jobs = new int[n];

                for (int i = 0; i < n; i++)

                {

                    int iJobPositions = int.Parse(Console.ReadLine());

                    if ((iJobPositions >= 1) && (iJobPositions <= 10))

                        jobs[i] = iJobPositions;

                    else

                        return tests;

                }



                List<Stud> stud = new List<Stud>();

                List<Stud> OrderedStud = new List<Stud>();

                for (int i = 0; i < m; i++)

                {

                    var studLine = Console.ReadLine().Split();

                    int theYear = int.Parse(studLine[0]);

                    int[] pref = new int[4];

                    for (int j = 1; j <= 4; j++)

                    {

                        pref[j - 1] = int.Parse(studLine[j]);

                    }

                    stud.Add(new Stud(theYear, pref));

                }



                OrderedStud = stud.OrderByDescending(o => o.Year).ToList();

                tests.Add(new Testing(n, m, jobs, OrderedStud));

            }

            return tests;

        }



        static int CalcMaxSat(Testing testC)

        {

            int[,] satisfac = {

                { 0, 0, 0, 0 },

                { 4, 3, 2, 1 },

                { 8, 7, 6, 5 },

                { 12, 11, 10, 9 }

            };



            int totSlot = testC.Jobs.Sum();

            int[] jobSlots = new int[totSlot];

            int[,] costs = new int[testC.M, totSlot];

            int index = 0;

            for (int i = 0; i < testC.N; i++)

            {

                for (int j = 0; j < testC.Jobs[i]; j++)

                {

                    jobSlots[index++] = i;

                }

            }



            for (int i = 0; i < testC.M; i++)

            {

                for (int j = 0; j < totSlot; j++)

                {

                    costs[i, j] = int.MaxValue;

                }

            }



            for (int studIndex = 0; studIndex < testC.M; studIndex++)

            {

                var stud = testC.Students[studIndex];

                for (int rank = 0; rank < 4; rank++)

                {

                    int jobId = stud.Preferences[rank];

                    for (int slotIndex = 0; slotIndex < totSlot; slotIndex++)

                    {

                        if (jobSlots[slotIndex] == jobId)

                        {

                            costs[studIndex, slotIndex] = -satisfac[stud.Year, rank];

                        }

                    }

                }

            }



            return Sequence.MaxSat(costs);

        }

    }



    class Stud

    {

        public int Year { get; }

        public int[] Preferences { get; }



        public Stud(int year, int[] preferences)

        {

            Year = year;

            Preferences = preferences;

        }

    }



    class Testing

    {

        public int N { get; }

        public int M { get; }

        public int[] Jobs { get; }

        public List<Stud> Students { get; }



        public Testing(int n, int m, int[] jobPostings, List<Stud> students)

        {

            N = n;

            M = m;

            Jobs = jobPostings;

            Students = students;

        }

    }



    public static class Sequence

    {

        public static int MaxSat(int[,] costM)

        {

            int n = costM.GetLength(0);

            int d = costM.GetLength(1);

            int[,] initialCostM = costM;

            int[] h = new int[n + 1];

            int[] o = new int[d + 1];

            int[] p = new int[d + 1];

            int[] way = new int[d + 1];



            for (int i = 1; i <= n; i++)

            {

                p[0] = i;

                int j0 = 0;

                int[] minv = new int[d + 1];

                bool[] used = new bool[d + 1];

                for (int j = 0; j <= d; j++)

                {

                    minv[j] = int.MaxValue;

                    used[j] = false;

                }



                do

                {

                    used[j0] = true;

                    int i0 = p[j0];

                    int de = int.MaxValue;

                    int j1 = 0;

                    int costBase = initialCostM[i0 - 1, 0] - h[i0] - o[0];

                    for (int j = 1; j <= d; j++)

                    {

                        int cur = costBase + initialCostM[i0 - 1, j - 1] - o[j];

                        if (!used[j] && cur < minv[j])

                        {

                            minv[j] = cur;

                            way[j] = j0;

                        }

                        if (minv[j] < de)

                        {

                            de = minv[j];

                            j1 = j;

                        }

                    }



                    for (int j = 0; j <= d; j++)

                    {

                        if (used[j])

                        {

                            h[p[j]] += de;

                            o[j] -= de;

                        }

                        else

                        {

                            minv[j] -= de;

                        }

                    }

                    j0 = j1;

                } while (p[j0] != 0);



                do

                {

                    int j1 = way[j0];

                    p[j0] = p[j1];

                    j0 = j1;

                } while (j0 != 0);

            }



            int result = 0;

            for (int j = 1; j <= d; j++)

            {

                if (p[j] > 0)

                {

                    result += initialCostM[p[j] - 1, j - 1];

                }

            }

            return -result;

        }

    }

}
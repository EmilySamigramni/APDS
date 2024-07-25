namespace ArrayApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] grades = new int[5, 3];

            grades[0, 0] = 85; grades[0, 1] = 90; grades[0, 2] = 88;
            grades[1, 0] = grades[1, 1] = 75; grades[1, 2] = 65;
            grades[2, 0] = 92; grades[2, 1] = 89; grades[2, 2] = 94;
            grades[3, 0] = 76; grades[3, 1] = 85; grades[3, 2] = 79;
            grades[4, 0] = 88; grades[4, 1] = 91; grades[4, 2] = 87;

            for (int student = 0; student < 5; student++)
            {
                {
                    int total = 0;
                    for (int subject = 0; subject < 3; subject++)
                    {
                        total += grades[student, subject];  
                    }
                    double average = total / 3.0;
                    Console.WriteLine($"Student {student + 1} Average Grade: {average:F2}");
                }
            }


        }
    }
}

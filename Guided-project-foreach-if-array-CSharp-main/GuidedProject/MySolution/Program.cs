using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // initialize variables - graded assignments 
        int examAssignments = 5;

    int[] sophiaScores = { 90, 86, 87, 98, 100, 94, 90 };
    int[] andrewScores = { 92, 89, 81, 96, 90, 89 };
    int[] emmaScores = { 90, 85, 87, 98, 68, 89, 89, 89 };
    int[] loganScores = { 90, 95, 87, 88, 96, 96 };
    int[] beckyScores = { 92, 91, 90, 91, 92, 92, 92 };
    int[] chrisScores = { 84, 86, 88, 90, 92, 94, 96, 98 };
    int[] ericScores = { 80, 90, 100, 80, 90, 100, 80, 90 };
    int[] gregorScores = { 91, 91, 91, 91, 91, 91, 91 };    

    // Student names
    string[] names = { "Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor" };

        int[] currentScores = new int[10];

        string currentStudentLetterGrade;

        Console.WriteLine("Student\t\tGrade\n");

        foreach (string currentStudent in names)
        {
            if (currentStudent == "Sophia")
                currentScores = sophiaScores;
            else if (currentStudent == "Andrew")
                currentScores = andrewScores;
            else if (currentStudent == "Emma")
                currentScores = emmaScores;
            else if (currentStudent == "Logan")
                currentScores = loganScores;
            else if (currentStudent == "Becky")
                currentScores = beckyScores;
            else if (currentStudent == "Chris")
                currentScores = chrisScores;
            else if (currentStudent == "Eric")
                currentScores = ericScores;
            else if (currentStudent == "Gregor")
                currentScores = gregorScores;
            else
                continue;

            // regular calification
            decimal currentStudentGrade = (decimal) currentScores[..examAssignments].Sum() / examAssignments;

            // extra points
            currentStudentGrade += (decimal) currentScores[examAssignments..].Sum() / (10*examAssignments);
            
            if (currentStudentGrade >= 97)
                currentStudentLetterGrade = "A+";

            else if (currentStudentGrade >= 93)
                currentStudentLetterGrade = "A";

            else if (currentStudentGrade >= 90)
                currentStudentLetterGrade = "A-";

            else if (currentStudentGrade >= 87)
                currentStudentLetterGrade = "B+";

            else if (currentStudentGrade >= 83)
                currentStudentLetterGrade = "B";

            else if (currentStudentGrade >= 80)
                currentStudentLetterGrade = "B-";

            else if (currentStudentGrade >= 77)
                currentStudentLetterGrade = "C+";

            else if (currentStudentGrade >= 73)
                currentStudentLetterGrade = "C";

            else if (currentStudentGrade >= 70)
                currentStudentLetterGrade = "C-";

            else if (currentStudentGrade >= 67)
                currentStudentLetterGrade = "D+";

            else if (currentStudentGrade >= 63)
                currentStudentLetterGrade = "D";

            else if (currentStudentGrade >= 60)
                currentStudentLetterGrade = "D-";

            else
                currentStudentLetterGrade = "F";

            Console.WriteLine($"{currentStudent}\t\t{currentStudentGrade}\t{currentStudentLetterGrade}");
        }

        Console.WriteLine("Press the Enter key to continue");
        Console.ReadLine();
    }
}
using System;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException("problemsSolved", "problemsSolved cannot be negative!");
        }
        if (problemsSolved > 2)
        {
            throw new ArgumentOutOfRangeException("problemsSolved", "problemsSolved cannot be more than 2!");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: one problem solved.");
        }
        else if (ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Excellent result: all problems solved.");
        }

        throw new ArgumentException("Invalid number of solved problems!", "ProblemsSolved");
    }
}

using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade","Grade should not be less than 0!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade", "minGrade should not be less than 0!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("maxGrade", "maxGrade should not be less than minGrade!");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentException("comments", "Comments can not be null or empty!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}

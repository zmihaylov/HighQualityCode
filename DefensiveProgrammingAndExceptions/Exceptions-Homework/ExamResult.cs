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
            throw new ArgumentOutOfRangeException("Grade must be positive!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Minimal grade must be positive!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("Max grade must be bigger than min grade!");
        }

        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentNullException("Some comments should be added!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}

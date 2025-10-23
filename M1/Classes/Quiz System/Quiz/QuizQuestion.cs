namespace QuizSystem;

/*Properties: Question, CorrectAnswer
Private field to store user's answer
Method SubmitAnswer(string answer) - returns bool if correct
Static fields to track TotalQuestions and TotalCorrect across all instances*/
public class QuizQuestion
{
    private static string? userAnswer = "";
    private static int totalQuestions = 0;
    private static int totalCorrect = 0;
    public string? Question { get; set; }
    public string? CorrectAnswer { get; set; }

    public static int TotalQuestions
    {
        get => totalQuestions;
    }

    public static int TotalCorrect
    {
        get => totalCorrect;
    }

    public QuizQuestion(string? question, string? correctAnswer)
    {
        Question = question;
        CorrectAnswer = correctAnswer;
        Console.WriteLine("Question has successfully been stored.");
        totalQuestions++;
    }

    public bool SubmitAnswer(string? answer)
    {
        userAnswer = answer;
        if (CorrectAnswer.Equals(userAnswer))
        {
            totalCorrect++;
            return true;
        }
        return false;
    }

}
namespace QuizSystem;

/*List of QuizQuestion objects
Method AddQuestion(string question, string answer)
Method TakeQuiz() - asks all questions and tracks answers
Static method GetScorePercentage() - returns overall score %*/

public class Quiz
{
    List<QuizQuestion> questions = [];

    public string? QuizName { get; set; }

    public Quiz(string? name)
    {
        QuizName = name;
    }
    public void AddQuestion(string? question, string? answer)
    {
        QuizQuestion quizQuestion = new(question, answer);
        questions.Add(quizQuestion);
    }
    public void TakeQuiz()
    {
        foreach (QuizQuestion q in questions)
        {
            Console.WriteLine(q.Question);
            Console.Write("Enter answer: ");
            string? answer = Console.ReadLine();
            if (q.SubmitAnswer(answer))
            {
                Console.WriteLine("Correct Answer.");
            }
            else
            {
                Console.WriteLine("Incorrect Answer!");
                Console.WriteLine($"Correct Answer is: {q.CorrectAnswer}");
            }
        }
    }

    public static double GetScorePercentage()
    {
        return (QuizQuestion.TotalCorrect / QuizQuestion.TotalQuestions) * 100;
    }

    public void DisplayStatistic()
    {
        Console.WriteLine($"=========Quiz Results for {QuizName}============");
        Console.WriteLine($"Score: {QuizQuestion.TotalCorrect}/{QuizQuestion.TotalQuestions}");
        Console.WriteLine($"Score Percentage: {GetScorePercentage():F2}%");
        Console.WriteLine("======================================================");
    }
}


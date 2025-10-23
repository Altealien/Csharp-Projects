using QuizSystem;
List<Quiz> quizzes = [];
Console.WriteLine("============Quiz Sytsem===========");
bool running = true;
while (running)
{
    Console.WriteLine("1.Create Quiz");
    Console.WriteLine("2.Add Question");
    Console.WriteLine("3.Take Quiz");
    Console.WriteLine("4.Display Quiz Statistics");
    Console.WriteLine("5.Exit");
    Console.Write("Enter choice(1-5): ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            CreateQuiz();
            break;
        case "2":
            if (quizzes.Count == 0)
            {
                Console.WriteLine("No quiz available");
                Console.Clear();
            }
            else
            {
                Console.WriteLine("=======Adding Question========");
                Console.WriteLine("Enter quiz name: ");
                string? quizName = Console.ReadLine();
                if (ContainsQuiz(quizName, out Quiz q))
                {
                    Console.WriteLine($"=======Adding Question to {q.QuizName}========");
                    Console.Write("Enter a question: ");
                    string? question = Console.ReadLine();
                    Console.Write("Enter answer: ");
                    string? answer = Console.ReadLine();
                    q.AddQuestion(question, answer);
                }
                else
                {
                    Console.WriteLine("Quiz doesn't exist");
                }
                Console.WriteLine("=================================================");
            }
            break;
        case "3":
            if (quizzes.Count == 0)
            {
                Console.WriteLine("No quiz available");
                Console.Clear();
            }
            else
            {
                DisplayQuizzes();
                Console.Write("Select quiz: ");
                string? selectedQuiz = Console.ReadLine();
                if (ContainsQuiz(selectedQuiz, out Quiz q))
                {
                    q.TakeQuiz();
                }
            }
            break;
        case "4":
            if (quizzes.Count == 0)
            {
                Console.WriteLine("No quiz available");
                Console.Clear();
            }
            else
            {
                DisplayQuizzes();
                Console.Write("Select quiz: ");
                string? selectedQuiz = Console.ReadLine();
                if (ContainsQuiz(selectedQuiz, out Quiz q))
                {
                    q.DisplayStatistic();
                }
            }
            break;
        case "5":
            running = false;
            break;
        default:
            break;
    }
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

void CreateQuiz()
{
    Console.WriteLine("=============Creating New Quiz==============");
    Console.Write("Enter quiz name: ");
    string? name = Console.ReadLine();
    Quiz q = new(name);
    quizzes.Add(q);
    string? question = "";
    string? answer = "";
    do
    {
        Console.Write("Enter a question(Enter -1 to go back to main menu): ");
        question = Console.ReadLine();
        Console.Write("Enter answer: ");
        answer = Console.ReadLine();
        q.AddQuestion(question, answer);
    } while (question != "-1");
    Console.WriteLine("=====================================================");
}

bool ContainsQuiz(string? quizName, out Quiz quiz)
{
    bool contains = false;
    quiz = default;
    foreach (Quiz q in quizzes)
    {
        if (q.QuizName.ToLower().Equals(quizName.ToLower()))
        {
            quiz = q;
            contains = true;
        }
    }
    return contains;
}

void DisplayQuizzes()
{
    Console.WriteLine("========Displaying Available Quizzes===========");
    foreach (Quiz q in quizzes)
    {
        Console.WriteLine($"- {q.QuizName}");
    }
    Console.WriteLine("=======================================================");
}
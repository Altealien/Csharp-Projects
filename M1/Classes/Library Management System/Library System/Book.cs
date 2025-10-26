namespace LibrarySystem;

public class Book
{
    private static int nextID = 1;
    public string? BookID { get; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ISBN { get; private set; }
    public bool IsAvailable { get; private set; } = true;
    public string? BorrowedBy { get; set; }
    public DateTime BorrowedDate { get; set; }

    private static int bookCounter = 0;

    public static int TotalBooks { get => bookCounter; }


    public Book(string? title, string? author) : this(title, author, Book.GenerateISBN())
    {
    }

    public Book(string? title, string? author, string? isbn)
    {
        BookID = GenerateBookID();
        Title = title;
        Author = author;
        if (string.IsNullOrEmpty(isbn))
        {
            ISBN = null;
        }
        ISBN = isbn;
        bookCounter++;
    }

    public void Borrow(string memberName)
    {
        IsAvailable = false;
        BorrowedBy = memberName;
        BorrowedDate = DateTime.Now;
    }

    public void Return()
    {
        IsAvailable = true;
        BorrowedBy = null;
    }

    public void BookDisplay()
    {
        Console.WriteLine("======Book Info=====");
        Console.WriteLine($"Book Name:{Title}");
        Console.WriteLine($"Author:{Author}");
        Console.WriteLine($"ISBN:{ISBN}");
        Console.WriteLine($"ID:{BookID}");
        if (IsAvailable)
        {
            Console.WriteLine("This book is available.");
        }
        else
        {
            Console.WriteLine("This book is unavailable.");
        }
        Console.WriteLine("==================================");
    }

    private string GenerateBookID()
    {
        string id = $"BK{nextID.ToString().PadLeft(6, '0')}";
        nextID++;
        return id;
    }

    private static string GenerateISBN()
    {
        Random random = new();
        long randomISBN = random.Next(1_000_000_000, 2_000_000_000);
        return randomISBN.ToString();
    }
}
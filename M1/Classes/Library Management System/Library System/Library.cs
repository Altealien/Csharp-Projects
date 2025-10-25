namespace LibrarySystem;
public static class Library
{
    public static List<Book> AvailableBooks { get; } = [];
    public static List<Book> BorrowedBooks { get; } = [];
    public static HashSet<Member> ActiveBorrowers { get; } = [];
    public static void GenerateBookReport(List<Book> books)
    {
        Console.WriteLine("=======Book Report=======");
        Console.WriteLine($"Total Number of Books: {books.Count}");
        foreach (Book book in books)
        {
            if (book.IsAvailable)
            {
                AvailableBooks.Add(book);
            }
            else
            {
                BorrowedBooks.Add(book);
            }
        }
        Console.Write("Available books: ");
        for (int i = 0; i < AvailableBooks.Count; i++)
        {
            while (i != AvailableBooks.Count - 1)
            {
                Console.Write(AvailableBooks[i].Title + ", ");
                i++;
            }
            Console.WriteLine(AvailableBooks[i].Title + ".");
        }
        Console.Write($"Borrowed Books: ");
        for (int i = 0; i < BorrowedBooks.Count; i++)
        {
            while (i != BorrowedBooks.Count - 1)
            {
                Console.Write(BorrowedBooks[i].Title + ", ");
                i++;
            }
            Console.WriteLine(BorrowedBooks[i].Title + ".");
        }
    }

    public static void GenerateMemberReport(List<Member> members)
    {
        Console.WriteLine("======Member Report======");
        Console.WriteLine($"Total Members: {members.Count}");
        foreach (Member member in members)
        {
            if (member.BooksBorrowed.Count > 0)
            {
                ActiveBorrowers.Add(member);
            }
        }
        Console.Write($"Active borrowers: ");
        int i = 0;
        foreach (Member borrower in ActiveBorrowers)
        {
            while (i != ActiveBorrowers.Count - 1)
            {
                Console.Write(borrower.MemberName + ", ");
                i++;
            }
            Console.WriteLine(borrower.MemberName + ".");
        }
        Console.WriteLine($"Active Borrower Count: {ActiveBorrowers.Count}");
    }

    public static List<Book> SearchBook(List<Book> books, string? searchTerm)
    {
        return [.. books.Where(book => book.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        book.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))];
    }
    public static bool IsValidISBN(string? isbn)
    {
        if (isbn.Length == 10 || isbn.Length == 13)
        {
            return true;
        }
        return false;
    }
}
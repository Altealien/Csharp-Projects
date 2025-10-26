namespace LibrarySystem;

public class LibraryManager
{
    private List<Book> books;
    private List<Member> members;

    public LibraryManager()
    {
        books = [];
        members = [];
    }

    public void AddBook()
    {
        //ISBN is causing issues when I click enter to skip.
        Console.WriteLine("=== Add New Book ===");
        Console.Write("Title: ");
        string? title = Console.ReadLine();
        Console.Write("Author: ");
        string? author = Console.ReadLine();
        Console.Write("ISBN(optional, press Enter to skip): ");
        string? isbn = Console.ReadLine();
        Book? book = default;
        if (Library.IsValidISBN(isbn) && string.IsNullOrEmpty(isbn))
        {
            book = new(title, author);
        }
        else if (Library.IsValidISBN(isbn))
        {
            book = new(title, author, isbn);
        }
        else
        {
            Console.WriteLine("Invalid ISBN!");
            return;
        }
        Console.WriteLine($"Book created successfully! Book ID: {book.BookID}");
        books.Add(book);
    }

    public void AddMember()
    {
        Console.WriteLine("=== Library Registeration ===");
        Console.Write("Name: ");
        string? name = Console.ReadLine();
        Console.Write("Email: ");
        string? email = Console.ReadLine();
        Console.Write("Phone Number: ");
        string? phoneNumber = Console.ReadLine();
        Member member = new(name, email, phoneNumber);
        Console.WriteLine($"Library Registeration was successful! Member ID: {member.MemberID}");
        members.Add(member);
    }
    public void BorrowBook()
    {
        Console.WriteLine("=== Borrow Book ===");
        Console.Write("Enter Member ID: ");
        string? memberID = Console.ReadLine();
        Console.Write("Enter Book ID: ");
        string? bookID = Console.ReadLine();

        Book? book = books.FirstOrDefault(b => b.BookID == bookID);
        if (book == null)
        {
            Console.WriteLine("Book ID not found!");
            return;
        }

        Member? member = members.FirstOrDefault(m => m.MemberID == memberID);
        if (member == null)
        {
            Console.WriteLine("Member ID not found!");
            return;
        }

        member.BorrowBook(book);
        Console.WriteLine($"Book '{book.Title}' borrowed successfully by {member.MemberName}!");
    }
    public void ReturnBook()
    {
        Console.WriteLine("=== Return Book ===");
        Console.Write("Enter Member ID: ");
        string? memberID = Console.ReadLine();
        Console.Write("Enter Book ID: ");
        string? bookID = Console.ReadLine();

        Book? book = books.FirstOrDefault(b => b.BookID == bookID);
        if (book == null)
        {
            Console.WriteLine("Book ID not found!");
            return;
        }

        Member? member = members.FirstOrDefault(m => m.MemberID == memberID);
        if (member == null)
        {
            Console.WriteLine("Member ID not found!");
            return;
        }

        member.ReturnBook(book);
        Console.WriteLine($"Book '{book.Title}' returned successfully by {member.MemberName}!");
    }

    public void ListAllBooks()
    {
        Console.Write("All Books: ");
        if (books.Count == 0)
        {
            Console.WriteLine();
        }
        for (int i = 0; i < books.Count; i++)
        {
            while (i != books.Count - 1)
            {
                Console.Write(books[i].Title + ", ");
                i++;
            }
            Console.WriteLine(books[i].Title + ".");
        }
        Console.WriteLine("====================================");
    }

    public void ListAllMembers()
    {
        Console.Write("All Members: ");
        if (members.Count == 0)
        {
            Console.WriteLine();
        }
        for (int i = 0; i < members.Count; i++)
        {
            while (i != members.Count - 1)
            {
                Console.Write(members[i].MemberName + ", ");
                i++;
            }
            Console.WriteLine(members[i].MemberName + ".");
        }
        Console.WriteLine("====================================");
    }
    public void SearchBooks()
    {
        // Logic isn't completely correct
        Console.Write("Enter search term(either Book Title or Author): ");
        string? searchTerm = Console.ReadLine();
        List<Book> searchResults = Library.SearchBook(books, searchTerm);
        Console.Write("Search results: ");
        for (int i = 0; i < searchResults.Count; i++)
        {
            while (i != searchResults.Count - 1)
            {
                Console.Write(searchResults[i] + ", ");
                i++;
            }
            Console.WriteLine(searchResults[i] + ".");
        }
        Console.WriteLine("====================================");
    }
    public void ShowReports()
    {
        Library.GenerateBookReport(books);
        Library.GenerateMemberReport(members);
    }
}
using Microsoft.VisualBasic;

namespace LibrarySystem;
/*
BorrowBook() - handles borrowing process
ReturnBook() - handles return process
*/
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
        Console.WriteLine("=== Add New Book ===");
        Console.Write("Title: ");
        string? title = Console.ReadLine();
        Console.Write("Author: ");
        string? author = Console.ReadLine();
        Console.Write("ISBN(optional, press Enter to skip): ");
        string? isbn = Console.ReadLine();
        Book? book = default;
        if (Library.IsValidISBN(isbn))
        {
            if (string.IsNullOrEmpty(isbn))
            {
                book = new(title, author);
            }
            else
            {
                book = new(title, author, isbn);
            }
        }
        else
        {
            Console.WriteLine("Invalid ISBN!");
            Console.Write("Enter valid  ISBN: ");
            isbn = Console.ReadLine();
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
        for (int i = 0; i < books.Count; i++)
        {
            while (i != books.Count - 1)
            {
                Console.Write(books[i] + ", ");
                i++;
            }
            Console.WriteLine(books[i] + ".");
        }
        Console.WriteLine("====================================");
    }

    public void ListAllMembers()
    {
        Console.Write("All Members: ");
        for (int i = 0; i < members.Count; i++)
        {
            while (i != members.Count - 1)
            {
                Console.Write(members[i] + ", ");
                i++;
            }
            Console.WriteLine(members[i] + ".");
        }
        Console.WriteLine("====================================");
    }
    public void SearchBooks()
    {
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
namespace LibrarySystem;
/*

Constructor initializes the lists
Methods:

AddBook() - gets user input and creates book
AddMember() - gets user input and creates member
BorrowBook() - handles borrowing process
ReturnBook() - handles return process
ListAllBooks() - displays all books
ListAllMembers() - displays all members
SearchBooks() - uses Library static method
ShowReports() - displays both reports
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
        Book book;
        if (string.IsNullOrEmpty(isbn))
        {
            book = new(title, author);
        }
        else
        {
            book = new(title, author, isbn);
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
}
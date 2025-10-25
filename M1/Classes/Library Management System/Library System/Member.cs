namespace LibrarySystem;
// Work on enabling proper validation for email.
public class Member
{
    private static int totalMembers = 0;
    private static int nextID = 1;
    public string? MemberID { get; }
    public string? MemberName { get; set; }
    public string? MemberEmail { get; set; }
    public string? MemberPhoneNumber { get; set; }
    public List<string> BooksBorrowed { get; set; } = [];
    public DateTime MembershipDate { get; private set; }
    public static int TotalMembers { get => totalMembers; }
    public Member(string? memberName, string? memberEmail, string? memberPhoneNumber)
    {
        MemberName = memberName;
        MemberID = GenerateMemberID();
        if (memberEmail.Contains('@'))
        {
            MemberEmail = memberEmail;
        }
        else
        {
            Console.WriteLine("Invalid email address!");
        }

        MemberPhoneNumber = memberPhoneNumber;
        totalMembers++;
        MembershipDate = DateTime.Now;
    }

    public void BorrowBook(Book book)
    {
        if (BooksBorrowed.Count < 3)
        {
            book.Borrow(MemberName);
            BooksBorrowed.Add(book.Title);
        }
        else
        {
            Console.WriteLine("You've reached the max limits of books you can borrow.");
        }
    }

    public void ReturnBook(Book book)
    {
        BooksBorrowed.Remove(book.Title);
        book.Return();
    }

    public void MemberDisplay()
    {
        Console.WriteLine("======Member Info=====");
        Console.WriteLine($"Name:{MemberName}");
        Console.WriteLine($"Email:{MemberEmail}");
        Console.WriteLine($"Phone Number:{MemberPhoneNumber}");
        Console.WriteLine($"ID:{MemberID}");
        Console.WriteLine($"Date joined: {MembershipDate}");
        Console.Write("Books Borrowed: ");
        for (int i = 0; i < BooksBorrowed.Count; i++)
        {
            while (i != BooksBorrowed.Count - 1)
            {
                Console.Write(BooksBorrowed[i] + ", ");
                i++;
            }
            Console.WriteLine(BooksBorrowed[i] + ".");
        }
        Console.WriteLine("====================================");
    }
    private string GenerateMemberID()
    {
        string id = $"MEM{nextID.ToString().PadLeft(6, '0')}";
        nextID++;
        return id;
    }
}
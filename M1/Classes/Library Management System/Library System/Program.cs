using LibrarySystem;

Console.WriteLine("=== Library Management System ===");

LibraryManager library = new();
bool running = true;
while (running)
{
    MenuDisplay();
    Console.Write("Enter choice: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            //Add Book
            library.AddBook();
            break;
        case "2":
            //Add Member
            library.AddMember();
            break;
        case "3":
            //Borrow Book
            library.BorrowBook();
            break;
        case "4":
            //Return Book
            library.ReturnBook();
            break;
        case "5":
            //List All Books
            library.ListAllBooks();
            break;
        case "6":
            //List All Members
            library.ListAllMembers();
            break;
        case "7":
            //Search Books
            library.SearchBooks();
            break;
        case "8":
            //Show Reports
            library.ShowReports();
            break;
        case "9":
            //Exit System
            running = false;
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            break;
    }
}


void MenuDisplay()
{
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Add Member");
    Console.WriteLine("3. Borrow Book");
    Console.WriteLine("4. Return Book");
    Console.WriteLine("5. List All Books");
    Console.WriteLine("6. List All Members");
    Console.WriteLine("7. Search Books");
    Console.WriteLine("8. Show Reports");
    Console.WriteLine("9. Exit");
}
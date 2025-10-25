using LibrarySystem;

Console.WriteLine("=== Library Management System ===");
/*bool running = true;
while (running)
{
    MenuDisplay();
    Console.Write("Enter choice: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            //Add Book
            break;
        case "2":
            //Add Member
            break;
        case "3":
            //Borrow Book
            break;
        case "4":
            //Return Book
            break;
        case "5":
            //List All Books
            break;
        case "6":
            //List All Members
            break;
        case "7":
            //Search Books
            break;
        case "8":
            //Show Reports
            break;
        case "9":
            //Exit System
            break;
    }
}*/


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
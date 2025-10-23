using Inventory;

List<Product> products = [];
Console.WriteLine("-----------Product Inventory System-----------");

while (Product.TotalProductCount != 3)
{
    bool running = true;
    while (running)
    {
        Console.WriteLine("===========MENU=========");
        Console.WriteLine("1.Store new product.");
        Console.WriteLine("2.Update stock.");
        Console.WriteLine("3.View Inventory");
        Console.Write("Enter choice(1-3): ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("------------Creating New Product-----------");
                Console.Write("Enter product name: ");
                string? name = Console.ReadLine();
                Console.Write("Enter product price:£");
                decimal price = decimal.TryParse(Console.ReadLine(), out decimal value) ? value : 0m;
                Console.Write("Enter product quantity: ");
                int quantity = int.TryParse(Console.ReadLine(), out int q) ? q : 0;

                Product product = new(name, price, quantity);
                products.Add(product);
                running = false;
                break;
            case "2":
                Console.WriteLine("-----------Updating Stock-------------");
                Console.Write("Enter product name: ");
                string? pName = Console.ReadLine();
                Console.Write("Would you like to add stock or reduce stock(a for add, r for remove)? ");
                string? response = Console.ReadLine();
                Console.Write("Enter amount to add/remove: ");
                int amount = int.TryParse(Console.ReadLine(), out int a) ? a : 0;
                foreach (Product p in products)
                {
                    if (p.ProductName.ToLower().Equals(pName.ToLower()))
                    {
                        p.UpdateStock(amount, response);
                    }
                }
                Console.WriteLine();
                break;
            case "3":
                ViewInventory();
                break;
            default:
                break;
        }
    }
}
ViewInventory();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();


void ViewInventory()
{
    foreach (Product p in products)
    {
        Console.WriteLine("------------INVENTORY-------------");
        p.DisplayInfo();
    }
}
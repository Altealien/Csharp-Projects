namespace Inventory;

public class Product
{
    private static int productCount = 0;
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductQuantity { get; set; }

    public decimal TotalValue
    {
        get => InventoryHelper.CalculateTotalValue(ProductPrice, ProductQuantity);
    }

    public string StockStatus
    {
        get => InventoryHelper.IsLowStock(ProductQuantity) ? "Low" : "Ok";
    }

    public static int TotalProductCount
    {
        get => productCount;
    }

    public Product(string? name, decimal price, int quantity)
    {
        ProductName = name;
        if (price > 0m)
        {
            ProductPrice = price;
        }
        else
        {
            Console.WriteLine("Price has to be greater than £0.");
        }
        if (quantity >= 0)
        {
            ProductQuantity = quantity;
        }
        else
        {
            Console.WriteLine("Quantity cannot be less than 0");
        }
        productCount++;
        Console.WriteLine($"Product '{InventoryHelper.FormatProductCode(ProductName)}' has been created successfully");
    }

    public void UpdateStock(int amount, string? instruction)
    {
        if (instruction.ToLower() == "a")
        {
            AddStock(amount);
        }
        else
        {
            RemoveStock(amount);
        }
    }

    public void AddStock(int amount)
    {
        ProductQuantity += amount;
        Console.WriteLine($"{amount} stocks added to {ProductName}.");
    }
    public void RemoveStock(int amount)
    {
        if (ProductQuantity > amount)
        {
            ProductQuantity -= amount;
            Console.WriteLine($"{amount} stocks removed from {ProductName}.");
        }
        else
        {
            ProductQuantity = 0;
            Console.WriteLine("Amount exceeds current stock. Stock has been set to 0");
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"--------------{InventoryHelper.FormatProductCode(ProductName)}----------------");
        Console.WriteLine($"Product Name: {ProductName}");
        Console.WriteLine($"Total Value:£{TotalValue}");
        Console.WriteLine($"Stock Status: {StockStatus}");
        Console.WriteLine("=======================================================================");
    }
}